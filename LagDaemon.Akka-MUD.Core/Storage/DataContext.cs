using Akka.Routing;
using Akka.Util;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.Akka_MUD.Core.Storage
{
    public class DataContext<T> : IDisposable, IDataContext<T>
    {
        protected bool disposed = false;
        protected readonly string PATH = "LagDaemon\\Akka.MUD\\Database";
        protected readonly string FILENAME = "mud.db";
        protected LiteDatabase database;
        protected ILiteCollection<T> collection;

        private string DataPath { get; set; }
        private string Name { get; set; }
        private string FilePath { get; set; }

        public DataContext()
        {
            Name = typeof(T).Name;
            DataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                            Path.DirectorySeparatorChar + PATH;

            FilePath = DataPath + Path.DirectorySeparatorChar + FILENAME;

            if (!Directory.Exists(DataPath))
            {
                Directory.CreateDirectory(DataPath);
            }

            database = new LiteDatabase(FilePath);
            collection = database.GetCollection<T>(Name);
        }

        public DataContext(Stream stream)
        {
            DataPath = string.Empty;
            Name = typeof(T).Name;
            database = new LiteDatabase(stream);
            collection = database.GetCollection<T>(Name);
        }

        public ILiteQueryable<T>? Query()
        {
            return collection.Query();
        }

        public BsonValue Insert(T item)
        {
            return collection.Insert(item);
        }

        public int Insert(IEnumerable<T> items)
        {
            return collection.Insert(items);
        }

        public void Insert(BsonValue id, T item)
        {
            collection.Insert(id, item);
        }

        public BsonValue Update(T item)
        {
            return collection.Update(item);
        }

        public bool Delete(int id)
        {
            return collection.Delete(id);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DataContext()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this.database.Dispose();
                }
                disposed = true;
            }
        }
    }
}
