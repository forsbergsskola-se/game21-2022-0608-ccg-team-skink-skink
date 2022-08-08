using System;

namespace Meta.LoadSave
{
    [Serializable]
    public class GameState
    {
        public int currency;
        public override string ToString() => $"Currency: {currency}\n";

    }
}
