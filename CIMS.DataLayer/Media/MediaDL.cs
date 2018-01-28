using CIMS.BaseLayer.Media;
using CIMS.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.DataLayer.Media
{
    public class MediaDL
    {
        #region Declaration
        // DataSet dsContainer;
        DataTable dtContainer;
        #endregion


        #region PicturesVideos_LoadAll
        public DataTable PicturesVideos_LoadAll(PictureVideosBase pictureVideosBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                new MyParameter("@PictureType",pictureVideosBase.PictureType),
                                new MyParameter("@SubFeatureID",pictureVideosBase.SubFeatureID),
                                new MyParameter("@SubFeaturesid",pictureVideosBase.SubFeaturesid)
                                        };
                Common.Set_Procedures("PicturesVideos_LoadAll");
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

        #region PictureVideos_Insert
        public DataTable PictureVideos_Insert(PictureVideosBase pictureVideoBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                new MyParameter("@Assigned",pictureVideoBase.Assigned),
                                new MyParameter("@MediaExtention",pictureVideoBase.MediaExtention),
                                new MyParameter("@MediaName",pictureVideoBase.MediaName),
                                new MyParameter("@Description",pictureVideoBase.Description),
                                new MyParameter("@PicType",pictureVideoBase.PicType),
                                new MyParameter("@DefaultPic",pictureVideoBase.DefaultPic ),
                             //   new MyParameter("@EncodeArray",pictureVideoBase.EncodeArray),
                                new MyParameter("@EncodeState",pictureVideoBase.EncodeState),
                                new MyParameter("@FilePath",pictureVideoBase.FilePath ),
                                new MyParameter("@EncodeFaceValues",pictureVideoBase.EncodeFaceValues ),
                                new MyParameter("@FaceValue",pictureVideoBase.FaceValue ),
                                new MyParameter("@PictureType",pictureVideoBase.PictureType ),
                                new MyParameter("@SubFeatureID",pictureVideoBase.SubFeatureID ),
                                new MyParameter("@SubFeaturesid",pictureVideoBase.SubFeaturesid )

            };
                Common.Set_Procedures("PictureVideos_Insert");
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

        #region PictureVideos_Delete
        public DataTable PictureVideos_Delete(PictureVideosBase pictureVideoBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                new MyParameter("@MediaID",pictureVideoBase.MediaID)
            };
                Common.Set_Procedures("PictureVideos_Delete");
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

        #region SubjectEmployeePicture_Insert
        public DataTable SubjectEmployeePicture_Insert(CommonPictureVideosBase pictureVideoBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                new MyParameter("@ID",pictureVideoBase.ID),
                                new MyParameter("@IncidentID",pictureVideoBase.IncidentID),
                                new MyParameter("@MediaID",pictureVideoBase.MediaID),
                                new MyParameter("@QuestionID",pictureVideoBase.QuestionID),
                                new MyParameter("@Observation",pictureVideoBase.Observation),
                                new MyParameter("@MediaType",pictureVideoBase.MediaType),
                                new MyParameter("@Type",pictureVideoBase.Type)

            };
                Common.Set_Procedures("SubjectEmployeePicture_Insert");
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

        #region CropMediaPicture_U
        public DataTable CropMediaPicture_U(PictureVideosBase pictureVideoBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                new MyParameter("@MediaID",pictureVideoBase.MediaID),
                                new MyParameter("@FilePath",pictureVideoBase.FilePath)


            };
                Common.Set_Procedures("CropMediaPicture_U");
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

        #region AssignToPicture
        public DataTable AssignToPicture(PictureVideosBase pictureVideoBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                new MyParameter("@MediaID",pictureVideoBase.MediaID),
                                new MyParameter("@SubFeatureID",pictureVideoBase.SubFeatureID),
                                new MyParameter("@PictureType",pictureVideoBase.PictureType)
            };
                Common.Set_Procedures("AssignToPicture");
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

    }
}
