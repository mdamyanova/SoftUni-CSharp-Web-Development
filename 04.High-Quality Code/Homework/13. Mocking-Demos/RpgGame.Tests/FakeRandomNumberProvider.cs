namespace RpgGame.Tests
{
    public class FakeRandomNumberProvider : IRandomNumberProvider
    {
        public int GetRandomNumber(int min, int max)
        {
            return 0;
        }
    }
}