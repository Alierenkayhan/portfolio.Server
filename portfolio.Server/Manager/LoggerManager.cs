namespace portfolio.Server.Manager
{
    public class LoggerManager
    {
        private readonly Serilog.ILogger _logger;
        private readonly List<string> _logList = new List<string>();

        public LoggerManager(Serilog.ILogger logger)
        {
            var logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "log.json");

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private void LogToMemory(string logMessage) => _logList.Add(logMessage);

        public List<string> GetLogList() => _logList;

        public void LogInformation(string message)
        {
            _logger.Information(message);
            LogToMemory($"[Information] - {message}");
        }

        public void LogWarning(string message)
        {
            _logger.Warning(message);
            LogToMemory($"[Warning] - {message}");
        }

        public void LogError(string message)
        {
            _logger.Error(message);
            LogToMemory($"[Error] - {message}");
        }

        public void LogException(Exception ex, string message)
        {
            _logger.Fatal(ex, message);
            LogToMemory($"[Exception] - {message}. Exception details: {ex}");
        }

        private class DelegatingSink : ILogEventSink
        {
            private readonly Action<LogEvent> _logAction;

            public DelegatingSink(Action<LogEvent> logAction) => _logAction = logAction ?? throw new ArgumentNullException(nameof(logAction));

            public void Emit(LogEvent logEvent) => _logAction(logEvent);

        }
    }
}

