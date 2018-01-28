using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIMS.DataLayer.IncidentList;
using CIMS.BaseLayer;
using CIMS.BaseLayer.IncidentList;

namespace CIMS.ActionLayer.IncidentList
{
    public class IncidentListAction
    {
        #region Declaration
        IncidentListDL incidentListDL = new IncidentListDL();
        ActionResult actionResult = new ActionResult();
        #endregion

        #region Method IncidentList_print
        public ActionResult IncidentList_print(IncidentListBase reports)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = incidentListDL.IncidentList_print(reports);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actionResult;
        }
        #endregion

    }
}
