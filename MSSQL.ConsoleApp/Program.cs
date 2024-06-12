using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

//SqlConnection con = new("Data Source=TANER\\SQLEXPRESS;Initial Catalog=TestDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;");

//con.Open();

//SqlCommand cmd = new("Select * From Users", con);

//SqlDataReader reader = cmd.ExecuteReader();

//Console.ReadLine();



//RMDB
//MSSQL MYSQL PostgreSQl Oracle
//Object Relational Mapping



ApplicationDbContext context = new();
//List<User> users = 
//    context.Users
//    .Where(p => p.Name == "Taner")
//    .ToList(); //"select * from users"


//User? user = context.Users.FirstOrDefault();

//User user2 = context.Users.OrderBy(p=> p.Id).Last();

//User? user3 = context.Users.Where(p => p.Name == "Pınar").FirstOrDefault();

//List<User> users2 = context.Users.OrderBy(p => p.Id).ThenBy(p=> p.Name).ToList();

//HashSet<string> names = context.Users.Select(s=> s.Name).ToHashSet();

//List<User2> users3 = context.Users.Select(s => new User2
//{
//    Id = s.Id,
//    Name = s.Name,
//    LastName = "Saydam"
//}).ToList();

//User newUser = new();
//newUser.Id = 5;
//newUser.Name = "Toprak";

//context.Users.Add(newUser); //insert into Users value(@Id, @Name)

//context.SaveChanges();


//User updateUser = new()
//{
//    Id = 5,
//    Name = "Foo"
//};

//context.Users.Update(updateUser);
//context.SaveChanges();

//var users = context.Users.ToList();



//int id = 5;
//User? deleteUser = context.Users.Find(id);

//context.Users.Remove(deleteUser);

//context.SaveChanges();


//context.Remove(deleteUser);


//List<User> users = context.Users.ToList();

//context.Users.RemoveRange(users);
//context.SaveChanges();

//List<User> user2 = new()
//{
//    new User()
//    {
//        Name = "Taner"
//    },
//    new User()
//    {
//        Name = "Ahmet"
//    }
//};

//context.Users.AddRange(user2);
//context.SaveChanges();

//transaction



//context.Database.BeginTransaction();

try
{
    User user = new()
    {
        Id = 6,
        Name = "Nisa"
    };

    context.Users.Add(user);
    //context.SaveChanges();

    Product product = new()
    {
        Id = 1,
        Name = null
    };
    context.Products.Add(product);
    context.SaveChanges(); //21: 09 görüşelim

   // context.Database.CommitTransaction();
}
catch(Exception ex)
{
    Console.WriteLine("İşlem başarısız oldu!");
    //context.Database.RollbackTransaction();
}




Console.ReadLine();




public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=TANER\\SQLEXPRESS;Initial Catalog=TestDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}


public class User2 : User
{
    public string LastName { get; set; } = string.Empty;

}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}


public class TestContext
{
    public string? ConnectionString;

    public virtual void Connect(string connectionString)
    {
        ConnectionString = connectionString;

    }
}

public class MyDbContext : TestContext
{
    public override void Connect(string connectionString)
    {
        base.Connect(connectionString);

        connectionString = "taner";
    }
}