using System;
using LegacyApp.Interfaces;

namespace LegacyApp;

public class UserManager
{
    private readonly IUserCreditService _userCreditService;
    
    public UserManager(IUserCreditService userCreditService)
    {
        _userCreditService = userCreditService;
    }

    public User CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Client client)
    {
        var user = new User
        {
            Client = client,
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            FirstName = firstName,
            LastName = lastName
        };
        
        SetCreditLimit(client, user);

        return user;
    }
    
    private void SetCreditLimit(Client client, User user)
    {
        if (client.Type == "VeryImportantClient")
        {
            user.HasCreditLimit = false;
        }
        else
        {
            user.HasCreditLimit = true;
            var creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            if (client.Type == "ImportantClient") creditLimit *= 2;
            user.CreditLimit = creditLimit;
        }
    }
}