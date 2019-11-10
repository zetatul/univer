using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace cinema
{
    public class Chair : Button
    {
        enum EStatus
        {
            Free = 0,
            Reserv,
            Sale
        }

        public Chair(Thickness _position)
        {
            uri_Free    = new Uri(@"pack://application:,,,/res/free.png");
            uri_Reserv  = new Uri(@"pack://application:,,,/res/reserv.png");
            uri_Sales   = new Uri(@"pack://application:,,,/res/sales.png");

            me_Status = EStatus.Free;
            ml_Lable = new Label();
            var _stackPanel = new StackPanel();

            Height = 120;
            Width = 100;
            HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            VerticalAlignment = System.Windows.VerticalAlignment.Top;
            Margin = _position;
            Click += Chair_Click;

            mimg_Icon = new Image();
            mimg_Icon.Height = 100;
            mimg_Icon.Width = 100;
            mimg_Icon.Margin = new Thickness(0, -10, 0, 0);
            mimg_Icon.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            mimg_Icon.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            ChangeIcon();
            
            ml_Lable.Height = 30;
            ml_Lable.Width = 100;
            ml_Lable.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            ml_Lable.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            ml_Lable.Margin = new Thickness(0, 0, 0, 0);
            ml_Lable.Content = "";

            _stackPanel.Children.Add(ml_Lable);
            _stackPanel.Children.Add(mimg_Icon);
            _stackPanel.Height = 120;
            _stackPanel.Width = 100;
            _stackPanel.Margin = new Thickness(0, 0, 0, 0);
            _stackPanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            _stackPanel.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            Content = _stackPanel;
        }

        private void ChangeIcon()
        {
            switch (me_Status)
            {
                case EStatus.Free:
                    mimg_Icon.Source = new BitmapImage(uri_Free);
                    break;
                case EStatus.Reserv:
                    mimg_Icon.Source = new BitmapImage(uri_Reserv);
                    break;
                case EStatus.Sale:
                    mimg_Icon.Source = new BitmapImage(uri_Sales);
                    break;
                default:
                    break;
            }
        }

        private void Chair_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            switch (me_Status)
            {
                case EStatus.Free:
                    me_Status = EStatus.Reserv;
                    ChangeIcon();
                    break;
                case EStatus.Reserv:
                    me_Status = EStatus.Free;
                    ChangeIcon();
                    break;
                default:
                    break;
            }
        }

        public void Buy()
        {
            switch (me_Status)
            {
                case EStatus.Reserv:
                    ml_Lable.Content = "Выкупленно";
                    me_Status = EStatus.Sale;
                    ChangeIcon();
                    IsEnabled = false;
                    break;
                default:
                    break;
            }
        }

        public bool isReserv()
        {
            if(me_Status == EStatus.Reserv)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isSale()
        {
            if (me_Status == EStatus.Sale)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            if(me_Status == EStatus.Sale)
            {
                me_Status = EStatus.Free;
                ml_Lable.Content = "";
                ChangeIcon();
                IsEnabled = true;
            }
        }

        private Uri uri_Free;
        private Uri uri_Reserv;
        private Uri uri_Sales;

        private EStatus me_Status;
        private Image   mimg_Icon;
        private Label   ml_Lable;
    }
}
