using Roger.ParseTheParcel.Infra.Data.Context;
using Roger.Framework.DomainDrivenDesign.Domain.Models;

namespace Roger.ParseTheParcel.Infra.Data.Repository.Base
{
    public abstract class WriteNotSupportedRepository<TEntity>
        : Framework.DomainDrivenDesign.Infra.Repository.WriteNotSupportedRepository<TEntity, ParseTheParcelContext>
        where TEntity : class, IEntity
    {
        protected WriteNotSupportedRepository(ParseTheParcelContext context) : base(context)
        {
        }
    }
}