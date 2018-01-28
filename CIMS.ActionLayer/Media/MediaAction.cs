using CIMS.BaseLayer;
using CIMS.BaseLayer.Media;
using CIMS.DataLayer.Media;
using CIMS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.ActionLayer.Media
{
    public class MediaAction
    {
        #region Declaration
        MediaDL mediatDL = new MediaDL();
        ActionResult actionResult = new ActionResult();
        #endregion

        #region PicturesVideos_LoadAll
        public ActionResult PicturesVideos_LoadAll(PictureVideosBase pictureVideosBase)
        {
            try
            {
                actionResult.dtResult = mediatDL.PicturesVideos_LoadAll(pictureVideosBase);
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
        #endregion

        #region PictureVideos_Insert
        public ActionResult PictureVideos_Insert(PictureVideosBase pictureVideoBase)
        {
            try
            {
                actionResult.dtResult = mediatDL.PictureVideos_Insert(pictureVideoBase);
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
        #endregion
        #region PictureVideos_Delete
        public ActionResult PictureVideos_Delete(PictureVideosBase pictureVideoBase)
        {
            try
            {
                actionResult.dtResult = mediatDL.PictureVideos_Delete(pictureVideoBase);
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
        #endregion


        #region Subject Employee Picture_Insert
        public ActionResult SubjectEmployeePicture_Insert(CommonPictureVideosBase pictureVideoBase)
        {
            try
            {
                actionResult.dtResult = mediatDL.SubjectEmployeePicture_Insert(pictureVideoBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    //actionResult.RowsAffected = Convert.ToInt32(actionResult.dtResult.Rows[0]["result"]);
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Subject Employee CropMediaPicture_U
        public ActionResult CropMediaPicture_U(PictureVideosBase pictureVideoBase)
        {
            try
            {
                actionResult.dtResult = mediatDL.CropMediaPicture_U(pictureVideoBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    //actionResult.RowsAffected = Convert.ToInt32(actionResult.dtResult.Rows[0]["result"]);
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region AssignToPicture
        public ActionResult AssignToPicture(PictureVideosBase pictureVideoBase)
        {
            try
            {
                actionResult.dtResult = mediatDL.AssignToPicture(pictureVideoBase);
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
        #endregion

    }
}
