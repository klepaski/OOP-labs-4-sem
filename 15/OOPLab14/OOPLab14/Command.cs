using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
namespace OOPLab14
{
    //позвол.инкапс запрос на вып-ние оперд.д-вия в виде отд.объекта.

    //представляет запускаемую игровую команду
    interface ICommand
    {
        void Execute(Singleton hero);
    }

    //классы различных игровых команд
    class JumpCommand:ICommand
    {
        public void Execute(Singleton hero) => Jump(hero);
        public void Jump(Singleton hero)
        {
            Thickness t = hero.rel.Margin;
            hero.rel.Margin = new Thickness(t.Left, t.Top - 10, t.Right, t.Bottom);
        }
    }
    class LeftCommand : ICommand
    {
        public void Execute(Singleton hero) => Left(hero);
        public void Left(Singleton hero)
        {
            Thickness t = hero.rel.Margin;
            hero.rel.Margin = new Thickness(t.Left+10, t.Top, t.Right, t.Bottom);
        }
    }

    public interface ObjectState
    {
        void HandleInput(Singleton hero, KeyEventArgs key);
        void Update(Singleton hero);
    }
    class JumpingState:ObjectState
    {
        JumpCommand jump = new JumpCommand();
        public void HandleInput(Singleton hero, KeyEventArgs e)
        {
            if(e.Key.Equals(Key.Down))
            {
                hero.ChangeState(new StandingState());
            }
            if (e.Key.Equals(Key.Up))
            {
                Update(hero);
            }
        }
        public void Update(Singleton hero)
        {
            jump.Execute(hero);  
        }
    }
    class StandingState : ObjectState
    {
        LeftCommand left = new LeftCommand();
        public void HandleInput(Singleton hero, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Up))
            {
                hero.ChangeState(new JumpingState());
            }
            if (e.Key.Equals(Key.Right))
            {
                Update(hero);
            }
        }
        public void Update(Singleton hero)
        {
            left.Execute(hero);
        }
    }

}
