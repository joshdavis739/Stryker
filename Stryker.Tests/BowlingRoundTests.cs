using System;
using Moq;
using Xunit;

namespace Stryker.Tests
{
    public class BowlingRoundTests
    {
        private readonly Mock<Random> _badLuck = new();
        private readonly Mock<Random> _hax = new();

        public BowlingRoundTests()
        {
            _badLuck
                .Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(0);

            _hax
                .Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(10);
        }

        [Fact]
        public void DoThrowBall_ShouldThrowInvalidOperationException_IfAttemptingToThrowThreeTimes()
        {
            var sut = new BowlingRound(_badLuck.Object);

            sut.DoThrowBall();
            sut.DoThrowBall();

            Assert.Throws<InvalidOperationException>(() => sut.DoThrowBall());
        }

        [Fact]
        public void DoThrowBall_ShouldThrowInvalidOperationException_IfYouAcedItOnTheFirstThrow()
        {
            var sut = new BowlingRound(_hax.Object);

            sut.DoThrowBall();

            Assert.Throws<InvalidOperationException>(() => sut.DoThrowBall());
        }

        [Fact]
        public void Reset_ShouldSetScoreToZero()
        {
            var sut = new BowlingRound(_hax.Object);

            sut.DoThrowBall();
            sut.Reset();

            Assert.Equal(0, sut.GetScore());
        }
    }
}