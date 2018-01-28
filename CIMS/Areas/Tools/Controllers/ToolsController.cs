using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIMS.Models;
using System.Data;
using CIMS.ActionLayer.Tools;
using CIMS.BaseLayer.Tools;
using CIMS.Helpers;
using System.IO;
using System.Text;


namespace CIMS.Areas.Tools.Controllers
{
    public class ToolsController : Controller
    {
        DataSet dsResult = new DataSet();
        DataTable drResult = new DataTable();
        ToolsAction toolsAction = new ToolsAction();
        ToolsBase ToolsBase = new ToolsBase();
        CIMS.BaseLayer.ActionResult actionResult = new CIMS.BaseLayer.ActionResult();

        // GET: /Tools/Tools/
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ReportDesign()
        {
            ToolsModel model = new ToolsModel();
            List<ToolsModel> toolsList = new List<ToolsModel>();
            List<ToolsModel> ReportNameList = new List<ToolsModel>();
            List<ToolsModel> RoleNameList = new List<ToolsModel>();
            actionResult = toolsAction.Data_Group();
            if (actionResult.IsSuccess)
            {
                toolsList = (from DataRow row in actionResult.dtResult.Rows
                             select new ToolsModel
                             {
                                 GroupName = row["GroupName"] != DBNull.Value ? row["GroupName"].ToString() : ""
                             }).ToList();
            }
            model.toolsList = toolsList;
           
            actionResult = toolsAction.LoadReportNames_ReportDesigner();
            if (actionResult.IsSuccess)
            {
                ReportNameList.Add(new ToolsModel { ReportID = 0, ReportName = "Select" });
                ReportNameList = (from DataRow row in actionResult.dtResult.Rows
                             select new ToolsModel
                             {
                                 ReportID = row["ReportID"] != DBNull.Value ? Convert.ToInt32(row["ReportID"]) : 0,
                                 ReportName = row["ReportName"] != DBNull.Value ? row["ReportName"].ToString() : ""
                             }).ToList();
            }
            actionResult = toolsAction.SecurityFunctions_LoadAll();
            if (actionResult.IsSuccess)
            {
                RoleNameList = (from DataRow row in actionResult.dtResult.Rows
                                  select new ToolsModel
                                  {
                                      RoleName = row["RoleName"] != DBNull.Value ? row["RoleName"].ToString() : ""
                                  }).ToList();
            }
            model.RoleNameList = RoleNameList;
            model.toolsList = toolsList;
            model.ReportNameList = ReportNameList;
            return View(model);
        }

        public JsonResult LoadDataTablesTree(string GroupName=null)
        {
            string json = "";
            ToolsModel model = new ToolsModel();
            List<ToolsModel> toolsList = new List<ToolsModel>();
            ToolsBase.GroupName = GroupName;
            try
            {

                actionResult = toolsAction.LoadDataTablesTree_ReportDesign(ToolsBase);
                if (actionResult.IsSuccess)
                {
                    toolsList = (from DataRow row in actionResult.dtResult.Rows
                                   select new ToolsModel
                                   {

                                    
                                       TableName = row["TableName"] != DBNull.Value ? row["TableName"].ToString() : "",
                                       DisplayName = row["DisplayName"] != DBNull.Value ? row["DisplayName"].ToString() : ""
                                  
                                   }).ToList(); 
                }
                model.LoadDataTablesTreeList = toolsList;
            }
            catch (Exception ex)
            {
            
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadTableColumnsTreeNode(string TableName = null)
        {
            string json = "";
            ToolsModel model = new ToolsModel();
            List<ToolsModel> toolsList = new List<ToolsModel>();
            ToolsBase.TableName = TableName;
            try
            {

                actionResult = toolsAction.LoadTableColumnsTreeNode_ReportDesign(ToolsBase);
                if (actionResult.IsSuccess)
                {
                    toolsList = (from DataRow row in actionResult.dtResult.Rows
                                 select new ToolsModel
                                 {


                                     column_name = row["column_name"] != DBNull.Value ? row["column_name"].ToString() : "",
                                     data_type = row["data_type"] != DBNull.Value ? row["data_type"].ToString() : ""

                                 }).ToList();
                }
                model.LoadTableColumnsTreeNodeList = toolsList;
            }
            catch (Exception ex)
            {

            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        #region Exexcute Sql
        [HttpPost]
        public JsonResult ExexcuteSql(string FinalSql=null)
        {
            string json = string.Empty;
            ToolsBase.ExecuteSql = FinalSql;
            ToolsModel model = new ToolsModel();
            List<ToolsModel> toolsList = new List<ToolsModel>();
          
            try
            {

                actionResult = toolsAction.ExecuteReport_Sql(ToolsBase);
                if (actionResult.IsSuccess)
                {
                    
                    toolsList = (from DataRow row in actionResult.dtResult.Rows
                                 select new ToolsModel
                                 {


                                     ExecuteSql = row["Column1"] != DBNull.Value ? row["Column1"].ToString() : ""
                                   

                                 }).ToList();
                   
                }
                model.ExecuteSQlList = toolsList;
            }
            catch (Exception ex)
            {
               
            }
            return Json(toolsList, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region SaveReport
        [HttpPost]
        public JsonResult SaveReport(string ReportID=null,string ReportName = null, string Role = null, string ReportLayout = null, string ExecuteSql=null, string WholeLayout = null)
        {
            string json = string.Empty;
            ToolsBase.ReportID =Convert.ToInt32(ReportID);
            ToolsBase.ReportName = ReportName;
            ToolsBase.Role = Role;
            ToolsBase.ReportLayout = ReportLayout;
            ToolsBase.ExecuteSql = ExecuteSql;
            ToolsBase.WholeLayout = WholeLayout;

            actionResult = toolsAction.ReportDesigner_I(ToolsBase);

            if (actionResult.dtResult.Rows.Count > 0)
            {
                json = "success";
            }
            else
            {
                json = "fail";
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region bindReportData
        [HttpPost]
        public JsonResult bindReportData(int ReportID = 0)
        {
            string json = string.Empty;
            ToolsBase.ReportID = ReportID;
            ToolsModel model = new ToolsModel();
            List<ToolsModel> ReportLayoutList = new List<ToolsModel>();

            try
            {

                actionResult = toolsAction.ReportLayout_Load(ToolsBase);
                if (actionResult.IsSuccess)
                {

                    ReportLayoutList = (from DataRow row in actionResult.dtResult.Rows
                                 select new ToolsModel
                                 {


                                     ReportLayout = row["ReportLayout"] != DBNull.Value ? row["ReportLayout"].ToString() : "",
                                     WholeLayout = row["WholeLayout"] != DBNull.Value ? row["WholeLayout"].ToString() : ""

                                 }).ToList();

                }
                model.ReportLayoutList = ReportLayoutList;
            }
            catch (Exception ex)
            {

            }
            return Json(ReportLayoutList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region BindReportSql
        [HttpPost]
        public JsonResult BindReportSql(int ReportID = 0)
        {
            string json = string.Empty;
            ToolsBase.ReportID = ReportID;
            ToolsModel model = new ToolsModel();
            List<ToolsModel> QuerySQLList = new List<ToolsModel>();

            try
            {

                actionResult = toolsAction.ReportSQL_Load(ToolsBase);
                if (actionResult.IsSuccess)
                {

                    QuerySQLList = (from DataRow row in actionResult.dtResult.Rows
                                        select new ToolsModel
                                        {


                                             QuerySQL= row["QuerySQL"] != DBNull.Value ? row["QuerySQL"].ToString() : ""


                                        }).ToList();

                }
                model.QuerySQLList = QuerySQLList;
            }
            catch (Exception ex)
            {

            }
            return Json(QuerySQLList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Badge Designer

        public ActionResult BadgeDesign()
        {
            return View();
        }


        #endregion
        #region WriteXmlFile
    
        public JsonResult WriteXmlFile(string xmldata = null)
        {
            var fullpath = "";
            string json = string.Empty;
            string FilePath = "~/Content/Tools/BadgeDesigner/";
            if (!Directory.Exists(Server.MapPath(FilePath)))
            {
                Directory.CreateDirectory(Server.MapPath(FilePath));
            }
            string Pic_Path = HttpContext.Server.MapPath("~/Content/Tools/BadgeDesigner/Badge.xml");
            using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(xmldata);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);

            }
            fullpath = "/Content/Tools/BadgeDesigner/Badge.xml";
            //return File(Path, contentType, "BurpReport.xml");

            return Json(fullpath, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}