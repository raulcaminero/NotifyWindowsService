using System.ServiceProcess;

namespace NotifyAuthenticationService
{
    internal static class Program
    {
        private static void Main()
        {
            var servicesToRun = new ServiceBase[]
            {
                new NotifyAuthenticationServices()
            };

            ServiceBase.Run(servicesToRun);
        }
    }
}
