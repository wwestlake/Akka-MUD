using LiteDB;

namespace LagDaemon.Akka_MUD.Core.Storage
{
    public interface IDataContext<T>
    {
        bool Delete(int id);
        void Dispose();
        void Insert(BsonValue id, T item);
        int Insert(IEnumerable<T> items);
        BsonValue Insert(T item);
        ILiteQueryable<T>? Query();
        BsonValue Update(T item);
    }
}