using System;
using System.Collections.Generic;
using System.Linq;
using Toolbox.Errors.Internal;

namespace Toolbox.Errors
{
    public class Error
    {
        public Error() : this(Guid.NewGuid().ToString())
        { }

        public Error(string id, IEnumerable<ErrorMessage> errorMessages = null)
        {
            AssertNotNullOrWhiteSpace(id, nameof(id));
            Id = id;
            _messages = errorMessages == null ? new List<ErrorMessage>() : new List<ErrorMessage>(errorMessages);
        }

        public Error(string id, ErrorMessage errorMessage)
        {
            AssertNotNullOrWhiteSpace(id, nameof(id));
            Id = id;
            _messages = new List<ErrorMessage> { errorMessage };
        }

        public string Id { get; private set; }

        private List<ErrorMessage> _messages;
        public IEnumerable<ErrorMessage> Messages { get { return _messages; } }

        public void AddErrorMessage(ErrorMessage errorMessage)
        {
            if ( errorMessage == null ) return;
            _messages.Add(errorMessage);
        }

        public void AddErrorMessages(IEnumerable<ErrorMessage> errorMessages)
        {
            if ( errorMessages == null ) return;
            foreach ( var errorMessage in errorMessages )
            {
                AddErrorMessage(errorMessage);
            }
        }

        public void AddMessage(string message)
        {
            if ( message == null ) return;
            AddErrorMessage(new DefaultErrorMessage(message));
        }

        public void AddMessage(string key, string message)
        {
            var errorMessage = new ErrorMessage(key, message);
            AddErrorMessage(errorMessage);
        }

        public void AddMessages(IEnumerable<string> messages)
        {
            if ( messages == null ) return;
            foreach ( string message in messages )
            {
                AddMessage(message);
            }
        }

        public override string ToString()
        {
            var messages = Messages.Count() == 0 ? "none " : "";
            foreach ( var message in Messages )
            {
                messages += message.ToString();
                messages += " ";
            }
            return $"Error ( Id = {Id}, Messages = {messages})";
        }
        
        private void AssertNotNullOrWhiteSpace(string value, string name)
        {
            if ( value == null ) throw new ArgumentNullException(name, $"{name} is null.");
            if ( value.Trim() == String.Empty ) throw new ArgumentException($"{name} is empty.", name);
        }
    }
}
