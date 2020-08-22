using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService
{

    public interface IRepository<T> where T :class 
    {
        T Get(object id);
        void Add(T item);
        void Delete(T item);
        void Update(T item);
    }

    public class RepositoryBase<T> : IRepository<T>
        where T : class        
    {
        public T Get(object id)
        {
            //get Item
            return null;
        }

        public void Add(T item)
        {
            //save Item
        }

        public void Delete(T item)
        {
            //Delete Item
        }

        public void Update(T item)
        {
            //Update Item
        }
    }



    public interface ILogger
    {
        void Log(string error);
    }

    public class FileLogger: ILogger
    {
        public void Log(string error)
        {
            File.WriteAllText(@"C:\Error.txt", error);
        }
    }

    public class DatabaseLogger: ILogger
    {
        public void Log(string error)
        {
           //Log To DB
        }
    }

    public class Customer
    {

    }
}
