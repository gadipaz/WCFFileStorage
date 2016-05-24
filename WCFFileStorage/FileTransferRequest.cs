

namespace WCFFileStorage
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.ServiceModel;

    [DataContract]
    /// <summary>
    /// Transfer Request Object
    /// </summary>
    public class FileTransferRequest
    {
        [DataMember]
        /// <summary>
        /// Gets or sets File Name
        /// </summary>
        public string FileName { get; set; }

        [DataMember]
        public byte[] Content { get; set; }
    }
}
