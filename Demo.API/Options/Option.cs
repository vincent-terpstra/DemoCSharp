namespace Demo.API.Options;

public sealed class None<T> : Option<T>
    where T : class
{
    public override Option<TResult> Map<TResult>(Func<T, TResult> map)
        => Option<TResult>.None();

    public override T Reduce(T @default)
        => @default;

    public override T Reduce(Func<T> @default)
        => @default();

    public override bool Equals(Option<T>? other)
        => false;

    public override int GetHashCode()
        => 0;
}

public sealed class Some<T> : Option<T>
    where T : class
{
    private readonly T _value;

    public Some(T value)
        => _value = value;

    public override Option<TResult> Map<TResult>(Func<T, TResult> map)
        => Option<TResult>.Some(map(_value));

    public override T Reduce(T @default)
        => _value;

    public override T Reduce(Func<T> @default)
        => _value;

    public override bool Equals(Option<T>? other)
        => other is Some<T> some && _value.Equals(some._value);
    
    public override int GetHashCode()
        => _value.GetHashCode();
}

public abstract class Option<T>
    : IEquatable<Option<T>>
    where T : class
{
    public static Option<T> Some(T value)
        => new Some<T>(value);

    public static Option<T> None()
        => new None<T>();

    public static Option<T> Create(T? value)
        => value is null ? None() : Some(value);

    public abstract Option<TResult> Map<TResult>(Func<T, TResult> map)
        where TResult : class;

    public abstract T Reduce(T @default);

    public abstract T Reduce(Func<T> @default);
    public abstract bool Equals(Option<T>? other);
}