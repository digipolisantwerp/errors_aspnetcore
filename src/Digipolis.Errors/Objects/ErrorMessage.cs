using System;
using Digipolis.Errors.Internal;

namespace Digipolis.Errors
{
    public class ErrorMessage
    {
        public ErrorMessage(string key, string message)
        {
            if ( key == null ) throw new ArgumentNullException(nameof(key), $"{nameof(key)} is null.");
            Key = key;
            Message = message == null ? Defaults.ErrorMessage.NullString : message;
        }

        public string Key { get; private set; }
        public string Message { get; private set; }

        public override string ToString()
        {
            return $"ErrorMessage ( Key = {Key}, Message = {Message} )";
        }
    }
}
