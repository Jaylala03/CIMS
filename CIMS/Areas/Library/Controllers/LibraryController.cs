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

namespace CIMS.Areas.Library.Controllers
{
    [CheckLogin]
    [CheckPermissionAttribute]
    public class LibraryController : Controller
    {
        DataSet dsResult = new DataSet();
        DataTable drResult = new DataTable();
        LibraryAction libraryAction = new LibraryAction();
        CIMS.BaseLayer.LibraryBase library = new CIMS.BaseLayer.LibraryBase();
        CIMS.BaseLayer.ActionResult actionResult = new CIMS.BaseLayer.ActionResult();

        // GET: Visitor/Visitor
        public ActionResult Index(int? LibraryID = 0)
        {
            LibraryModel model = new LibraryModel();
            List<LibraryModel> libraryList = new List<LibraryModel>();

            if (LibraryID.Value > 0)
            {
                library.LibraryID = LibraryID.Value;
                actionResult = libraryAction.Library_Load(library);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {

                    DataRow row = actionResult.dtResult.Rows[0];
                    model.LibraryID = row["LibraryID"] != DBNull.Value ? Convert.ToInt32(row["LibraryID"]) : 0;
                    model.LibraryName = row["LibraryName"] != DBNull.Value ? row["LibraryName"].ToString() : "";
                    model.FileExistence = row["FileExistence"] != DBNull.Value ? row["FileExistence"].ToString() : "";
                    model.FilePath = row["FilePath"] != DBNull.Value ? row["FilePath"].ToString() : "";
                    model.FileTypeId = row["FileTypeId"] != DBNull.Value ? Convert.ToInt32(row["FileTypeId"].ToString()) : 0;
                    model.FileType = row["Name"] != DBNull.Value ? row["Name"].ToString() : "";
                }
            }
            actionResult = libraryAction.Library_Load(library);
            if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
            {

                libraryList = (from DataRow row in actionResult.dtResult.Rows
                               select new LibraryModel
                               {
                                   LibraryID = row["LibraryID"] != DBNull.Value ? Convert.ToInt32(row["LibraryID"]) : 0,
                                   LibraryName = row["LibraryName"] != DBNull.Value ? row["LibraryName"].ToString() : "",
                                   FileExistence = row["FileExistence"] != DBNull.Value ? row["FileExistence"].ToString() : "",
                                   FilePath = row["FilePath"] != DBNull.Value ? row["FilePath"].ToString() : "",
                                   FileTypeId = row["FileTypeId"] != DBNull.Value ? Convert.ToInt32(row["FileTypeId"].ToString()) : 0,
                                   FileType = row["Name"] != DBNull.Value ? row["Name"].ToString() : "",
                               }).ToList();
            }

            List<SelectListItem> fileTypeList = new List<SelectListItem>();
            CIMS.ActionLayer.Employee.EmployeeAction employeeAction = new CIMS.ActionLayer.Employee.EmployeeAction();
            actionResult = employeeAction.FileType_Load();
            if (actionResult.IsSuccess)
            {
                fileTypeList = (from DataRow row in actionResult.dtResult.Rows
                                select new SelectListItem
                                {
                                    Text = row["Name"] != DBNull.Value ? row["Name"].ToString() : "",
                                    Value = row["FileTypeId"] != DBNull.Value ? row["FileTypeId"].ToString() : ""
                                }).ToList();
            }
            ViewBag.FileTypeList = fileTypeList;
            model.LibraryList = libraryList;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LibraryModel model, HttpPostedFileBase pdfFile)
        {
            bool exists = System.IO.Directory.Exists(Server.MapPath("~/LibraryPDFFiles/"));

            if (!exists)
                System.IO.Directory.CreateDirectory(Server.MapPath("~/LibraryPDFFiles/"));

            string fileName, fileExistence = string.Empty;
            string destinationPath = string.Empty;

            fileName = Path.GetFileName(pdfFile.FileName);
            fileExistence = Path.GetExtension(pdfFile.FileName);
            destinationPath = Path.Combine(Server.MapPath("~/LibraryPDFFiles/"), model.LibraryName + fileExistence);
            model.FileExistence = Path.GetExtension(pdfFile.FileName);
            pdfFile.SaveAs(destinationPath);

            library.FileExistence = fileExistence;
            library.FilePath = destinationPath;
            library.FileTypeId = model.FileTypeId;
            library.LibraryID = model.LibraryID;
            library.LibraryName = model.LibraryName;

            actionResult = libraryAction.Library_AddEdit(library);
            if (actionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = " Library Details Successfully Saved !!";
            }
            else
            {
                TempData["ErrorMessage"] = "Error in Request !!";
            }
            return RedirectToAction("Index");
        }

        public JsonResult DeleteLibrary(int LibraryID)
        {
            string jsonString = string.Empty;
            try
            {
                library.LibraryID = LibraryID;
                actionResult = libraryAction.Library_Delete(library);

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


    }
}