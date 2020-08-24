namespace NotifyAuthenticationHandler.Contracts
{
    /// <summary>
    /// Represents the responsibility to log events
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs an error event
        /// </summary>
        /// <param name="message">Represents the message to be log.</param>
        void LogError(string message);

        /// <summary>
        /// Logs a success message event
        /// </summary>
        /// <param name="message">Represents the message to be log.</param>
        void LogEvent(string message);
    }
}
