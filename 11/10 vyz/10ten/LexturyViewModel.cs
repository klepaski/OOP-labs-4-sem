using System.ComponentModel;
using System.Data.Entity;
using System.Windows;
using System.Windows.Input;
using SampleMVVM.Commands;

namespace _lab11
{
    class LexturyViewModel : INotifyPropertyChanged
    {
        public Lextury lextury;
        TicketsContext db;

        public LexturyViewModel(Lextury ticket)
        {
            this.lextury = ticket;
        }

        public int Id
        {
            get
            {
                return lextury.Id;
            }
            set
            {
                lextury.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Title
        {
            get
            {
                return lextury.Title;
            }
            set
            {
                lextury.Title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Date
        {
            get
            {
                return lextury.Date;
            }
            set
            {
                lextury.Date = value;
                OnPropertyChanged("Date");
            }
        }

        public string Type
        {
            get
            {
                return lextury.NameLector;
            }
            set
            {
                lextury.NameLector = value;
                OnPropertyChanged("Type");
            }
        }

        public int Count
        {
            get
            {
                return lextury.Count;
            }
            set
            {
                lextury.Count = value;
                OnPropertyChanged("Count");
            }
        }

        public string Interval
        {
            get
            {
                return lextury.Interval;
            }
            set
            {
                lextury.Interval = value;
                OnPropertyChanged("Interval");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Отписаться

        private DelegateCommand getItemCommand;
        public ICommand GetItemCommand
        {
            get
            {
                if (getItemCommand == null)
                {
                    getItemCommand = new DelegateCommand(GetItem);
                }
                return getItemCommand;
            }
        }

        private void GetItem()
        {
            Count++;
            db = new TicketsContext();
            db.Lexturys.Load();
            Lextury ticket = new Lextury();
            ticket = db.Lexturys.Find(Id);
            ticket.Count = Count;
            db.SaveChanges();
            db.Dispose();
        }

        #endregion

        #region Записаться

        private DelegateCommand giveItemCommand;

        public ICommand GiveItemCommand
        {
            get
            {
                if (giveItemCommand == null)
                {
                    giveItemCommand = new DelegateCommand(GiveItem, CanGiveItem);
                }
                return giveItemCommand;
            }
        }

        private void GiveItem()
        {
            Count--;
            db = new TicketsContext();
            db.Lexturys.Load();
            Lextury ticket = new Lextury();
            ticket = db.Lexturys.Find(Id);
            ticket.Count = Count;
            db.SaveChanges();
            db.Dispose();
        }

        private bool CanGiveItem()
        {
            return Count > 0;
        }

        #endregion

    }
}
