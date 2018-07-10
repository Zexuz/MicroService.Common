using Dapper.Contrib.Extensions;

namespace MicroService.Common.Core.Databases.Repository.MsSql.Impl
{
    public abstract class SqlEntityBase
    {
        [Key]
        public virtual int Id { get; set; }

        [Computed]
        public bool IsNew => Id == default(int);
    }
}