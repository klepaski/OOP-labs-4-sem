using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _lab11
{
    class Lextury
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string NameLector { get; set; }
        public int Count { get; set; }
        public string Interval { get; set; }
        public Lextury(int id, string title, string date, string namelector, int count, string interval)
        {
            this.Id = id;
            this.Title = title;
            this.Date = date;
            this.NameLector = namelector;
            this.Count = count;
            this.Interval = interval;
        }

        public Lextury()
        {

        }
    }
}
