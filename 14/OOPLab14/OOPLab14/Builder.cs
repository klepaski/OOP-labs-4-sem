using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
namespace OOPLab14
{
    public abstract class Builder
    {
        public Ellipse el1 = new Ellipse();
        public Ellipse el2 = new Ellipse();
        public abstract void Part1();
        public abstract void Part2();
        public abstract void GetResult();
    }
    public class ConcreteBuilder : Builder,IComponent
    {
        public string Title
        {
            get
            {
                return "Builder";
            }
            set { }
        }
        public void Draw() { }
        public IComponent Find(string title) { return this; }
        public override void GetResult()
        {
            Part1();
            Part2();
        }
        public override void Part1()
        {
            el1.Width = 30;
            el1.Height = 30;
            el1.Margin = new Thickness(400, 200, 0, 0);
            el1.Fill = Brushes.Blue;
        }
        public override void Part2()
        {
            el2.Width = 60;
            el2.Height = 60;
            el2.Margin = new Thickness(400, 200, 0, 0);
            el2.Fill = Brushes.Purple;
        }
    }
    public class Director
    {
        public ConcreteBuilder builder;
        public Director(ConcreteBuilder _builder)
        {
            this.builder = _builder;
        }
        public void Construct()
        {
            builder.GetResult();
        }
    }
}
