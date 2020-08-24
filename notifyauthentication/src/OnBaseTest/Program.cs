using NotifyAuthenticationHandler.Helpers;
using System;
using System.Configuration;

namespace OnBaseTest
{
    internal class Program
    {
        private const string Source = "AdmBalanceo";
        private const string LogName = "NotifyAssignation";

        private static void Main(string[] args)
        {
            string onBaseQueue = ConfigurationManager.AppSettings["OnBaseQueue"];
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            string workingStoredProcedure = ConfigurationManager.AppSettings["WorkingStoredProcedure"];

            var eventViewerLoggerAdapter = new LoggerAdapter(Source, LogName);
            var onBaseInteractionHandler = new OnBaseInteractionHandler(connectionString)
            {
                LoggerAdapter = new LoggerAdapter(Source, LogName)
            };

            try
            {
                onBaseInteractionHandler.AssignSolicitudeToAnUser(onBaseQueue, workingStoredProcedure);
            }
            catch (Exception e)
            {
                eventViewerLoggerAdapter.LogError($"{e.Message} \n {e.StackTrace}");
            }

            Console.ReadKey();
        }
    }
}
