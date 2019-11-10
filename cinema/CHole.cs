using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace cinema
{
    public class CHole : Grid
    {
        public CHole(Window _form, int _chairCount)
        {
            m_CountChair = _chairCount;

            //initial Grid
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;
            Margin = new Thickness(0, 0, 0, 0);
            Width = _form.Width - 10;
            Height = _form.Height - 30;

            //initial Chair
            m_Chair = new List<Chair>();
            for(int i = 0; i < m_CountChair; i++)
            {
                var _chair = new Chair(new Thickness(i * 100, Height - 130, 0, 0));
                m_Chair.Add(_chair);
                this.Children.Add(_chair);
            }

            //initial CasheBox
            m_CashBox = new CashBox(new Thickness(0, 30, 0, 0), this);
            this.Children.Add(m_CashBox);
        }

        public List<Chair> CheckChair()
        {
            return m_Chair;
        }

        private List<Chair> m_Chair;
        private CashBox     m_CashBox;
        private int         m_CountChair;
    }
}
