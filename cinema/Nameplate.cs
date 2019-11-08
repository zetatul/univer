using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace cinema
{
    class Nameplate : Label
    {
        public Nameplate()
        {
        }

        public Nameplate(int _position)
        {

            HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            VerticalAlignment = System.Windows.VerticalAlignment.Top;
            Height  = 24;
            Width   = 100;
            Margin  = new System.Windows.Thickness(_position * 100, 275, 0, 0);
            Name    = "Lable" + _position.ToString();
            Content = "";
        }

        public void Sales()
        {
            Content = "Выкуплено";
        }

        public void Reset()
        {
            Content = "";
        }
    }
}
