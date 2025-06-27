using Demo.API.Options;

namespace Demo.API.Models;

public class Person
{
    public string FirstName { get; init; }
    public Option<string> LastName { get; init; }

    private Person(string firstName, Option<string> lastName)
        => (FirstName, LastName) = (firstName, lastName);

    public static Person Create(string firstName)
        => new(firstName, Option<string>.None());

    public static Person Create(string firstName, string lastName)
        => new(firstName, Option<string>.Some(lastName));

    public override string ToString() =>
        LastName
            .Map(lastName => $"{FirstName} {lastName}")
            .Reduce($"{FirstName}");
}