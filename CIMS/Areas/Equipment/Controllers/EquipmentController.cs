using CIMS.ActionLayer;
using CIMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIMS.Helpers;
using CIMS.Filters;
namespace CIMS.Areas.Equipment.Controllers
{
    [CheckLogin]
    [CheckPermissionAttribute]
    public class EquipmentController : Controller
    {
        DataSet dsResult = new DataSet();
        DataTable drResult = new DataTable();
        EquipmentAction equipmentAction = new EquipmentAction();
        CIMS.BaseLayer.Equipment equipment = new CIMS.BaseLayer.Equipment();
        CIMS.BaseLayer.ActionResult actionResult = new CIMS.BaseLayer.ActionResult();
        // GET: Equipment/Equipment
        public ActionResult Index(int? problemID = 0)
        {
            ViewBag.EditMode = problemID.Value > 0 ;

            EquipmentModel model = new EquipmentModel();
            equipment.userID = Convert.ToInt32(Session["UserId"]);
            actionResult = equipmentAction.EquipmentProblems_LoadByUserID(equipment);

            List<EquipmentModel> equipmentList = new List<EquipmentModel>();

            if (actionResult.IsSuccess)
            {
                equipmentList = (from DataRow row in actionResult.dtResult.Rows
                                 select new EquipmentModel
                                 {
                                     userID = row["userID"] != DBNull.Value ? Convert.ToInt32(row["userID"]) : 0,
                                     problemID = row["problemID"] != DBNull.Value ? Convert.ToInt32(row["problemID"]) : 0,
                                     ProblemType = row["ProblemType"] != DBNull.Value ? row["ProblemType"].ToString() : "",
                                     EquipNumber = row["EquipNumber"] != DBNull.Value ? row["EquipNumber"].ToString() : "",
                                     Problem = row["Problem"] != DBNull.Value ? row["Problem"].ToString() : "",
                                     Details = row["Details"] != DBNull.Value ? row["Details"].ToString() : "",
                                     Corrected = row["Corrected"] != DBNull.Value ? Convert.ToBoolean(row["Corrected"]) : false,
                                     Solution = row["Solution"] != DBNull.Value ? row["Solution"].ToString() : "",
                                     Replacement = row["Replacement"] != DBNull.Value ? row["Replacement"].ToString() : "",
                                     StatusTime = row["StatusTime"] != DBNull.Value ? Convert.ToDateTime(row["StatusTime"]).ToString("MM/dd/yyyy") : "",
                                     CompletedTime = row["CompletedTime"] != DBNull.Value ? Convert.ToDateTime(row["CompletedTime"]).ToString("MM/dd/yyyy") : ""
                                 }).ToList();

            }
            model.EquipmentList = equipmentList;
            if (problemID.Value > 0)
            {
                equipment.problemID = problemID.Value;
                actionResult = equipmentAction.EquipmentProblems_Load(equipment);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    DataRow row = actionResult.dtResult.Rows[0];
                    model.userID = row["userID"] != DBNull.Value ? Convert.ToInt32(row["userID"]) : 0;
                    model.problemID = row["problemID"] != DBNull.Value ? Convert.ToInt32(row["problemID"]) : 0;
                    model.ProblemType = row["ProblemType"] != DBNull.Value ? row["ProblemType"].ToString() : "";
                    model.EquipNumber = row["EquipNumber"] != DBNull.Value ? row["EquipNumber"].ToString() : "";
                    model.Problem = row["Problem"] != DBNull.Value ? row["Problem"].ToString() : "";
                    model.Details = row["Details"] != DBNull.Value ? row["Details"].ToString() : "";
                    model.Corrected = row["Corrected"] != DBNull.Value ? Convert.ToBoolean(row["Corrected"]) : false;
                    model.Solution = row["Solution"] != DBNull.Value ? row["Solution"].ToString() : "";
                    model.Replacement = row["Replacement"] != DBNull.Value ? row["Replacement"].ToString() : "";
                    model.StatusTime = row["StatusTime"] != DBNull.Value ? Convert.ToDateTime(row["StatusTime"]).ToString("MM/dd/yyyy") : "";
                    model.CompletedTime = row["CompletedTime"] != DBNull.Value ? Convert.ToDateTime(row["CompletedTime"]).ToString("MM/dd/yyyy") : "";
                }
            }

            CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();
            List<SelectListItem> problemsList = new List<SelectListItem>();
            List<SelectListItem> solutionsList = new List<SelectListItem>();
            actionResult = settingAction.EquipmentStatus_Load();
            if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
            {
                problemsList = (from DataRow row in actionResult.dtResult.Rows
                                select new SelectListItem
                                {
                                    Text = row["Problems"] != DBNull.Value ? row["Problems"].ToString() : "",
                                    Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                }).ToList();
            }
            ViewBag.ProblemsList = problemsList;

            actionResult = settingAction.EquipmentAction_Load();
            if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
            {
                solutionsList = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["Actions"] != DBNull.Value ? row["Actions"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
            }
            ViewBag.SolutionsList = solutionsList;

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(EquipmentModel model)
        {
            equipment.userID = Convert.ToInt32(Session["UserId"]);
            equipment.ProblemType = model.ProblemType;
            equipment.Problem = model.Problem;
            equipment.Solution = model.Solution;
            equipment.StatusTime = model.StatusTime;
            equipment.CompletedTime = model.CompletedTime;
            equipment.EquipNumber = model.EquipNumber;
            equipment.Replacement = model.Replacement;
            equipment.Details = model.Details;
            equipment.problemID = model.problemID;
            equipment.Corrected = model.Corrected;

            actionResult = equipmentAction.EquipmentProblems_AddEdit(equipment);
            if (actionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "Successfully Saved !!";
            }
            else
            {
                TempData["ErrorMessage"] = "Error in Request !!";
            }
            return RedirectToAction("Index");
        }




        public JsonResult DeleteEquipment(int problemID)
        {
            string jsonString = string.Empty;
            try
            {
                equipment.problemID = problemID;
                actionResult = equipmentAction.EquipmentProblems_Delete(equipment);

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

        public JsonResult EquipmentProblems_Filter(string startDate, string endDate, bool status)
        {

            string jsonString = string.Empty;
            try
            {
                equipment = new BaseLayer.Equipment();
                equipment.userID = Convert.ToInt32(Session["UserId"]); ;
                equipment.StatusTime = startDate;
                equipment.CompletedTime = endDate;
                equipment.Corrected = status;
                List<EquipmentModel> EquipmentList = new List<EquipmentModel>();
                EquipmentModel model = new EquipmentModel();
                actionResult = equipmentAction.EquipmentProblems_Filter(equipment);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr id=" + actionResult.dtResult.Rows[i]["ProblemID"].ToString() + ">";
                        jsonString += "<td>" + actionResult.dtResult.Rows[i]["ProblemType"]
                            + "</td><td>" + actionResult.dtResult.Rows[i]["StatusTime"] + "</td><td>" + actionResult.dtResult.Rows[i]["EquipNumber"]
                            + "</td><td>" + actionResult.dtResult.Rows[i]["Problem"] + "</td><td>" + actionResult.dtResult.Rows[i]["Solution"]
                            + "</td><td>" + actionResult.dtResult.Rows[i]["Replacement"]
                            + "</td><td><a href='/Equipment/Equipment/Index?problemID=" + actionResult.dtResult.Rows[i]["ProblemID"].ToString() + "' class='btn small btn-info btn-sm btn-icon'><i class='fa fa-pencil'></i></a> | <a href ='javascript:;' onclick='DeleteEquipment("
                                   + actionResult.dtResult.Rows[i]["ProblemID"].ToString() + ",this);' title='Delete Employee' class='btn small btn-danger btn-sm btn-icon delete-sm'><i class='fa fa-trash'></i></a></td>";
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



    }
}