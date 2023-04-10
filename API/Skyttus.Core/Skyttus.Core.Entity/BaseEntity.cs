using Skyttus.Core.Entity.Contracts;

namespace Skyttus.Core.Entity
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }

        public T Clone<T>()
        {
            return (T)this.MemberwiseClone();
        }
    }
}