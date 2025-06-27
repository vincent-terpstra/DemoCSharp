using Demo.API.Options;

namespace Demo.API.Tests;

public class InitialUnitTests
{
    static Person _mann = Person.Create("Thomas", "Mann");
    static Person _aristotle = Person.Create("Aristotle");
    
    static Book _faustus = Book.Create("Doctor Faustus", _mann);
    static Book _wittgenstein = Book.Create("Wittgenstein", _aristotle);
    static Book _nights = Book.Create("One thousand and One Nights");
    
    [Fact]
    public void GetAuthorInitialTest()
    {
        Assert.Equal("M", _faustus.GetAuthorInitial("-"));
        Assert.Equal("A", _wittgenstein.GetAuthorInitial("?"));
        Assert.Equal("?", _nights.GetAuthorInitial("?"));
    }
}