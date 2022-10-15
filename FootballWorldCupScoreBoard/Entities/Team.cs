using System;
using System.Collections.Generic;

namespace FootballWorldCupScoreBoard.Entities
{
    public class Team
    {
        public Team()
        {
            this.Name = "";
            this.City="";
            this.Players = null;
            this.Score = 0;
            this.Local=false;
        }

        public Team(string name,string city, List<Player> players, int score)
        {
            this.Name = name;
            this.City=city;
            this.Players = players;
            this.Score = score;
        }

        public string Name { get; set; }
        public string City { get; set; }
        public List<Player> Players { get; set; }
        public int Score { get; set; }
        public bool Local { get; set; }
    }
}