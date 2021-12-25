using log4net.Core;
using System;

namespace Core.Cross_Cutting_Concers.Logging.Log4Net
{
    public partial class LoggerServiceBase
    {
        [Serializable]
        public class SerializableLogEvent
        {
            private LoggingEvent _loggingEvent;

            public SerializableLogEvent(LoggingEvent loggingEvent)
            {
                _loggingEvent = loggingEvent;
            }

            public object Message => _loggingEvent.MessageObject;
        }

    }
}
