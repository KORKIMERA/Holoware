using Bizmonger.UILogic;

namespace CommandModule.Infrastructure
{
    public class ConsoleLine : ViewModelBase
    {
        public string Content { get; set; }

        CommandStatus _status = CommandStatus.None;
        public CommandStatus Status
        {
            get { return _status; }

            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
