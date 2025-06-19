using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animation.Model;

namespace Animation.ViewModel
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Ball> Balls{get; set;}

        public MainViewModel() {
            Balls = new ObservableCollection<Ball>();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void AddBall(System.Windows.Point pos)
        {
            Balls.Add(new Ball(pos));
        }
    }
}
