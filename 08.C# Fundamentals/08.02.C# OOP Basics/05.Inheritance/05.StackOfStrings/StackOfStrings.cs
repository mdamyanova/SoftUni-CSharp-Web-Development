using System;
using System.Collections.Generic;
using System.Linq;

public class StackOfStrings
{
    private List<string> data;

    public void Push(string item)
    {
        this.data.Add(item);   
    }

    public string Pop()
    {
        if (this.data.Count != 0)
        {
            var item = this.data.Last();
            this.data.Remove(item);

            return item;
        }

        throw new ArgumentNullException("Stack is empty");
    }

    public string Peek()
    {
         if (this.data.Count != 0)
        {
            var item = this.data.Last();

            return item;
        }

        throw new ArgumentNullException("Stack is empty");
    }

    public bool IsEmpty()
    {
        return data.Count == 0;
    }
}