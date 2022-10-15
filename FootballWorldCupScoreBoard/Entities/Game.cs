using System;
using System.Collections.Generic;

namespace FootballWorldCupScoreBoard.Entities
{
    public class Game : IComparable
    {
        public static int gameId = 0;

        public Game()
        {
            GameId = gameId++;
        }
        public int GameId { get; set; }
        public string Place { get; set; }
        public DateTime StartDate { get; set; }
        public bool EndGame { get; set; }
        public List<Team> Teams { get; set; }

        public int CompareTo(object obj)
        {
            int totalScore1 = 0;
            int totalScore2 = 0;

            Game game = obj as Game;

            game.Teams.ForEach(x => totalScore1 = totalScore1 + x.Score);
            Teams.ForEach(x => totalScore2 = totalScore2 + x.Score);

            int compare = (totalScore1.CompareTo(totalScore2) < 0 ? -1 : (totalScore1.CompareTo(totalScore2) >= 1 ? 1 : (game.StartDate.CompareTo(this.StartDate) < 0 ? -1 : (game.StartDate.CompareTo(this.StartDate) >= 1 ? 1 : 0))));

            return compare;

        }

    }
}
