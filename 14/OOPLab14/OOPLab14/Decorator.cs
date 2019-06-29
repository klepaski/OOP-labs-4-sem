using System.Windows.Media;

namespace OOPLab14
{
    //доп.функциональность
    public abstract class Decorator:Builder
    {
        public Builder builder;
        public void SetComponent(Builder concrete)
        {
            this.builder = concrete;
        }     
    }

    public class ConcreteDecorator:Decorator
    {
        public override void Part1()
        {
            if(builder!= null)
            {
                builder.el1.Stroke = Brushes.Pink;
                builder.el1.StrokeThickness = 2;
            }
        }
        public override void Part2()
        {
            if (builder != null)
            {
                builder.el2.Stroke = Brushes.Blue;
                builder.el2.StrokeThickness = 5;
            }
        }
        public override void GetResult()
        {
            Part1();
            Part2();
        }
    }
}