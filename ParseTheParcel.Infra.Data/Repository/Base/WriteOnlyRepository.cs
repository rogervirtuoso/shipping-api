using Roger.ParseTheParcel.Infra.Data.Context;
using Roger.Framework.DomainDrivenDesign.Domain.Models;

namespace Roger.ParseTheParcel.Infra.Data.Repository.Base
{
    public abstract class WriteOnlyRepository<TEntity>
        : Framework.DomainDrivenDesign.Infra.Repository.WriteOnlyRepository<TEntity, ParseTheParcelContext>
        where TEntity : class, IEntity
    {
        protected WriteOnlyRepository(ParseTheParcelContext context) : base(context)
        {
        }
    }
}