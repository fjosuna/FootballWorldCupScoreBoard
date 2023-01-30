using FluentAssertions;
using FootballWorldCupScoreBoard.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FootballWorldCupScoreBoard.Test {
    public class GameShould {
        [TestClass]
        public class ScoreBoardShould
        {

            [TestMethod]
            public void WhenAGameIsCreated_CheckNamesTeamIsCorrectlyStore()
            {
                // When
                var game = Game.Create("homeTeam", "awayTeam");

                // Then
                game.AwayTeam.Should().Be("awayTeam");
                game.HomeTeam.Should().Be("homeTeam");
            }
            [TestMethod]
            public void GivenAGameWhenScoreGameIsUpdated_CheckIsCorrectlyStore()
            {
                var scoreHomeTeam = 2;
                var scoreAwayTeam = 3;
                var game = Game.Create("homeTeam", "awayTeam");

                game.UpdateScore(scoreAwayTeam, scoreHomeTeam);

                game.ScoreAwayTeam.Should().Be(scoreAwayTeam);
                game.ScoreHomeTeam.Should().Be(scoreHomeTeam);

                // Then
                game.AwayTeam.Should().Be("awayTeam");
                game.HomeTeam.Should().Be("homeTeam");
            }
        }
    }
}
