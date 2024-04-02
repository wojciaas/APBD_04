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
        var dateOfBirth = new DateTime(DateTime.Now.Year - 21, DateTime.Now.Month, DateTime.Now.Day);
        
        //Act
        var result = userService.AddUser(null, "kowalski", "kowalski@wp.pl", dateOfBirth, 1);
        
        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_LastName_Is_Null()
    {
        //Arrange
        var userService = new UserService();
        var dateOfBirth = new DateTime(DateTime.Now.Year - 21, DateTime.Now.Month, DateTime.Now.Day);
        
        //Act
        var result = userService.AddUser("Jan", null, "kowalski@wp.pl", dateOfBirth, 1);

        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Not_Contains_At_And_Dot()
    {
        //Arrange
        var userService = new UserService();
        var dateOfBirth = new DateTime(DateTime.Now.Year - 21, DateTime.Now.Month, DateTime.Now.Day);
        
        //Act
        var result = userService.AddUser("Jan", "Kowalski", "kowalskiwppl", dateOfBirth, 1);
        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_If_Age_Is_Less_Than_21()
    {
        //Arrange
        var userService = new UserService();
        var dateOfBirth = new DateTime(DateTime.Now.Year - 21,
                                            DateTime.Now.Month, 
                                            DateTime.Now.Day + 1);

        //Act
        var result = userService.AddUser("Jan", "Kowalski", "kowalski@wp.pl", dateOfBirth, 1);
        
        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Trow_Exception_When_Client_Does_Not_Exist()
    {
        //Arrange
        var userService = new UserService();
        var dateOfBirth = new DateTime(DateTime.Now.Year - 21, DateTime.Now.Month, DateTime.Now.Day);

        //Act
        Action act = () => userService.AddUser("Jan", "Kowalski", "kowalski@wp.pl", dateOfBirth, 7);
        
        //Assert
        Assert.Throws<ArgumentException>(act);
    }
    
    [Fact]
    
}