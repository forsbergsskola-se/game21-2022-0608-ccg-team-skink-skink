using System;
using Meta.Interfaces;

namespace Meta.LoadSave
{
    public interface ICardArray
    {
        public ICard GetCard(int id);
        public Object[] GetCollection();
    }
}
