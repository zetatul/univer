using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cinema
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        struct STicket
        {
            public Chair m_Chair;
            public Nameplate m_Lable;
            public STicket(Chair _c, Nameplate _n)
            {
                this.m_Chair = _c;
                this.m_Lable = _n;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            lst_Ticket = new List<STicket>();
            for (int i = 0; i < 8; i++)
            {
                STicket _ticket = new STicket(new Chair(i), new Nameplate(i));
                
                lst_Ticket.Add(_ticket);

                g_canvas.Children.Add(_ticket.m_Chair);
                g_canvas.Children.Add(_ticket.m_Lable);
            }

            _btn_buy.Click += _btn_buy_Click;
            _btn_reset.Click += _btn_reset_Click;
        }

        private void _btn_reset_Click(object sender, RoutedEventArgs e)
        {
            foreach (STicket o in lst_Ticket)
            {
                if (o.m_Chair.isSale())
                {
                    o.m_Chair.Reset();
                    o.m_Lable.Reset();
                }
            }
        }

        private void _btn_buy_Click(object sender, RoutedEventArgs e)
        {
            foreach(STicket o in lst_Ticket)
            {
                if (o.m_Chair.isReserv())
                {
                    o.m_Chair.Buy();
                    o.m_Lable.Sales();
                }
            }
        }

        private List<STicket> lst_Ticket;
    }
}
