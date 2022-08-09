namespace Meta.Interfaces
{
    public interface ILevelLoader
    {
        /// <summary>
        /// Load and start the provided level.
        /// </summary>
        /// <param name="level"></param>
        public void LoadLevel(ILevel level);
    }
}