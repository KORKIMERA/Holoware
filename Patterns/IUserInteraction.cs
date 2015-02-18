using System.Windows;

namespace Bismonger.Patterns
{
    public delegate MessageBoxResult RequestInteractionHandler(object sender, UserInteractionEventArgs e);

    public interface IUserInteraction
    {
        event RequestInteractionHandler RequestInteraction;
        MessageBoxResult Confirm();
    }
}