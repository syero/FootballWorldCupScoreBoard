using System;
using System.Collections.Generic;
using FootballWorldCupScoreBoard.Entities;

namespace FootballWorldCupScoreBoard.Dummy
{
    public class DummyData
    {
        Random random = new Random();
        public static List<Game> matches = new List<Game>();

        public DummyData() { getMatchesList(); }

        #region Player random data

        public string playerRandomName()
        {
            string[] names = { "Pepe", "Luis", "Mario", "Paulo", "Fernando", "Gilberto", "Juan", "Francisco", "Carlos", "Ángel", "Fabio", "Pedro", "Marcos" };

            return names[random.Next(names.Length)];
        }

        public string playerRandomLastName()
        {
            string[] lastNames = { "Gómez", "Castelo", "Pereira", "Car", "Fez", "Gill", "Dolores", "Caster", "Moos", "Ruiz" };

            return lastNames[random.Next(lastNames.Length)];
        }

        //para generar una edad aleatoria entre 27 y 40 años
        public int playerRandomAge()
        {
            return random.Next(27, 40);
        }

        public string playerRandomPosition()
        {
            string[] positions = { "Portero", "Defensa", "Centrocampista", "Delantero" };

            return positions[random.Next(positions.Length)];
        }

        public int playerRandomDorsal()
        {
            return random.Next(0, 50);
        }

        public List<Player> genarateTeamPlayers()
        {
            var teamPlayers = new List<Player>();

            for (int i = 0; i < 11; i++)
            {
                var randomPlayer = new Player();
                randomPlayer.Name = playerRandomName();
                randomPlayer.LastName = playerRandomLastName();
                randomPlayer.Age = playerRandomAge();
                randomPlayer.Position = playerRandomPosition();
                randomPlayer.Dorsal = playerRandomDorsal();

                teamPlayers.Add(randomPlayer);
            }
            return (teamPlayers);
        }

        #endregion

        public List<Team> teamsFootballWorldCupe()
        {
            List<Team> teamsWorldCupe = new List<Team>();

            var players = genarateTeamPlayers();

            //generate teams dummy data, no pongo el score por que por defecto es 0
            var mexicoTeam = new Team();
            mexicoTeam.Name = "Mexico";
            mexicoTeam.Players = players;
            teamsWorldCupe.Add(mexicoTeam);

            var canadaTeam = new Team();
            canadaTeam.Name = "Canada";
            canadaTeam.Players = players;
            teamsWorldCupe.Add(canadaTeam);

            var uruguayTeam = new Team();
            uruguayTeam.Name = "Uruguay";
            uruguayTeam.Players = players;
            teamsWorldCupe.Add(uruguayTeam);

            var spainTeam = new Team();
            spainTeam.Name = "Spain";
            spainTeam.Players = players;
            teamsWorldCupe.Add(spainTeam);

            var brazilTeam = new Team();
            brazilTeam.Name = "Brazil";
            brazilTeam.Players = players;
            teamsWorldCupe.Add(brazilTeam);

            var germanyTeam = new Team();
            germanyTeam.Name = "Germany";
            germanyTeam.Players = players;
            teamsWorldCupe.Add(germanyTeam);

            var franceTeam = new Team();
            franceTeam.Name = "France";
            franceTeam.Players = players;
            teamsWorldCupe.Add(franceTeam);

            var italyTeam = new Team();
            italyTeam.Name = "Italy";
            italyTeam.Players = players;
            teamsWorldCupe.Add(italyTeam);

            var argentinaTeam = new Team();
            argentinaTeam.Name = "Argentina";
            argentinaTeam.Players = players;
            teamsWorldCupe.Add(argentinaTeam);

            var australiaTeam = new Team();
            australiaTeam.Name = "Australia";
            australiaTeam.Players = players;
            teamsWorldCupe.Add(australiaTeam);

            return teamsWorldCupe;
        }


        public List<Game> getMatchesList()
        {

            //Match 1
            var mexicoTeam = new Team();
            mexicoTeam.City = "Mexico";
            mexicoTeam.Name = "RFC Mexico";
            mexicoTeam.Players = genarateTeamPlayers();
            mexicoTeam.Local = true;

            var canadaTeam = new Team();
            canadaTeam.City = "Canada";
            canadaTeam.Name = "RFC Canada";
            canadaTeam.Players = genarateTeamPlayers();

            DateTime startDateGameMexico = new DateTime(2022, 10, 12);

            List<Team> teamsMatchMexico = new List<Team>();
            teamsMatchMexico.Add(mexicoTeam);
            teamsMatchMexico.Add(canadaTeam);

            Game matchMexico = new Game();
            //matchMexico.GameId=0;
            matchMexico.Place = "Mexico";
            matchMexico.StartDate = startDateGameMexico;
            matchMexico.Teams = teamsMatchMexico;

            //Match 2
            var spainTeam = new Team();
            spainTeam.City = "Spain";
            spainTeam.Name = "RFC Spain";
            spainTeam.Players = genarateTeamPlayers();
            spainTeam.Local = true;

            var brazilTeam = new Team();
            brazilTeam.City = "Brazil";
            brazilTeam.Name = "RFC Brazil";
            brazilTeam.Players = genarateTeamPlayers();

            DateTime startDateMatchSpain = new DateTime(2022, 10, 13);

            List<Team> teamsMatchSpain = new List<Team>();
            teamsMatchSpain.Add(spainTeam);
            teamsMatchSpain.Add(brazilTeam);

            Game matchSpain = new Game();
            //matchSpain.GameId=1;
            matchSpain.Place = "Spain";
            matchSpain.StartDate = startDateMatchSpain;
            matchSpain.Teams = teamsMatchSpain;

            //Match 3
            var germanyTeam = new Team();
            germanyTeam.City = "Germany";
            germanyTeam.Name = "RFC Germany";
            germanyTeam.Players = genarateTeamPlayers();
            germanyTeam.Local = true;

            var franceTeam = new Team();
            franceTeam.City = "France";
            franceTeam.Name = "RFC France";
            franceTeam.Players = genarateTeamPlayers();

            DateTime startDateMatchGermany = new DateTime(2022, 10, 10);

            List<Team> teamsMatchGermany = new List<Team>();
            teamsMatchGermany.Add(germanyTeam);
            teamsMatchGermany.Add(franceTeam);

            Game matchGermany = new Game();
            //matchGermany.GameId=2;
            matchGermany.Place = "Germany";
            matchGermany.StartDate = startDateMatchGermany;
            matchGermany.Teams = teamsMatchGermany;

            //Match 4
            var uruguayTeam = new Team();
            uruguayTeam.City = "Uruguay";
            uruguayTeam.Name = "RFC Uruguay";
            uruguayTeam.Players = genarateTeamPlayers();
            uruguayTeam.Local = true;

            var italyTeam = new Team();
            italyTeam.City = "Italy";
            italyTeam.Name = "RFC Italy";
            italyTeam.Players = genarateTeamPlayers();

            DateTime startDateMatchUruguay = new DateTime(2022, 10, 14);

            List<Team> teamsMatchUruguay = new List<Team>();
            teamsMatchUruguay.Add(uruguayTeam);
            teamsMatchUruguay.Add(italyTeam);

            Game matchUruguay = new Game();
            //matchUruguay.GameId=3;
            matchUruguay.Place = "Uruguay";
            matchUruguay.StartDate = startDateMatchUruguay;
            matchUruguay.Teams = teamsMatchUruguay;

            //Match 5
            var argentinaTeam = new Team();
            argentinaTeam.City = "Argentina";
            argentinaTeam.Name = "RFC Argentina";
            argentinaTeam.Players = genarateTeamPlayers();
            argentinaTeam.Local = true;

            var australiaTeam = new Team();
            australiaTeam.City = "Australia";
            australiaTeam.Name = "RFC Australia";
            australiaTeam.Players = genarateTeamPlayers();

            DateTime startDateMatchArgentina = new DateTime(2022, 10, 11);

            List<Team> teamsMatchArgentina = new List<Team>();
            teamsMatchArgentina.Add(argentinaTeam);
            teamsMatchArgentina.Add(australiaTeam);

            Game matchArgentina = new Game();
            //matchArgentina.GameId=4;
            matchArgentina.Place = "Argentina";
            matchArgentina.StartDate = startDateMatchArgentina;
            matchArgentina.Teams = teamsMatchArgentina;

            matches.Add(matchMexico);
            matches.Add(matchSpain);
            matches.Add(matchGermany);
            matches.Add(matchUruguay);
            matches.Add(matchArgentina);

            return matches;
        }

    }
}