namespace _02.ExtendedDatabase
{
    public class Person
    {
        public Person(int id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public string Username { get; set; }

        public int Id { get; set; }
    }
}