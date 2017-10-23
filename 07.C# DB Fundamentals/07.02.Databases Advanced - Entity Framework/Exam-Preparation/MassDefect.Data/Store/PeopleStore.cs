using System;
using System.Collections.Generic;
using System.Linq;
using MassDefect.Data.DTO;
using MassDefect.Model;

namespace MassDefect.Data.Store
{
    public static class PeopleStore
    {
        public static void AddPeople(IEnumerable<PersonDto> people)
        {
            using (var context = new MassDefectContext())
            {
                foreach (var personDto in people)
                {
                    if (personDto.Name == null || personDto.HomePlanet == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        var planet = PlanetStore.GetPlanetByName(personDto.HomePlanet);

                        if (planet == null)
                        {
                            Console.WriteLine("Error: Invalid data.");
                        }
                        else
                        {
                            var person = new Person()
                            {
                                Name = personDto.Name,
                                HomePlanetId = planet.Id
                            };
                            context.People.Add(person);
                            Console.WriteLine($"Successfully imported Person {person.Name}.");
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        public static Person GetPersonByName(string name)
        {
            using (var context = new MassDefectContext())
            {
                return context.People.FirstOrDefault(p => p.Name == name);
            }
        }
    }
}