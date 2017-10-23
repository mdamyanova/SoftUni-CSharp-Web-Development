using System;
using System.Collections.Generic;
using System.Linq;

public class CoffeeMachine
{
    public CoffeeMachine()
    {
        this.Coins = new List<Coin>();
        this.CoffeesSold = new List<CoffeeType>();
    }

    public IList<Coin> Coins { get; }
    public IList<CoffeeType> CoffeesSold { get; }

    public void BuyCoffee(string size, string type)
    {
        var prize = (int) Enum.Parse(typeof(CoffeePrice), size);
        if (this.Coins.Sum(c => (int) c) >= prize)
        {
            var cofType = (CoffeeType) Enum.Parse(typeof(CoffeeType), type);

            this.CoffeesSold.Add(cofType);

            this.Coins.Clear();
        }
    }

    public void InsertCoin(string coin)
    {
        var currentCoin = (Coin) Enum.Parse(typeof(Coin), coin);
        this.Coins.Add(currentCoin);
    }
}