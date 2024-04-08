using LegacyApp;
using DateTime = System.DateTime;

namespace LegacyAppTests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_FirstName_Is_Null()
    {
        //Arrange
        var userService = new UserService();
        var dateOfBirth = new DateTime(
            DateTime.Now.Year - 21, 
            DateTime.Now.Month, 
            DateTime.Now.Day
            );
        
        //Act
        var result = userService.AddUser(
            null, 
            "kowalski", 
            "kowalski@wp.pl", 
            dateOfBirth, 
            1
            );
        
        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_LastName_Is_Null()
    {
        //Arrange
        var userService = new UserService();
        var dateOfBirth = new DateTime(
            DateTime.Now.Year - 21, 
            DateTime.Now.Month, 
            DateTime.Now.Day
            );
        
        //Act
        var result = userService.AddUser(
            "Jan", 
            null, 
            "kowalski@wp.pl", 
            dateOfBirth, 
            1
            );

        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Not_Contains_At_And_Dot()
    {
        //Arrange
        var userService = new UserService();
        var dateOfBirth = new DateTime(
            DateTime.Now.Year - 21, 
            DateTime.Now.Month, 
            DateTime.Now.Day
            );
        
        //Act
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalskiwppl", 
            dateOfBirth, 
            1
            );
        
        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_If_Age_Is_Less_Than_21()
    {
        //Arrange
        var userService = new UserService();
        var dateOfBirth = new DateTime(
            DateTime.Now.Year - 21, 
            DateTime.Now.Month, 
            DateTime.Now.Day + 1
            );

        //Act
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@wp.pl", 
            dateOfBirth, 
            1
            );
        
        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Trow_Exception_When_Client_Does_Not_Exist()
    {
        //Arrange
        var userService = new UserService();
        var dateOfBirth = new DateTime(
            DateTime.Now.Year - 21, 
            DateTime.Now.Month, 
            DateTime.Now.Day
            );

        //Act
        Action act = () => userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@wp.pl", 
            dateOfBirth, 
            7
            );
        
        //Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Client_Type_Is_NormalClient_And_BreachedCreditLimit()
    {
        //Arrange
        var userService = new UserService();
        var dateOfBirth = new DateTime(
            DateTime.Now.Year - 21, 
            DateTime.Now.Month, 
            DateTime.Now.Day
        );
        
        //Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@kowal.com",
            dateOfBirth,
            1
        );
        
        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_True_When_Client_Type_Is_NormalClient_And_CreditLimit_Is_Not_Breached()
    {
        //Arrange
        var userService = new UserService();
        var dateOfBirth = new DateTime(
            DateTime.Now.Year - 21, 
            DateTime.Now.Month, 
            DateTime.Now.Day
        );
        
        //Act
        var result = userService.AddUser(
            "Jan",
            "Kwiatkowski",
            "kowalski@kowal.com",
            dateOfBirth,
            5
        );

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void AddUser_Should_Return_True_When_Client_Type_Is_ImportantClient_And_CreditLimit_Is_Not_Breached()
    {
        //Arrange
        var userService = new UserService();
        var dateOfBirth = new DateTime(
            DateTime.Now.Year - 21, 
            DateTime.Now.Month, 
            DateTime.Now.Day
        );
        
        //Act
        var result = userService.AddUser(
            "Jan",
            "Smith",
            "kowalski@kowal.com",
            dateOfBirth,
            3
        );

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void AddUser_Should_Return_True_When_Client_Type_Is_VeryImportantClient()
    {
        //Arrange
        var userService = new UserService();
        var dateOfBirth = new DateTime(
            DateTime.Now.Year - 21, 
            DateTime.Now.Month, 
            DateTime.Now.Day
        );

        //Act
        var result = userService.AddUser(
            "Jan",
            "Malewski",
            "kowalski@kowal.com",
            dateOfBirth,
            2
        );
        
        //Assert
        Assert.True(result);
    }

    [Fact]
    public void AddUser_Should_Throw_Exception_When_No_CreditLimit_Exists_For_User()
    {
        //Arrange
        var userService = new UserService();
        var dateOfBirth = new DateTime(
            DateTime.Now.Year - 21, 
            DateTime.Now.Month, 
            DateTime.Now.Day
        );
        
        //Act
        Action action = () => userService.AddUser(
            "Jan",
            "Iksinski",
            "kowalski@kowal.com",
            dateOfBirth,
            5
        );

        //Assert
        Assert.Throws<ArgumentException>(action);
    }
}