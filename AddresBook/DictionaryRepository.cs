using AddresBook.Models;

namespace AddresBook
{
    public class DictionaryRepository : IRepository<Person>
    {
        private readonly Dictionary<int, Person> addressBook = new();
        private int index = 0;

        public DictionaryRepository()
        {
            List<Person> persons = new()
            { 
                new Person
                {
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1990, 5, 15),
                    Email = "johndoe@example.com"
                },
                new Person
                {
                    FirstName = "Alice",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1985, 10, 8),
                    Email = "alicesmith@example.com"
                },
                new Person
                {
                    FirstName = "Michael",
                    LastName = "Johnson",
                    DateOfBirth = new DateTime(1982, 3, 22),
                    Email = "michaeljohnson@example.com"
                },
                new Person
                {
                    FirstName = "Emily",
                    LastName = "Brown",
                    DateOfBirth = new DateTime(1993, 7, 4),
                    Email = "emilybrown@example.com"
                },
                new Person
                {
                    FirstName = "Daniel",
                    LastName = "Taylor",
                    DateOfBirth = new DateTime(1988, 12, 18),
                    Email = "danieltaylor@example.com"
                }
            };
            foreach (var person in persons)
            {
                Add(person);
            }
        }

        public Person Add(Person item)
        {
            item.Id= ++index;
            addressBook.Add(index, item);
            return item;
        }

        public Person Delete(Person item)
        {
            addressBook.Remove(item.Id);
            return item;
        }

        public IEnumerable<Person> GetAll()
        {
            return addressBook.Values;
        }

        public Person Read(int id)
        {
            if (addressBook.TryGetValue(id, out var person))
            {
                return person;
            }
            throw new KeyNotFoundException();
        }

        public bool Update(Person item)
        {
            if (addressBook.ContainsKey(item.Id))
            {
                addressBook[item.Id] = item;
                return true;
            }
            return false;
        }
    }
}
