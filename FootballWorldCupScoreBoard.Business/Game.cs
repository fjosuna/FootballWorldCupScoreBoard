
using System;

namespace FootballWorldCupScoreBoard.Business {
    public class Game {
        private DateTime _Inserted { get; set; }
        private string _HomeTeam { get;  set; }

        private string _AwayTeam { get; set; }

        private int _ScoreHomeTeam { get; set; }

        private int _ScoreAwayTeam { get; set; }

        public string HomeTeam
        {
            get { return _HomeTeam; }
        }

        public string AwayTeam
        {
            get { return _AwayTeam; }
        }

        public int ScoreHomeTeam
        {
            get {  return _ScoreHomeTeam; }
        }

        public int ScoreAwayTeam
        {
            get  {  return _ScoreAwayTeam; }
        }
        public DateTime Inserted
        {
            get { return _Inserted; }
        }
        private Game(string homeTeam, string awayTeam)
        {
            _HomeTeam = homeTeam;
            _AwayTeam = awayTeam;
            _ScoreHomeTeam = 0;
            _ScoreAwayTeam = 0;
            _Inserted = DateTime.UtcNow;
        }

        public static Game Create(string homeTeam, string awayTeam)
        {
            return new Game(homeTeam, awayTeam);
        }

        public void UpdateScore(int scoreAwayTeam, int scoreHomeTeam)
        {
            _ScoreHomeTeam = scoreHomeTeam;
            _ScoreAwayTeam = scoreAwayTeam;
        }
    }
}
