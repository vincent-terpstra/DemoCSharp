using Demo.API.Options;

namespace Demo.API.Models;

public class Book
{
    public string Title { get; init; }
    public Option<Person> Author { get; init; }
    
    private Book(string title, Option<Person> author)
        => (Title, Author) = (title, author);
    
    public static Book Create(string title, Person? author = null)
        => new(title, Option<Person>.Create(author));
}