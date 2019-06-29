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
    public class Singleton:IComponent
    {
        private static Singleton instance;
        private ObjectState objectState=new StandingState();
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
        public void HandleInput(KeyEventArgs e)
        {
            objectState.HandleInput(this,e);
        }
        void Update()
        {
            objectState.Update(this);
        }
        public void ChangeState(ObjectState newstate)
        {
            objectState = newstate;
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
        public Memento CreateMemento()
        {
            return new Memento(objectState);
        }
        public void SaveMemento(Memento memento)
        {
            memento.State=this.objectState;
        }
        public void SetState(Restorer restorer)
        {
            this.objectState=restorer.memento.State;
        }
    }
}
