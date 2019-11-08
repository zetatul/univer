using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace cinema
{
    class Chair : Button
    {
        enum EStatus
        {
            Free = 0,
            Reserv,
            Sale
        }

        public Chair()
        {
        }

        public Chair(int _position)
        {
            uri_Free    = new Uri(@"pack://application:,,,/res/free.png");
            uri_Reserv  = new Uri(@"pack://application:,,,/res/reserv.png");
            uri_Sales   = new Uri(@"pack://application:,,,/res/sales.png");

            e_Status = EStatus.Free;

            img_Icon = new Image();
            ChangeIcon();
            Content = img_Icon;

            Height = Width = 100;
            HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            VerticalAlignment = System.Windows.VerticalAlignment.Top;
            Margin = new System.Windows.Thickness(_position * 100, 300, 0, 0);
            Name = "Button" + _position.ToString();
            Click += Chair_Click;
        }

        private void ChangeIcon()
        {
            switch (e_Status)
            {
                case EStatus.Free:
                    img_Icon.Source = new BitmapImage(uri_Free);
                    break;
                case EStatus.Reserv:
                    img_Icon.Source = new BitmapImage(uri_Reserv);
                    break;
                case EStatus.Sale:
                    img_Icon.Source = new BitmapImage(uri_Sales);
                    break;
                default:
                    break;
            }
        }

        private void Chair_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            switch (e_Status)
            {
                case EStatus.Free:
                    e_Status = EStatus.Reserv;
                    ChangeIcon();
                    break;
                case EStatus.Reserv:
                    e_Status = EStatus.Free;
                    ChangeIcon();
                    break;
                default:
                    break;
            }
        }

        public void Buy()
        {
            switch (e_Status)
            {
                case EStatus.Reserv:
                    e_Status = EStatus.Sale;
                    ChangeIcon();
                    IsEnabled = false;
                    break;
                default:
                    break;
            }
        }

        public bool isReserv()
        {
            if(e_Status == EStatus.Reserv)
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
            if (e_Status == EStatus.Sale)
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
            if(e_Status == EStatus.Sale)
            {
                e_Status = EStatus.Free;
                ChangeIcon();
                IsEnabled = true;
            }
        }

        private Uri uri_Free;
        private Uri uri_Reserv;
        private Uri uri_Sales;

        private EStatus e_Status;
        private Image img_Icon;
    }
}
