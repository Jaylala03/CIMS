using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using CIMS.ActionLayer;
using CIMS.Models;
using CIMS.Helpers;
using CIMS.Filters;
using System.IO;

namespace CIMS.Areas.Visitor.Controllers
{
    [CheckLogin]
    [CheckPermissionAttribute]
    public class VisitorController : Controller
    {
        DataSet dsResult = new DataSet();
        DataTable drResult = new DataTable();
        VisitorAction visitorAction = new VisitorAction();
        CIMS.BaseLayer.VisitorBase visitor = new CIMS.BaseLayer.VisitorBase();
        CIMS.BaseLayer.ActionResult actionResult = new CIMS.BaseLayer.ActionResult();

        // GET: Visitor/Visitor
        public ActionResult Index(int? visitorID = 0)
        {
            VisitorModel model = new VisitorModel();
            List<VisitorModel> visitorList = new List<VisitorModel>();
            model.GroupIdentifier = "Group " + DateTime.Now.ToString("dd-MMMM-yyyy hh:mm");

            model.VisitorDate = DateTime.Now.Date.ToString();
            model.FromHoursMinutes = DateTime.Now.ToString("hh:mm tt");
            model.ToHoursMinutes = DateTime.Now.ToString("hh:mm tt");

            if (visitorID.Value > 0)
            {
                visitor.VisitorID = visitorID.Value;
                actionResult = visitorAction.Visitor_Load(visitor);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    DataRow row = actionResult.dtResult.Rows[0];
                    model.VisitorID = row["VisitorID"] != DBNull.Value ? Convert.ToInt32(row["VisitorID"]) : 0;
                    model.VisitorName = row["VisitorName"] != DBNull.Value ? row["VisitorName"].ToString() : "";
                    model.Description = row["Description"] != DBNull.Value ? row["Description"].ToString() : "";
                    model.FromHoursMinutes = row["FromHoursMinutes"] != DBNull.Value ? row["FromHoursMinutes"].ToString() : "";
                    model.ToHoursMinutes = row["ToHoursMinutes"] != DBNull.Value ? row["ToHoursMinutes"].ToString() : "";
                    model.VisitorDate = row["VisitorDate"] != DBNull.Value ? row["VisitorDate"].ToString() : "";
                    model.GroupIdentifier = row["GroupIdentifier"] != DBNull.Value ? row["GroupIdentifier"].ToString() : "Group " + DateTime.Now.ToString("dd-MMMM-yyyy hh:mm");
                }
            }
            actionResult = visitorAction.Visitor_Filter(visitor);
            if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
            {

                visitorList = (from DataRow row in actionResult.dtResult.Rows
                               select new VisitorModel
                               {
                                   VisitorID = row["VisitorID"] != DBNull.Value ? Convert.ToInt32(row["VisitorID"]) : 0,
                                   VisitorName = row["VisitorName"] != DBNull.Value ? row["VisitorName"].ToString() : "",
                                   Description = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
                                   FromHoursMinutes = row["FromHoursMinutes"] != DBNull.Value ? row["FromHoursMinutes"].ToString() : "",
                                   ToHoursMinutes = row["ToHoursMinutes"] != DBNull.Value ? row["ToHoursMinutes"].ToString() : "",
                                   VisitorDate = row["VisitorDate"] != DBNull.Value ? row["VisitorDate"].ToString() : "",
                                   GroupIdentifier = row["GroupIdentifier"] != DBNull.Value ? row["GroupIdentifier"].ToString() : "Group " + DateTime.Now.ToString("dd-MMMM-yyyy hh:mm")
                               }).ToList();
            }
            model.VisitorList = visitorList;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(VisitorModel model)
        {
            visitor.VisitorName = model.VisitorName;
            visitor.Description = model.Description;
            visitor.FromHoursMinutes = model.FromHoursMinutes;
            visitor.ToHoursMinutes = model.ToHoursMinutes;
            visitor.VisitorDate = model.VisitorDate;
            visitor.GroupIdentifier = model.GroupIdentifier;
            visitor.VisitorID = model.VisitorID;
            visitor.CreatedBy = Convert.ToInt32(Session["UserId"]);

            actionResult = visitorAction.Visitor_AddEdit(visitor);
            if (actionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = " Visitor Details Successfully Saved !!";
            }
            else
            {
                TempData["ErrorMessage"] = "Error in Request !!";
            }
            return RedirectToAction("Index");
        }

        public JsonResult DeleteVisitor(int visitorID)
        {
            string jsonString = string.Empty;
            try
            {
                visitor.VisitorID = visitorID;
                actionResult = visitorAction.Visitor_Delete(visitor);

                if (actionResult.IsSuccess)
                {
                    jsonString = "Success";
                }
                else
                {
                    jsonString = "Fail";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Visitor_Filter(string startDate, string endDate)
        {
            string jsonString = string.Empty;
            try
            {
                visitor = new BaseLayer.VisitorBase();
                visitor.StartDate = startDate;
                visitor.EndDate = endDate;
                List<VisitorModel> VisitorList = new List<VisitorModel>();
                VisitorModel model = new VisitorModel();
                actionResult = visitorAction.Visitor_Filter(visitor);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr id=" + actionResult.dtResult.Rows[i]["VisitorID"].ToString() + ">";
                        jsonString += "<td>" + actionResult.dtResult.Rows[i]["VisitorDate"]
                            + "</td><td>" + actionResult.dtResult.Rows[i]["VisitorName"] + "</td><td>" + actionResult.dtResult.Rows[i]["GroupIdentifier"]
                            + "</td><td>" + actionResult.dtResult.Rows[i]["FromHoursMinutes"] + "</td><td>" + actionResult.dtResult.Rows[i]["ToHoursMinutes"]
                            + "</td><td><a href='Index?visitorID=" + actionResult.dtResult.Rows[i]["VisitorID"].ToString() + "' class='btn small btn-info btn-sm btn-icon' title='Edit Visitor'><i class='fa fa-pencil'></i></a> | <a href ='javascript:;' onclick='DeleteVisitor("
                                + actionResult.dtResult.Rows[i]["VisitorID"].ToString() + ",this);' class='btn small btn-danger btn-sm -icon delete-sm' title='Delete Visitor'><i class='fa fa-trash'></i></a></td>";
                        jsonString += "</tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }

            return Json(jsonString, JsonRequestBehavior.AllowGet);

        }

        public JsonResult SendEmailData(FormCollection fc, string Attachment = null, string To = null, string Subject = null, string Desciption = null)
        {
            string json = string.Empty;

            //create pdf
            var pdfBinary = Convert.FromBase64String(Attachment);
            var dir = Server.MapPath("~/DataDump");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            var fileName = dir + "\\PDFnMail-" + DateTime.Now.ToString("yyyyMMdd-HHMMss") + ".pdf";

            // write content to the pdf
            using (var fs = new FileStream(fileName, FileMode.Create))
            using (var writer = new BinaryWriter(fs))
            {
                writer.Write(pdfBinary, 0, pdfBinary.Length);
                writer.Close();
            }


            //string FilePath = "~/Content/Media/";
            //if (!Directory.Exists(Server.MapPath(FilePath)))
            //{
            //    Directory.CreateDirectory(Server.MapPath(FilePath));
            //}
            //string filename = "Record.png";
            //var fullpath = "";
            //int userId = Convert.ToInt32(Session["UserId"]);
            //var file = filename.Split('.');
            //file[0] = file[0] + userId;
            //string fileName = Convert.ToString(Guid.NewGuid()).Substring(0, 5);
            //string Pic_Path = HttpContext.Server.MapPath(FilePath + fileName + file[0] + "." + file[1]);
            //using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
            //{
            //    using (BinaryWriter bw = new BinaryWriter(fs))
            //    {
            //        byte[] data = Convert.FromBase64String(Attachment);
            //        bw.Write(data);
            //        bw.Close();
            //    }
            //    //Session["CapturedPath"] = Pic_Path;
            //     fullpath = Server.MapPath("/Content/Media/" + fileName + file[0] + "." + file[1]);

            //}


            if (To != null)
            {
                CIMS.Utility.SendMail.EventSendEmail(To, Subject, Desciption, true, fileName);
            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }

    }
}