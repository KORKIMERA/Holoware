using System;

namespace Bismonger.Patterns
{
    public class UserInteractionEventArgs : EventArgs
    {
        public UserInteractionEventArgs() { }

        public UserInteractionEventArgs(string message, string caption, object parameter = null)
        {
            Message = message;
            Caption = caption;
            Parameter = parameter;
        }

        public string Message { get; set; }
        public string Caption { get; set; }
        public object Parameter { get; set; }
    }
}