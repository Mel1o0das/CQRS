namespace Domain.Abstractions;

public interface IEntity<T> : IEntity
{
    public T Id { get; }
}

public interface IEntity
{

}