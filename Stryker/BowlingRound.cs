namespace Stryker
{
    public class BowlingRound
    {
        public BowlingRound(Random rng)
        {
            _rng = rng;
        }

        private int _throwsUsed = 0;

        private int _pinsKnockedDown = 0;

        private readonly Random _rng = new();

        public void DoThrowBall()
        {
            if (_throwsUsed >= 2) {
                throw new InvalidOperationException("You can't throw the ball any more!");
            }

            if (_pinsKnockedDown >= 10)
            {
                throw new InvalidOperationException("You've already knocked down all the pins!");
            }

            var pinsToKnockDown = _rng.Next(0, 10 - _pinsKnockedDown);
            _pinsKnockedDown += pinsToKnockDown;
            _throwsUsed++;
        }

        public int GetScore()
        {
            return _pinsKnockedDown;
        }

        public void Reset()
        {
            _throwsUsed = 0;
            _pinsKnockedDown = 0;
        }
    }
}