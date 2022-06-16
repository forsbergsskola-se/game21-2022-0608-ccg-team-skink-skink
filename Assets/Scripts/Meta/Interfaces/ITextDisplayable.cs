using System;
namespace Meta.Interfaces
{
    public interface ITextDisplayable
    {
        public event Action<string> DisplayText;
    }
}
