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

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            p1point = 0;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = "";
            
            p1res = ScoreToString(p1point);
            p2res = ScoreToString(p2point);
            
            if (p1point == p2point && p1point < 3)
            {
                score = $"{p1res}-All";
            }
            if (p1point == p2point && p1point > 2)
                score = "Deuce";

            if (p1point > 0 && p2point == 0
            || p2point > 0 && p1point == 0
            || p1point > p2point && p1point < 4
            || p2point > p1point && p2point < 4)
            {
                score = $"{p1res}-{p2res}";
            }

            if (p1point > p2point && p2point >= 3)
            {
                score = "Advantage player1";
            }

            if (p2point > p1point && p1point >= 3)
            {
                score = "Advantage player2";
            }

            if (p1point >= 4 && p2point >= 0 && (p1point - p2point) >= 2)
            {
                score = "Win for player1";
            }
            if (p2point >= 4 && p1point >= 0 && (p2point - p1point) >= 2)
            {
                score = "Win for player2";
            }
            return score;
        }
        
        private string ScoreToString(int scoreNum)
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

