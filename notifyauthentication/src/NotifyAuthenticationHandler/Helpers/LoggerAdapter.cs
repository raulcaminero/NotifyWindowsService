using NotifyAuthenticationHandler.Contracts;

namespace NotifyAuthenticationHandler.Helpers
{
    /// <inheritdoc/>
    public sealed class LoggerAdapter : ILogger
    {
        private readonly string _source;
        private readonly string _logName;

        /// <summary>
        /// Initializes a new instance of <see cref="T:NotifyAuthenticationHandler.Helpers.LoggerAdapter"></see> class for the given source and log name.
        /// </summary>
        /// <param name="source">Event viewer source.</param>
        /// <param name="logName">Event viewer logName.</param>
        public LoggerAdapter(string source, string logName)
        {
            _source = source;
            _logName = logName;
        }

        /// <inheritdoc />
        public void LogError(string message)
        {
#if !DEBUG
            if (!System.Diagnostics.EventLog.SourceExists(_source))
            {
                System.Diagnostics.EventLog.CreateEventSource(_source, _logName);
            }

            System.Diagnostics.EventLog.WriteEntry(_source, message, System.Diagnostics.EventLogEntryType.Error, 234);
#else
            System.Console.Out.WriteLine(message);
#endif
        }

        /// <inheritdoc />
        public void LogEvent(string message)
        {
#if !DEBUG
            if (!System.Diagnostics.EventLog.SourceExists(_source))
            {
                System.Diagnostics.EventLog.CreateEventSource(_source, _logName);
            }

            System.Diagnostics.EventLog.WriteEntry(_source, message, System.Diagnostics.EventLogEntryType.SuccessAudit, 777);
#else
            System.Console.Out.WriteLine(message);
#endif
        }
    }
}
