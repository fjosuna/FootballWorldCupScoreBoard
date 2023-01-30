using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FluentAssertions;
using FootballWorldCupScoreBoard.Business;

namespace FootballWorldCupScoreBoard.Test {

    [TestClass]
    public class ScoreBoardShould
    {
        private ScoreBoard scoreBoard = new ScoreBoard();

        [TestMethod]
        public void GivenANewGameWhenStartGameCheckItIsAdded()
        {
            // Given
            var newGame = Game.Create("awayTeam", "homeTeam");

            // When
            scoreBoard.StartGame(newGame);

            // Then
            scoreBoard.games.Should().ContainEquivalentOf(newGame);
        }

        

        [TestMethod]
        public void GivenAnExistGameInBoardWhenFinishGameItShouldBeRemoveFromBoard()
        {
            // Given two games
            var aGame = Game.Create("homeTeam", "awayTeam");
            scoreBoard.StartGame(aGame);
            var aGameToRemove = Game.Create("homeTeamToRemove", "awayTeamToRemove");
            scoreBoard.StartGame(aGameToRemove);

            // When remove one
            scoreBoard.FinishGame(aGameToRemove);

            // Then check is removed one but not the another
            scoreBoard.games.Should().NotContainEquivalentOf(aGameToRemove);
            scoreBoard.games.Should().ContainEquivalentOf(aGame);
        }

        [TestMethod]
        public void GivenAGameWhenUpdateScoreCheckIfItsUpdated()
        {
            var homeTeam = "homeTeam";
            var awayTeam = "awayTeam";
            var aGivenGame = Game.Create(homeTeam, awayTeam);
            scoreBoard.StartGame(aGivenGame);
            var newScoreHomeTeam = 1;
            var newScoreAwayTeam = 2;

            scoreBoard.UpdateScore(aGivenGame, newScoreHomeTeam, newScoreAwayTeam);

            aGivenGame.ScoreHomeTeam.Should().Be(newScoreHomeTeam);
            aGivenGame.ScoreAwayTeam.Should().Be(newScoreAwayTeam);
        }

        
        [TestMethod]
        public void GivenSeveralGamesWhenGetGamesByTotalScoreDescCheckIfItsOk()
        {
            var aLowerScoreGame = Game.Create("team_score_1", "team_score_2");
            scoreBoard.StartGame(aLowerScoreGame);
            scoreBoard.UpdateScore(aLowerScoreGame, 2, 1);
            var aHigherScoreGame1StInserted = Game.Create("team_score3_first", "team_score4_first");
            scoreBoard.StartGame(aHigherScoreGame1StInserted);
            scoreBoard.UpdateScore(aHigherScoreGame1StInserted, 4, 3);
            var aHigherScoreGame2NdInserted = Game.Create("team_score3_second", "team_score4_second");
            scoreBoard.StartGame(aHigherScoreGame2NdInserted);
            scoreBoard.UpdateScore(aHigherScoreGame2NdInserted, 4, 3);

            var result= scoreBoard.GetGamesByTotalScoreDesc();
                
            result[0].Should().Be(aHigherScoreGame1StInserted);
            result[1].Should().Be(aHigherScoreGame2NdInserted);
            result[2].Should().Be(aLowerScoreGame);

        }
        [TestMethod]
        public void GivenAGameWhenUpdateScoreIfNotExistCheckRaiseError() {
            var homeTeam = "homeTeam";
            var awayTeam = "awayTeam";
            var aGivenGame = Game.Create(homeTeam, awayTeam);
            var newScoreHomeTeam = 1;
            var newScoreAwayTeam = 2;

            var result = Assert.ThrowsException<Exception>(() => scoreBoard.UpdateScore(aGivenGame, newScoreHomeTeam, newScoreAwayTeam));

            Assert.IsInstanceOfType(result, typeof(Exception));
        }

        [TestMethod]
        public void GivenAGameAlreadyCreatedWhenStartGameCheckRaiseError() {
            var aGame = Game.Create("homeTeam", "awayTeam");
            scoreBoard.StartGame(aGame);

            var result = Assert.ThrowsException<Exception>(() => scoreBoard.StartGame(aGame));

            Assert.IsInstanceOfType(result, typeof(Exception));
        }
        [TestMethod]
        public void WhenFinalizeGameNotExistsCheckRaiseError() {
            var aGame = Game.Create("homeTeam", "awayTeam");

            var result = Assert.ThrowsException<Exception>(() => scoreBoard.FinishGame(aGame));

            Assert.IsInstanceOfType(result, typeof(Exception));
        }
    }
}