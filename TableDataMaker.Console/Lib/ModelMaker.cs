using System;

namespace TableDataMaker.ConsoleApp.Lib
{
    public static class ModelMaker
    {
        private static Random Dice = new Random();

        public static Models.PersonEntity PersonMake()
        {
            var gender  = Faker.Name.Gender();
            var nameLast = Faker.Name.LastName();
            var nameFirst = string.Empty;

            if (gender.ToLowerInvariant().StartsWith("f"))
            {
                nameFirst = Faker.Name.FemaleFirstName();
            }
            else
            {
                nameFirst = Faker.Name.MaleFirstName();
            }

            var person = new Models.PersonEntity(nameLast, nameFirst);

            person.Gender = gender;

            person.Birthday = Faker.Date.Birthday();
            person.EMail = Faker.User.Email();
            person.NameLast = Faker.Name.LastName();

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