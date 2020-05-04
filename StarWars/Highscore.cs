namespace StarWars
{
    class Highscore
    {
        /// <summary>
        /// The name of the person setting the <c>Highscore</c>
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// The <c>Highscore</c> points score
        /// </summary>
        public int Score { get; private set; }
        /// <summary>
        /// The date the <c>Highscore</c> was set
        /// </summary>
        public string Date { get; private set; }

        /// <summary>
        /// Empty cunstructor for <c>Highscore</c>,
        /// used for example when creating empty lists or arrays
        /// </summary>
        public Highscore() { }

        /// <summary>
        /// Custructor for <c>Highscore</c>, used when adding a new highscore
        /// </summary>
        /// <param name="name">The name of the person setting the <c>Highscore</c></param>
        /// <param name="score">The <c>Highscore</c> points score</param>
        /// <param name="date">The date the <c>Highscore</c> was set</param>
        public Highscore(string name, int score, string date)
        {
            Name = name;
            Score = score;
            Date = date;
        }
    }
}
