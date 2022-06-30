namespace Meta.Interfaces
{
    /// <summary>
    /// Interface for daily reward
    /// </summary>
    public interface IDailyReward
    {
        /// <summary>
        /// Checks the last date the player logged in (if there is one) then compares it to the daytime to check if you logged in the day before, if so you get your daily reward, otherwise it resets the daily reward.
        /// </summary>
        public void CheckDailyReward();
    }
}
