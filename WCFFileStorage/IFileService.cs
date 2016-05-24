using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFFileStorage
{
    [ServiceContract]
    public interface IFileService
    {
        [OperationContract]
        FileTransferResponse Put(FileTransferRequest fileToPush);        
    }
}
