using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CIMS.BaseLayer;
using CIMS.DataLayer;

namespace CIMS.ActionLayer
{
    public class VisitorAction
    {
        #region Declaration
        VisitorDL visitorDL = new VisitorDL();
        ActionResult actionResult = new ActionResult();
        #endregion

        #region Method Visitor_AddEdit
        public ActionResult Visitor_AddEdit(VisitorBase visitor)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = visitorDL.Visitor_AddEdit(visitor);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }

        #endregion

        #region Method Visitor_Delete
        public ActionResult Visitor_Delete(VisitorBase visitor)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = visitorDL.Visitor_Delete(visitor);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }

        #endregion

        #region Method Visitor_Load
        public ActionResult Visitor_Load(VisitorBase visitor)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = visitorDL.Visitor_Load(visitor);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }

        #endregion

        #region Method Visitor_Filter
        public ActionResult Visitor_Filter(VisitorBase visitor)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = visitorDL.Visitor_Filter(visitor);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method Visitor_Filter
        public ActionResult Visitor_dashboard()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = visitorDL.Visitor_dashboard();
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

    }
}
