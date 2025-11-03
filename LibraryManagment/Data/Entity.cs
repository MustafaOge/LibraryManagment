using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace LibraryManagment.Data
{

    public interface IAuditableEntity
    {
    }
    public interface IAuditableEntity<T> : IAuditableEntity
    {
        T Id { get; set; }
    }

    public interface IEntity
    {
    }
    public interface IEntity<T> : IEntity
    {
        T Id { get; set; }
    }

    public abstract class Entity : IEntity
    {
        public bool IsDeleted { get; set; }
    }

    public abstract class Entity<T> : Entity, IEntity<T>
    {
        [Key]
        public T Id { get; set; }
    }

    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity<T>
    {
        public DateTimeOffset CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
