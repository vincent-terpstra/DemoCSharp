using Demo.API.Models;

namespace Demo.API.Options;

public static class Initial
{
    public static string GetInitial(Person person)
        => person.LastName.Map(GetInitial)
            .Reduce(GetInitial(person.FirstName));
    
    public static string GetInitial(string name)
        => name.Length == 0 ? string.Empty : name[0].ToString().ToUpper();
    
    public static string GetAuthorInitial(this Book book, string @default)
        => book.Author.Map(GetInitial)
            .Reduce(@default);
}