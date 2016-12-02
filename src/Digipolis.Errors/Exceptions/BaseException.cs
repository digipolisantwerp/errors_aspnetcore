using System;
using System.Collections.Generic;
using System.Linq;
using Digipolis.Errors.Internal;

namespace Digipolis.Errors.Exceptions
{
    public abstract class BaseException : Exception
    {
        public Dictionary<string, IEnumerable<string>> Messages { get; protected set; }
        public string Code { get; set; }

        #region C'tors

        protected BaseException(string message = null, string code =null,  Exception exception = null, Dictionary<string, IEnumerable<string>> messages = null)
            : base(message, exception)
        {
            Messages = messages ?? new Dictionary<string, IEnumerable<string>>();
            Code = code;
        }

        #endregion

        #region Messages

        public void AddMessage(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
                AddMessages(Defaults.ErrorMessage.Key, new[] { message });
        }

        public void AddMessage(string key, string message)
        {
            if (string.IsNullOrWhiteSpace(key) && !Defaults.ErrorMessage.Key.Equals(key))
                throw new ArgumentNullException(nameof(key));

            if (!string.IsNullOrWhiteSpace(message)) AddMessages(key, new[] { message });
        }

        public void AddMessages(IEnumerable<string> messages)
        {
            AddMessages(Defaults.ErrorMessage.Key, messages);
        }

        public void AddMessages(string key, IEnumerable<string> messages)
        {
            if (messages == null || !messages.Any()) return;

            if (string.IsNullOrWhiteSpace(key) && !Defaults.ErrorMessage.Key.Equals(key))
                throw new ArgumentNullException(nameof(key));

            if (Messages.ContainsKey(key))
            {
                var modelMessages = new List<string>(Messages[key]);
                modelMessages.AddRange(messages);
                Messages[key] = modelMessages;
            }
            else Messages.Add(key, messages);
        }

        #endregion
    }
}
