using System.Windows;

namespace Bizmonger.UILogic.Interactions
{
    public delegate MessageBoxResult RequestConfirmationHandler(string message, string caption);

    public interface IConfirmationInteraction
    {
        event RequestConfirmationHandler RequestConfirmation;
        MessageBoxResult Confirm();
    }
}