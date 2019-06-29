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
    public interface ITarget
    {
        void MoveX(int x);
        void MoveY(int y);
    }
    class Adapter:ITarget
    {
        public readonly Singleton singleton;
        public Adapter(Singleton singl)
        {
            this.singleton = singl;
        }
        public void MoveX(int x)
        {
            singleton.i += x;
            singleton.rel.Margin= new Thickness(singleton.i, 200, 0, 0);
        }
        public void MoveY(int y)
        {
            singleton.y += y;
            singleton.rel.Margin = new Thickness(singleton.i, singleton.y, 0, 0);
        }
    }
}
