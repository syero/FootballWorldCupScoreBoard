using System;
using System.Collections.Generic;
using FootballWorldCupScoreBoard.Dummy;
using FootballWorldCupScoreBoard.Entities;
using FootballWorldCupScoreBoard.Services.Interfaces;

namespace FootballWorldCupScoreBoard.Services
{
    public class GameService : IGameService
    {
        /// <summary>
        /// 1. Start a game. Our data partners will send us data for the games when they start, and 
        /// these should capture (Initial score is 0 – 0).
        ///   a. Home team
        ///   b. Away team 
        /// </summary>
        /// <param name="place"></param>
        /// <param name="startDate"></param>
        /// <param name="team1"></param>
        /// <param name="team2"></param>
        /// <returns></returns>

        public Game StartGame(string place, DateTime startDate, Team team1, Team team2)
        {
            Game matchInfo = new Game();
            List<Team> teams = new List<Team>();

            try
            {
                if (!string.IsNullOrEmpty(place) && team1 != null && team2 != null)
                {
                    matchInfo.Place = place;

                    if (place.ToUpper().Equals(team1.City.ToUpper()))
                    {
                        team1.Local = true;
                    }
                    else if (place.ToUpper().Equals(team2.City.ToUpper()))
                    {
                        team2.Local = true;
                    }

                    teams.Add(team1);
                    teams.Add(team2);
                    matchInfo.Teams = teams;
                    matchInfo.StartDate = startDate;

                    DummyData.matches.Add(matchInfo); //add a new match to the matches list "stored data"

                    return matchInfo;
                }
                else
                {
                    throw new NullReferenceException("Null values are not supported");
                }

            }
            catch (NullReferenceException e)
            {
                throw e;
            }


        }

        /// <summary>
        /// 2. Finish game. It will remove a match from the scoreboard
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public bool EndGame(int gameId)
        {
            bool deleteMatch = false;

            try
            {
                Game gameToDelete = DummyData.matches.Find(x => x.GameId == gameId);

                if (gameToDelete != null)
                {
                    //DummyData.matches.Find(x => x.GameId == gameId).EndGame = true; // mark the match as delete from the list
                    DummyData.matches.Remove(DummyData.matches.Find(x => x.GameId == gameId));
                    deleteMatch = true;

                }
                else
                {
                    throw new NullReferenceException("The match does not exist");
                }
            }
            catch (NullReferenceException e)
            {

                throw e;
            }

            return deleteMatch;
        }


        /// <summary>
        /// 3.Update score. Receiving the pair score; home team score and away team score 
        ///  updates a game score
        /// </summary>
        /// <param name="idGame"></param>
        /// <param name="homeTeamScore"></param>
        /// <param name="awayTeamScore"></param>
        public Game UpdateScore(int idGame, int homeTeamScore, int awayTeamScore)
        {
            try
            {
                Game gameToUpdate = DummyData.matches.Find(x => x.GameId == idGame);  //get the match from the "stored data"
                if (gameToUpdate != null && gameToUpdate.EndGame != true)
                {
                    DummyData.matches.Find(x => x.GameId == idGame).Teams.Find(y => y.Local == true).Score = homeTeamScore;
                    DummyData.matches.Find(x => x.GameId == idGame).Teams.Find(y => y.Local == false).Score = awayTeamScore;
                    return gameToUpdate;
                }
                else
                {
                    throw new NullReferenceException("The match does not exist");
                }
            }
            catch (NullReferenceException e)
            {
                throw e;
            }

        }

        /// <summary>
        /// 4. Get a summary of games by total score. Those games with the same total score will  be returned ordered by the most recently added to our system.
        /// </summary>
        /// <returns></returns>
        public List<Game> GetSummary()
        {
            try
            {
                List<Game> summary = DummyData.matches; //get the matches from the "stored data"
                if (summary != null)
                {
                    summary.Sort();
                    return summary;
                }
                else
                {
                    throw new NullReferenceException("The match list it's null or empty");
                }
            }
            catch (NullReferenceException e)
            {
                throw e;
            }

        }

    }
}