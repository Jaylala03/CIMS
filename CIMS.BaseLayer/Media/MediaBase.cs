using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.BaseLayer.Media
{
    public class MediaBase
    {
    }

    public class PictureVideosBase
    {
        #region Declaration
        private string _filePath = string.Empty;
        private string _mediaName = string.Empty;
        private string _mediaExtention = string.Empty;
        private string _mediaDateTime = string.Empty;
        private string _encodeFaceValues = string.Empty;
        private string _encodeArray = string.Empty;
        private string _description = string.Empty;
        private int _picType = 0;
        private int _encodeState = 0;
        private int _mediaID = 0;
        private int _assigned = 0;
        private float _faceValue = 0;
        private bool _defaultPic = false;
        private string _PictureType = string.Empty;
        private int _SubFeatureID = 0;
        private int _SubFeaturesid = 0;
        #endregion

        #region Properties
        public string FilePath { get { return _filePath; } set { _filePath = value; } }
        public string MediaName { get { return _mediaName; } set { _mediaName = value; } }
        public string MediaExtention { get { return _mediaExtention; } set { _mediaExtention = value; } }
        public string MediaDateTime { get { return _mediaDateTime; } set { _mediaDateTime = value; } }
        public string EncodeFaceValues { get { return _encodeFaceValues; } set { _encodeFaceValues = value; } }
        public string EncodeArray { get { return _encodeArray; } set { _encodeArray = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public int PicType { get { return _picType; } set { _picType = value; } }
        public int MediaID { get { return _mediaID; } set { _mediaID = value; } }
        public int EncodeState { get { return _encodeState; } set { _encodeState = value; } }
        public int Assigned { get { return _assigned; } set { _assigned = value; } }
        public float FaceValue { get { return _faceValue; } set { _faceValue = value; } }
        public bool DefaultPic { get { return _defaultPic; } set { _defaultPic = value; } }
        public string PictureType { get { return _PictureType; } set { _PictureType = value; } }
        public int SubFeatureID { get { return _SubFeatureID; } set { _SubFeatureID = value; } }
        public int SubFeaturesid { get { return _SubFeaturesid; } set { _SubFeaturesid = value; } }
        #endregion

    }


    public class CommonPictureVideosBase
    {
        #region Declaration
        private string _mediaType = string.Empty;
        private int _questionID = 0;
        private int _observation = 0;
        private int _mediaID = 0;
        private int _incidentID = 0;
        private int _iD = 0;
        private string _type = string.Empty;
        #endregion

        #region Properties
        public string MediaType { get { return _mediaType; } set { _mediaType = value; } }
        public int QuestionID { get { return _questionID; } set { _questionID = value; } }
        public int Observation { get { return _observation; } set { _observation = value; } }
        public int MediaID { get { return _mediaID; } set { _mediaID = value; } }
        public int IncidentID { get { return _incidentID; } set { _incidentID = value; } }
        public int ID { get { return _iD; } set { _iD = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        #endregion

    }
}
