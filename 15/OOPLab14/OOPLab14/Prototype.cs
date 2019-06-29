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
    public abstract class Prototype
    {
        public Ellipse el1;
        public Prototype(Ellipse el)
        {
            this.el1 = el;
        }
        public abstract Prototype Clone();
    }
    public class ConcretePrototype : Prototype,IComponent
    {
        public string Title
        {
            get
            {
                return "Prototype";
            }
            set { }
        }
        public void Draw() { }
        public IComponent Find(string title) { return this; }
        public ConcretePrototype(Ellipse el) : base(el) { }
        public override Prototype Clone()
        {
            return new ConcretePrototype(el1);
        }

    }

}
