using BowlingBall;
using Xunit;

namespace BowlingBallTest
{
    public class GamesFixture
    {
        private Games game = new Games();

        public GamesFixture()
        {
            game = new Games();
        }

        [Fact(DisplayName = " This is test will always pass.")]
        public void DummyTest()
        {

        }

        [Fact(DisplayName = "Get total score")]
        public void HappyPath()
        {
            int[] score = { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 };
            for (var i = 0; i < score.Length; i++)
            {
                game.Roll(score[i]);
            }

            Assert.Equal(187, game.GetTotalScore());
        }

        [Fact(DisplayName = "Test to validate total score when each roll is a strike")]
        public void AllStrikeTest()
        {
            for (var i = 0; i < 12; i++)
                game.Roll(10);

            Assert.Equal(300, game.GetTotalScore());
        }

        [Fact(DisplayName = "Test to validate total score when each roll is a spare")]
        public void AllSpares()
        {
            for (var i = 0; i < 21; i++)
                game.Roll(5);
            Assert.Equal(150, game.GetTotalScore());
        }

        [Fact(DisplayName = "Test to validate total score when each roll is zero ")]
        public void RollWithAllZero()
        {
            for (var i = 0; i < 20; i++)
                game.Roll(0);
            Assert.Equal(0, game.GetTotalScore());
        }
    }
}

