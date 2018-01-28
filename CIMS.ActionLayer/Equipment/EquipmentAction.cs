using CIMS.BaseLayer;
using CIMS.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.ActionLayer
{
    public class EquipmentAction
    {
        #region Declaration
        EquipmentDL equipmentDL = new EquipmentDL();
        ActionResult actionResult = new ActionResult();
        #endregion

        #region Method EquipmentProblems_AddEdit
        public ActionResult EquipmentProblems_AddEdit(Equipment equipment)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = equipmentDL.EquipmentProblems_AddEdit(equipment);
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

        #region Method EquipmentProblems_Load
        public ActionResult EquipmentProblems_Load(Equipment equipment)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = equipmentDL.EquipmentProblems_Load(equipment);
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


        #region Method EquipmentProblems_LoadByUserID
        public ActionResult EquipmentProblems_LoadByUserID(Equipment equipment)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = equipmentDL.EquipmentProblems_LoadByUserID(equipment);
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


        #region Method EquipmentProblems_Delete
        public ActionResult EquipmentProblems_Delete(Equipment equipment)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = equipmentDL.EquipmentProblems_Delete(equipment);
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

        #region Method Codes_LoadByPart
        public ActionResult Codes_LoadByPart(string parts)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = equipmentDL.Codes_LoadByPart(parts);
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

        #region Method EquipmentProblems_Filter
        public ActionResult EquipmentProblems_Filter(Equipment equipment)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = equipmentDL.EquipmentProblems_Filter(equipment);
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
