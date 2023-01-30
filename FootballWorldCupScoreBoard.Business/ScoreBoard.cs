using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("FootballWorldCupScoreBoard.Test")]
namespace FootballWorldCupScoreBoard.Business {
    public class ScoreBoard {
        internal List<Game> games { get; set; }

        public ScoreBoard()
        {
            games = new List<Game>();
        }
       
        public void StartGame(Game newGame)
        {
            if (Find(newGame) != null)
                throw new Exception("Game already exists");
            games.Add(newGame);
        }

        public void FinishGame(Game aGame)
        {
            var gameToRemove = Find(aGame);
            if (gameToRemove == null)
                throw new Exception("Game not exists");
            games.Remove(gameToRemove);
        }

        private Game Find(Game game) {
            return games.Where(g => g.AwayTeam == game.AwayTeam && g.HomeTeam == game.HomeTeam)
                .ToList()
                .FirstOrDefault();
        }
        public void UpdateScore(Game game, int scoreHomeTeam, int scoreAwayTeam) {
            var gameToUpdate = Find(game);
            if (gameToUpdate == null)
                throw new Exception("Game have not found");
            gameToUpdate.UpdateScore(scoreAwayTeam,scoreHomeTeam);
        }

        public List<Game> GetGamesByTotalScoreDesc()
        {
            return games.OrderByDescending(g => g.ScoreAwayTeam + g.ScoreHomeTeam)
                .ThenBy(g=> g.Inserted)
                        .ToList();
        }
    }
}
