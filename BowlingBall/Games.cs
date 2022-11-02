namespace BowlingBall
{
    public class Games
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;
        private const int MAXROLL = 21;
        public void Roll(int pins)
        {
            if (currentRoll < MAXROLL)
            {
                rolls[currentRoll] = pins;
                currentRoll = currentRoll + 1;
            }
        }

        /// <summary>
        /// Gets total score
        /// </summary>
        /// <returns></returns>
        public int GetTotalScore()
        {
            int score = 0;
            currentRoll = 0;
            for (var frames = 1; frames <= 10; frames++)
            {
                if (IsStrike(currentRoll))
                {
                    score = score + GetScoreByRoll(currentRoll) + Bonus(currentRoll);
                    currentRoll = currentRoll + 1;
                }
                else if (IsSpare(currentRoll))
                {
                    score = score + GetScoreByRoll(currentRoll) + Bonus(currentRoll);
                    currentRoll = currentRoll + 2;
                }
                else
                {
                    score = score + GetScoreByRoll(currentRoll);
                    currentRoll = currentRoll + 1;

                    score = score + GetScoreByRoll(currentRoll);
                    currentRoll = currentRoll + 1;
                }
            }

            return score;
        }

        /// <summary>
        /// Check if current roll is a strike
        /// </summary>
        /// <param name="currentRoll"></param>
        /// <returns></returns>
        private bool IsStrike(int currentRoll)
        {
            if (rolls[currentRoll] == 10)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if current roll is a spare
        /// </summary>
        /// <param name="currentRoll"></param>
        /// <returns></returns>
        private bool IsSpare(int currentRoll)
        {
            if (rolls[currentRoll] + rolls[currentRoll + 1] == 10)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Calculates bonus
        /// </summary>
        /// <param name="currentRoll"></param>
        /// <returns></returns>
        private int Bonus(int currentRoll)
        {
            return rolls[currentRoll + 1] + rolls[currentRoll + 2];
        }

        /// <summary>
        /// Gets score by roll
        /// </summary>
        /// <param name="currentRoll"></param>
        /// <returns></returns>
        private int GetScoreByRoll(int currentRoll)
        {
            return rolls[currentRoll];
        }

    }
}
