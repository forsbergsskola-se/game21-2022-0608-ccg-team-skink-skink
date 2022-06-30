namespace Meta.Interfaces
{
    /// <summary>
    /// Interface that indicates your class supports receiving ICards from events or similar.
    /// </summary>
    public interface ICardReceiver
    {
        public void ReceiveCard(ICard card);
    }
}