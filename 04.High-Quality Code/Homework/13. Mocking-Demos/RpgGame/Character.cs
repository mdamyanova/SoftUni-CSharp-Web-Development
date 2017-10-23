namespace RpgGame
{
    using System;
    using System.Collections.Generic;

    public class Character
    {
        private static Random random;
        private readonly List<Item> possibleItemDrops;

        public Character(List<Item> items, IRandomNumberProvider numberProvider)
        {
            this.RandomNumberProvider = numberProvider;
            random = new Random();
            this.possibleItemDrops = items;
        }

        public IRandomNumberProvider RandomNumberProvider { get; private set; }

        public Item DropItem()
        {
            var randomIndex = this.RandomNumberProvider.GetRandomNumber(0, this.possibleItemDrops.Count - 1);

            return this.possibleItemDrops[randomIndex];
        }
    }

    public interface IRandomNumberProvider
    {
        int GetRandomNumber(int min, int max);
    }

    public class RandomNumberProvider : IRandomNumberProvider
    {
        private readonly Random random;

        public RandomNumberProvider()
        {
            this.random = new Random();
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }
    }
}
