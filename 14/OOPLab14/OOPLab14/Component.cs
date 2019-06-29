using System.Collections.Generic;

namespace OOPLab14
{
    public interface IComponent
    {
        string Title { get; set; }
        void Draw();
        IComponent Find(string title);
    }
    public class Map : IComponent
    {
        private readonly List<IComponent> _map = new List<IComponent>();
        public string Title { get; set; }
        public void AddComponent(IComponent component)
        {
            _map.Add(component);
        }
        public IComponent Find(string title)
        {
            foreach(var x in _map)
            {
                if(x.Title.Equals(title))
                {
                    return x;
                }
            }
            return null;
        }
        public void Draw() { }
    }
}
