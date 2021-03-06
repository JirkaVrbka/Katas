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
            if (_player1Score == _player2Score)
                return GetScoreWhenEqual();

            if (_player1Score >= 4 || _player2Score >= 4)
                return GetScoreWhenOverFour();
                
            return $"{ScoreToString(_player1Score)}-{ScoreToString(_player2Score)}";
        }

        private string GetScoreWhenOverFour()
        {
            var minusResult = _player1Score - _player2Score;
            if (minusResult == 1) 
                return "Advantage player1";
            if (minusResult == -1) 
                return "Advantage player2";
            if (minusResult >= 2) 
                return "Win for player1";
            return "Win for player2";
        }

        private string GetScoreWhenEqual()
        {
            switch (_player1Score)
            {
                case 0:
                case 1:
                case 2:
                    return $"{ScoreToString(_player1Score)}-All";
                default:
                    return "Deuce";
            }
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

