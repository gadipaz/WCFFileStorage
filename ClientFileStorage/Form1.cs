using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientFileStorage.WCFFileStorageReference;

namespace ClientFileStorage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            FileTransferResponse response = null;
            OpenFileDialog file = new OpenFileDialog();
            string fileName = "";            
            string filePath = "";
            if (file.ShowDialog() == DialogResult.OK)
            {
                filePath = file.FileName;
                fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
            }
            FileTransferRequest createdFile = new FileTransferRequest()
            {
                FileName = fileName,
                Content = File.ReadAllBytes(filePath)
            };
            response = new FileServiceClient().Put(createdFile);
            if (response.ResponseStatus.Equals("Successful"))
            {
                //TODO: Hurray
            }
            else
            {
                //TODO: Bummer
            }
        }
    }
}
