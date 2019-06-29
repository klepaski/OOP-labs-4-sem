using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//оперд.алг.и взаимод.между классами и объектами

namespace OOPLab14
{
    //возвол.выносить внутр.сост.объекта за его пределы для послед.восстановл.объекта без наруш.принц.инкапс.

    public class Memento
    {
        ObjectState state;
        public ObjectState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
        public Memento(ObjectState _state)
        {
            this.state = _state;
        }
    }

    public class Restorer
    {
        public Memento memento;
    }
}




//Chain of responsibility - избежать жесткой привязки отправителя к получателю, позволяя неск.объектам обработать запрос.
//все возм.обработчики образ.цепочку, а сам запрос перемещается по этой цепочке, пока один из объектов не обработает запрос.

//Observer - отнош.один ко многим. 1 наблюд.объект и мн-во наблюдателей.

//Mediator - взаимод.мн-ва объектов без необх-сти ссылаться друг на друга -> слабосвязанность

//Facade - предоставляет сущ-щие ф-ции, а mediator добавл.к сущ.ф-циям

//Visitor - добавл. один.набор операций разнородным классам, без изм.

//Strategy - семейство алг.инкапс.каждого - вз  аимозаменяемость