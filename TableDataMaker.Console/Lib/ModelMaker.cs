using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableDataMaker.ConsoleApp.Lib
{
    public static class ModelMaker
    {
        private static Random Dice = new Random();

        public static Models.PersonEntity PersonMake()
        {
            var id = Guid.NewGuid();
            var person = new Models.PersonEntity(id)
            {
                
                Birthday = Faker.Date.Birthday(),
                EMail = Faker.User.Email(),
                NameLast = Faker.Name.LastName()
            };

            person.Gender = Faker.Name.Gender();
            if (person.Gender.ToLowerInvariant().StartsWith("f"))
            {
                person.NameFirst = Faker.Name.FemaleFirstName();
            }
            else
            {
                person.NameFirst = Faker.Name.MaleFirstName();
            }

            person.Company = person.EMail.Substring(person.EMail.IndexOf('@') + 1);

            person.EMail = string.Format("{0}.{1}@{2}", person.NameFirst, person.NameLast, person.Company);

            person.Address1 = string.Format("{0} {1} {2}", Faker.Number.RandomNumber(101, 8888), Faker.Address.StreetName(), Faker.Address.StreetSuffix());

            if (Dice.Next(1, 100) > 70)
            {
                person.Address2 = string.Format("Appt. {0}", Dice.Next(2, 204));
            }

            person.City = Faker.Address.USCity();
            person.State = Faker.Address.StateAbbreviation();
            person.Zip = Faker.Address.USZipCode();

            return person;
        }
    }
}