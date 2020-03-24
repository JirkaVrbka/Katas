using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _p1Point;
        private int _p2Point;

        private readonly string _player1Name;
        private readonly string _player2Name;

        private readonly List<Tuple<Func<int, int, bool>, Func<int, int, string>>> _judge =
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
            this._player1Name = player1Name;
            this._player2Name = player2Name;
        }

        public string GetScore()
        {
            return _judge.First(j => j.Item1.Invoke(_p1Point, _p2Point)).Item2.Invoke(_p1Point, _p2Point);
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
            if (player == _player1Name)
                _p1Point++;
            if (player == _player2Name)
                _p2Point++;
        }

    }
}

