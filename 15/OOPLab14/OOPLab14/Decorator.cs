using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OOPLab14
{
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
                builder.el1.Stroke = Brushes.Orange;
                builder.el1.StrokeThickness = 2;
            }
        }
        public override void Part2()
        {
            if (builder != null)
            {
                builder.el2.Stroke = Brushes.Beige;
                builder.el2.StrokeThickness = 3;
            }
        }
        public override void GetResult()
        {
            Part1();
            Part2();
        }
    }
}
