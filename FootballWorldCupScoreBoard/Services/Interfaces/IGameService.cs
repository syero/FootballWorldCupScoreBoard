using System;
using System.Collections.Generic;
using FootballWorldCupScoreBoard.Entities;

namespace FootballWorldCupScoreBoard.Services.Interfaces
{
    public interface IGameService
    {
        public Game StartGame(string place,DateTime startDate,Team homeTeam,Team awayTeam);
        public bool EndGame(int gameId);

        public Game UpdateScore(int idGame, int homeTeamScore, int awayTeamScore);

        public List<Game> GetSummary();

    }
}