using System;

namespace LegacyApp;

public class UserValidator
{
    private const int MinimumAge = 21;
    private const int MinimumCreditLimit = 500;
    public static bool Validate_Name(string name, string surname)
    {
        return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname);
    }
    
    public static bool Validate_Email(string email)
    {
        return email.Contains('@') && email.Contains('.');
    }
    
    public static bool Validate_Age(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        var age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
        return age >= MinimumAge;
    }
    
    public static bool Is_Credit_Limit_Required(User user)
    {
        return user.HasCreditLimit && user.CreditLimit < MinimumCreditLimit;
    }
    
}