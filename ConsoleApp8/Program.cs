using System.ComponentModel.DataAnnotations;

Random random = new Random();
List<string> addresses = new List<string>()
{
    "Tehran",
    "Karaj",
    "Shiraz",
    "Tabriz",
    "Mashhad",
    "Isfahan"
};
List<Person> people = new List<Person>();
for (int i=1; i<=1000;i++)
{
    people.Add(new Person
    {
        Id = random.Next(1, 100000),
        Name = "Person"+i,
        Age = random.Next(15, 60),
        MailCode
        = random.Next(100, 200),
        Address = addresses[random.Next(addresses.Count)],
        BirthDate = new DateTime(random.Next(1990, 2010),
       random.Next(1, 13),
       random.Next(1, 28))
    });
    var resultA =
        from p in people
        where p.Age > 20
        orderby p.Name
        select p;
    var resultB = from p in people
                 where p.BirthDate.Year < 1999
                 select p;
    var resultC = from p in people
                  group p by p.BirthDate into g
                  where g.Count() > 1
                  from item in g
                  select item;
    var resultD = (from p in people
                   orderby p.Id
                   select p).Skip(3).Take(1);
    var resultE = (from p in people
                   orderby p.Id
                   select p).Skip(49).Take(31);
    int maxAge = (from p in people
                  select p.Age).Max();
    var resultF = from p in people
                  where p.Age == maxAge
                  select p;
    var resultG = from p in people
                  group p by p.MailCode into g
                  where g.Count() > 1
                  select g;
    var resultH = from p in people
                  where p.Address == "Tehran"
                  group p by p.Name into g
                  where g.Count() >= 2
                  from item in g
                  select item;
    var resultI = from p in people
                  where p.MailCode.ToString().Contains("123")
                  select p;
    var resultj = from p in people
                  where p.Age > 25
                  select new
                  {
                      p.MailCode,
                      p.Address
                  };
}
