using Demo.API.Options;

namespace Demo.API.Tests;

public class InitialExtensionsUnitTests
{
    [Fact]
    public void GetAuthorInitialTest()
    {
        Person mann = Person.Create("Thomas", "Mann");
        Person aristotle = Person.Create("Aristotle");

        Book faustus = Book.Create("Doctor Faustus", mann);
        Book wittgenstein = Book.Create("Wittgenstein", aristotle);
        Book nights = Book.Create("One thousand and One Nights");

        var bookshelf = new[]
        {
            faustus, wittgenstein, nights
        };
        var ordered = bookshelf.GroupBy(book => book.GetAuthorInitial()
                .Reduce(string.Empty))
            .OrderBy(group => group.Key);

        foreach (var book in ordered)
        {
        }

        Assert.Equal("M", faustus.GetAuthorInitial().Reduce("-"));
        Assert.Equal("A", wittgenstein.GetAuthorInitial().Reduce("?"));
        Assert.Equal("?", nights.GetAuthorInitial().Reduce("?"));
        ;
    }
}