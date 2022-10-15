using FootballWorldCupScoreBoard.Entities;
using FootballWorldCupScoreBoard.Services;
using FootballWorldCupScoreBoard.Dummy;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FootballWorldCupScoreBoard_Tests
{
    public class Tests
    {
        DummyData dummyData = new DummyData();
        GameService gameService = new GameService();

        [SetUp]
        public void Setup()
        {
        }

        #region Test StartGame method
        [Test]
        public void StartGame_oneTeamNull_ReturnsNullReferenceException()
        {
            DateTime startDate = new DateTime(2022, 10, 13);

            //Asserts
            Assert.Throws<NullReferenceException>(() => gameService.StartGame("Mexico", startDate, new Team(), null));
        }

        [Test]
        public void StartGame_PlaceNull_ReturnsNullReferenceException()
        {
            DateTime startDate = new DateTime(2022, 10, 13);

            //Asserts
            Assert.Throws<NullReferenceException>(() => gameService.StartGame(null, startDate, new Team(), new Team()));
        }

        [Test]
        public void StartGame_ReturnsGame()
        {
            //The score by default is 0 in all the teams
            var mexicoTeam = new Team();
            mexicoTeam.Name = "Mexico";
            mexicoTeam.Players = dummyData.genarateTeamPlayers();
            mexicoTeam.Local = true;

            var canadaTeam = new Team();
            canadaTeam.Name = "Canada";
            canadaTeam.Players = dummyData.genarateTeamPlayers();

            DateTime startDate = new DateTime(2022, 10, 13);

            List<Team> teams = new List<Team>();
            teams.Add(mexicoTeam);
            teams.Add(canadaTeam);

            Game game = gameService.StartGame("Mexico", startDate, mexicoTeam, canadaTeam);

            //the result after create a new game
            Game gameExpectedResult = new Game();
            gameExpectedResult.Place = "Mexico";
            gameExpectedResult.StartDate = startDate;
            gameExpectedResult.Teams = teams;

            //Asserts
            Assert.NotNull(game);
            Assert.AreEqual(gameExpectedResult.Place, game.Place);
            Assert.AreEqual(gameExpectedResult.StartDate, game.StartDate);
            Console.WriteLine(game.ToString());
        }

        [Test]
        public void StartGame_ReturnsNoLocalTeam()
        {
            var cubaTeam = new Team();
            cubaTeam.City = "Cuba";
            cubaTeam.Name = "RFC Cuba";
            cubaTeam.Players = dummyData.genarateTeamPlayers();

            var chinaTeam = new Team();
            chinaTeam.Name = "China";
            chinaTeam.City = "RFC China";
            chinaTeam.Players = dummyData.genarateTeamPlayers();

            DateTime startDate = new DateTime(2022, 10, 13);

            List<Team> teams = new List<Team>();
            teams.Add(cubaTeam);
            teams.Add(chinaTeam);
            Game game = gameService.StartGame("Mexico", startDate, cubaTeam, chinaTeam);

            //Asserts
            Assert.False(game.Teams[0].Local);
            Assert.False(game.Teams[1].Local);
        }

        #endregion


        #region Tests EndGame method

        [Test]
        public void EndGame_Return_NullReferenceException()
        {
            //Asserts
            Assert.Throws<NullReferenceException>(() => gameService.EndGame(7)); //trying to delete a game that does not exist

        }

        [Test]
        public void EndGame_Return_True()
        {
            //Asserts
            Assert.IsTrue(gameService.EndGame(2)); //delete ok a game

        }

        #endregion

        #region  UpdateScore

        [Test]
        public void UpdateScore_Return_NullReferenceException()
        {
            //Asserts
            Assert.Throws<NullReferenceException>(() => gameService.UpdateScore(-7, 2, 6)); //trying to update a game that does not exist
        }


        [Test]
        public void UpdateScore_Return_NullReferenceException_UpdateDeletedGame()
        {
            DummyData.matches.Find(x => x.GameId == 0).EndGame = true;
            //Asserts
            Assert.Throws<NullReferenceException>(() => gameService.UpdateScore(0, 5, 3)); //trying to update a DeletedGame

        }


        [Test]
        public void UpdateScore_AssertNotNull_Return_Game()
        {
            //Asserts
            Assert.NotNull(gameService.UpdateScore(3, 2, 6));

        }

        [Test]
        public void UpdateScore_AssertAreEqual_Return_Game()
        {
            Game game = DummyData.matches.Find(x => x.GameId == 3);

            //Asserts
            Assert.AreEqual(game, gameService.UpdateScore(3, 2, 6));

        }

        #endregion

        #region  GetSummary

        [Test]
        public void GetSummary_IsNotEmpty_Return_GameList()
        {      
            //Asserts
            Assert.IsNotEmpty(gameService.GetSummary());
        }
  
        #endregion
    }
}