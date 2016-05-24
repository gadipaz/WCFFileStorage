using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            FileServiceClient myService = new FileServiceClient();
            MessageBox.Show(myService.GetData(123), "My Service");
            myService.Close();
        }
    }
}
