using System.Collections;
using System.Collections.Generic;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        public Lake(List<int> stones)
        {
            this.Stones = stones;
        }

        public List<int> Stones { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.Stones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return this.Stones[i];
                }
            }

            for (int i = this.Stones.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.Stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}