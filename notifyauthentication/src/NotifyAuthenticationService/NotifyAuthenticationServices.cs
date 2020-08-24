using NotifyAuthenticationHandler.Helpers;
using System;
using System.Configuration;
using System.ServiceProcess;

namespace NotifyAuthenticationService
{
    /// <inheritdoc />
    public partial class NotifyAuthenticationServices : ServiceBase
    {
        private const string Source = "AdmBalanceoILPService";
        private const string LogName = "Notify Authentication Service";
        private OnBaseInteractionHandler _onBaseInteractionHandler;
        private System.Timers.Timer timer;

        /// <inheritdoc />
        public NotifyAuthenticationServices()
            => InitializeComponent();

        protected override void OnStart(string[] args)
        {

            var eventViewerLoggerAdapter = new LoggerAdapter(Source, LogName);
            try
            {
                // Set up a timer that triggers every minute.
                timer = new System.Timers.Timer();
                timer.Interval = 60000; // 60 seconds
                timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
                timer.Start();
            }
            catch (Exception e)
            {
                eventViewerLoggerAdapter.LogError($"{e.Message} \n {e.StackTrace}");
            }
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {

            timer.Interval = 500;
            // TODO: Insert monitoring activities here.
            string workingStoredProcedure = ConfigurationManager.AppSettings["WorkingStoredProcedure"];
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            string queue = ConfigurationManager.AppSettings["OnBaseQueue"];

            _onBaseInteractionHandler = new OnBaseInteractionHandler(connectionString)
            {
                LoggerAdapter = new LoggerAdapter(Source, LogName)
            };

            _onBaseInteractionHandler.AssignSolicitudeToAnUser(queue, workingStoredProcedure);
        }

        protected override void OnStop()
        {
            // Method intentionally leave empty.
        }
    }
}


