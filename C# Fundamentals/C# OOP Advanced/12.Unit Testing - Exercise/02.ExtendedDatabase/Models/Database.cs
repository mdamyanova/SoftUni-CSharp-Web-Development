using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _02.ExtendedDatabase.Models
{
    public class Database
    {
        private const int DataCapacity = 16;
        private List<Person> data;

        public Database(params Person[] people)
        {
            if (people.Length <= DataCapacity)
            {
                this.Data = new List<Person>(people);
            }
            else
            {
                throw new InvalidOperationException($"People can't be more than {DataCapacity} characters long.");
            }
        }

        public List<Person> Data
        {
            get => data;
            set
            {
                if (value.Count > DataCapacity)
                {
                    throw new InvalidOperationException("Data can't be more than 16 integers.");
                }

                this.data = value;
            }
        }

        public int Count => this.Data.Count;

        public void Add(Person person)
        {
            if (this.Data.Count >= DataCapacity)
            {
                throw new InvalidOperationException("Can't add more elements.");
            }
            if (this.Data.Any(p => p.Id == person.Id))
            {
                throw new InvalidOperationException("There's already a person with this id.");
            }
            if (this.Data.Any(p => p.Username == person.Username))
            {
                throw new InvalidOperationException("There's already a person with this username.");
            }
            
            this.Data.Add(person);
        }

        public void Remove()
        {
            if (this.Data.Count == 0 || this.Data == null)
            {
                throw new InvalidOperationException("Data is empty.");
            }

            this.Data.Remove(this.Data[this.Data.Count - 1]);
        }

        public Person FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException(nameof(username), "Person can't be null.");
            }
            if (this.Data.All(p => p.Username != username))
            {
                throw new InvalidOperationException("There's no user with this username.");
            }

            return this.Data.FirstOrDefault(p => p.Username == username);
        }

        public Person FindById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id can't be negative.");
            }
            if (this.Data.All(p => p.Id != id))
            {
                throw new InvalidOperationException("There's no user with this id.");
            }

            return this.data.FindLast(p => p.Id == id);
        }
    }
}