using System.Threading.Tasks;
using Roger.Framework.CQRS;
using Roger.Framework.DomainDrivenDesign.Domain.Engine;
using Roger.Framework.DomainDrivenDesign.Infra.CQRS;
using Roger.ParseTheParcel.Domain.Models.Package.Events;
using Roger.ParseTheParcel.Domain.Models.Package.Repository;

namespace Roger.ParseTheParcel.Domain.Models.PackageCost.Events.EventHandlers
{
    public class PackageEventHandler : CommandHandler<Package.Package, IPackageReadRepository, IPackageWriteRepository>,
        IHandler<PackageCostQueryEvent>
    {
        public PackageEventHandler(IAppEngine engine, IPackageReadRepository readRepository,
            IPackageWriteRepository writeRepository) : base(engine, readRepository, writeRepository)
        {
        }

        public Task HandlerAsync(PackageCostQueryEvent message)
        {
            return Task.CompletedTask;
        }
    }
}