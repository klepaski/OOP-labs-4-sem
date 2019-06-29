using System.Windows;
namespace OOPLab14
{
    /*Adapter - преобраз.интерф.1 класса в интерф.другого*/
    public interface ITarget
    {
        void MoveX(int x);
        void MoveY(int y);
    }
    class Adapter : ITarget
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
//А.класса исп.наслед-ние и м.переносить только класс - не м.обернуть интерфейс
//А.объектов м.переносить классы или интерфейсы или и то, и другое

//proxy - предоставляет объект-заместитель, кот. управл.доступом к другому объекту
//Composite - компоновщик объединяет (часть-целое)
//facade - скрыть сложность системы с пом.упрощенного интерфейса
//bridge - отделить абстракцию от реализации (изменять независимо друг от друга)