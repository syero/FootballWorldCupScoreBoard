using System;
using System.Collections.Generic;
using FootballWorldCupScoreBoard.Entities;
using FootballWorldCupScoreBoard.Services;
using FootballWorldCupScoreBoard.Dummy;

namespace FootballWorldCupScoreBoard
{
    class Program
    {

        static void Main(string[] args)
        {

            GameService gameService = new GameService();
            DummyData dummyData = new DummyData();

            foreach (var match in DummyData.matches)
            {
                Console.WriteLine(match.GameId + " - " + match.Place + " - " + match.StartDate + " - " + match.EndGame);
                match.Teams.ForEach(x => Console.WriteLine(x.Name + " - " + x.Score + " - " + x.Local));
            }

            //The score by default is 0 in all the teams
            var cubaTeam = new Team();
            cubaTeam.City = "Cuba";
            cubaTeam.Name = "RFC Cuba";
            cubaTeam.Players = dummyData.genarateTeamPlayers();

            var chinaTeam = new Team();
            chinaTeam.City = "China";
            chinaTeam.Name = "RFC China";
            chinaTeam.Players = dummyData.genarateTeamPlayers();

            DateTime startDate = new DateTime(2022, 10, 13);

            List<Team> teams = new List<Team>();
            teams.Add(cubaTeam);
            teams.Add(chinaTeam);
            Game game = gameService.StartGame("Mexico", startDate, cubaTeam, chinaTeam);


            Console.WriteLine("****************************  ADD MATCH  ********************************");

            foreach (var match in DummyData.matches)
            {
                Console.WriteLine(match.GameId + " - " + match.Place + " - " + match.StartDate + " - " + match.EndGame);
                match.Teams.ForEach(x => Console.WriteLine(x.Name + " - " + x.Score + " - " + x.Local));
            }

            Console.WriteLine("****************************  DELETE MATCH  ********************************");

            gameService.EndGame(0);

            foreach (var match in DummyData.matches)
            {
                Console.WriteLine(match.GameId + " - " + match.Place + " - " + match.StartDate + " - " + match.EndGame);
                match.Teams.ForEach(x => Console.WriteLine(x.Name + " - " + x.Score + " - " + x.Local));
            }


            Console.WriteLine("****************************  UPDATE MATCH SCOPE  ********************************");

            gameService.UpdateScore(1, 10, 2);
            gameService.UpdateScore(2, 2, 2);
            gameService.UpdateScore(3, 6, 6);
            gameService.UpdateScore(4, 3, 1);

            foreach (var match in DummyData.matches)
            {
                Console.WriteLine(match.GameId + " - " + match.Place + " - " + match.StartDate + " - " + match.EndGame);
                match.Teams.ForEach(x => Console.WriteLine(x.Name + " - " + x.Score + " - " + x.Local));
            }


            Console.WriteLine("**************************** SUMMARY MATCHES  ********************************");
            
            List<Game> summary=gameService.GetSummary();

            foreach (var match in summary)
            {
                Console.WriteLine(match.GameId + " - " + match.Place + " - " + match.StartDate + " - " + match.EndGame);
                match.Teams.ForEach(x => Console.WriteLine(x.Name + " - " + x.Score + " - " + x.Local));
            }

        }


    }
}
