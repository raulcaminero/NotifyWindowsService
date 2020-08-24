namespace NotifyAuthenticationService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NotifyAuthenticationServices = new System.ServiceProcess.ServiceProcessInstaller();
            this.NotifyAuthenticationServicesInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // NotifyAuthenticationServices
            // 
            this.NotifyAuthenticationServices.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.NotifyAuthenticationServices.Password = null;
            this.NotifyAuthenticationServices.Username = null;
            // 
            // NotifyAuthenticationServicesInstaller
            // 
            this.NotifyAuthenticationServicesInstaller.Description = "Servicio encargaodo de notificar a la aplicación de AdmBalanceo cuando uusario ha" +
    " iniciado sesión en OnBase por primera vez durante el día y necesita que le sea " +
    "asignada una solicitud.";
            this.NotifyAuthenticationServicesInstaller.DisplayName = "NotifyAuthenticationServices";
            this.NotifyAuthenticationServicesInstaller.ServiceName = "NotifyAuthenticationServices";
            this.NotifyAuthenticationServicesInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.NotifyAuthenticationServices,
            this.NotifyAuthenticationServicesInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller NotifyAuthenticationServices;
        private System.ServiceProcess.ServiceInstaller NotifyAuthenticationServicesInstaller;
    }
}