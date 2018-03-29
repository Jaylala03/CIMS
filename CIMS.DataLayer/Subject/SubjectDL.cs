using CIMS.BaseLayer.Events;
using CIMS.BaseLayer.Subject;
using CIMS.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.DataLayer.Subject
{
    public class SubjectDL
    {
        #region Declaration

        DataTable dtContainer;
        DataSet dsContainer;
        #endregion

        #region Subject
        #region Subject_IU
        public DataTable Subject_IU(SubjectBase subjectBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@SubjectID", subjectBase.SubjectID),
                                            new MyParameter("@VIP", subjectBase.VIP),
                                            new MyParameter("@Age", subjectBase.Age),
                                            new MyParameter("@AgeRange", subjectBase.AgeRange ),
                                            new MyParameter("@Sex", subjectBase.Sex),
                                            new MyParameter("@Race", subjectBase.Race),
                                            new MyParameter("@LastName" , subjectBase.LastName),
                                            new MyParameter("@FirstName", subjectBase.FirstName),
                                            new MyParameter("@MiddleName", subjectBase.MiddleName),
                                            new MyParameter("@Height", subjectBase.Height),
                                            new MyParameter("@Weight", subjectBase.Weight),
                                            new MyParameter("@DateOfBirth", subjectBase.DateOfBirth),
                                            new MyParameter("@HairColor", subjectBase.HairColor),
                                            new MyParameter("@Eyes", subjectBase.Eyes),
                                            new MyParameter("@Complexion", subjectBase.Complexion),
                                            new MyParameter("@Build", subjectBase.Build),
                                            new MyParameter("@FacialHair", subjectBase.FacialHair),
                                            new MyParameter("@HairLength", subjectBase.HairLength),
                                            new MyParameter("@Glasses", subjectBase.Glasses),
                                            new MyParameter("@Restricted", subjectBase.Restricted),
                                            new MyParameter("@Status", subjectBase.Status),
                                            new MyParameter("@RoleName", subjectBase.RoleName),
                                            new MyParameter("@CIDSubject", subjectBase.CIDSubject),
                                            new MyParameter("@CIDPersonID", subjectBase.CIDPersonID),
                                            new MyParameter("@CreatedBy", subjectBase.CreatedBy),
                                            new MyParameter("@SubjectNumber", subjectBase.SubjectNumber),
                                            new MyParameter("@SubjectStatus", subjectBase.SubjectStatus)
                                         };
                Common.Set_Procedures("Subject_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Subject_DeleteById
        public DataTable Subject_DeleteById(SubjectBase subjectBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@SubjectID", subjectBase.SubjectID)
                                         };
                Common.Set_Procedures("Subject_DeleteById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Subject_LoadById
        public DataTable Subject_LoadById(SubjectBase subjectBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@SubjectID", subjectBase.SubjectID)
                                            ,new MyParameter("@ReportAccessRole", subjectBase.RoleID)
                                            ,new MyParameter("@UserID", subjectBase.CreatedBy)
                                         };
                Common.Set_Procedures("Subject_LoadById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion     

        #region Subjects_LoadAll
        public DataTable Subjects_LoadAll(SubjectBase model)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = { new MyParameter("@UserID", model.CreatedBy)
                ,new MyParameter("@ReportAccessRole", model.RoleID) };
                Common.Set_Procedures("Subjects_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #endregion

        #region Subject Address
        #region SubjectAddress_InsertUpdate
        public DataTable SubjectAddress_InsertUpdate(SubjectAddressBase addressBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@AddressID", addressBase.AddressID),
                                            new MyParameter("@SubjectID", addressBase.SubjectID),
                                            new MyParameter("@IncidentID", addressBase.IncidentID),
                                            new MyParameter("@Apartment", addressBase.Apartment),
                                            new MyParameter("@Address", addressBase.Address),
                                            new MyParameter("@CountryID", addressBase.CountryID),
                                            new MyParameter("@City", addressBase.City),
                                            new MyParameter("@ProvState", addressBase.ProvState),
                                            new MyParameter("@PostalZip", addressBase.PostalZip),
                                            new MyParameter("@AddressType", addressBase.AddressType)
                                         };
                Common.Set_Procedures("SubjectAddress_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region SubjectAddress_LoadById
        public DataTable SubjectAddress_LoadById(SubjectAddressBase addressBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@AddressID", addressBase.AddressID)
                                         };
                Common.Set_Procedures("SubjectAddress_LoadById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region SubjectAddress_LoadBySubjectId
        public DataTable SubjectAddress_LoadBySubjectId(SubjectAddressBase addressBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@SubjectID", addressBase.SubjectID)
                                         };
                Common.Set_Procedures("SubjectAddress_LoadBySubjectId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region SubjectAddress_DeleteById
        public DataTable SubjectAddress_DeleteById(SubjectAddressBase addressBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@AddressID", addressBase.AddressID)
                                         };
                Common.Set_Procedures("SubjectAddress_DeleteById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #endregion

        #region Subject Alias
        #region SubjectAlias_InsertUpdate
        public DataTable SubjectAlias_InsertUpdate(SubjectAliasBase aliasBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@AliasID", aliasBase.AliasID),
                                            new MyParameter("@SubjectID", aliasBase.SubjectID),
                                            new MyParameter("@NameType", aliasBase.NameType),
                                            new MyParameter("@FirstName", aliasBase.FirstName),
                                            new MyParameter("@MiddleName", aliasBase.MiddleName),
                                            new MyParameter("@LastName", aliasBase.LastName)
                                         };
                Common.Set_Procedures("SubjectAlias_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region SubjectAlias_LoadById
        public DataTable SubjectAlias_LoadById(SubjectAliasBase aliasBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@AliasID", aliasBase.AliasID)
                                         };
                Common.Set_Procedures("SubjectAlias_LoadById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region SubjectAlias_LoadBySubjectId
        public DataTable SubjectAlias_LoadBySubjectId(SubjectAliasBase aliasBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@SubjectID", aliasBase.SubjectID)
                                         };
                Common.Set_Procedures("SubjectAlias_LoadBySubjectId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region SubjectAlias_DeleteById
        public DataTable SubjectAlias_DeleteById(SubjectAliasBase aliasBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@AliasID", aliasBase.AliasID)
                                         };
                Common.Set_Procedures("SubjectAlias_DeleteById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #endregion

        #region Subject Linked
        #region SubjectLinked_InsertUpdate
        public DataTable SubjectLinked_InsertUpdate(SubjectLinkedBase linkBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", linkBase.ID),
                                            new MyParameter("@SubjectID", linkBase.SubjectID),
                                            new MyParameter("@IncidentID", linkBase.IncidentID),
                                            new MyParameter("@FilePath", linkBase.FilePath),
                                            new MyParameter("@Description", linkBase.Description)
                                         };
                Common.Set_Procedures("SubjectLinked_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region SubjectLinked_LoadById
        public DataTable SubjectLinked_LoadById(SubjectLinkedBase linkBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", linkBase.ID)
                                         };
                Common.Set_Procedures("SubjectLinked_LoadById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #region SubjectLinked_LoadByIncidentId
        public DataTable SubjectLinked_LoadByIncidentId(IncidentLinkedBase linkBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", linkBase.ID)
                                         };
                Common.Set_Procedures("SubjectLinked_LoadById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #region SubjectLinked_LoadBySubjectId_IncidentID
        public DataTable SubjectLinked_LoadBySubjectId_IncidentID(IncidentLinkedBase linkBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@SubjectID", linkBase.SubjectID),
                                              new MyParameter("@IncidentID", linkBase.IncidentID)

                                         };
                Common.Set_Procedures("SubjectLinked_LoadBySubjectId_IncidentID");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #region SubjectLinked_LoadBySubjectId
        public DataTable SubjectLinked_LoadBySubjectId(SubjectLinkedBase linkBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@SubjectID", linkBase.SubjectID)


                                         };
                Common.Set_Procedures("SubjectLinked_LoadBySubjectId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Method SubjectLinked_LoadBySubjectID
        public DataTable SubjectIncidentProofRead_LoadBySubjectID(SubjectIncidentsBase subject)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();

            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@SubjectID", subject.SubjectID),
                                           new MyParameter("@ReportID", subject.IncidentID)
                                        };
                Common.Set_Procedures("SubReportProofread_Log_Bind");
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


        #region SubjectLinked_DeleteById
        public DataTable SubjectLinked_DeleteById(SubjectLinkedBase linkBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", linkBase.ID)
                                         };
                Common.Set_Procedures("SubjectLinked_DeleteById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #endregion

        #region Subject Identification
        #region SubjectIdentification_InsertUpdate
        public DataTable SubjectIdentification_InsertUpdate(SubjectIdentificationBase identificationBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", identificationBase.ID),
                                            new MyParameter("@LCTID", identificationBase.LCTID),
                                            new MyParameter("@BusinessName", identificationBase.BusinessName),
                                            new MyParameter("@IDDefault1", identificationBase.IDDefault1),
                                            new MyParameter("@IDDefault2", identificationBase.IDDefault2),
                                            new MyParameter("@IDDefault3", identificationBase.IDDefault3),
                                            new MyParameter("@IDNumber1", identificationBase.IDNumber1),
                                            new MyParameter("@IDNumber2", identificationBase.IDNumber2),
                                            new MyParameter("@IDNumber3", identificationBase.IDNumber3),
                                            new MyParameter("@IDType1", identificationBase.IDType1),
                                            new MyParameter("@IDType2", identificationBase.IDType2),
                                            new MyParameter("@IDType3", identificationBase.IDType3),
                                            new MyParameter("@SubjectID", identificationBase.SubjectID),
                                            new MyParameter("@Occupation", identificationBase.Occupation)
                                         };
                Common.Set_Procedures("SubjectIdentification_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region SubjectIdentification_LoadBySubjectId
        public DataTable SubjectIdentification_LoadBySubjectId(SubjectIdentificationBase identificationBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@SubjectID", identificationBase.SubjectID)
                                         };
                Common.Set_Procedures("SubjectIdentification_LoadBySubjectId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Get_NextLCTIDSequential
        public DataTable Get_NextLCTIDSequential()
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("Get_NextLCTIDSequential");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #endregion

        #region Subject WatchList
        #region SubjectWatch_InsertUpdate
        public DataTable SubjectWatch_InsertUpdate(SubjectWatchListBase subWatchBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@Xml", subWatchBase.Xml),
                                            new MyParameter("@SubjectID", subWatchBase.SubjectID),
                                            new MyParameter("@IsDelete", subWatchBase.IsDelete)
                                         };
                Common.Set_Procedures("SubjectWatch_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region SubjectWatch_LoadBySubjectId
        public DataTable SubjectWatch_LoadBySubjectId(SubjectWatchListBase subWatchBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@SubjectID", subWatchBase.SubjectID)
                                         };
                Common.Set_Procedures("SubjectWatch_LoadBySubjectId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #endregion

        #region Subject Marks
        #region SubjectMark_InsertUpdate
        public DataTable SubjectMark_InsertUpdate(SubjectFeaturesBase featureBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@MarkID", featureBase.MarkID),
                                            new MyParameter("@SubjectID", featureBase.SubjectID),
                                            new MyParameter("@FeatureLocation", featureBase.FeatureLocation),
                                            new MyParameter("@FeatureType", featureBase.FeatureType),
                                            new MyParameter("@Description", featureBase.Description),
                                            new MyParameter("@MediaID", featureBase.MediaID)
                                         };
                Common.Set_Procedures("SubjectMark_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region SubjectMarks_LoadById
        public DataTable SubjectMarks_LoadById(SubjectFeaturesBase featureBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@MarkID", featureBase.MarkID)
                                         };
                Common.Set_Procedures("SubjectMarks_LoadById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region SubjectMarks_LoadBySubjectId
        public DataTable SubjectMarks_LoadBySubjectId(SubjectFeaturesBase featureBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@SubjectID", featureBase.SubjectID)
                                         };
                Common.Set_Procedures("SubjectMarks_LoadBySubjectId");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region SubjectMarks_DeleteById
        public DataTable SubjectMarks_DeleteById(SubjectFeaturesBase featureBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@MarkID", featureBase.MarkID)
                                         };
                Common.Set_Procedures("SubjectMarks_DeleteById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #endregion

        #region  Watch
        #region WatchName_InsertUpdate
        public DataTable WatchName_InsertUpdate(WatchBase watchBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@WatchID", watchBase.WatchID),
                                            new MyParameter("@WatchName", watchBase.WatchName),
                                         };
                Common.Set_Procedures("WatchName_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region WatchName_LoadById
        public DataTable WatchName_LoadById(WatchBase watchBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@WatchID", watchBase.WatchID)
                                         };
                Common.Set_Procedures("WatchName_LoadById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region WatchList_LoadAll
        public DataTable WatchList_LoadAll()
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("WatchList_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region WatchName_DeleteById
        public DataTable WatchName_DeleteById(WatchBase watchBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@WatchID", watchBase.WatchID)
                                         };
                Common.Set_Procedures("WatchName_DeleteById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #endregion

        #region Codes_LoadAll
        public DataTable Codes_LoadAll()
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("Codes_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region IncidentTypeDescription_LoadByEventName
        public DataTable IncidentTypeDescription_LoadByEventName(SubjectBase subjectBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@Event", subjectBase.NatureOfIncident),
                                            };
                Common.Set_Procedures("IncidentTypeDescription_LoadByEventName");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region IncidentNatureOfEvent_LoadAll
        public DataTable IncidentNatureOfEvent_LoadAll()
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("IncidentNatureOfEvent_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region SearchSubject
        public DataTable SearchSubject(SubjectBase subjectBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@FirstName", subjectBase.FirstName),
                                            new MyParameter("@LastName", subjectBase.LastName),
                                            new MyParameter("@Sex", subjectBase.Sex),
                                            new MyParameter("@Race", subjectBase.Race),
                                            new MyParameter("@DateOfBirth", subjectBase.DateOfBirth),
                                            new MyParameter("@IncidentDate", subjectBase.IncidentDate),
                                            new MyParameter("@NatureOfIncident", subjectBase.NatureOfIncident),
                                            new MyParameter("@ShortDescription", subjectBase.ShortDescription),
                                            new MyParameter("@OverallStatus", subjectBase.OverallStatus)
                                         };
                Common.Set_Procedures("SearchSubject");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region CombineSubject
        public DataTable CombineSubject(SubjectBase subjectBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@CurrentSubjectID", subjectBase.SubjectID),
                                            new MyParameter("@CombineSubjectID", subjectBase.CIDPersonID)
                                         };
                Common.Set_Procedures("CombineSubject");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Method Incidents_InsertUpdate
        public DataTable Incidents_InsertUpdate(SubjectIncidentsBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@SubjectId", subject.SubjectID),
                                           new MyParameter("@Id", subject.IncidentID),
                                           new MyParameter("@IncidentNumber", subject.IncidentNumber),
                                           new MyParameter("@NatureOfEvent", subject.NatureOfEvent),
                                           new MyParameter("@ShortDescriptor", subject.ShortDescriptor),
                                           new MyParameter("@ActiveStatus", subject.ActiveStatus),
                                           new MyParameter("@Status", subject.Status),
                                           new MyParameter("@IncidentDate", subject.IncidentDate),
                                           new MyParameter("@Description", subject.Description),
                                           new MyParameter("@Location", subject.Location),
                                           new MyParameter("@IncidentRole", subject.IncidentRole),
                                           new MyParameter("@OccurrenceNumber", subject.OccurrenceNumber),
                                            new MyParameter("@IncidentTime", subject.IncidentTime),
                                            new MyParameter("@EndDate", subject.EndDate),
                                            new MyParameter("@EndTime", subject.EndTime),
                                           new MyParameter("@RoleName", subject.RoleName),
                                           new MyParameter("@UD26", subject.UD26),
                                            new MyParameter("@UD32", subject.UD32),
                                           new MyParameter("@UD33", subject.UD33),
                                           new MyParameter("@EventID", subject.EventID),
                                           new MyParameter("@CreatedBy", subject.CreatedBy),
                                           new MyParameter("@ReportView", subject.ReportCreatorView),
                                           new MyParameter("@ReportEdit", subject.ReportCreatorEdit),
                                           new MyParameter("@ReportDelete", subject.ReportCreatorDelete)
                                        };
                Common.Set_Procedures("Incidents_IU");
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

        #region Method IncidentReports_IU
        public DataTable IncidentReports_IU(ReportBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={

                                           new MyParameter("@IncidentId", subject.IncidentID),
                                           new MyParameter("@UserId", subject.UserID),
                                           new MyParameter("@ReportDate", subject.ReportDate),
                                           new MyParameter("@Report", subject.Description)


                                        };
                Common.Set_Procedures("IncidentReports_IU");
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

        #region Method Incidents_LoadBySubjectId
        public DataTable Incidents_LoadBySubjectId(SubjectIncidentsBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@UserID", subject.UserID),
                                           new MyParameter("@SubjectId", subject.SubjectID),
                                           new MyParameter("@ReportAccessRole", subject.ReportAccessRole),
                                           new MyParameter("@AllReport", subject.AllReport)
                                        };
                Common.Set_Procedures("Incidents_LoadBySubjectId");
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

        #region Method Incidents_LoadAll
        public DataTable Incidents_LoadAll(SubjectIncidentsBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@UserID", subject.UserID),
                                           new MyParameter("@EventId", subject.EventId),
                                           new MyParameter("@ReportAccessRole", subject.ReportAccessRole),
                                           new MyParameter("@AllReport", subject.AllReport)
                                        };
                Common.Set_Procedures("Incidents_LoadAll");
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

        #region Method Incidents_LoadByIncidentID
        public DataTable Incidents_LoadByIncidentID(SubjectIncidentsBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@IncidentId", subject.IncidentID)
                                           ,new MyParameter("@UserID", subject.UserID)
                                           ,new MyParameter("@ReportAccessRole", subject.ReportAccessRole)
                                        };
                Common.Set_Procedures("Incidents_LoadByIncidentID");
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
        #region Method Reports_LoadByIncidentID
        public DataTable Reports_LoadByIncidentID(ReportBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@IncidentId", subject.IncidentID)
                                        };
                Common.Set_Procedures("Reports_LoadByIncidentID");
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
        #region Method Disputes_LoadByIncidentID
        public DataTable Disputes_LoadByIncidentID(DisputeBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@IncidentId", subject.IncidentID)
                                        };
                Common.Set_Procedures("Disputes_LoadByIncidentID");
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
        #region Method Banned_LoadByIncidentID
        public DataTable Banned_LoadByIncidentID(BannedBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@IncidentId", subject.IncidentID)
                                        };
                Common.Set_Procedures("Banned_LoadByIncidentID");
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

        public DataTable Banned_LoadByID(int BannedId)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@BannedId", @BannedId)
                                        };
                Common.Set_Procedures("Banned_LoadByID");
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

        public DataTable Banned_DeleteById(int BannedID)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@BannedID", BannedID)
                                         };
                Common.Set_Procedures("SubjectBan_DeleteById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }

        #endregion
        #region Method SubjectBanType_LoadByIncidentID
        public DataTable SubjectBanType_LoadByIncidentID(BanTypeBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@IncidentId", subject.IncidentID),
                                            new MyParameter("@SubjecID", subject.SubjectID)
                                        };
                Common.Set_Procedures("SubjectBanType_LoadByIncidentID");
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
        #region Method LCTForeignExchange_LoadById
        public DataTable LCTForeignExchange_LoadById(LCTForeignExchangeBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@IncidentID", subject.IncidentID),
                                            new MyParameter("@SubjectID", subject.SubjectID)
                                        };
                Common.Set_Procedures("LCTForeignExchange_LoadById");
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
        #region Method LCTCashOuts_LoadById
        public DataTable LCTCashOuts_LoadById(LCTCashOutsBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@IncidentID", subject.IncidentID),
                                            new MyParameter("@SubjectID", subject.SubjectID)
                                        };
                Common.Set_Procedures("LCTCashOuts_LoadById");
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
        #region Method LCTCashCall_LoadById
        public DataTable LCTCashCall_LoadById(LCTCashCallBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@IncidentID", subject.IncidentID),
                                            new MyParameter("@SubjectID", subject.SubjectID)
                                        };
                Common.Set_Procedures("LCTCashCall_LoadById");
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
        #region Method Vehicles_LoadById
        public DataTable Vehicles_LoadById(VehiclesBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@IncidentID", subject.IncidentID),
                                            new MyParameter("@SubjectID", subject.SubjectID)
                                        };
                Common.Set_Procedures("Vehicles_LoadById");
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
        #region Method SubjectServicesOffered_LoadbyIncidentSubjectID
        public DataTable SubjectServicesOffered_LoadbyIncidentSubjectID(ServiceBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@IncidentID", subject.IncidentID),
                                            new MyParameter("@SubjectID", subject.SubjectID)
                                        };
                Common.Set_Procedures("SubjectServicesOffered_LoadbyIncidentSubjectID");
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
        #region Method SubjectServices_LoadbyIncidentSubjectID
        public DataTable SubjectServices_LoadbyIncidentSubjectID(ServiceBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@IncidentID", subject.IncidentID),
                                            new MyParameter("@SubjectID", subject.SubjectID)
                                        };
                Common.Set_Procedures("SubjectServices_LoadbyIncidentSubjectID");
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
        #region Method LCTPitTransactions_LoadById
        public DataTable LCTPitTransactions_LoadById(LCTPitTransactionsBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@IncidentID", subject.IncidentID),
                                            new MyParameter("@SubjectID", subject.SubjectID)
                                        };
                Common.Set_Procedures("LCTPitTransactions_LoadById");
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
        #region Method Incidents_Delete
        public DataTable Incidents_Delete(SubjectIncidentsBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", subject.IncidentID)
                                        };
                Common.Set_Procedures("Incidents_Delete");
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
        #region Method LCTPitTransactions_Delete
        public DataTable LCTPitTransactions_Delete(LCTPitTransactionsBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", subject.ID)
                                        };
                Common.Set_Procedures("LCTPitTransactions_Delete");
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
        #region Method LCTForeignExchange_Delete
        public DataTable LCTForeignExchange_Delete(LCTForeignExchangeBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", subject.ID)
                                        };
                Common.Set_Procedures("LCTForeignExchange_Delete");
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
        #region Method LCTCashOuts_Delete
        public DataTable LCTCashOuts_Delete(LCTCashOutsBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", subject.ID)
                                        };
                Common.Set_Procedures("LCTCashOuts_Delete");
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

        #region Method SubjectInvolved_Delete
        public DataTable SubjectInvolved_Delete(SubjectInvolvedBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", subject.SubjectIncidentID),
                                           new MyParameter("@ReportID", subject.IncidentID),
                                        };
                Common.Set_Procedures("SubjectInvolved_Delete");
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
        #region Method LCTCashCall_Delete
        public DataTable LCTCashCall_Delete(LCTCashCallBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", subject.ID)
                                        };
                Common.Set_Procedures("LCTCashCall_Delete");
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
        #region Method Vehicles_Delete
        public DataTable Vehicles_Delete(VehiclesBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", subject.VehicleID)
                                        };
                Common.Set_Procedures("Vehicles_Delete");
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
        #region Method BuyIn_InsertUpdate
        public DataTable BuyIn_InsertUpdate(LCTPitTransactionsBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectId", subject.SubjectID),
                                           new MyParameter("@IncidentID", subject.IncidentID),
                                           new MyParameter("@BuyInGameID", subject.BuyInGameID),
                                           new MyParameter("@BuyInTypePitID", subject.BuyInTypePitID),
                                           new MyParameter("@ID", subject.ID),
                                           new MyParameter("@BuyInTime", subject.BuyInTime.ToString()),
                                           new MyParameter("@BuyInType", subject.BuyInType),
                                           new MyParameter("@Amount", subject.Amount),
                                           new MyParameter("@Game", subject.Game),
                                           new MyParameter("@Pit", subject.Pit)

                                        };
                Common.Set_Procedures("LCTPitTransactions_IU");
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
        #region Method LCTCashCall_IU
        public DataTable LCTCashCall_IU(LCTCashCallBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectId", subject.SubjectID),
                                           new MyParameter("@IncidentID", subject.IncidentID),
                                           new MyParameter("@ID", subject.ID),
                                           new MyParameter("@Cashier", subject.Cashier),
                                           new MyParameter("@CashCallTime", subject.CashCallTime),
                                           new MyParameter("@Amount", subject.Amount)


                                        };
                Common.Set_Procedures("LCTCashCall_IU");
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
        #region Method SubjectLinked_IU
        public DataTable SubjectLinked_IU(IncidentLinkedBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectId", subject.SubjectID),
                                           new MyParameter("@IncidentID", subject.IncidentID),
                                           new MyParameter("@ID", subject.ID),
                                           new MyParameter("@Description", subject.Description),
                                           new MyParameter("@FilePath ", subject.FilePath)



                                        };
                Common.Set_Procedures("SubjectLinked_IU");
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
        #region Method LCTForeignExchange_IU
        public DataTable LCTForeignExchange_IU(LCTForeignExchangeBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectId", subject.SubjectID),
                                           new MyParameter("@IncidentID", subject.IncidentID),
                                           new MyParameter("@ID", subject.ID),
                                           new MyParameter("@ForeignAmount", subject.ForeignAmount),
                                           new MyParameter("@ForeignCountry", subject.ForeignCountry),
                                           new MyParameter("@Amount", subject.Amount),
                                           new MyParameter("@Rate", subject.Rate)


                                        };
                Common.Set_Procedures("LCTForeignExchange_IU");
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
        #region Method Vehicles_IU
        public DataTable Vehicles_IU(VehiclesBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectId", subject.SubjectID),
                                           new MyParameter("@IncidentID", subject.IncidentID),
                                           new MyParameter("@VehicleID ", subject.VehicleID),
                                           new MyParameter("@VehicleVIN", subject.VehicleVIN),
                                           new MyParameter("@VehicleColor", subject.VehicleColor),
                                           new MyParameter("@VehicleYear", subject.VehicleYear),
                                           new MyParameter("@VehicleModel", subject.VehicleModel),
                                            new MyParameter("@VehicleMake ", subject.VehicleMake),
                                           new MyParameter("@IssuedIn", subject.VehicleYear),
                                           new MyParameter("@LicensePlate", subject.LicensePlate)


                                        };
                Common.Set_Procedures("Vehicles_IU");
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
        #region Method LCTCashOuts_IU
        public DataTable LCTCashOuts_IU(LCTCashOutsBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectId", subject.SubjectID),
                                           new MyParameter("@IncidentID", subject.IncidentID),
                                           new MyParameter("@ID", subject.ID),
                                           new MyParameter("@TypeOfWin", subject.TypeOfWin),
                                           new MyParameter("@PaymentType ", subject.PaymentType),
                                           new MyParameter("@ChequeNo", subject.ChequeNo),
                                           new MyParameter("@CashOutTime", subject.CashOutTime),
                                            new MyParameter("@TableNumber", subject.TableNumber),
                                             new MyParameter("@Amount", subject.Amount)


                                        };
                Common.Set_Procedures("LCTCashOuts_IU");
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

        #region Method Subject_IncidentServices_IU
        public DataTable Subject_IncidentServices_IU(ServiceBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectId", subject.SubjectID),
                                           new MyParameter("@IncidentID", subject.IncidentID),

                                           new MyParameter("@CallTime", subject.CallTime),
                                           new MyParameter("@ArriveTime ", subject.ArriveTime),
                                           new MyParameter("@ServiceBy", subject.ServiceBy),
                                           new MyParameter("@ServiceFor", subject.ServiceFor),
                                            new MyParameter("@Description", subject.Description)



                                        };
                Common.Set_Procedures("Subject_IncidentServices_IU");
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

        #region Method Disputes_IU
        public DataTable Disputes_IU(DisputeBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={

                                           new MyParameter("@IncidentID", subject.IncidentID),

                                           new MyParameter("@DisputeType", subject.DisputeType),
                                           new MyParameter("@Resolution", subject.Resolution),
                                           new MyParameter("@Amount", subject.Amount),
                                           new MyParameter("@Description ", subject.Description),
                                            new MyParameter("@RecoveredMoney", subject.RecoveredMoney)



                                        };
                Common.Set_Procedures("Disputes_IU");
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

        #region Method SubjectServicesOffered_I
        public DataTable SubjectServicesOffered_I(ServiceBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectID", subject.SubjectID),
                                           new MyParameter("@IncidentId", subject.IncidentID),
                                           new MyParameter("@ServiceName", subject.ServiceName),
                                           new MyParameter("@Offered ", subject.Offered),
                                           new MyParameter("@Declined", subject.DeclinedAvailable)
                                        };
                Common.Set_Procedures("SubjectServicesOffered_I");
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
        #region SubjectIncidentLinked_DeleteById
        public DataTable SubjectIncidentLinked_DeleteById(IncidentLinkedBase linkBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", linkBase.ID)
                                         };
                Common.Set_Procedures("SubjectLinked_DeleteById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #region Method GetAuthorName
        public DataTable GetAuthorName(int UserId, int ReportId)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@UserId",UserId)
                                            ,new MyParameter("@ReportId",ReportId)
                                        };
                Common.Set_Procedures("GetAuthorName");
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

        #region Method SubjectInvolved_Insert
        public DataTable SubjectInvolved_Insert(SubjectInvolvedBase involved)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@CreatedBy", involved.CreatedBy),
                                            new MyParameter("@ID", involved.SubjectIncidentID),
                                            new MyParameter("@InvolvedID", involved.InvolvedID),
                                            new MyParameter("@SubjectID", involved.SubjectID),
                                           new MyParameter("@IncidentID", involved.IncidentID),
                                           new MyParameter("@FirstName", involved.FirstName),
                                           new MyParameter("@LastName", involved.LastName),
                                           new MyParameter("@Race", involved.Race),
                                           new MyParameter("@Sex", involved.Sex),
                                           new MyParameter("@RoleName", involved.RoleName),
                                            new MyParameter("@MediaID", involved.MediaID)
                                        };
                Common.Set_Procedures("SubjectInvolved_I");
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
        #region Method IncidentBanType_I
        public DataTable IncidentBanType_I(BanTypeBase bantype)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectID", bantype.SubjectID),
                                           new MyParameter("@IncidentID", bantype.IncidentID),
                                           new MyParameter("@BanTypeTable", bantype.BanTypeTable)

                                        };
                Common.Set_Procedures("IncidentBanType_I");
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

        #region Method SubjectInvolve_I
        public DataTable SubjectInvolve_I(SubjectInvolvedBase bantype)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectID", bantype.SubjectID),
                                           new MyParameter("@IncidentID", bantype.IncidentID),
                                           new MyParameter("@InvolvedID", bantype.InvolvedID),
                                            new MyParameter("@MediaID ", 0),
                                             new MyParameter("@InvolvedRole", null),
                                            new MyParameter("@IsEmployee", bantype.IsEmployee),
                                            new MyParameter("@CreatedBy", bantype.CreatedBy)

                                        };
                Common.Set_Procedures("SubjectInvolve_I");
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
        #region Method IncidentBanned_IU
        public DataTable IncidentBanned_IU(BannedBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                    new MyParameter("@BannedID", subject.BannedID),
                                           new MyParameter("@IncidentID", subject.IncidentID),
                                           new MyParameter("@StartDate", subject.StartDate),
                                           new MyParameter("@EndDate", subject.EndDate),
                                           new MyParameter("@EntryDate", subject.Currentdate),
                                           new MyParameter("@AuthorizedBy ", subject.AuthorizedBy),
                                           new MyParameter("@Description", subject.Description),
                                            new MyParameter("@BanYears", subject.year),
                                            new MyParameter("@BanMonths", subject.month),
                                            new MyParameter("@BanDays", subject.Day),
                                            new MyParameter("@BanTypeId", subject.BanTypeId)
                                        };
                Common.Set_Procedures("IncidentBanned_IU");
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

        #region Method SubjectInvolved_LoadAll
        public DataTable SubjectInvolved_LoadAll(SubjectInvolvedBase involved)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@SubjectID", involved.SubjectID),
                                            new MyParameter("@IncidentID", involved.IncidentID)
                                        };
                Common.Set_Procedures("SubjectInvolved_LoadAll");
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

        #region Services_LoadAll
        public DataTable Services_LoadAll()
        {
            dtContainer = new DataTable();
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
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #region ForeignRates_LoadAll
        public DataTable ForeignRates_LoadAll()
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("ForeignRates_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Method Codes_LoadByPart
        public DataTable Codes_LoadByPart(SubjectIncidentsBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Part", subject.Part)
                                        };
                Common.Set_Procedures("Codes_LoadByPart");
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

        #region IncidentType_LoadDistinct
        public DataTable IncidentType_LoadDistinct()
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("IncidentType_LoadDistinct");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Method IncidentType_LoadByNatureOfEvent
        public DataTable IncidentType_LoadByNatureOfEvent(SubjectIncidentsBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@NatureOfEvent", subject.NatureOfEvent)
                                        };
                Common.Set_Procedures("IncidentType_LoadByNatureOfEvent");
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

        #region Method Subjects_Search
        public DataTable Subjects_Search(SubjectInvolvedBase involve)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@FirstName", involve.FirstName),
                                           new MyParameter("@LastName", involve.LastName),
                                           new MyParameter("@Sex", involve.Sex),
                                           new MyParameter("@Race", involve.Race)
                                        };
                Common.Set_Procedures("Subjects_Search");
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

        public DataTable Subjects_FirstNameSearch(string firstnameprefix)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@FirstName", firstnameprefix)
                                        };
                Common.Set_Procedures("Subjects_FirstNameSearch");
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
        public DataTable Subjects_LastNameSearch(string firstname,string lastnameprefix)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@FirstName", firstname)
                                           ,new MyParameter("@LastName", lastnameprefix)
                                        };
                Common.Set_Procedures("Subjects_LastNameSearch");
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

        #region Method Employee_Search
        public DataTable Employee_Search(SubjectInvolvedBase involve)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={                                            
                                           new MyParameter("@FirstName", involve.FirstName),
                                           new MyParameter("@LastName", involve.LastName),
                                           new MyParameter("@Sex", involve.Sex),
                                           new MyParameter("@Race", involve.Race)
                                        };
                Common.Set_Procedures("Employee_Search");
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


        #region Method Subject_dashboard
        public DataTable Subject_dashboard(SubjectBase model)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {new MyParameter("@UserID", model.CreatedBy),
                                           new MyParameter("@ReportAccessRole", model.RoleID) };
                Common.Set_Procedures("Subject_dashboard");
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

        #region SubjectIDMax_Load
        public DataTable SubjectIDMax_Load()
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                         };
                Common.Set_Procedures("SubjectIDMax_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #region SubjectIncidentsMax_Load
        public DataTable SubjectIncidentsMax_Load()
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                         };
                Common.Set_Procedures("SubjectIncidentsMax_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion

        #region Method LCTIdentification_ByID
        public DataTable LCTIdentification_ByID(LCTIdentificationBase lct)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectID", lct.SubjectID),
                                           new MyParameter("@IncidentID", lct.IncidentID)
                                        };
                Common.Set_Procedures("LCTIdentification_ByID");
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

        #region Method LCTIdentification_AddEdit
        public DataTable LCTIdentification_AddEdit(LCTIdentificationBase lct)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@SubjectID", lct.SubjectID),
                                           new MyParameter("@IncidentID", lct.IncidentID),
                                           new MyParameter("@TransactionDate", lct.TransactionDate),
                                           new MyParameter("@FirstName", lct.FirstName),
                                           new MyParameter("@MiddleName", lct.MiddleName),
                                           new MyParameter("@LastName", lct.LastName),
                                           new MyParameter("@DateOfBirth", lct.DateOfBirth),
                                           new MyParameter("@Occupation", lct.Occupation),
                                           new MyParameter("@BusinessName", lct.BusinessName),
                                           new MyParameter("@TypeOfID", lct.TypeOfID),
                                           new MyParameter("@IDNumber", lct.IDNumber),
                                           new MyParameter("@Apartment", lct.Apartment),
                                           new MyParameter("@Address", lct.Address),
                                           new MyParameter("@City", lct.City),
                                           new MyParameter("@ProvState", lct.ProvState),
                                           new MyParameter("@PostalZip", lct.PostalZip),
                                           new MyParameter("@LCTIDNumber", lct.LCTIDNumber),
                                        };
                Common.Set_Procedures("LCTIdentification_AddEdit");
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

        #region Method LCTAttestation_AddEdit
        public DataTable LCTAttestation_AddEdit(LCTIdentificationBase lct)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@SubjectID", lct.SubjectID),
                                           new MyParameter("@IncidentID", lct.IncidentID),
                                           new MyParameter("@EmployeeName", lct.EmployeeName),
                                           new MyParameter("@EmployeeTitle", lct.EmployeeTitle),
                                           new MyParameter("@EmployeeGPEB", lct.EmployeeGPEB),
                                           new MyParameter("@CashierName", lct.CashierName),
                                           new MyParameter("@CashierTitle", lct.CashierTitle),
                                           new MyParameter("@CashierGPEB", lct.CashierGPEB)
                                        };
                Common.Set_Procedures("LCTAttestation_AddEdit");
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

        #region Method LCTNotes_AddEdit
        public DataTable LCTNotes_AddEdit(LCTIdentificationBase lct)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@SubjectID", lct.SubjectID),
                                           new MyParameter("@IncidentID", lct.IncidentID),
                                           new MyParameter("@Notes", lct.Notes)
                                        };
                Common.Set_Procedures("LCTNotes_AddEdit");
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

        #region Method LCTTotalsSubject_Load
        public DataTable LCTTotalsSubject_Load(LCTIdentificationBase lct)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectID", lct.SubjectID),
                                           new MyParameter("@IncidentID", lct.IncidentID)
                                        };
                Common.Set_Procedures("LCTTotalsSubject_Load");
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

        #region Method LCTSubjectTotals_Add
        public DataTable LCTSubjectTotals_Add(LCTIdentificationBase lct)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@SubjectID", lct.SubjectID),
                                           new MyParameter("@IncidentID", lct.IncidentID),
                                           new MyParameter("@TotalPit", lct.TotalPit),
                                           new MyParameter("@TotalExchange", lct.TotalExchange),
                                           new MyParameter("@TotalCashOut", lct.TotalCashOut),
                                           new MyParameter("@BuyInMarker", lct.BuyInMarker),
                                           new MyParameter("@CashOutMarker", lct.CashOutMarker)
                                        };
                Common.Set_Procedures("LCTSubjectTotals_Add");
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

        #region Method LCTTotals_Load
        public DataSet LCTTotals_Load(LCTIdentificationBase lct)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@SubjectID", lct.SubjectID),
                                           new MyParameter("@StartDate", lct.StartDate),
                                           new MyParameter("@EndDate", lct.EndDate)
                                        };
                Common.Set_Procedures("LCTTotals_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsContainer;
        }
        #endregion

        #region Method SubReportsAccessPermission_AddEdit
        public DataTable SubReportsAccessPermission_AddEdit(SubjectIncidentsBase subjectIncidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", subjectIncidentBase.RepPerID),
                                            new MyParameter("@SubjectID", subjectIncidentBase.SubjectID),
                                            new MyParameter("@ReportID", subjectIncidentBase.IncidentID),
                                            new MyParameter("@ReportAccessBy", subjectIncidentBase.ReportAccessBy),
                                            new MyParameter("@ReportView", subjectIncidentBase.ReportView),
                                            new MyParameter("@ReportEdit", subjectIncidentBase.ReportEdit),
                                            new MyParameter("@ReportDelete", subjectIncidentBase.ReportDelete),
                                            new MyParameter("@CreatedBy", subjectIncidentBase.CreatedBy)
                                        };
                Common.Set_Procedures("SubjectAccessPermission_AddEdit");
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

        #region Method UsersSubjectReportsAccess_LoadAll
        public DataTable UsersSubjectReportsAccess_LoadAll(SubjectIncidentsBase subjectIncidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                        new MyParameter("@UserID", subjectIncidentBase.UserID),
                                        new MyParameter("@ReportID", subjectIncidentBase.IncidentID)
                                        };
                Common.Set_Procedures("UsersSubjectReportsAccess_LoadAll");
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

        #region Method SubjectReportPermissionCheck_User
        public DataTable SubjectReportPermissionCheck_User(SubjectIncidentsBase subjectIncidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@SubjectID", subjectIncidentBase.SubjectID),
                                            new MyParameter("@ReportID", subjectIncidentBase.IncidentID),
                                            new MyParameter("@ReportAccessBy", subjectIncidentBase.ReportAccessBy),
                                            new MyParameter("@ReportAccessRole", subjectIncidentBase.ReportAccessRole)
                                        };
                Common.Set_Procedures("SubjectReportPermissionCheck_User");
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

        #region Method ForeignExchangeRates_LoadByID
        public DataTable ForeignExchangeRates_LoadByID(CIMS.BaseLayer.Setting.ForeignExchangeRatesBase exchangeBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@Id", exchangeBase.ID)
                                        };
                Common.Set_Procedures("ForeignExchangeRates_LoadByID");
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

        #region Method Subjects_AdvancedSearch
        public DataTable Subjects_AdvancedSearch(SubjectBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                //int? FromAge = null;
                //int? ToAge = null;
                //if (!string.IsNullOrEmpty(subject.AgeRange.Trim()))
                //{
                //    int[] agerange = subject.AgeRange.Trim().Split('-').Select<string, int>(int.Parse).ToArray();
                //    FromAge = agerange[0];
                //    ToAge = agerange[1];
                //}

                MyParameter[] myParams ={
                                            new MyParameter("@VIP", subject.VIP),
                                            new MyParameter("@FirstName", subject.FirstName),
                                            new MyParameter("@LastName", subject.LastName),
                                            new MyParameter("@MiddleName", subject.MiddleName),
                                            new MyParameter("@Sex", subject.Sex),
                                            new MyParameter("@Race", subject.Race),
                                            new MyParameter("@Eyes", subject.Eyes),
                                            new MyParameter("@Build", subject.Build),
                                            new MyParameter("@Complexion", subject.Complexion),
                                            new MyParameter("@DateOfBirth", subject.DateOfBirth),
                                            new MyParameter("@HairLength", subject.HairLength),
                                            new MyParameter("@HairColor", subject.HairColor),
                                            new MyParameter("@FacialHair", subject.FacialHair),
                                            new MyParameter("@AgeRange", subject.AgeRange),
                                            new MyParameter("@SubjectNumber", subject.SubjectNumber),
                                            new MyParameter("@SubjectStatus", subject.SubjectStatus)
                                            //, new MyParameter("@FromAge", FromAge)
                                            //, new MyParameter("@ToAge", ToAge)
                                        };
                Common.Set_Procedures("Subjects_AdvancedSearch");
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
        public DataTable AdvancedSearchSubjectAddress(string AddressType, string Apartment, string Address, string country, string city, string state, string zipCode)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@AddressType", AddressType),
                                            new MyParameter("@Apartment", Apartment),
                                            new MyParameter("@Address", Address),
                                            new MyParameter("@country", country),
                                            new MyParameter("@city", city),
                                            new MyParameter("@state", state),
                                            new MyParameter("@zipCode", zipCode),
                                            new MyParameter("@type", "A"),
                                         };
                Common.Set_Procedures("AdvancedSearchSubject");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }

        //Ankur New 1
        public DataTable AdvancedSearchSubjectFeatures(string FeatureType, string FeatureLocation,string type,string watchid)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@FeatureType", FeatureType),
                                            new MyParameter("@FeatureLocation", FeatureLocation),
                                             new MyParameter("@type", type),
                                             new MyParameter("@watchid", watchid)
                                         };
                Common.Set_Procedures("AdvancedSearchSubjectFeature");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }

        //AnkurNew
        public DataTable AdvancedSearchSubjectAliases(string NameType, string FirstName, string MiddleName, string LastName)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@NameType", NameType),
                                            new MyParameter("@FirstName", FirstName),
                                            new MyParameter("@MiddleName", MiddleName),
                                            new MyParameter("@LastName", LastName),
                                            new MyParameter("@type", "A1"),
                                         };
                Common.Set_Procedures("AdvancedSearchSubject");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }

       

        #region Method SubjectLCT_CheckAddress
        public DataSet SubjectLCT_CheckAddress(SubjectBase subject)
        {
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectID", subject.SubjectID),
                                        };
                Common.Set_Procedures("SubjectLCT_CheckAddress");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dsContainer = Common.Execute_Procedures_Select();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsContainer;
        }
        #endregion


        #region Method UsersSubReportsAccess_Bind
        public DataTable UsersSubReportsAccess_Bind(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@UserID", incidentBase.UserID),
                                            new MyParameter("@ReportID", incidentBase.IncidentID)
                                        };
                Common.Set_Procedures("UsersSubReportsAccess_Bind");
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

        #region Method AddUsersSubReportsAccess
        public DataTable AddUsersSubReportsAccess(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectID", incidentBase.SubjectID),
                                            new MyParameter("@ReportID", incidentBase.IncidentID),
                                            new MyParameter("@ReportAccessBy", incidentBase.ReportAccessBy),
                                             new MyParameter("@CreatedBy", incidentBase.CreatedBy)
                                        };
                Common.Set_Procedures("AddUsersSubReportsAccess");
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

        public bool AddAll_UsersAndRoles_SubReportsAccess(SubjectIncidentsBase incidentBase)
        {
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectID", incidentBase.SubjectID),
                                            new MyParameter("@ReportID", incidentBase.IncidentID),
                                             new MyParameter("@CreatedBy", incidentBase.CreatedBy)
                                        };
                Common.Set_Procedures("AddAll_UsersAndRoles_SubReportsAccess");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                return Common.Execute_Procedure();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Method RemoveUsersSubReportsAccess
        public DataTable RemoveUsersSubReportsAccess(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ID", incidentBase.ReportAccessID)
                                        };
                Common.Set_Procedures("RemoveUsersSubReportsAccess");
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

        #region Method SubReportsAccessUsers_Bind
        public DataTable SubReportsAccessUsers_Bind(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@UserID", incidentBase.UserID),
                                            new MyParameter("@ReportID", incidentBase.IncidentID)
                                        };
                Common.Set_Procedures("SubReportsAccessUsers_Bind");
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

        #region Method SubReportAccessPermission
        public DataTable SubReportAccessPermission(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", incidentBase.ReportAccessID),
                                            new MyParameter("@ReportID", incidentBase.IncidentID),
                                            new MyParameter("@Type", incidentBase.ReportAccessType),
                                            new MyParameter("@Permission", incidentBase.ReportAccessPermission),
                                        };
                Common.Set_Procedures("SubReportAccessPermission");
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

        #region Method SubReportsAccessPermission_ByUser
        public DataTable SubReportsAccessPermission_ByUser(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", incidentBase.ReportAccessID),
                                           new MyParameter("@ReportID", incidentBase.IncidentID)
                                        };
                Common.Set_Procedures("SubReportsAccessPermission_ByUser");
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

        #region Method UsersSubReportsAccessRole
        public DataTable UsersSubReportsAccessRole(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ReportID", incidentBase.IncidentID)
                                        };
                Common.Set_Procedures("UsersSubReportsAccessRole");
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

        #region Method AddRolesSubReportsAccess
        public DataTable AddRolesSubReportsAccess(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectID", incidentBase.SubjectID),
                                            new MyParameter("@ReportID", incidentBase.IncidentID),
                                            new MyParameter("@ReportAccessRole", incidentBase.ReportAccessRole),
                                             new MyParameter("@CreatedBy", incidentBase.CreatedBy)
                                        };
                Common.Set_Procedures("AddRolesSubReportsAccess");
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

        #region Method RemoveRolesSubReportsAccess
        public DataTable RemoveRolesSubReportsAccess(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ID", incidentBase.ReportAccessID)
                                        };
                Common.Set_Procedures("RemoveRolesSubReportsAccess");
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

        #region Method SubReportsAccessRoles_Bind
        public DataTable SubReportsAccessRoles_Bind(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@UserID", incidentBase.UserID),
                                           new MyParameter("@ReportID", incidentBase.IncidentID)
                                        };
                Common.Set_Procedures("SubReportsAccessRoles_Bind");
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

        #region Method SubReportAccessPermissionByRole
        public DataTable SubReportAccessPermissionByRole(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", incidentBase.ReportAccessID),
                                            new MyParameter("@ReportID", incidentBase.IncidentID),
                                            new MyParameter("@Type", incidentBase.ReportAccessType),
                                            new MyParameter("@Permission", incidentBase.ReportAccessPermission),
                                        };
                Common.Set_Procedures("SubReportAccessPermissionByRole");
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

        #region Method SubReportsAccessPermission_ByRole
        public DataTable SubReportsAccessPermission_ByRole(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", incidentBase.ReportAccessID),
                                           new MyParameter("@ReportID", incidentBase.IncidentID)
                                        };
                Common.Set_Procedures("SubReportsAccessPermission_ByRole");
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

        #region Method SubReportProofread_add
        public DataTable SubReportProofread_add(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ProofreadID", incidentBase.ProofreadID),
                                           new MyParameter("@SubjectID", incidentBase.SubjectID),
                                            new MyParameter("@ReportID", incidentBase.IncidentID),
                                            new MyParameter("@ReportProofread", incidentBase.ReportProofread),
                                            new MyParameter("@UserID", incidentBase.UserID),
                                        };
                Common.Set_Procedures("SubReportProofread_add");
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

        #region Method SubReportProofread_Bind
        public DataTable SubReportProofread_Bind(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@SubjectID", incidentBase.SubjectID),
                                            new MyParameter("@ReportID", incidentBase.IncidentID)
                                        };
                Common.Set_Procedures("SubReportProofread_Bind");
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

        #region Method SubReportProofread_Check
        public DataTable SubReportProofread_Check(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@SubjectID", incidentBase.SubjectID),
                                            new MyParameter("@ReportID", incidentBase.IncidentID)
                                        };
                Common.Set_Procedures("SubReportProofread_Check");
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

        #region Method SubReportCreatorPermission
        public DataTable SubReportCreatorPermission(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();

            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ReportID", incidentBase.IncidentID),
                                            new MyParameter("@Type", incidentBase.ReportAccessType),
                                            new MyParameter("@Permission", incidentBase.ReportAccessPermission)
                                        };

                Common.Set_Procedures("SubReportCreatorPermission");
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

        #region Method SubjectIncident_Edit
        public DataTable SubjectIncident_Edit(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", incidentBase.IncidentID)
                                        };
                Common.Set_Procedures("SubjectIncident_Permission");
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

        #region Method Subject permission load by subjectid
        public DataTable SubjectPermission_LoadBySubjectID(int SubjectID)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@SubjectID", SubjectID)
                                        };
                Common.Set_Procedures("SubjectPermission_LoadById");
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

        #region Method UsersSubjectAccess_Bind
        public DataTable UsersSubjectAccess_Bind(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@UserID", incidentBase.UserID),
                                            new MyParameter("@SubjectID", incidentBase.SubjectID)
                                        };
                Common.Set_Procedures("UsersSubjectAccess_Bind");
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

        #region Method AddUsersSubjectAccess
        public DataTable AddUsersSubjectAccess(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectID", incidentBase.SubjectID),
                                            new MyParameter("@ReportAccessBy", incidentBase.ReportAccessBy),
                                             new MyParameter("@CreatedBy", incidentBase.CreatedBy)
                                        };
                Common.Set_Procedures("AddUsersSubjectAccess");
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

        public bool AddAll_UsersAndRoles_SubjectAccess(SubjectIncidentsBase incidentBase)
        {
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectID", incidentBase.SubjectID),
                                             new MyParameter("@CreatedBy", incidentBase.CreatedBy)
                                        };
                Common.Set_Procedures("AddAll_UsersAndRoles_SubjectAccess");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                return Common.Execute_Procedure();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Method RemoveUsersSubjectAccess
        public DataTable RemoveUsersSubjectAccess(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ID", incidentBase.ReportAccessID)
                                        };
                Common.Set_Procedures("RemoveUsersSubjectAccess");
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

        #region Method SubjectAccessUsers_Bind
        public DataTable SubjectAccessUsers_Bind(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@UserID", incidentBase.UserID),
                                            new MyParameter("@SubjectID", incidentBase.SubjectID)
                                        };
                Common.Set_Procedures("SubjectAccessUsers_Bind");
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

        #region Method SubjectAccessPermission
        public DataTable SubjectAccessPermission(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", incidentBase.ReportAccessID),
                                            new MyParameter("@SubjectID", incidentBase.SubjectID),
                                            new MyParameter("@Type", incidentBase.ReportAccessType),
                                            new MyParameter("@Permission", incidentBase.ReportAccessPermission),
                                        };
                Common.Set_Procedures("SubjectAccessPermission");
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

        #region Method SubjectAccessPermission_ByUser
        public DataTable SubjectAccessPermission_ByUser(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", incidentBase.ReportAccessID),
                                           new MyParameter("@SubjectID", incidentBase.SubjectID)
                                        };
                Common.Set_Procedures("SubjectAccessPermission_ByUser");
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

        #region Method UsersSubjectAccessRole
        public DataTable UsersSubjectAccessRole(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectID", incidentBase.SubjectID)
                                        };
                Common.Set_Procedures("UsersSubjectAccessRole");
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

        #region Method AddRolesSubjectAccess
        public DataTable AddRolesSubjectAccess(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@SubjectID", incidentBase.SubjectID),
                                            new MyParameter("@ReportAccessRole", incidentBase.ReportAccessRole),
                                             new MyParameter("@CreatedBy", incidentBase.CreatedBy)
                                        };
                Common.Set_Procedures("AddRolesSubjectAccess");
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

        #region Method RemoveRolesSubjectAccess
        public DataTable RemoveRolesSubjectAccess(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ID", incidentBase.ReportAccessID)
                                        };
                Common.Set_Procedures("RemoveRolesSubjectAccess");
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

        #region Method SubjectAccessRoles_Bind
        public DataTable SubjectAccessRoles_Bind(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@UserID", incidentBase.UserID),
                                           new MyParameter("@SubjectID", incidentBase.SubjectID)
                                        };
                Common.Set_Procedures("SubjectAccessRoles_Bind");
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

        #region Method SubjectAccessPermissionByRole
        public DataTable SubjectAccessPermissionByRole(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", incidentBase.ReportAccessID),
                                            new MyParameter("@SubjectID", incidentBase.SubjectID),
                                            new MyParameter("@Type", incidentBase.ReportAccessType),
                                            new MyParameter("@Permission", incidentBase.ReportAccessPermission),
                                        };
                Common.Set_Procedures("SubjectAccessPermissionByRole");
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

        #region Method SubjectAccessPermission_ByRole
        public DataTable SubjectAccessPermission_ByRole(SubjectIncidentsBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", incidentBase.ReportAccessID),
                                           new MyParameter("@SubjectID", incidentBase.SubjectID)
                                        };
                Common.Set_Procedures("SubjectAccessPermission_ByRole");
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

        #region Method Event_SubjectReportLink
        public DataTable SubjectReportEventsLink_Delete(int SubjectID, int IncidentID)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = { new MyParameter("@SubjectID", SubjectID)
                        , new MyParameter("@IncidentID", IncidentID) };
                Common.Set_Procedures("SubjectReportEventsLink_Delete");
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
