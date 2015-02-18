using System.Windows;

namespace Bizmonger.UILogic.Interactions
{
    public class ConfirmationInteraction : IConfirmationInteraction
    {
        public event RequestConfirmationHandler RequestConfirmation;

        string _message { get; set; }
        string _caption { get; set; }

        public ConfirmationInteraction() { }

        public ConfirmationInteraction(string message, string caption)
        {
            _message = message;
            _caption = caption;
        }

        public MessageBoxResult Confirm()
        {
            return RequestConfirmation(_message, _caption);
        }

        public MessageBoxResult Show(string message, string caption)
        {
            return RequestConfirmation(message, caption);
        }
    }
}