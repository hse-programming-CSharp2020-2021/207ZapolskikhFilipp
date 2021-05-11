namespace DataBaseTask2
{
    interface IEntityFactory<out T>
    {
        T Instance { get; }
    }
}
