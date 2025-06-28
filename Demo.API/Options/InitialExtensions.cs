using Demo.API.Models;

namespace Demo.API.Options;

public static class InitialExtensions
{
    public static string GetInitial(Person person)
        => person.LastName.Map(GetInitial)
            .Reduce(GetInitial(person.FirstName));
    
    public static string GetInitial(string name)
        => name.Length == 0 ? string.Empty : name[0].ToString().ToUpper();

    public static Option<string> GetAuthorInitial(this Book book)
        => book.Author.Map(GetInitial);
}