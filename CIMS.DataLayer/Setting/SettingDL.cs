using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIMS.BaseLayer.Setting;
using System.Data;

namespace CIMS.DataLayer
{
    public class SettingDL
    {
        DataTable dtContainer;
        DataSet dsContainer;

        #region Method DepartmentType_IU
        public DataTable DepartmentType_IU(DepartmentTypeBase departmentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@id", departmentBase.DepartmentID),
                                           new MyParameter("@DepartmentType", departmentBase.DepartmentName )
                                        };
                Common.Set_Procedures("DepartmentType_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method EmployeeDepartment_IU
        public DataTable EmployeeDepartment_IU(EmployeeDepartmentBase employeeDepartmentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@id", employeeDepartmentBase.EmployeeDepartmentID),
                                           new MyParameter("@DepartmentType", employeeDepartmentBase.EmployeeDepartmentName )
                                        };
                Common.Set_Procedures("EmployeeDepartment_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method DepartmentType_Delete
        public DataTable DepartmentType_Delete(DepartmentTypeBase departmentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@id", departmentBase.DepartmentID)
                                        };
                Common.Set_Procedures("DepartmentType_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method EmployeeDepartment_Delete
        public DataTable EmployeeDepartment_Delete(EmployeeDepartmentBase employeeDepartmentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@id", employeeDepartmentBase.EmployeeDepartmentID)
                                        };
                Common.Set_Procedures("EmployeeDepartment_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method TemplateCategory_IU
        public DataTable TemplateCategory_IU(TemplateCategoryBase templateCategoryBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@id", templateCategoryBase.TemplateCategoryID),
                                           new MyParameter("@CategoryName", templateCategoryBase.TemplateCategoryName)
                                        };
                Common.Set_Procedures("TemplateCategory_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method TemplateCategory_Delete
        public DataTable TemplateCategory_Delete(TemplateCategoryBase templateCategoryBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@id", templateCategoryBase.TemplateCategoryID)
                                        };
                Common.Set_Procedures("TemplateCategory_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method TemplateCategoryType_IU
        public DataTable TemplateCategoryType_IU(TemplateCategoryTypeBase templateCategoryTypeBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@id", templateCategoryTypeBase.TemplateCategoryTypeID),
                                           new MyParameter("@CategoryID", templateCategoryTypeBase.TemplateCategoryID),
                                           new MyParameter("@TemplateName", templateCategoryTypeBase.TemplateCategoryTypeName),
                                           new MyParameter("@Content", templateCategoryTypeBase.TemplateCategoryTypeContent),
                                           new MyParameter("@CreatedBy", templateCategoryTypeBase.CreatedBy)
                                        };
                Common.Set_Procedures("TemplateCategoryType_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method SubjectStatus_IU
        public DataTable SubjectStatus_IU(SubjectStatusBase subjectStatusBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@id", subjectStatusBase.SubjectStatusID),
                                           new MyParameter("@Status", subjectStatusBase.SubjectStatusName)
                                        };
                Common.Set_Procedures("MasterSubjectStatus_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method SubjectStatus_Delete
        public DataTable SubjectStatus_Delete(SubjectStatusBase subjectStatusBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@id", subjectStatusBase.SubjectStatusID)
                                        };
                Common.Set_Procedures("MasterSubjectStatus_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method LicenseType_IU
        public DataTable LicenseType_IU(LicenseTypeBase licenseBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@id", licenseBase.LicenseID),
                                           new MyParameter("@LicenseType", licenseBase.LicenseName)
                                        };
                Common.Set_Procedures("LicenseType_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method LicenseType_Delete
        public DataTable LicenseType_Delete(LicenseTypeBase licenseBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@id", licenseBase.LicenseID)
                                        };
                Common.Set_Procedures("LicenseType_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method LicenseStatus_IU
        public DataTable LicenseStatus_IU(LicenseStatusBase licenseStatusBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@id", licenseStatusBase.ID),
                                           new MyParameter("@LicenseStatus", licenseStatusBase.LicenseStatus)
                                        };
                Common.Set_Procedures("LicenseStatus_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method LicenseStatus_Delete
        public DataTable LicenseStatus_Delete(LicenseStatusBase licenseStatusBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@id", licenseStatusBase.ID)
                                        };
                Common.Set_Procedures("LicenseStatus_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method FeatureType_Load
        public DataTable FeatureType_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("FeatureType_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method FeatureType_IU
        public DataTable FeatureType_IU(FeatureTypeBase featureBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", featureBase.ID),
                                           new MyParameter("@FeatureType", featureBase.FeatureType)
                                        };
                Common.Set_Procedures("FeatureType_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method FeatureType_Delete
        public DataTable FeatureType_Delete(FeatureTypeBase featureBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", featureBase.ID)
                                        };
                Common.Set_Procedures("FeatureType_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method FeatureLocation_Load
        public DataTable FeatureLocation_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("FeatureLocation_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method FeatureLocation_IU
        public DataTable FeatureLocation_IU(FeatureLocationBase featureLocationBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", featureLocationBase.ID),
                                           new MyParameter("@FLocation", featureLocationBase.FLocation)
                                        };
                Common.Set_Procedures("FeatureLocation_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method FeatureLocation_Delete
        public DataTable FeatureLocation_Delete(FeatureLocationBase featureLocationBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", featureLocationBase.ID)
                                        };
                Common.Set_Procedures("FeatureLocation_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method Complexion_Load
        public DataTable Complexion_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("Complexion_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method Complexion_IU
        public DataTable Complexion_IU(ComplexionBase complexionBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", complexionBase.ID),
                                           new MyParameter("@Complexion", complexionBase.Complexion)
                                        };
                Common.Set_Procedures("Complexion_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method Complexion_Delete
        public DataTable Complexion_Delete(ComplexionBase complexionBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", complexionBase.ID)
                                        };
                Common.Set_Procedures("Complexion_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method Build_Load
        public DataTable Build_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("Build_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method Build_IU
        public DataTable Build_IU(BuildBase buildBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", buildBase.ID),
                                           new MyParameter("@Build", buildBase.Build)
                                        };
                Common.Set_Procedures("Build_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method Build_Delete
        public DataTable Build_Delete(BuildBase buildBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", buildBase.ID)
                                        };
                Common.Set_Procedures("Build_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        public DataTable MasterTypeID1_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MasterTypeID1_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        public DataTable MasterTypeID2_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MasterTypeID2_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        public DataTable MasterTypeID3_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MasterTypeID3_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #region Method HairLength_Load
        public DataTable HairLength_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("HairLength_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method HairLength_IU
        public DataTable HairLength_IU(HairLengthBase hairLengthBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", hairLengthBase.ID),
                                           new MyParameter("@HairLength", hairLengthBase.HairLength),
                                           new MyParameter("@ImagePath", hairLengthBase.ImagePath)
                                        };
                Common.Set_Procedures("HairLength_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion
        public DataTable MasterTypeID1_IU(MasterTypeID MstTypeID)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", MstTypeID.ID),
                                           new MyParameter("@TypeIDName", MstTypeID.Value)
                                        };
                Common.Set_Procedures("MasterTypeID1_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        public DataTable MasterTypeID2_IU(MasterTypeID MstTypeID)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", MstTypeID.ID),
                                           new MyParameter("@TypeIDName", MstTypeID.Value)
                                        };
                Common.Set_Procedures("MasterTypeID2_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        public DataTable MasterTypeID3_IU(MasterTypeID MstTypeID)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", MstTypeID.ID),
                                           new MyParameter("@TypeIDName", MstTypeID.Value)
                                        };
                Common.Set_Procedures("MasterTypeID3_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        public DataTable MasterType1_Delete(MasterTypeID MasterType)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", MasterType.ID)
                                        };
                Common.Set_Procedures("MasterTypeID1_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        public DataTable MasterType2_Delete(MasterTypeID MasterType)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", MasterType.ID)
                                        };
                Common.Set_Procedures("MasterTypeID2_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        public DataTable MasterType3_Delete(MasterTypeID MasterType)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", MasterType.ID)
                                        };
                Common.Set_Procedures("MasterTypeID3_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #region Method HairLength_Delete
        public DataTable HairLength_Delete(HairLengthBase hairLengthBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", hairLengthBase.ID)
                                        };
                Common.Set_Procedures("HairLength_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method HairColor_Load
        public DataTable HairColor_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("HairColor_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method LU_AgeSearch_Load
        public DataTable LU_AgeSearch_Load()
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("LU_AgeSearch_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method HairColor_IU
        public DataTable HairColor_IU(HairColorBase hairColorBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", hairColorBase.ID),
                                           new MyParameter("@HairColor", hairColorBase.HairColor)
                                        };
                Common.Set_Procedures("HairColor_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method HairColor_Delete
        public DataTable HairColor_Delete(HairColorBase hairColorBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", hairColorBase.ID)
                                        };
                Common.Set_Procedures("HairColor_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method FacialHair_Load
        public DataTable FacialHair_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("FacialHair_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method FacialHair_IU
        public DataTable FacialHair_IU(FacialHairBase facialHairBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", facialHairBase.ID),
                                           new MyParameter("@FacialHair", facialHairBase.FacialHair)
                                        };
                Common.Set_Procedures("FacialHair_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method FacialHair_Delete
        public DataTable FacialHair_Delete(FacialHairBase facialHairBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", facialHairBase.ID)
                                        };
                Common.Set_Procedures("FacialHair_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterRace_IU
        public DataTable MasterRace_IU(RaceBase racebase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", racebase.ID),
                                           new MyParameter("@Race", racebase.Race)
                                        };
                Common.Set_Procedures("MasterRace_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterRace_Load
        public DataTable MasterRace_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MasterRace_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterRace_Delete
        public DataTable MasterRace_Delete(RaceBase racebase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", racebase.ID)
                                        };
                Common.Set_Procedures("MasterRace_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterEyes_IU
        public DataTable MasterEyes_IU(EyesBase eyesBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", eyesBase.ID),
                                           new MyParameter("@Eyes", eyesBase.Eyes)
                                        };
                Common.Set_Procedures("MasterEyes_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterEyes_Load
        public DataTable MasterEyes_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MasterEyes_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterEyes_Delete
        public DataTable MasterEyes_Delete(EyesBase eyesBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", eyesBase.ID)
                                        };
                Common.Set_Procedures("MasterEyes_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterSex_IU
        public DataTable MasterSex_IU(SexBase sexBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", sexBase.ID),
                                           new MyParameter("@Sex", sexBase.Sex)
                                        };
                Common.Set_Procedures("MasterSex_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterSex_Load
        public DataTable MasterSex_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MasterSex_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterSex_Delete
        public DataTable MasterSex_Delete(SexBase sexBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", sexBase.ID)
                                        };
                Common.Set_Procedures("MasterSex_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method EmployeePosition_IU
        public DataTable EmployeePosition_IU(EmployeePositionBase empPositionBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", empPositionBase.ID),
                                           new MyParameter("@Position", empPositionBase.Position)
                                        };
                Common.Set_Procedures("EmployeePosition_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method EmployeePosition_Load
        public DataTable EmployeePosition_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("EmployeePosition_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method EmployeePosition_Delete
        public DataTable EmployeePosition_Delete(EmployeePositionBase empPositionBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", empPositionBase.ID)
                                        };
                Common.Set_Procedures("EmployeePosition_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method AddressType_IU
        public DataTable AddressType_IU(AddressTypeBase addressTypeBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", addressTypeBase.ID),
                                           new MyParameter("@AddressType", addressTypeBase.AddressType)
                                        };
                Common.Set_Procedures("AddressType_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method AddressType_Load
        public DataTable AddressType_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("AddressType_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method AddressType_Delete
        public DataTable AddressType_Delete(AddressTypeBase addressTypeBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", addressTypeBase.ID)
                                        };
                Common.Set_Procedures("AddressType_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion
        
        // Report Setting
        
        #region Method MasterShortDescriptor_IU
        public DataTable MasterShortDescriptor_IU(ShortDescriptorBase shortBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", shortBase.ID),
                                           new MyParameter("@Descriptor", shortBase.Descriptor),
                                           new MyParameter("@NatureID", shortBase.NatureID),
                                           new MyParameter("@ProShortDescriptor", shortBase.ProShortDescriptor)
                                        };
                Common.Set_Procedures("MasterShortDescriptor_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        //Ankur New 1
        #region Method InsertUpdatePreferenceValue
        public DataTable InsertUpdatePreferenceValue(Incedent_Pref incedentpref)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@prefType", incedentpref.pref_Type),
                                           new MyParameter("@prefValue", incedentpref.pref_Value),
                                        };
                Common.Set_Procedures("InsertUpdate_incedent_pref");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterShortDescriptor_Load
        public DataTable MasterShortDescriptor_Load(ShortDescriptorBase shortBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { 
                                             new MyParameter("@NatureID", shortBase.NatureID)
                                         };
                Common.Set_Procedures("MasterShortDescriptor_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterShortDescriptor_Delete
        public DataTable MasterShortDescriptor_Delete(ShortDescriptorBase shortBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", shortBase.ID)
                                        };
                Common.Set_Procedures("MasterShortDescriptor_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterShortDescriptor_DestilsbyID
        public DataTable MasterShortDescriptor_DestilsbyID(ShortDescriptorBase shortBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { 
                                             new MyParameter("@Id", shortBase.ID)
                                         };
                Common.Set_Procedures("MasterShortDescriptor_DestilsbyID");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion


        #region Method MasterNatureofIncident_IU
        public DataTable MasterNatureofIncident_IU(NatureofIncidentBase natureBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", natureBase.ID),
                                           new MyParameter("@Nature", natureBase.Nature),
                                           new MyParameter("@NatureType", natureBase.NatureType),
                                           new MyParameter("@NatureImage", natureBase.NatureImage)
                                        };
                Common.Set_Procedures("MasterNatureofIncident_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterNatureofIncident_Load
        public DataTable MasterNatureofIncident_Load(NatureofIncidentBase natureBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@NatureType", natureBase.NatureType),
                                         };
                Common.Set_Procedures("MasterNatureofIncident_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method GetNatureImage
        public DataTable GetNatureImage(NatureofIncidentBase natureBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@NatureType", natureBase.NatureType),
                                             new MyParameter("@Nature", natureBase.Nature),
                                         };
                Common.Set_Procedures("GetNatureImage");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterNatureofIncident_Delete
        public DataTable MasterNatureofIncident_Delete(NatureofIncidentBase natureBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", natureBase.ID)
                                        };
                Common.Set_Procedures("MasterNatureofIncident_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterStatus_IU
        public DataTable MasterStatus_IU(StatusBase statusBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", statusBase.ID),
                                           new MyParameter("@Status", statusBase.Status)
                                        };
                Common.Set_Procedures("MasterStatus_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterStatus_Load
        public DataTable MasterStatus_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MasterStatus_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterStatus_Delete
        public DataTable MasterStatus_Delete(StatusBase statusBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", statusBase.ID)
                                        };
                Common.Set_Procedures("MasterStatus_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterRole_IU
        public DataTable MasterRole_IU(RoleBase roleBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", roleBase.ID),
                                           new MyParameter("@Role", roleBase.Role)
                                        };
                Common.Set_Procedures("MasterRole_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterRole_Load
        public DataTable MasterRole_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MasterRole_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterRole_Delete
        public DataTable MasterRole_Delete(RoleBase roleBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", roleBase.ID)
                                        };
                Common.Set_Procedures("MasterRole_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterGame_IU
        public DataTable MasterGame_IU(GameBase gameBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", gameBase.ID),
                                           new MyParameter("@Game", gameBase.Game)
                                        };
                Common.Set_Procedures("MasterGame_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterGame_Load
        public DataTable MasterGame_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MasterGame_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterGame_Delete
        public DataTable MasterGame_Delete(GameBase gameBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", gameBase.ID)
                                        };
                Common.Set_Procedures("MasterGame_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterBuyInGame_IU
        public DataTable MasterBuyInGame_IU(BuyInGameBase gameBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", gameBase.ID),
                                           new MyParameter("@Game", gameBase.Game)
                                        };
                Common.Set_Procedures("MasterBuyInGame_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterBuyInGame_Load
        public DataTable MasterBuyInGame_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MasterBuyInGame_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterBuyInGame_Delete
        public DataTable MasterBuyInGame_Delete(BuyInGameBase gameBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", gameBase.ID)
                                        };
                Common.Set_Procedures("MasterBuyInGame_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion


        #region Method MasterCashoutTableNumber_IU
        public DataTable MasterCashoutTableNumber_IU(CashoutTableNumberBase tablenumberBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", tablenumberBase.ID),
                                           new MyParameter("@TableNumber", tablenumberBase.TableNumber)
                                        };
                Common.Set_Procedures("MasterCashoutTableNumber_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterCashoutTableNumber_Load
        public DataTable MasterCashoutTableNumber_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MasterCashoutTableNumber_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterCashoutTableNumber_Delete
        public DataTable MasterCashoutTableNumber_Delete(CashoutTableNumberBase tablenumberBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", tablenumberBase.ID)
                                        };
                Common.Set_Procedures("MasterCashoutTableNumber_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterDisputeType_IU
        public DataTable MasterDisputeType_IU(DisputeTypeBase disputeTypeBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", disputeTypeBase.ID),
                                           new MyParameter("@DisputeType", disputeTypeBase.DisputeType)
                                        };
                Common.Set_Procedures("MasterDisputeType_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterDisputeType_Load
        public DataTable MasterDisputeType_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MasterDisputeType_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterDisputeType_Delete
        public DataTable MasterDisputeType_Delete(DisputeTypeBase disputeTypeBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", disputeTypeBase.ID)
                                        };
                Common.Set_Procedures("MasterDisputeType_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterBuyInPitType_IU
        public DataTable MasterBuyInPitType_IU(BuyInPitTypeBase BuyInPitTypeBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", BuyInPitTypeBase.ID),
                                           new MyParameter("@BuyInPitType", BuyInPitTypeBase.BuyInPitType)
                                        };
                Common.Set_Procedures("MasterBuyInPitType_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterBuyInPitType_Load
        public DataTable MasterBuyInPitType_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MasterBuyInPitType_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method MasterBuyInPitType_Delete
        public DataTable MasterBuyInPitType_Delete(BuyInPitTypeBase BuyInPitTypeBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", BuyInPitTypeBase.ID)
                                        };
                Common.Set_Procedures("MasterBuyInPitType_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method CashierName_IU
        public DataTable CashierName_IU(CashierBase cashierBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", cashierBase.ID),
                                           new MyParameter("@CashierName", cashierBase.Cashier)
                                        };
                Common.Set_Procedures("CashierName_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method CashierName_Load
        public DataTable CashierName_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("CashierName_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method CashierName_Delete
        public DataTable CashierName_Delete(CashierBase cashierBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", cashierBase.ID)
                                        };
                Common.Set_Procedures("CashierName_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method Location_IU
        public DataTable Location_IU(LocationBase locationBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", locationBase.ID),
                                           new MyParameter("@Location", locationBase.Location)
                                        };
                Common.Set_Procedures("Location_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method Location_Load
        public DataTable Location_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("Location_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method Location_Delete
        public DataTable Location_Delete(LocationBase locationBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", locationBase.ID)
                                        };
                Common.Set_Procedures("Location_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method DisputeResolution_IU
        public DataTable DisputeResolution_IU(ResolutionBase resolutionBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", resolutionBase.ID),
                                           new MyParameter("@Resolution", resolutionBase.Resolution)
                                        };
                Common.Set_Procedures("DisputeResolution_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method DisputeResolution_Load
        public DataTable DisputeResolution_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("DisputeResolution_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method DisputeResolution_Delete
        public DataTable DisputeResolution_Delete(ResolutionBase resolutionBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", resolutionBase.ID)
                                        };
                Common.Set_Procedures("DisputeResolution_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method VehicleColor_IU
        public DataTable VehicleColor_IU(VehicleColorBase colorBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", colorBase.ID),
                                           new MyParameter("@Color", colorBase.Color)
                                        };
                Common.Set_Procedures("VehicleColor_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method VehicleColor_Load
        public DataTable VehicleColor_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("VehicleColor_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method VehicleColor_Delete
        public DataTable VehicleColor_Delete(VehicleColorBase colorBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", colorBase.ID)
                                        };
                Common.Set_Procedures("VehicleColor_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method BanAuthorizedBy_IU
        public DataTable BanAuthorizedBy_IU(AuthorizedByBase authorizedByBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", authorizedByBase.ID),
                                           new MyParameter("@AuthorizedBy", authorizedByBase.AuthorizedBy)
                                        };
                Common.Set_Procedures("BanAuthorizedBy_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method BanAuthorizedBy_Load
        public DataTable BanAuthorizedBy_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("BanAuthorizedBy_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method BanAuthorizedBy_Delete
        public DataTable BanAuthorizedBy_Delete(AuthorizedByBase authorizedByBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", authorizedByBase.ID)
                                        };
                Common.Set_Procedures("BanAuthorizedBy_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion


        #region Method for TypeofBen
        public DataTable MstTypeOfBan_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MstTypeOfBan_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        public DataTable MstTypeOfBen_Delete(TypeofBan authorizedByBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", authorizedByBase.ID)
                                        };
                Common.Set_Procedures("MstTypeOfBan_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        public DataTable MstTypeOfBan_IU(TypeofBan authorizedByBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", authorizedByBase.ID),
                                           new MyParameter("@TypeOfBan", authorizedByBase.BanType)
                                        };
                Common.Set_Procedures("MstTypeOfBan_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }

        #endregion

        #region Method VarianceType_IU
        public DataTable VarianceType_IU(VarianceTypeBase varianceBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", varianceBase.ID),
                                           new MyParameter("@VarianceType", varianceBase.VarianceType)
                                        };
                Common.Set_Procedures("VarianceType_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method VarianceType_Load
        public DataTable VarianceType_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("VarianceType_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method VarianceType_Delete
        public DataTable VarianceType_Delete(VarianceTypeBase varianceBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", varianceBase.ID)
                                        };
                Common.Set_Procedures("VarianceType_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method VarianceResolution_IU
        public DataTable VarianceResolution_IU(VarianceResolutionBase varianceResBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", varianceResBase.ID),
                                           new MyParameter("@Resolution", varianceResBase.Resolution)
                                        };
                Common.Set_Procedures("VarianceResolution_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        //AB New 22/2
        #region Method Audit_IU
        public DataTable Audit_IU(int ID, string Name)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@QuestionId", ID),
                                           new MyParameter("@AuditType", Name),
                                           new MyParameter("@Question", Name),
                                           new MyParameter("@ScoreType", 0)
                                        };
                Common.Set_Procedures("Audit_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }

        public DataTable AuditQuestion_IU(AuditsQuestionsVM aq)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@QuestionId", aq.QuestionID),
                                           new MyParameter("@AuditId", aq.AuditID),
                                           new MyParameter("@Question", aq.Question),
                                           new MyParameter("@QuestionType", aq.QuestionType),
                                           new MyParameter("@Tooltip", aq.ToolTip)
                                        };
                Common.Set_Procedures("Insert_AuditsQuestions");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method VarianceResolution_Load
        public DataTable VarianceResolution_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("VarianceResolution_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        //AB New 22/2
        #region Method Audit_Load
        public DataTable Audit_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("Audit_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }

        public DataTable GetAuditQuestionById(int QuestionId)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { new MyParameter("@QuestionID", QuestionId) };
                Common.Set_Procedures("GetAuditQuestionById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        public DataTable DeleteQuestionById(int QuestionId)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { new MyParameter("@QuestionID", QuestionId) };
                Common.Set_Procedures("DeleteAuditQuestionById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        public DataTable LoadAuditQuestionsByAuditID(int AuditId)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = { new MyParameter("@AuditID", AuditId) };
                Common.Set_Procedures("LoadAuditQuestionsByAuditID");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        //AB New 22/2
        #region Method Audit_Delete
        public DataTable Audit_Delete(int ID)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@QuestionId", ID)
                                        };
                Common.Set_Procedures("Audit_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method VarianceResolution_Delete
        public DataTable VarianceResolution_Delete(VarianceResolutionBase varianceResBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", varianceResBase.ID)
                                        };
                Common.Set_Procedures("VarianceResolution_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method AliasNameType_IU
        public DataTable AliasNameType_IU(AliasNameTypeBase aliasType)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", aliasType.ID),
                                           new MyParameter("@NameType", aliasType.NameType)
                                        };
                Common.Set_Procedures("AliasNameType_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method AliasNameType_Load
        public DataTable AliasNameType_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("AliasNameType_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method AliasNameType_Delete
        public DataTable AliasNameType_Delete(AliasNameTypeBase aliasType)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", aliasType.ID)
                                        };
                Common.Set_Procedures("AliasNameType_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method ForeignExchangeRates_IU
        public DataTable ForeignExchangeRates_IU(ForeignExchangeRatesBase exchangeBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", exchangeBase.ID),
                                           new MyParameter("@Country", exchangeBase.Country),
                                           new MyParameter("@Rate", exchangeBase.Rate)
                                        };
                Common.Set_Procedures("ForeignExchangeRates_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method ForeignExchangeRates_Load
        public DataTable ForeignExchangeRates_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("ForeignExchangeRates_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method ForeignExchangeRates_Delete
        public DataTable ForeignExchangeRates_Delete(ForeignExchangeRatesBase exchangeBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", exchangeBase.ID)
                                        };
                Common.Set_Procedures("ForeignExchangeRates_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method Services_IU
        public DataTable Services_IU(ServicesBase serviceBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", serviceBase.ID),
                                           new MyParameter("@ServiceName", serviceBase.ServiceName),
                                           new MyParameter("@DeclinedAvailable", serviceBase.DeclinedAvailable)
                                        };
                Common.Set_Procedures("Services_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method Services_LoadAll
        public DataTable Services_LoadAll()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("Services_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method Services_Delete
        public DataTable Services_Delete(ServicesBase serviceBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", serviceBase.ID)
                                        };
                Common.Set_Procedures("Services_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method EquipmentStatus_IU
        public DataTable EquipmentStatus_IU(EquipmentStatusBase statusBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", statusBase.ID),
                                           new MyParameter("@Problems", statusBase.Problems)
                                        };
                Common.Set_Procedures("EquipmentStatus_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method EquipmentStatus_Load
        public DataTable EquipmentStatus_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("EquipmentStatus_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method EquipmentStatus_Delete
        public DataTable EquipmentStatus_Delete(EquipmentStatusBase statusBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", statusBase.ID)
                                        };
                Common.Set_Procedures("EquipmentStatus_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method EquipmentAction_IU
        public DataTable EquipmentAction_IU(EquipmentActionBase actionBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", actionBase.ID),
                                           new MyParameter("@Actions", actionBase.Actions)
                                        };
                Common.Set_Procedures("EquipmentAction_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method EquipmentAction_Load
        public DataTable EquipmentAction_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("EquipmentAction_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method EquipmentAction_Delete
        public DataTable EquipmentAction_Delete(EquipmentActionBase actionBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", actionBase.ID)
                                        };
                Common.Set_Procedures("EquipmentAction_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method InitiatedBy_IU
        public DataTable InitiatedBy_IU(InitiatedByBase initiatedBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", initiatedBase.ID),
                                           new MyParameter("@Initiated", initiatedBase.Initiated)
                                        };
                Common.Set_Procedures("InitiatedBy_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method InitiatedBy_Load
        public DataTable InitiatedBy_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("InitiatedBy_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method InitiatedBy_Delete
        public DataTable InitiatedBy_Delete(InitiatedByBase initiatedBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", initiatedBase.ID)
                                        };
                Common.Set_Procedures("InitiatedBy_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method NatureCodes_IU
        public DataTable NatureCodes_IU(NatureEventBase natureEvent)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", natureEvent.ID),
                                           new MyParameter("@Code", natureEvent.Code),
                                           new MyParameter("@Description", natureEvent.Description),
                                           new MyParameter("@DefaultAction", natureEvent.DefaultAction),
                                           new MyParameter("@DefaultCamera", natureEvent.DefaultCamera),
                                        };
                Common.Set_Procedures("NatureCodes_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method NatureCodes_Delete
        public DataTable NatureCodes_Delete(NatureEventBase natureEvent)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", natureEvent.ID)
                                        };
                Common.Set_Procedures("NatureCodes_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method setmetrics_IU
        public DataTable setmetrics_IU(SetMetricsBase setMetricsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", setMetricsBase.ID),
                                           new MyParameter("@Type", setMetricsBase.Type),
                                           new MyParameter("@metrics", setMetricsBase.Metrics),
                                            new MyParameter("@ActiveMetrics", setMetricsBase.ActiveMetrics),
                                        };
                Common.Set_Procedures("setmetrics_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method setmetrics_Delete
        public DataTable setmetrics_Delete(SetMetricsBase setMetricsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", setMetricsBase.ID)
                                        };
                Common.Set_Procedures("setmetrics_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method setmetrics_LoadBy
        public DataTable setmetrics_LoadBy(SetMetricsBase setMetricsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@Type", setMetricsBase.Type)
                                         };
                Common.Set_Procedures("setmetrics_LoadBy");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method ActivateMetrics_ByID
        public DataTable ActivateMetrics_ByID(SetMetricsBase setMetricsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", setMetricsBase.ID),
                                           new MyParameter("@Type", setMetricsBase.Type)
                                        };
                Common.Set_Procedures("ActivateMetrics_ByID");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method VistorLogoImage_Bind
        public DataTable VistorLogoImage_Bind(LogoImageBase logoBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {};
                Common.Set_Procedures("VistorLogoImage_Bind");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method VistorLogoImage_Add
        public DataTable VistorLogoImage_Add(LogoImageBase logoBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ImagePath", logoBase.ImagePath),
                                           new MyParameter("@SetImage", logoBase.SetImage),
                                           new MyParameter("@CreatedBy", logoBase.CreatedBy)
                                        };
                Common.Set_Procedures("VistorLogoImage_Add");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method VistorLogoImage_Delete
        public DataTable VistorLogoImage_Delete(LogoImageBase logoBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", logoBase.ImageID)
                                        };
                Common.Set_Procedures("VistorLogoImage_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method VistorLogoImage_SetImage
        public DataTable VistorLogoImage_SetImage(LogoImageBase logoBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", logoBase.ImageID)
                                        };
                Common.Set_Procedures("VistorLogoImage_SetImage");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method ReportLogoImage_Bind
        public DataTable ReportLogoImage_Bind(LogoImageBase logoBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("ReportLogoImage_Bind");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method ReportLogoImage_Add
        public DataTable ReportLogoImage_Add(LogoImageBase logoBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ImagePath", logoBase.ImagePath),
                                           new MyParameter("@SetImage", logoBase.SetImage),
                                           new MyParameter("@CreatedBy", logoBase.CreatedBy)
                                        };
                Common.Set_Procedures("ReportLogoImage_Add");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method ReportLogoImage_Delete
        public DataTable ReportLogoImage_Delete(LogoImageBase logoBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", logoBase.ImageID)
                                        };
                Common.Set_Procedures("ReportLogoImage_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method ReportLogoImage_SetImage
        public DataTable ReportLogoImage_SetImage(LogoImageBase logoBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", logoBase.ImageID)
                                        };
                Common.Set_Procedures("ReportLogoImage_SetImage");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method VisitorEmailSend_Bind
        public DataTable VisitorEmailSend_Bind()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("VisitorEmailSend_Bind");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method VisitorEmailSend_AddEdit
        public DataTable VisitorEmailSend_AddEdit(EmailLogBase emailLogBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", emailLogBase.ID),
                                           new MyParameter("@Email", emailLogBase.Email),
                                           new MyParameter("@SMTP", emailLogBase.SMTP),
                                           new MyParameter("@Password", emailLogBase.Password),
                                            new MyParameter("@CreatedBy", emailLogBase.CreatedBy),
                                        };
                Common.Set_Procedures("VisitorEmailSend_AddEdit");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method VisitorEmailSend_Delete
        public DataTable VisitorEmailSend_Delete(EmailLogBase emailLogBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", emailLogBase.ID)
                                        };
                Common.Set_Procedures("VisitorEmailSend_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method SendEmailLog
        public DataTable SendEmailLog()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("SendEmailLog");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion
        public DataTable Masterwatch_IU(watchbase watchbase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", watchbase.ID),
                                           new MyParameter("@watch", watchbase.watch)
                                        };
                Common.Set_Procedures("Masterwatch_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }

        public DataTable Masterwatch_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("Masterwatch_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }

        public DataTable Masterwatch_Delete(watchbase watchbase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", watchbase.ID)
                                        };
                Common.Set_Procedures("Masterwatch_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }

        #region Method WeightUnit_IU
        public DataTable WeightUnit_IU(WeightUnitBase WeightUnitBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@id", WeightUnitBase.WeightUnitId),
                                           new MyParameter("@WeightUnit", WeightUnitBase.WeightUnitName ),
                                           new MyParameter("@IsDefault", WeightUnitBase.IsDefault),
                                        };
                Common.Set_Procedures("WeightUnit_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method WeightUnit_Delete
        public DataTable WeightUnit_Delete(WeightUnitBase WeightUnitBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@id", WeightUnitBase.WeightUnitId)
                                        };
                Common.Set_Procedures("WeightUnit_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method setweightUnit_LoadBy
        public DataTable setweightUnit_LoadBy(WeightUnitBase setWeightUnitBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@IsDefault", setWeightUnitBase.IsDefault)
                                         };
                Common.Set_Procedures("setweightUnit_LoadBy");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion



        #region Method HeightUnit_IU
        public DataTable HeightUnit_IU(HeightUnitBase HeightUnitBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@id", HeightUnitBase.HeightUnitId),
                                           new MyParameter("@HeightUnit", HeightUnitBase.HeightUnitName ),
                                           new MyParameter("@IsDefault", HeightUnitBase.IsDefault),
                                        };
                Common.Set_Procedures("HeightUnit_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method HeightUnit_Delete
        public DataTable HeightUnit_Delete(HeightUnitBase HeightUnitBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@id", HeightUnitBase.HeightUnitId)
                                        };
                Common.Set_Procedures("HeightUnit_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method setHeightUnit_LoadBy
        public DataTable setHeightUnit_LoadBy(HeightUnitBase setHeightUnitBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@IsDefault", setHeightUnitBase.IsDefault)
                                         };
                Common.Set_Procedures("setHeightUnit_LoadBy");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion
    }
}
