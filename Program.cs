using EFCryptography;

using (EfCryptographyContext context = new())
{
    User user = new("martinho@mas.ao", "D@tN#t7");

    // Criar o banco de dados caso não exista
    context.Database.EnsureCreated();

    context.Add(user);
    await context.SaveChangesAsync();

    string name = user.GetName();
    Console.WriteLine($"Hello {name}, .NET Core is life!");

    var _user = context.Users.FirstOrDefault();

    Console.WriteLine($"Password from Database is {_user?.Password}");
}





