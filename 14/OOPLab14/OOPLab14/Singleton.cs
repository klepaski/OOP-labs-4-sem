using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPLab14
{
    public class Singleton:IComponent
    {
        private static Singleton instance;
        public int i = -400;
        public int y = 200;
        public Rectangle rel;
        public string Title
        {
            get
            {
                return "Singleton";
            }
            set { }
        }
        public void Draw() { }
        public IComponent Find(string title) { return this; }
        private Singleton()
        {
            this.rel = new Rectangle();
            this.rel.Fill = Brushes.Orange;
            this.rel.Width = 40;
            this.rel.Height = 20;
            this.rel.Margin = new Thickness(i, 200, 0, 0);
        }
        public static Singleton getInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}
