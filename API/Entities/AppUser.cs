using System; // to say where the class is coming from and from where it should read its config. could be removed

namespace API.Entities; // seperates different pieces of code, we could have another AppUser in another namespace

public class AppUser
{
    // public int MyProperty { get; set; } ---> auto implemented property that has getter setter, private only inside class, protected from class and derived subclasses.
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string DisplayName { get; set; }
    public required string Email { get; set; }
    
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
}

// Update Migration CLI Command: dotnet ef migrations add UserEntityUpdated
// Database Update: dotnet ef database update