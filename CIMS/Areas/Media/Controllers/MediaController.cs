using CIMS.ActionLayer.Media;
using CIMS.BaseLayer.Media;
using CIMS.Filters;
using CIMS.Helpers;
using CIMS.Models;
using CIMS.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIMS.Areas.Media.Controllers
{
    [CheckLogin]

    public class MediaController : Controller
    {

        #region Declaration
        MediaAction mediaAction = new MediaAction();
        PictureVideosBase pictureVideoBase = new PictureVideosBase();
        CommonPictureVideosBase commonPictureBase = new CommonPictureVideosBase();
        CIMS.BaseLayer.ActionResult actionResult = new CIMS.BaseLayer.ActionResult();
        #endregion

        #region Index Get
        [HttpGet]
        public ActionResult Index(string type = "", string subtype = "", int subFeatureid = 0, int typeid = 0)
        {
            ViewBag.Type = type;
            ViewBag.SubType = subtype;
            ViewBag.SubFeatureid = subFeatureid;
            ViewBag.id = typeid;
            int action = 0;
            bool status = false;
            if (Session["Admin"] != null)
            {
                int userId = Convert.ToInt32(Session["Admin"]);
                string[] permission = CheckAdminPermissions.permission((type == "Employee" ? "Employees" : type), userId);


                if (permission != null)
                {
                    action = Convert.ToInt32(permission[1]);
                    status = Convert.ToBoolean(permission[0]);
                }
            }
            else if (Session["UserId"] != null)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                string[] permission = CheckPermissions.permission((type == "Employee" ? "Employees" : type), userId);


                if (permission != null)
                {
                    action = Convert.ToInt32(permission[1]);
                    status = Convert.ToBoolean(permission[0]);
                }
            }

            if (status == false)
            {
                string url = "~/Home/NoPermission";
                return Redirect(url);
            }
            ViewBag.Action = action;
            ViewBag.Status = status;
            return View();
        }
        #endregion

        #region Index Post
        [HttpPost]
        public ActionResult Index(MediaModel model, FormCollection fc, string type = "", string subtype = "", int subFeatureid = 0, int typeid = 0)
        {
            var fullpath = "";
            string imageData = !String.IsNullOrEmpty(fc["hdnFilePath"]) ? Convert.ToString(fc["hdnFilePath"]) : "";            
                string filename = "EmployeeMedia.png";
            string FilePath = "~/Content/Media/";
            if (!Directory.Exists(Server.MapPath(FilePath)))
            {
                Directory.CreateDirectory(Server.MapPath(FilePath));
            }
            string json = "";
            int userId = Convert.ToInt32(Session["UserId"]);
            var file = filename.Split('.');
            file[0] = file[0] + userId;
            string fileName = Convert.ToString(Guid.NewGuid()).Substring(0, 5);
            string Pic_Path = HttpContext.Server.MapPath(FilePath + fileName + file[0] + "." + file[1]);
            using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
            {
                string fileExt = System.IO.Path.GetExtension(imageData);
                if (fileExt == ".jpeg" || fileExt == ".jpg" || fileExt == ".png" || fileExt == ".gif")
                {
                    fullpath = imageData;
                }
                else
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(imageData);
                        bw.Write(data);
                        bw.Close();
                    }
                    //Session["CapturedPath"] = Pic_Path;
                    fullpath = "/Content/Media/" + fileName + file[0] + "." + file[1];
                }

                try
                {
                    pictureVideoBase.Assigned = 0;
                    pictureVideoBase.MediaExtention = null;
                    pictureVideoBase.MediaName = model.MediaName;
                    pictureVideoBase.Description = model.Description;
                    pictureVideoBase.PicType = 0;
                    pictureVideoBase.DefaultPic = false;
                    pictureVideoBase.EncodeArray = null;
                    pictureVideoBase.EncodeState = 0;
                    pictureVideoBase.FilePath = fullpath;
                    pictureVideoBase.EncodeFaceValues = null;
                    pictureVideoBase.FaceValue = 0;
                    pictureVideoBase.SubFeatureID = typeid;
                    pictureVideoBase.SubFeaturesid = subFeatureid;
                    pictureVideoBase.PictureType = !String.IsNullOrEmpty(fc["hdPicTureType"]) ? Convert.ToString(fc["hdPicTureType"]) : "";
                    actionResult = mediaAction.PictureVideos_Insert(pictureVideoBase);
                    if (actionResult.IsSuccess)
                    {
                        int result = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                        if (result > 0)
                        {
                            TempData["SuccessMessage"] = "Picture Added Successfully.";
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "Some error Occurred, please try again later.";
                        }

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Some error Occurred, please try again later.";
                    }

                }
                catch (Exception ex)
                {
                    ErrorReporting.WebApplicationError(ex);
                }

                if (subtype == "Features")
                {
                    return RedirectToAction("Index", new { type = "Subject", subtype = "Features", typeid = typeid, SubFeatureid = subFeatureid });
                }
                else if (subtype == "EmpReport")
                {
                    return RedirectToAction("Index", new { type = "Employee", subtype = "EmpReport", typeid = typeid, SubFeatureid = subFeatureid });
                }
                else if (subtype == "SubVehicle")
                {
                    return RedirectToAction("Index", new { type = "Employee", subtype = "SubVehicle", typeid = typeid, SubFeatureid = subFeatureid });
                }
                else {
                    if (type == "Media")
                    {
                        return RedirectToAction("Index", new { type = type });
                    }
                    else
                    {
                        return RedirectToAction("Index", new { type = type, typeid = typeid });
                    }
                }
            }

            // return RedirectToAction("Index", new { type = type, id = id });
        }


        #endregion

        #region GetAllPictures
        public JsonResult GetAllPictures(string type, int id, int subFeatureid)//string Picture Type, SubFeature ID for Feature media
        {
            string json = "";
            List<MediaModel> mediaListModel = new List<MediaModel>();
            try
            {
                PictureVideosBase pictureVideosBase = new PictureVideosBase();
                pictureVideosBase.PictureType = type;
                pictureVideosBase.SubFeatureID = id;
                pictureVideosBase.SubFeaturesid = subFeatureid;
                actionResult = mediaAction.PicturesVideos_LoadAll(pictureVideosBase);
                if (actionResult.IsSuccess)
                {
                    mediaListModel = CommonMethods.ConvertTo<MediaModel>(actionResult.dtResult);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(mediaListModel);
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region UploadMediaPic
        public JsonResult UploadMediaPic()
        {
            string fullpath = "";
            if (Request.Files.Count > 0)
            {
                string directory = Server.MapPath("~/Content/Media/");
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var pfb = Request.Files[i];
                    if (pfb != null && pfb.ContentLength > 0)
                    {
                        string fileName = Convert.ToString(Guid.NewGuid()).Substring(0, 5) + Path.GetFileName(pfb.FileName);
                        fullpath += "/Content/Media/" + fileName + ",";
                        string path = Path.Combine(directory, fileName);
                        pfb.SaveAs(path);
                    }
                }

            }
            return Json(fullpath.TrimEnd(','), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region AssignPictures
        [HttpPost]
        public JsonResult AssignPictures(string MediaType, string Type, int ID = 0, int IncidentID = 0, int MediaID = 0, int QuestionID = 0, int Observation = 0)//string FileType
        {
            string json = "";
            List<MediaModel> mediaListModel = new List<MediaModel>();
            try
            {
                commonPictureBase.ID = ID;
                commonPictureBase.IncidentID = IncidentID;
                commonPictureBase.MediaID = MediaID;
                commonPictureBase.MediaType = MediaType;
                commonPictureBase.QuestionID = QuestionID;
                commonPictureBase.Type = Type;
                commonPictureBase.Observation = Observation;
                actionResult = mediaAction.SubjectEmployeePicture_Insert(commonPictureBase);
                if (actionResult.IsSuccess)
                {

                    json = "success";

                    //mediaListModel = CommonMethods.ConvertTo<MediaModel>(actionResult.dtResult);
                    //Newtonsoft.Json.JsonConvert.SerializeObject(mediaListModel);
                }
                else
                {
                    json = "Fails";
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region DeletePictures
        [HttpPost]
        public JsonResult DeletePicture(int MediaID = 0)
        {
            string json = "";
            List<MediaModel> mediaListModel = new List<MediaModel>();
            try
            {
                pictureVideoBase.MediaID = MediaID;
                actionResult = mediaAction.PictureVideos_Delete(pictureVideoBase);
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "Fails";
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region UpdateCropImage
        [HttpPost]
        public JsonResult UpdateCropImage(string NewSrc, string MediaID)//string FileType
        {
            string json = "";
            List<MediaModel> mediaListModel = new List<MediaModel>();
            try
            {

                pictureVideoBase.MediaID = Convert.ToInt32(MediaID);
                pictureVideoBase.FilePath = NewSrc;

                actionResult = mediaAction.CropMediaPicture_U(pictureVideoBase);
                if (actionResult.IsSuccess)
                {

                    json = "success";

                    //mediaListModel = CommonMethods.ConvertTo<MediaModel>(actionResult.dtResult);
                    //Newtonsoft.Json.JsonConvert.SerializeObject(mediaListModel);
                }
                else
                {
                    json = "Fails";
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region WebCam
        //public JsonResult Capture()
        //{
        //    string json = "";
        //    var stream = Request.InputStream;
        //    string dump;
        //    using (var reader = new StreamReader(stream))
        //    {
        //        dump = reader.ReadToEnd();
        //        DateTime nm = DateTime.Now;
        //        string fileName = Convert.ToString(Guid.NewGuid()).Substring(0, 5);
        //        string path = "/Content/Media/" + fileName + "test.jpg";
        //        var Fullpath = Server.MapPath("/Content/Media/" + fileName + "test.jpg");
        //        System.IO.File.WriteAllBytes(Fullpath, String_To_Bytes2(dump));
        //        Session["CapturedPath"] = path;
        //    }
        //    return Json(json, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult Rebind()
        //{
        //    string path = Session["CapturedPath"].ToString();
        //    return Json(path, JsonRequestBehavior.AllowGet);
        //}
        private byte[] String_To_Bytes2(string strInput)
        {
            int numBytes = (strInput.Length) / 2;
            byte[] bytes = new byte[numBytes];
            for (int x = 0; x < numBytes; ++x)
            {
                bytes[x] = Convert.ToByte(strInput.Substring(x * 2, 2), 16);
            }
            return bytes;
        }

        #endregion
        public JsonResult UploadPic(string imageData, string filename)
        {
            string FilePath = "~/Content/Media/";
            if (!Directory.Exists(Server.MapPath(FilePath)))
            {
                Directory.CreateDirectory(Server.MapPath(FilePath));
            }
            string json = "";
            int userId = Convert.ToInt32(Session["UserId"]);
            var file = filename.Split('.');
            file[0] = file[0] + userId;
            string fileName = Convert.ToString(Guid.NewGuid()).Substring(0, 5);
            string Pic_Path = HttpContext.Server.MapPath(FilePath + fileName + file[0] + "." + file[1]);
            using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(imageData);
                    bw.Write(data);
                    bw.Close();
                }
                //Session["CapturedPath"] = Pic_Path;
                var fullpath = "/Content/Media/" + fileName + file[0] + "." + file[1];
                return Json(fullpath);
            }
        }

        #region MoveToPicture
        [HttpPost]
        public JsonResult MoveToPicture(string type, int id, int MediaID)
        {
            string json = "";
            try
            {
                pictureVideoBase.MediaID = MediaID;
                pictureVideoBase.SubFeatureID = id;
                pictureVideoBase.PictureType = type;
                actionResult = mediaAction.AssignToPicture(pictureVideoBase);
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "Fails";
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region GetAllMoveToPicture
        public JsonResult GetAllMoveToPicture(string type, int id, int subFeatureid)//string Picture Type, SubFeature ID for Feature media
        {
            string json = "";
            List<MediaModel> mediaListModel = new List<MediaModel>();
            try
            {
                PictureVideosBase pictureVideosBase = new PictureVideosBase();
                pictureVideosBase.PictureType = type;
                pictureVideosBase.SubFeatureID = id;
                pictureVideosBase.SubFeaturesid = subFeatureid;
                actionResult = mediaAction.PicturesVideos_LoadAll(pictureVideosBase);
                if (actionResult.IsSuccess)
                {
                    mediaListModel = CommonMethods.ConvertTo<MediaModel>(actionResult.dtResult);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(mediaListModel);
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region UploadRapidPic
        public JsonResult UploadRapidPic(string imageData, string filename, FormCollection fc)
        {
            string FilePath = "~/Content/Media/";
            if (!Directory.Exists(Server.MapPath(FilePath)))
            {
                Directory.CreateDirectory(Server.MapPath(FilePath));
            }
            string json = "";
            int userId = Convert.ToInt32(Session["UserId"]);
            var file = filename.Split('.');
            file[0] = file[0] + userId;
            string fileName = Convert.ToString(Guid.NewGuid()).Substring(0, 5);
            string Pic_Path = HttpContext.Server.MapPath(FilePath + fileName + file[0] + "." + file[1]);
            using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(imageData);
                    bw.Write(data);
                    bw.Close();
                }
                //Session["CapturedPath"] = Pic_Path;
                var fullpath = "/Content/Media/" + fileName + file[0] + "." + file[1];

                try
                {
                    pictureVideoBase.Assigned = 0;
                    pictureVideoBase.MediaExtention = null;
                    pictureVideoBase.MediaName = "";
                    pictureVideoBase.Description = "";
                    pictureVideoBase.PicType = 0;
                    pictureVideoBase.DefaultPic = false;
                    pictureVideoBase.EncodeArray = null;
                    pictureVideoBase.EncodeState = 0;
                    pictureVideoBase.FilePath = fullpath;
                    pictureVideoBase.EncodeFaceValues = null;
                    pictureVideoBase.FaceValue = 0;
                    pictureVideoBase.SubFeatureID = 0;
                    pictureVideoBase.SubFeaturesid = 0;
                    pictureVideoBase.PictureType = "Media";
                    actionResult = mediaAction.PictureVideos_Insert(pictureVideoBase);
                    if (actionResult.IsSuccess)
                    {
                        int result = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                        if (result > 0)
                        {
                            TempData["SuccessMessage"] = "Picture Added Successfully.";
                        }
                        else
                            TempData["ErrorMessage"] = "Some error Occurred, please try again later.";

                    }
                    else
                        TempData["ErrorMessage"] = "Some error Occurred, please try again later.";

                }
                catch (Exception ex)
                {
                    ErrorReporting.WebApplicationError(ex);
                }
                return Json(fullpath);
            }

        }
        #endregion


    }
}