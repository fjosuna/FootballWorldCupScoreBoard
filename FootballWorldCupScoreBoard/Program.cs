
using FootballWorldCupScoreBoard.Business;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace FootballWorldCupScoreBoard {
    class Program {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<ScoreBoard>()
                .AddScoped<Game>()
                .BuildServiceProvider();


            var scoreBoard = serviceProvider.GetService<ScoreBoard>();

            int option = 0;
            do
            {
                PrintMenu();

                option = Convert.ToInt32(Console.ReadLine());
                try
                {
                    switch (option) {
                        case 1:
                            scoreBoard.StartGame(GetGame());
                            break;
                        case 2:
                            var game = GetGame();
                            UpdateScoreGame(scoreBoard, game);
                            break;
                        case 3:
                            var games = scoreBoard.GetGamesByTotalScoreDesc();
                            Print(games);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
                

            } while (option != 0);
        }

        private static void PrintMenu()
        {
            Console.WriteLine("0 .- Exit of program");
            Console.WriteLine("1 .- Start a game");
            Console.WriteLine("2 .- Update a score game");
            Console.WriteLine("3 .- Get summary");
        }

        private static void UpdateScoreGame(ScoreBoard scoreBoard, Game game)
        {
            Console.WriteLine("New score home team: ");
            int scoreHomeTeam = Convert.ToInt32(Console.ReadLine());
            ;
            Console.WriteLine("New score away team: ");
            int scoreAwayTeam = Convert.ToInt32(Console.ReadLine());
            ;
            scoreBoard.UpdateScore(game, scoreHomeTeam, scoreAwayTeam);
        }

        private static void Print(List<Game> games) {
            foreach (var game in games) {
                Console.WriteLine(game.HomeTeam + " " + game.ScoreHomeTeam + " - " + game.AwayTeam + " " + game.ScoreAwayTeam);
            }
        }

        static Game GetGame()
        {
            Console.WriteLine("Home team: ");
            string homeTeam = Console.ReadLine();
            Console.WriteLine("Away team: ");
            string awayTeam = Console.ReadLine();
            return Game.Create(homeTeam, awayTeam);
        }

    }
}
