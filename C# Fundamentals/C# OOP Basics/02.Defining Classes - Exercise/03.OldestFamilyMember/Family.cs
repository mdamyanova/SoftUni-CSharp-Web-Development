using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> people;

    public Family()
    {
        this.people = new List<Person>();
    }

    public List<Person> People { get; set; }

    public void AddMember(Person member)
    {
        people.Add(member);
    }

    public Person GetOldestMember()
    {
        var maxAge = people.Select(a => a.Age).Max();
        return people.FirstOrDefault(p => p.Age == maxAge);

    }
}