using System;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace lab13
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }


        //опред.интерфейс для класссов, обекты кот.будут созд.в проге
        abstract class Circle
        {
            public abstract Ellipse DrawCircle();
        }
        abstract class Square
        {
            public abstract Rectangle DrawSquary();
        }

        //конкр.реализ.абстрактных классов
        class RedCircle : Circle
        {
            public override Ellipse DrawCircle()
            {
                Ellipse ellipseRed = new Ellipse();
                ellipseRed.Width = 50;
                ellipseRed.Height = 50;
                ellipseRed.Fill = Brushes.Red;
                return ellipseRed;
            }
        }
        class GreenCircle : Circle
        {
            public override Ellipse DrawCircle()
            {
                Ellipse ellipseGreen = new Ellipse();
                ellipseGreen.Width = 50;
                ellipseGreen.Height = 50;
                ellipseGreen.Fill = Brushes.Green;
                return ellipseGreen;
            }
        }
        class RedSquare : Square
        {
            public override Rectangle DrawSquary()
            {
                Rectangle squareRed = new Rectangle();
                squareRed.Width = 50;
                squareRed.Height = 50;
                squareRed.Fill = Brushes.Red;
                return squareRed;
            }
        }
        class GreenSquare : Square
        {
            public override Rectangle DrawSquary()
            {
                Rectangle squareGreen = new Rectangle();
                squareGreen.Width = 50;
                squareGreen.Height = 50;
                squareGreen.Fill = Brushes.Green;
                return squareGreen;
            }
        }

        //абтрактной класс фабрики - определяет методы для создания объектов
        abstract class FigureFactory
        {
            public abstract Circle CreateCircle();
            public abstract Square CreateSquare();
        }

        //конкретные классы фабрик реализуют абстрактные матоды базового класса
        //и непосредственно решают объект какого класса создавать
        class RedFigure : FigureFactory
        {
            public override Circle CreateCircle()
            {
                return new RedCircle();
            }
            public override Square CreateSquare()
            {
                return new RedSquare();
            }

        }
        class GreenFigure : FigureFactory
        {
            public override Circle CreateCircle()
            {
                return new GreenCircle();
            }

            public override Square CreateSquare()
            {
                return new GreenSquare();
            }

        }

        //класс фигуры исп класс фабрики для созд объектов.
        class Figure
        {
            private Circle circle;
            private Square square;
            public Figure(FigureFactory factory)
            {
                circle = factory.CreateCircle();
                square = factory.CreateSquare();
            }
            public Ellipse getCircle()
            {
                return circle.DrawCircle();
            }
            public Rectangle getSquary()
            {
                return square.DrawSquary();
            }
        }

        private void ButtonClickCreate(object sender, RoutedEventArgs e)
        {
            Create newItem = new Create();

            if (newItem.ShowDialog() == true)
            {
                Figure red = new Figure(new RedFigure());
                Figure green = new Figure(new GreenFigure());

                if ("Red ellipse" == newItem.FirureName)
                {
                    int g = -400;
                    for (int i = 0; i < newItem.FigureCount; i++)
                    {
                        Ellipse ellipseNew = red.getCircle();
                        g = g + 100;
                        ellipseNew.Margin = new Thickness(0, g, 340, 0);
                        Greed.Children.Add(ellipseNew);
                    }
                }
                if ("Green ellipse" == newItem.FirureName)
                {
                    int g = -400;
                    for (int i = 0; i < newItem.FigureCount; i++)
                    {
                        Ellipse ellipseNew = green.getCircle();
                        g = g + 100;
                        ellipseNew.Margin = new Thickness(-150, g, 0, 0);
                        Greed.Children.Add(ellipseNew);
                    }
                }
                if ("Red rectangle" == newItem.FirureName)
                {
                    int g = -400;
                    for (int i = 1; i < newItem.FigureCount + 1; i++)
                    {
                        Rectangle ellipseNew = red.getSquary();
                        g = g + 110;
                        ellipseNew.Margin = new Thickness(150, g, 0, 0);
                        Greed.Children.Add(ellipseNew);
                    }
                }
                if ("Green rectangle" == newItem.FirureName)
                {
                    int g = -400;
                    for (int i = 0; i < newItem.FigureCount; i++)
                    {
                        Rectangle ellipseNew = green.getSquary();
                        g = g + 110;
                        ellipseNew.Margin = new Thickness(340, g, 0, 0);
                        Greed.Children.Add(ellipseNew);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error open window");
            }

        }
        
        //Prototype
        //интерфейс клонирования самого себя
        interface IFigure
        {
            IFigure Clone();
            String GetInfo();
        }

        class Rectangles : IFigure
        {
            int width;
            int height;
            public Rectangles(int w, int h)
            {
                width = w;
                height = h;
            }

            public IFigure Clone()
            {
                return new Rectangles(this.width, this.height);
            }
            public string GetInfo()
            {
                String s = System.String.Format("Прямоугольник длиной {0} и шириной {1}", height, width);
                return s;
            }
        }

        class Circles : IFigure
        {
            int radius;
            public Circles(int r)
            {
                radius = r;
            }
            public IFigure Clone()
            {
                Circles circles = new Circles(this.radius);
                return circles;
            }
            public String GetInfo()
            {
                String s = System.String.Format("Круг радиусом {0}", radius);
                return s;
            }
        }

        private void ButtonClickClone(object sender, RoutedEventArgs e)
        {
            IFigure figure = new Rectangles(40, 50);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            IFigure figures = new Circles(50);
            IFigure clonedFigures = figures.Clone();
            tb.Text = System.String.Format(" {0} \n {1} \n {2} \n {3}", figures.GetInfo(), clonedFigures.GetInfo(), figure.GetInfo(), clonedFigure.GetInfo());

        }

        //Singleton - сущ.только 1 экземпляр класса
        class Singleton
        {
            private static Singleton instance;
            private Singleton()
            { }
            public static Singleton getInstance()
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }
        class GoldObject
        {
            public Color Color { get; set; }
            public void DrawColor(string osName)
            {
                Color = Color.getInstance(osName);
            }
        }
        class Color
        {
            private static Color instance;
            public string Name { get; private set; }
            protected Color(string name)
            {
                this.Name = name;
            }
            public static Color getInstance(string name)
            {
                if (instance == null)
                    instance = new Color(name);
                return instance;
            }
        }

        private void ButtonClickCreateGpld(object sender, RoutedEventArgs e)
        {
            GoldObject comp = new GoldObject();
            comp.DrawColor("Gold");
            String color = comp.Color.Name;
            comp.Color = Color.getInstance("Black");

            tb.Text = System.String.Format("Цвет {0} и при попытке изменить цвет на Black \n он останется {1}", color, comp.Color.Name);
        }


        //Builder - инкапсулирует создание объекта и позволяет разделить его на различн.этапы

        class Circletes
        {
            public string Color { get; set; }
            public Ellipse ellipse = new Ellipse();

        }
        class Squaretes
        {
            public string Color { get; set; }
            public Rectangle rectangle = new Rectangle();
        }

        class ComplexObject
        {
            public Circletes Circletes { get; set; }
            public Squaretes Squaretes { get; set; }
        }
        abstract class ComplexObjectBilder
        {
            public ComplexObject ComplexObject { get; private set; }
            public void CreateComplexObject()
            {
                ComplexObject = new ComplexObject();
            }
            public abstract Ellipse SetCircletes();
            public abstract Rectangle SetSquaretes();
        }
        class Creater
        {
            public ComplexObject complexObject(ComplexObjectBilder complexObjectBilder)
            {
                complexObjectBilder.CreateComplexObject();
                complexObjectBilder.SetCircletes();
                complexObjectBilder.SetSquaretes();

                return complexObjectBilder.ComplexObject;
            }
        }
        class YellowComplexObjectBilder : ComplexObjectBilder
        {
            public override Ellipse SetCircletes()
            {
                Ellipse ellipseYellow = new Ellipse();
                ellipseYellow.Width = 150;
                ellipseYellow.Height = 150;
                ellipseYellow.Fill = Brushes.Yellow;
                this.ComplexObject.Circletes = new Circletes { Color = "Yellow" };
                this.ComplexObject.Circletes = new Circletes { ellipse = ellipseYellow };
                return ellipseYellow;
            }

            public override Rectangle SetSquaretes()
            {
                Rectangle squareYellow = new Rectangle();
                squareYellow.Width = 250;
                squareYellow.Height = 50;
                squareYellow.Fill = Brushes.Yellow;
                this.ComplexObject.Squaretes = new Squaretes { Color = "Yellow" };
                this.ComplexObject.Squaretes = new Squaretes { rectangle = squareYellow };
                return squareYellow;
            }
        }
        class BlueComplexObjectBilder : ComplexObjectBilder
        {
            public override Ellipse SetCircletes()
            {

                Ellipse ellipseBlue = new Ellipse();
                ellipseBlue.Width = 150;
                ellipseBlue.Height = 150;
                ellipseBlue.Fill = Brushes.Blue;
                this.ComplexObject.Circletes = new Circletes { Color = "Blue" };
                this.ComplexObject.Circletes = new Circletes { ellipse = ellipseBlue };
                return ellipseBlue;
            }

            public override Rectangle SetSquaretes()
            {
                Rectangle squareBlue = new Rectangle();
                squareBlue.Width = 50;
                squareBlue.Height = 50;
                squareBlue.Fill = Brushes.Blue;
                this.ComplexObject.Squaretes = new Squaretes { Color = "Blue" };
                this.ComplexObject.Squaretes = new Squaretes { rectangle = squareBlue };
                return squareBlue;
            }
        }

        private void ButtonClickCreateComplexObject(object sender, RoutedEventArgs e)
        {
            Creater creater = new Creater();
            ComplexObjectBilder complexObjectBilder = new YellowComplexObjectBilder();
            ComplexObject grenComplexObject = creater.complexObject(complexObjectBilder);
            Greed.Children.Add(complexObjectBilder.SetCircletes());
            Greed.Children.Add(complexObjectBilder.SetSquaretes());

            complexObjectBilder = new BlueComplexObjectBilder();
            ComplexObject BlueComplexObject = creater.complexObject(complexObjectBilder);
            Greed.Children.Add(complexObjectBilder.SetSquaretes());
        }
    }
}
