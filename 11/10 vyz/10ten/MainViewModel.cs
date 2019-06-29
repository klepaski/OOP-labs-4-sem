using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _lab11
{
    class MainViewModel : INotifyPropertyChanged
    {
       // это специальная коллекция, которая умеет
       // отслеживать изменения в себе.
        public ObservableCollection<LexturyViewModel> TicketsList { get; set; }

        public MainViewModel(List<Lextury> lexturys)
        {
            TicketsList = new ObservableCollection<LexturyViewModel>(lexturys.Select(b => new LexturyViewModel(b)));
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}