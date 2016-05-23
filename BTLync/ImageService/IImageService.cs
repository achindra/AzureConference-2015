using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ImageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IImageService" in both code and config file together.
    [ServiceContract]
    public interface IImageService
    {
        [OperationContract]
        void UploadImage(ImageInfo img);
    }


    [DataContract(IsReference = true)]
    public class ImageInfo
    {
        [DataMember]
        public byte[] ARGBBuffer { get; set; }
    }

}
