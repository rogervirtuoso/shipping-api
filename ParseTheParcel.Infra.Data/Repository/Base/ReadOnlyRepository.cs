using Roger.ParseTheParcel.Infra.Data.Context;
using Roger.Framework.DomainDrivenDesign.Domain.Models;

namespace Roger.ParseTheParcel.Infra.Data.Repository.Base
{
    public abstract class ReadOnlyRepository<TEntity>
        : Framework.DomainDrivenDesign.Infra.Repository.ReadOnlyRepository<TEntity, ParseTheParcelContext>
        where TEntity : class, IEntity
    {
        protected ReadOnlyRepository(ParseTheParcelContext context) : base(context)
        {
        }
    }
}