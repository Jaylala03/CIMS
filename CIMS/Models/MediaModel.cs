using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIMS.Models
{
    public class MediaModel
    {
        public int MediaID { get; set; }
        public int Assigned { get; set; }
        public string MediaExtention { get; set; }
        public string MediaName { get; set; }
        public string Description { get; set; }
        public string MediaDateTime { get; set; }
        public bool DefaultPic { get; set; }
        public string EncodeArray { get; set; }
        public int EncodeState { get; set; }
        public int PicType { get; set; }
        public string EncodeFaceValues { get; set; }
        public float FaceValue { get; set; }
        public string FilePath { get; set; }
        public string PictureType { get; set; }
        public int SubFeatureID { get; set; }
    }    
}