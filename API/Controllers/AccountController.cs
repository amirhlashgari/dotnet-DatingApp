using System;
using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AccountController(ApplicationDbContext context) : BaseApiController
{
    [HttpPost("register")] // POST:api/account/register
    public async Task<ActionResult<AppUser>> Register(string email, string displayName, string password)
    {
        // now with this type it accepts query params as service inputs, should create DTO and object
        using var hmac = new HMACSHA512(); // USING means the parameter should be disposed after it is used and we should not be worried about its garbage collection 
        var user = new AppUser
        {
            DisplayName = displayName,
            Email = email,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            PasswordSalt = hmac.Key
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return user;
    }
}
