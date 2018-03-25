using CIMS.BaseLayer;
using CIMS.DataLayer;
using CIMS.BaseLayer.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIMS.Utility;

namespace CIMS.ActionLayer.Setting
{
    public class SettingAction
    {
        #region Declaration
        SettingDL settingDL = new SettingDL();
        ActionResult actionResult = new ActionResult();
        #endregion

        #region Method DepartmentType_IU
        public ActionResult DepartmentType_IU(DepartmentTypeBase departmentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.DepartmentType_IU(departmentBase);
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

        #region Method EmployeeDepartment_IU
        public ActionResult EmployeeDepartment_IU(EmployeeDepartmentBase employeeDepartmentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.EmployeeDepartment_IU(employeeDepartmentBase);
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

        #region Method DepartmentType_Delete
        public ActionResult DepartmentType_Delete(DepartmentTypeBase departmentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.DepartmentType_Delete(departmentBase);
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

        #region Method EmployeeDepartment_Delete
        public ActionResult EmployeeDepartment_Delete(EmployeeDepartmentBase employeeDepartmentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.EmployeeDepartment_Delete(employeeDepartmentBase);
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

        #region Method TemplateCategory_IU
        public ActionResult TemplateCategory_IU(TemplateCategoryBase templateCategoryBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.TemplateCategory_IU(templateCategoryBase);
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

        #region Method TemplateCategory_Delete
        public ActionResult TemplateCategory_Delete(TemplateCategoryBase templateCategoryBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.TemplateCategory_Delete(templateCategoryBase);
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

        #region Method TemplateCategoryType_IU
        public ActionResult TemplateCategoryType_IU(TemplateCategoryTypeBase templateCategoryTypeBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.TemplateCategoryType_IU(templateCategoryTypeBase);
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

        #region Method LicenseType_IU
        public ActionResult LicenseType_IU(LicenseTypeBase licenseBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.LicenseType_IU(licenseBase);
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

        #region Method LicenseType_Delete
        public ActionResult LicenseType_Delete(LicenseTypeBase licenseBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.LicenseType_Delete(licenseBase);
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

        #region Method LicenseStatus_IU
        public ActionResult LicenseStatus_IU(LicenseStatusBase licenseStatusBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.LicenseStatus_IU(licenseStatusBase);
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

        #region Method LicenseStatus_Delete
        public ActionResult LicenseStatus_Delete(LicenseStatusBase licenseStatusBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.LicenseStatus_Delete(licenseStatusBase);
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

        #region Method FeatureType_Load
        public ActionResult FeatureType_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.FeatureType_Load();
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

        #region Method FeatureType_IU
        public ActionResult FeatureType_IU(FeatureTypeBase featureBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.FeatureType_IU(featureBase);
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

        #region Method FeatureType_Delete
        public ActionResult FeatureType_Delete(FeatureTypeBase featureBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.FeatureType_Delete(featureBase);
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

        #region Method FeatureLocation_Load
        public ActionResult FeatureLocation_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.FeatureLocation_Load();
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

        #region Method FeatureLocation_IU
        public ActionResult FeatureLocation_IU(FeatureLocationBase featureLocationBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.FeatureLocation_IU(featureLocationBase);
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

        #region Method FeatureLocation_Delete
        public ActionResult FeatureLocation_Delete(FeatureLocationBase featureLocationBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.FeatureLocation_Delete(featureLocationBase);
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

        #region Method Complexion_Load
        public ActionResult Complexion_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.Complexion_Load();
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

        #region Method Complexion_IU
        public ActionResult Complexion_IU(ComplexionBase complexionBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.Complexion_IU(complexionBase);
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

        #region Method Complexion_Delete
        public ActionResult Complexion_Delete(ComplexionBase complexionBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.Complexion_Delete(complexionBase);
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

        #region Method Build_Load
        public ActionResult Build_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.Build_Load();
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

        #region Method Build_IU
        public ActionResult Build_IU(BuildBase buildBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.Build_IU(buildBase);
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

        #region Method Build_Delete
        public ActionResult Build_Delete(BuildBase buildBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.Build_Delete(buildBase);
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

        #region Method HairLength_Load
        public ActionResult HairLength_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.HairLength_Load();
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
        public ActionResult MasterTypeID1_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterTypeID1_Load();
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
        public ActionResult MasterTypeID2_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterTypeID2_Load();
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
        public ActionResult MasterTypeID3_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterTypeID3_Load();
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
        public ActionResult MasterTypeID1_IU(MasterTypeID MstTypeID)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterTypeID1_IU(MstTypeID);
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
        public ActionResult MasterTypeID2_IU(MasterTypeID MstTypeID)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterTypeID2_IU(MstTypeID);
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
        public ActionResult MasterTypeID3_IU(MasterTypeID MstTypeID)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterTypeID3_IU(MstTypeID);
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
        public ActionResult MasterTypeID1_Delete(MasterTypeID hairLengthBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterType1_Delete(hairLengthBase);
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
        public ActionResult MasterTypeID2_Delete(MasterTypeID hairLengthBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterType2_Delete(hairLengthBase);
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
        public ActionResult MasterTypeID3_Delete(MasterTypeID hairLengthBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterType3_Delete(hairLengthBase);
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
        #region Method HairLength_IU
        public ActionResult HairLength_IU(HairLengthBase hairLengthBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.HairLength_IU(hairLengthBase);
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

        #region Method HairLength_Delete
        public ActionResult HairLength_Delete(HairLengthBase hairLengthBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.HairLength_Delete(hairLengthBase);
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

        #region Method HairColor_Load
        public ActionResult HairColor_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.HairColor_Load();
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

        #region Method LU_AgeSearch_Load
        public ActionResult LU_AgeSearch_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.LU_AgeSearch_Load();
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

        #region Method HairColor_IU
        public ActionResult HairColor_IU(HairColorBase hairColorBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.HairColor_IU(hairColorBase);
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

        #region Method HairColor_Delete
        public ActionResult HairColor_Delete(HairColorBase hairColorBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.HairColor_Delete(hairColorBase);
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

        #region Method FacialHair_Load
        public ActionResult FacialHair_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.FacialHair_Load();
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

        #region Method FacialHair_IU
        public ActionResult FacialHair_IU(FacialHairBase facialHairBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.FacialHair_IU(facialHairBase);
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

        #region Method FacialHair_Delete
        public ActionResult FacialHair_Delete(FacialHairBase facialHairBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.FacialHair_Delete(facialHairBase);
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

        #region Method MasterRace_IU
        public ActionResult MasterRace_IU(RaceBase racebase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterRace_IU(racebase);
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

        #region Method MasterRace_Load
        public ActionResult MasterRace_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterRace_Load();
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

        #region Method MasterRace_Delete
        public ActionResult MasterRace_Delete(RaceBase racebase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterRace_Delete(racebase);
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

        #region Method MasterEyes_IU
        public ActionResult MasterEyes_IU(EyesBase eyesBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterEyes_IU(eyesBase);
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

        #region Method MasterEyes_Load
        public ActionResult MasterEyes_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterEyes_Load();
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

        #region Method MasterEyes_Delete
        public ActionResult MasterEyes_Delete(EyesBase eyesBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterEyes_Delete(eyesBase);
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

        #region Method MasterSex_IU
        public ActionResult MasterSex_IU(SexBase sexBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterSex_IU(sexBase);
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

        #region Method MasterSex_Load
        public ActionResult MasterSex_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterSex_Load();
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

        #region Method MasterSex_Delete
        public ActionResult MasterSex_Delete(SexBase sexBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterSex_Delete(sexBase);
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

        #region Method EmployeePosition_IU
        public ActionResult EmployeePosition_IU(EmployeePositionBase empPositionBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.EmployeePosition_IU(empPositionBase);
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

        #region Method EmployeePosition_Load
        public ActionResult EmployeePosition_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.EmployeePosition_Load();
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

        #region Method EmployeePosition_Delete
        public ActionResult EmployeePosition_Delete(EmployeePositionBase empPositionBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.EmployeePosition_Delete(empPositionBase);
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

        #region Method AddressType_IU
        public ActionResult AddressType_IU(AddressTypeBase addressTypeBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.AddressType_IU(addressTypeBase);
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

        #region Method AddressType_Load
        public ActionResult AddressType_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.AddressType_Load();
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

        #region Method AddressType_Delete
        public ActionResult AddressType_Delete(AddressTypeBase addressTypeBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.AddressType_Delete(addressTypeBase);
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



        // Report Setting

        #region Method MasterShortDescriptor_IU
        public ActionResult MasterShortDescriptor_IU(ShortDescriptorBase shortBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterShortDescriptor_IU(shortBase);
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

        //Ankur New 1
        #region Method InsertUpdatePreferenceValue
        public ActionResult InsertUpdatePreferenceValue(Incedent_Pref incedentpref)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.InsertUpdatePreferenceValue(incedentpref);
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

        #region Method MasterShortDescriptor_Load
        public ActionResult MasterShortDescriptor_Load(ShortDescriptorBase shortBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterShortDescriptor_Load(shortBase);
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

        #region Method MasterShortDescriptor_Delete
        public ActionResult MasterShortDescriptor_Delete(ShortDescriptorBase shortBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterShortDescriptor_Delete(shortBase);
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

        #region Method MasterShortDescriptor_DestilsbyID
        public ActionResult MasterShortDescriptor_DestilsbyID(ShortDescriptorBase shortBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterShortDescriptor_DestilsbyID(shortBase);
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

        #region Method MasterNatureofIncident_IU
        public ActionResult MasterNatureofIncident_IU(NatureofIncidentBase natureBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterNatureofIncident_IU(natureBase);
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

        #region Method MasterNatureofIncident_Load
        public ActionResult MasterNatureofIncident_Load(NatureofIncidentBase natureBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterNatureofIncident_Load(natureBase);
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

        #region Method GetNatureImage
        public ActionResult GetNatureImage(NatureofIncidentBase natureBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.GetNatureImage(natureBase);
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

        #region Method MasterNatureofIncident_Delete
        public ActionResult MasterNatureofIncident_Delete(NatureofIncidentBase natureBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterNatureofIncident_Delete(natureBase);
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

        #region Method MasterStatus_IU
        public ActionResult MasterStatus_IU(StatusBase statusBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterStatus_IU(statusBase);
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

        #region Method MasterStatus_Load
        public ActionResult MasterStatus_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterStatus_Load();
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

        #region Method MasterStatus_Delete
        public ActionResult MasterStatus_Delete(StatusBase statusBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterStatus_Delete(statusBase);
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

        #region Method MasterRole_IU
        public ActionResult MasterRole_IU(RoleBase roleBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterRole_IU(roleBase);
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

        #region Method MasterRole_Load
        public ActionResult MasterRole_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterRole_Load();
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

        #region Method MasterRole_Delete
        public ActionResult MasterRole_Delete(RoleBase roleBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterRole_Delete(roleBase);
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

        #region Method MasterGame_IU
        public ActionResult MasterGame_IU(GameBase gameBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterGame_IU(gameBase);
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

        #region Method MasterGame_Load
        public ActionResult MasterGame_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterGame_Load();
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

        #region Method MasterGame_Delete
        public ActionResult MasterGame_Delete(GameBase gameBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterGame_Delete(gameBase);
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

        #region Method MasterBuyInGame_IU
        public ActionResult MasterBuyInGame_IU(BuyInGameBase gameBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterBuyInGame_IU(gameBase);
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

        #region Method MasterBuyInGame_Load
        public ActionResult MasterBuyInGame_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterBuyInGame_Load();
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

        #region Method MasterBuyInGame_Delete
        public ActionResult MasterBuyInGame_Delete(BuyInGameBase gameBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterBuyInGame_Delete(gameBase);
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

        #region Method MasterCashoutTableNumber_IU
        public ActionResult MasterCashoutTableNumber_IU(CashoutTableNumberBase tablenumberBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterCashoutTableNumber_IU(tablenumberBase);
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

        #region Method MasterCashoutTableNumber_Load
        public ActionResult MasterCashoutTableNumber_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterCashoutTableNumber_Load();
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

        #region Method MasterCashoutTableNumber_Delete
        public ActionResult MasterCashoutTableNumber_Delete(CashoutTableNumberBase tablenumberBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterCashoutTableNumber_Delete(tablenumberBase);
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

        #region Method MasterDisputeType_IU
        public ActionResult MasterDisputeType_IU(DisputeTypeBase disputeTypeBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterDisputeType_IU(disputeTypeBase);
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

        #region Method MasterDisputeType_Load
        public ActionResult MasterDisputeType_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterDisputeType_Load();
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

        #region Method MasterDisputeType_Delete
        public ActionResult MasterDisputeType_Delete(DisputeTypeBase disputeTypeBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterDisputeType_Delete(disputeTypeBase);
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

        #region Method MasterBuyInPitType_IU
        public ActionResult MasterBuyInPitType_IU(BuyInPitTypeBase BuyInPitTypeBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterBuyInPitType_IU(BuyInPitTypeBase);
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

        #region Method MasterBuyInPitType_Load
        public ActionResult MasterBuyInPitType_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterBuyInPitType_Load();
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

        #region Method MasterBuyInPitType_Delete
        public ActionResult MasterBuyInPitType_Delete(BuyInPitTypeBase BuyInPitTypeBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MasterBuyInPitType_Delete(BuyInPitTypeBase);
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

        #region Method CashierName_IU
        public ActionResult CashierName_IU(CashierBase cashierBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.CashierName_IU(cashierBase);
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

        #region Method CashierName_Load
        public ActionResult CashierName_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.CashierName_Load();
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

        #region Method CashierName_Delete
        public ActionResult CashierName_Delete(CashierBase cashierBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.CashierName_Delete(cashierBase);
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

        #region Method Location_IU
        public ActionResult Location_IU(LocationBase locationBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.Location_IU(locationBase);
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

        #region Method Location_Load
        public ActionResult Location_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.Location_Load();
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

        #region Method Location_Delete
        public ActionResult Location_Delete(LocationBase locationBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.Location_Delete(locationBase);
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

        #region Method DisputeResolution_IU
        public ActionResult DisputeResolution_IU(ResolutionBase resolutionBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.DisputeResolution_IU(resolutionBase);
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

        #region Method DisputeResolution_Load
        public ActionResult DisputeResolution_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.DisputeResolution_Load();
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

        #region Method DisputeResolution_Delete
        public ActionResult DisputeResolution_Delete(ResolutionBase resolutionBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.DisputeResolution_Delete(resolutionBase);
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

        #region Method VehicleColor_IU
        public ActionResult VehicleColor_IU(VehicleColorBase colorBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.VehicleColor_IU(colorBase);
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

        #region Method VehicleColor_Load
        public ActionResult VehicleColor_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.VehicleColor_Load();
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

        #region Method VehicleColor_Delete
        public ActionResult VehicleColor_Delete(VehicleColorBase colorBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.VehicleColor_Delete(colorBase);
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

        #region Method BanAuthorizedBy_IU
        public ActionResult BanAuthorizedBy_IU(AuthorizedByBase authorizedByBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.BanAuthorizedBy_IU(authorizedByBase);
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

        #region Method BanAuthorizedBy_Load
        public ActionResult BanAuthorizedBy_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.BanAuthorizedBy_Load();
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

        #region Method BanAuthorizedBy_Delete
        public ActionResult BanAuthorizedBy_Delete(AuthorizedByBase authorizedByBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.BanAuthorizedBy_Delete(authorizedByBase);
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

        #region Method for TypeofBen
        public ActionResult MstBanType_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MstTypeOfBan_Load();
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

        public ActionResult MstBanType_Delete(TypeofBan authorizedByBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MstTypeOfBen_Delete(authorizedByBase);
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

        public ActionResult MstBanType_IU(TypeofBan authorizedByBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.MstTypeOfBan_IU(authorizedByBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception)
            {

            }
            return actionResult;
        }
        #endregion
        #region Method VarianceType_IU
        public ActionResult VarianceType_IU(VarianceTypeBase varianceBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.VarianceType_IU(varianceBase);
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

        #region Method VarianceType_Load
        public ActionResult VarianceType_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.VarianceType_Load();
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

        #region Method VarianceType_Delete
        public ActionResult VarianceType_Delete(VarianceTypeBase varianceBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.VarianceType_Delete(varianceBase);
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

        #region Method VarianceResolution_IU
        public ActionResult VarianceResolution_IU(VarianceResolutionBase varianceResBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.VarianceResolution_IU(varianceResBase);
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

        //AB New 22/2
        #region Method Audit_IU
        public ActionResult Audit_IU(int ID, string Name)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.Audit_IU(ID, Name);
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
        public ActionResult AuditQuestion_IU(AuditsQuestionsVM aq)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.AuditQuestion_IU(aq);
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

        #region Method VarianceResolution_Load
        public ActionResult VarianceResolution_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.VarianceResolution_Load();
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

        //AB New 22/2
        #region Method Audit_Load
        public ActionResult Audit_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.Audit_Load();
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

        public ActionResult GetAuditQuestionById(int QuestionId)
        {
            actionResult = new ActionResult();
            actionResult.dtResult = settingDL.GetAuditQuestionById(QuestionId);
            if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
            {
                actionResult.IsSuccess = true;
            }
            return actionResult;
        }
        public ActionResult DeleteQuestionById(int QuestionId)
        {
            try
            {
                actionResult.dtResult = settingDL.DeleteQuestionById(QuestionId);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        public ActionResult LoadAuditQuestionsByAuditID(int AuditId)
        {
            actionResult = new ActionResult();
            actionResult.dtResult = settingDL.LoadAuditQuestionsByAuditID(AuditId);
            if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
            {
                actionResult.IsSuccess = true;
            }
            return actionResult;
        }
        #endregion

        //AB New 22/2
        #region Method Audit_Delete
        public ActionResult Audit_Delete(int ID)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.Audit_Delete(ID);
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

        #region Method VarianceResolution_Delete
        public ActionResult VarianceResolution_Delete(VarianceResolutionBase varianceResBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.VarianceResolution_Delete(varianceResBase);
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

        #region Method AliasNameType_IU
        public ActionResult AliasNameType_IU(AliasNameTypeBase aliasType)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.AliasNameType_IU(aliasType);
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

        #region Method AliasNameType_Load
        public ActionResult AliasNameType_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.AliasNameType_Load();
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

        #region Method AliasNameType_Delete
        public ActionResult AliasNameType_Delete(AliasNameTypeBase aliasType)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.AliasNameType_Delete(aliasType);
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

        #region Method ForeignExchangeRates_IU
        public ActionResult ForeignExchangeRates_IU(ForeignExchangeRatesBase exchangeBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.ForeignExchangeRates_IU(exchangeBase);
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

        #region Method ForeignExchangeRates_Load
        public ActionResult ForeignExchangeRates_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.ForeignExchangeRates_Load();
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

        #region Method ForeignExchangeRates_Delete
        public ActionResult ForeignExchangeRates_Delete(ForeignExchangeRatesBase exchangeBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.ForeignExchangeRates_Delete(exchangeBase);
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

        #region Method Services_IU
        public ActionResult Services_IU(ServicesBase serviceBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.Services_IU(serviceBase);
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

        #region Method Services_LoadAll
        public ActionResult Services_LoadAll()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.Services_LoadAll();
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

        #region Method Services_Delete
        public ActionResult Services_Delete(ServicesBase serviceBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.Services_Delete(serviceBase);
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

        #region Method EquipmentStatus_IU
        public ActionResult EquipmentStatus_IU(EquipmentStatusBase statusBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.EquipmentStatus_IU(statusBase);
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

        #region Method EquipmentStatus_Load
        public ActionResult EquipmentStatus_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.EquipmentStatus_Load();
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

        #region Method EquipmentStatus_Delete
        public ActionResult EquipmentStatus_Delete(EquipmentStatusBase statusBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.EquipmentStatus_Delete(statusBase);
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

        #region Method EquipmentAction_IU
        public ActionResult EquipmentAction_IU(EquipmentActionBase actionBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.EquipmentAction_IU(actionBase);
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

        #region Method EquipmentAction_Load
        public ActionResult EquipmentAction_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.EquipmentAction_Load();
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

        #region Method EquipmentAction_Delete
        public ActionResult EquipmentAction_Delete(EquipmentActionBase actionBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.EquipmentAction_Delete(actionBase);
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

        #region Method InitiatedBy_IU
        public ActionResult InitiatedBy_IU(InitiatedByBase initiatedBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.InitiatedBy_IU(initiatedBase);
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

        #region Method InitiatedBy_Load
        public ActionResult InitiatedBy_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.InitiatedBy_Load();
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

        #region Method InitiatedBy_Delete
        public ActionResult InitiatedBy_Delete(InitiatedByBase initiatedBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.InitiatedBy_Delete(initiatedBase);
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

        #region Method NatureCodes_IU
        public ActionResult NatureCodes_IU(NatureEventBase natureEvent)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.NatureCodes_IU(natureEvent);
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

        #region Method NatureCodes_Delete
        public ActionResult NatureCodes_Delete(NatureEventBase natureEvent)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.NatureCodes_Delete(natureEvent);
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

        #region Method setmetrics_IU
        public ActionResult setmetrics_IU(SetMetricsBase setMetricsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.setmetrics_IU(setMetricsBase);
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

        #region Method setmetrics_Delete
        public ActionResult setmetrics_Delete(SetMetricsBase setMetricsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.setmetrics_Delete(setMetricsBase);
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

        #region Method setmetrics_LoadBy
        public ActionResult setmetrics_LoadBy(SetMetricsBase setMetricsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.setmetrics_LoadBy(setMetricsBase);
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

        #region Method ActivateMetrics_ByID
        public ActionResult ActivateMetrics_ByID(SetMetricsBase setMetricsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.ActivateMetrics_ByID(setMetricsBase);
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

        #region Method VistorLogoImage_Bind
        public ActionResult VistorLogoImage_Bind(LogoImageBase logoBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.VistorLogoImage_Bind(logoBase);
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

        #region Method VistorLogoImage_Add
        public ActionResult VistorLogoImage_Add(LogoImageBase logoBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.VistorLogoImage_Add(logoBase);
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

        #region Method VistorLogoImage_Delete
        public ActionResult VistorLogoImage_Delete(LogoImageBase logoBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.VistorLogoImage_Delete(logoBase);
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

        #region Method VistorLogoImage_SetImage
        public ActionResult VistorLogoImage_SetImage(LogoImageBase logoBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.VistorLogoImage_SetImage(logoBase);
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

        #region Method ReportLogoImage_Bind
        public ActionResult ReportLogoImage_Bind(LogoImageBase logoBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.ReportLogoImage_Bind(logoBase);
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

        #region Method ReportLogoImage_Add
        public ActionResult ReportLogoImage_Add(LogoImageBase logoBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.ReportLogoImage_Add(logoBase);
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

        #region Method ReportLogoImage_Delete
        public ActionResult ReportLogoImage_Delete(LogoImageBase logoBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.ReportLogoImage_Delete(logoBase);
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

        #region Method ReportLogoImage_SetImage
        public ActionResult ReportLogoImage_SetImage(LogoImageBase logoBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.ReportLogoImage_SetImage(logoBase);
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

        #region Method VisitorEmailSend_Bind
        public ActionResult VisitorEmailSend_Bind()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.VisitorEmailSend_Bind();
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

        #region Method VisitorEmailSend_AddEdit
        public ActionResult VisitorEmailSend_AddEdit(EmailLogBase emailLogBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.VisitorEmailSend_AddEdit(emailLogBase);
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

        #region Method VisitorEmailSend_Delete
        public ActionResult VisitorEmailSend_Delete(EmailLogBase emailLogBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.VisitorEmailSend_Delete(emailLogBase);
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

        #region Method SendEmailLog
        public ActionResult SendEmailLog()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.SendEmailLog();
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

        public ActionResult Masterwatch_Delete(watchbase watchbase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.Masterwatch_Delete(watchbase);
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

        public ActionResult Masterwatch_IU(watchbase watchbase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.Masterwatch_IU(watchbase);
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

        public ActionResult Masterwatch_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.Masterwatch_Load();
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

        #region Method WeightUnit_IU
        public ActionResult WeightUnit_IU(WeightUnitBase WeightUnitBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.WeightUnit_IU(WeightUnitBase);
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

        #region Method WeightUnit_Delete
        public ActionResult WeightUnit_Delete(WeightUnitBase WeightUnitBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.WeightUnit_Delete(WeightUnitBase);
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

        #region Method WeightUnit_LoadBy
        public ActionResult setWeightUnit_LoadBy(WeightUnitBase weightUnitBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.setweightUnit_LoadBy(weightUnitBase);
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



        #region Method HeightUnit_IU
        public ActionResult HeightUnit_IU(HeightUnitBase HeightUnitBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.HeightUnit_IU(HeightUnitBase);
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

        #region Method HeightUnit_Delete
        public ActionResult HeightUnit_Delete(HeightUnitBase HeightUnitBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.HeightUnit_Delete(HeightUnitBase);
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

        #region Method HeightUnit_LoadBy
        public ActionResult setHeightUnit_LoadBy(HeightUnitBase HeightUnitBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = settingDL.setHeightUnit_LoadBy(HeightUnitBase);
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
