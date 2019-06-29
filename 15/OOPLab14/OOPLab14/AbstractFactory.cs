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
namespace OOPLab14
{
    public abstract class AbstractFactory
    {
        public abstract Ellipse CreateEllipse();
        public abstract Rectangle CreateRectangle();
    }
    public class ConcreteFactory : AbstractFactory,IComponent
    {
        int i = -300;
        public string Title
        {
            get
            {
                return "AbstractFactory";
            }
            set { }
        }
        public void Draw() { }
        public IComponent Find(string title) { return this; }
        public override Ellipse CreateEllipse()
        {
            Ellipse el = new Ellipse();
            el.Fill = Brushes.Green;
            el.Width = 20;
            el.Height = 20;
            el.Margin = new Thickness(0, i, 0, 0);
            i = i + 60;
            return el;
        }

        public override Rectangle CreateRectangle()
        {
            Rectangle rel = new Rectangle();
            rel.Fill = Brushes.Red;
            rel.Width = 20;
            rel.Height = 20;
            rel.Margin = new Thickness(0, i, 0, 0);
            i = i + 60;
            return rel;
        }
    }
}
