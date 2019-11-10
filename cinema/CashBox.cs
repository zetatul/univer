using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace cinema
{
    public class CashBox : Button
    {
        public CashBox(Thickness _position, CHole _owner)
        {
            m_Owner = _owner;
            Height = 20;
            Width = 100;
            HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            VerticalAlignment = System.Windows.VerticalAlignment.Top;
            Margin = _position;
            Content = "Купить";
            Click += CashBox_Click;
        }

        private void CashBox_Click(object sender, RoutedEventArgs e)
        {
            foreach(Chair _c in m_Owner.CheckChair())
            {
                _c.Buy();
            }
        }

        private CHole m_Owner;
    }
}