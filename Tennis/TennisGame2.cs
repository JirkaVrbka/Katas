using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string p1res = "";
        private string p2res = "";

        private string player1Name;

        private string player2Name;

        private List<Tuple<Func<int, int, bool>, Func<int, int, string>>> judge =
            new List<Tuple<Func<int, int, bool>, Func<int, int, string>>>
            {
                new Tuple<Func<int, int, bool>, Func<int, int, string>>
                ((p1, p2) => p1 == p2 && p1 < 3, 
                    (p1, p2) => $"{ScoreToString(p1)}-All"),
                new Tuple<Func<int, int, bool>, Func<int, int, string>>
                ((p1, p2) => p1 == p2 && p1 > 2, 
                    (p1, p2) => "Deuce"),
                new Tuple<Func<int, int, bool>, Func<int, int, string>>
                ((p1, p2) => p1 >= 4 && p2 >= 0 && (p1 - p2) >= 2, 
                    (p1, p2) => "Win for player1"),
                new Tuple<Func<int, int, bool>, Func<int, int, string>>
                    ((p1, p2) => p2 >= 4 && p1 >= 0 && (p2 - p1) >= 2, 
                    (p1, p2) => "Win for player2"),
                new Tuple<Func<int, int, bool>, Func<int, int, string>>
                    ((p1, p2) => p1 > p2 && p2 >= 3, 
                    (p1, p2) => "Advantage player1"),
                new Tuple<Func<int, int, bool>, Func<int, int, string>>
                    ((p1, p2) => p2 > p1 && p1 >= 3, 
                    (p1, p2) => "Advantage player2"),
                new Tuple<Func<int, int, bool>, Func<int, int, string>>
                    ((p1, p2) => true, 
                    (p1, p2) => $"{ScoreToString(p1)}-{ScoreToString(p2)}"),
            };

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            p1point = 0;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            return judge.First(j => j.Item1.Invoke(p1point, p2point)).Item2.Invoke(p1point, p2point);
        }
        
        private static string ScoreToString(int scoreNum)
        {
            switch (scoreNum)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                default:
                    return "Forty";
            }
        }

        public void WonPoint(string player)
        {
            if (player == player1Name)
                p1point++;
            if (player == player2Name)
                p2point++;
        }

    }
}

