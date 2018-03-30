using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CIMS.BaseLayer;
using CIMS.DataLayer;
using System;

namespace CIMS.ActionLayer
{
    public class LibraryAction
    {
        #region Declaration
        LibraryDL libraryDL = new LibraryDL();
        ActionResult actionResult = new ActionResult();
        #endregion

        #region Method Visitor_AddEdit
        public ActionResult Library_AddEdit(LibraryBase library)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = libraryDL.Library_AddEdit(library);
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
        public ActionResult Library_Delete(LibraryBase library)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = libraryDL.Library_Delete(library);
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
        public ActionResult Library_Load(LibraryBase library)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = libraryDL.Library_Load(library);
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
