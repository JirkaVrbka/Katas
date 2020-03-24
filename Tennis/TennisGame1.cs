namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int _player1Score = 0;
        private int _player2Score = 0;
        private readonly string _player1Name;
        private readonly string _player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name)
                _player1Score += 1;
            if (playerName == _player2Name)
                _player2Score += 1;
        }

        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            if (_player1Score == _player2Score)
            {
                switch (_player1Score)
                {
                    case 0:
                    case 1:
                    case 2:
                        score = $"{ScoreToString(_player1Score)}-All";
                        break;
                    default:
                        score = "Deuce";
                        break;
                }
            }
            else
            if (_player1Score >= 4 || _player2Score >= 4)
            {
                var minusResult = _player1Score - _player2Score;
                if (minusResult == 1) score = "Advantage player1";
                else if (minusResult == -1) score = "Advantage player2";
                else if (minusResult >= 2) score = "Win for player1";
                else score = "Win for player2";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = _player1Score;
                    else { score += "-"; tempScore = _player2Score; }

                    score += ScoreToString(tempScore);
                }
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
    }
}

