using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UIModule;

namespace UXModule
{
    public class Regions
    {
        public ContentControl Main { get; set; } = new ContentControl();
        public ContentControl Horizon { get; set; } = new ContentControl();
        public ContentControl Ten30 { get; set; } = new ContentControl();
        public ContentControl NineOClock { get; set; } = new ContentControl();
        public ContentControl OneThirty { get; set; } = new ContentControl();
        public ContentControl ThreeOClock { get; set; } = new ContentControl();
    }
}
