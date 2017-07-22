namespace _11.Tuple
{
    public class Tuple<T1, T2>
    {
        public Tuple()
        {
            
        }

        public T1 Item1 { get; set; }

        public T2 Item2 { get; set; }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2}";
        }
    }
}