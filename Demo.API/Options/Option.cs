namespace Demo.API.Options;

public readonly struct Option<T> where T : class
{
    private readonly T? _content;

    private Option(T? content = null) =>
        (_content) = (content);

    public static Option<T> Some(T value)
        => new(value);

    public static Option<T> None()
        => new();
    
    public static Option<T> Create(T? value)
        => value is null ? None() : Some(value);

    public Option<TResult> Map<TResult>(Func<T, TResult> map)
        where TResult : class =>
        new(_content is null ? null : map(_content));

    public T Reduce(T @default)
        => _content ?? @default;
}