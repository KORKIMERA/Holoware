using System.Windows;

namespace Bismonger.Patterns
{
    public class UserInteraction : IUserInteraction
    {
        #region Events
        public event RequestInteractionHandler RequestInteraction;
        #endregion

        #region Members
        object _sender = null;
        UserInteractionEventArgs _e = null;
        #endregion

        public UserInteraction(object sender, UserInteractionEventArgs e)
        {
            _sender = sender;
            _e = e;
        }

        public MessageBoxResult Confirm()
        {
            return RequestInteraction(_sender, _e);
        }

        public MessageBoxResult Confirm(string message, string caption)
        {
            _e.Message = message;
            _e.Caption = caption;
            return RequestInteraction(_sender, _e);
        }
    }
}