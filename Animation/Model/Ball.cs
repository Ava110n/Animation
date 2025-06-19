using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Animation.Model
{
    public class Ball: INotifyPropertyChanged
    {
        int x;
        int y;
        int dx;
        int dy;
        Color color;
        int radius = 5;

        public SolidColorBrush Color => new SolidColorBrush(color);
        public int R => radius;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int X { 
            get { return x; } 
            set { 
                x = value;
                OnPropertyChanged();
            } 
        }
        public int Y { 
            get { return y; } 
            set { 
                y = value;
                OnPropertyChanged();
            } 
        }

        public Thickness Position {  get => new Thickness(X,Y,0,0); }

        private Ball()
        {
            Random random = new Random();
            this.dx = random.Next(-25, 25);
            this.dy = random.Next(-25, 25);
            this.color = System.Windows.Media.Color.FromArgb((byte)random.Next(0, 256),(byte)random.Next(0, 256), (byte)random.Next(0, 256), (byte)random.Next(0, 256));
        }
        public Ball(int x, int y) : this()
        {
            this.x = x;
            X = x;
            this.y = y;
            Y = y;
        }
        public Ball(System.Windows.Point pos) : this()
        {
            x = (int)(pos.X-radius/2);
            X = x;
            y = (int)(pos.Y-radius/2);
            Y = y;
        }

        public void Move(int maxWidth, int maxHeight)
        {
            X += dx;
            Y += dy;

            if (X < 0 || X > maxWidth - radius)
            {
                dx = -dx;
                X += 2 * dx;
            }
            if (Y < 0 || Y > maxHeight - radius)
            {
                dy = -dy;
                Y += 2 * dy;
            }
        }


        private void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }



        
    }
}
