using System;
using System.Collections.Generic;
using System.Linq;

namespace VerifyExample
{
    public class PeopleRepository
    {
        public static readonly List<Person> People = new()
        {
            new(
                Id: new("ebced679-45d3-4653-8791-3d969c4a986c"),
                GivenNames: "Emmy",
                FamilyName: "Annachiara",
                DateOfBirth: new(2000, 1, 2, 3, 0, 0),
                Address: new(
                    Street: "924 Jehovah Drive",
                    City: "Strasburg",
                    State: "Virginia")),
            new(
                Id: new("7e6e1c62-92f2-4b64-8a85-988107458606"),
                GivenNames: "Javed",
                FamilyName: "Sargis",
                DateOfBirth: new(1998, 4, 2, 5, 0, 0),
                Address: new(
                    Street: "1587 Elliott Street",
                    City: "Manchester",
                    State: "New Hampshire"))
        };

        public Person GetById(Guid id)
        {
            return People.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            return People;
        }
    }

    public record Person(Guid Id, string GivenNames, string FamilyName, DateTime DateOfBirth, Address Address)
    {
        public string Description => $"{GivenNames} {FamilyName} ({Id})";
        public TimeSpan Age => DateTime.Now - DateOfBirth;
    }

    public record Address(string Street, string City, string State);
}
