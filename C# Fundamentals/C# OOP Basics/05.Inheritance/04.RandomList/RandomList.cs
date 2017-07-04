using System;
using System.Collections;
using System.Collections.Generic;

public class RandomList : ArrayList
{
    private Random rnd;
    private List<string> data;

    public RandomList()
    {
        this.data = new List<string>();
    }

    public string RandomString()
    {
        var element = rnd.Next(0, data.Count - 1);
        var str = data[element];
        data.Remove(str);

        return str;
    }
}