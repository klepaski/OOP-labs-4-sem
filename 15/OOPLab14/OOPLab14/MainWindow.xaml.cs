using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPLab14
{
    public partial class MainWindow : Window
    {
        Restorer restorer = new Restorer();
        Memento memento;
        ConcreteFactory factory = new ConcreteFactory();
        Singleton singleton;
        ConcreteDecorator decor = new ConcreteDecorator();
        Map map = new Map();

        public MainWindow()
        {
            InitializeComponent();
            map.AddComponent(factory);
            map.AddComponent(singleton);
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Dialog dialog = new Dialog();
            if (dialog.ShowDialog() == true)
            {
                if (dialog.TypeObject.Equals("Square"))
                {
                    for (int i = 0; i < Convert.ToInt32(dialog.CountObject); i++)
                    {
                        grid1.Children.Add(factory.CreateRectangle());
                    }
                }
                else
                {
                    for (int i = 0; i < Convert.ToInt32(dialog.CountObject); i++)
                    {
                        grid1.Children.Add(factory.CreateEllipse());
                    }
                }
            }
        }
        private void Singleton_Click(object sender, RoutedEventArgs e)
        {
            singleton = Singleton.getInstance();
            memento = singleton.CreateMemento();
            grid1.Children.Add(singleton.rel);
        }
        private void Builder_Click(object sender, RoutedEventArgs e)
        {
            ConcreteBuilder build = new ConcreteBuilder();
            Director director = new Director(build);
            director.Construct();
            decor.SetComponent(build);
            decor.GetResult();
            grid1.Children.Add(decor.builder.el2);
            grid1.Children.Add(decor.builder.el1);
        }
        private void Clone_Click(object sender, RoutedEventArgs e)
        {
            Ellipse el2 = new Ellipse();
            el2.Fill = Brushes.DarkCyan;
            el2.Width = 10;
            el2.Height = 10;
            Prototype p1 = new ConcretePrototype(el2);
            grid1.Children.Add(p1.el1);
            Prototype clone = p1.Clone();
        }
        private void Find_Click(object sender, RoutedEventArgs e)
        {
            var x = map.Find("AbstractFactory");
            if (x != null)
            {
               // textbox1.Text = x.Title;
            }
        }
        private void textbox1_PreviewKeyDown(object sender, System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue.Equals(Key.Down) || e.KeyValue.Equals(Key.Left) || e.KeyValue.Equals(Key.Right) || e.KeyValue.Equals(Key.Up))
            {
                e.IsInputKey = true;
            }
        }
        private void Adapter_Click(object sender, RoutedEventArgs e)
        {
            Adapter adap = new Adapter(singleton);
            adap.MoveX(50);
            adap.MoveY(10);
        }

        private void grid1_KeyDown(object sender, KeyEventArgs e)
        {
            singleton.HandleInput(e);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            singleton.SaveMemento(memento);
            restorer.memento = memento;
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            singleton.SetState(restorer);
        }
    }
}

