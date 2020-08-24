using System.ComponentModel;
using System.Diagnostics;

namespace NotifyAuthenticationService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        private EventLogInstaller _eventLogInstaller;
        public ProjectInstaller()
        {
            _eventLogInstaller = new EventLogInstaller
            {
                Source = "AdmBalanceo",
                Log = "NotifyAssignation"
            };
            Installers.Add(_eventLogInstaller);

            InitializeComponent();
        }
    }
}
