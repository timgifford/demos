using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sayso.Domain{
    public interface IRepository<IDTYPE, TYPE> where TYPE:IEntity<IDTYPE>
    {
        TYPE GetById(IDTYPE id);
        void Save(TYPE value);
    }

    public abstract class InMemoryRepository<IDTYPE, TYPE> : IRepository<IDTYPE, TYPE> where TYPE : IEntity<IDTYPE>
    {
        private readonly IDictionary<IDTYPE, TYPE> dataStore = new Dictionary<IDTYPE, TYPE>();

        public TYPE GetById(IDTYPE id)
        {
            return dataStore[id];
        }

        public void Save(TYPE value)
        {
            dataStore[value.Id] = value;
        }
    }

    public interface IEntity<IDTYPE>
    {
        IDTYPE Id { get; }
    }

    public abstract class Entity : IEntity<Guid>
    {
        private readonly Guid id;

        protected Entity(Guid id)
        {
            this.id = id;
        }

        public Guid Id {
            get { return id; }
        }
    }

    public class CustomerRepository : InMemoryRepository<Guid, Customer>
    {
    }

    public class SalesOrderRepository : InMemoryRepository<Guid, SalesOrder> 
    {
    }
}
