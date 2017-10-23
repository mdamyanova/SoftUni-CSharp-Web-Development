namespace RpgGame
{
    public class Item
    {
        public Item(string name, int attackPoints, int defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
        }

        public string Name { get; set; }

        public int AttackPoints { get; set; }

        public int DefensePoints { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - AP: {1}, DP: {2}",
                this.Name, this.AttackPoints, this.DefensePoints);
        }
    }
}
