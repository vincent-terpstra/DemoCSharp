namespace Demo.API.Options;

public static class Initial
{
    internal static string GetInitial(Person person)
        => person.LastName.Map(GetInitial)
            .Reduce(GetInitial(person.FirstName));
    
    internal static string GetInitial(string name)
        => name.Length == 0 ? string.Empty : name[0].ToString().ToUpper();
}