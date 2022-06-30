namespace Meta.Interfaces
{
    public interface ICardLoader
    {
        public ICard[] LoadCardsFromPath(string path);
    }
}
