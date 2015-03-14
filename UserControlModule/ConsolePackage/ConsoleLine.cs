using Bizmonger.UILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controls.ConsolePackage
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
