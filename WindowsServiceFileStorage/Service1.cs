using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WCFFileStorage;

namespace WindowsServiceFileStorage
{
    public partial class Service1 : ServiceBase
    {
        internal static ServiceHost MyServiceHost;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            MyServiceHost?.Close();
            MyServiceHost = new ServiceHost(typeof(Service1));
            MyServiceHost.Open();
        }

        protected override void OnStop()
        {
            if (MyServiceHost == null) return;
            MyServiceHost.Close();
            MyServiceHost = null;
        }
    }
}
