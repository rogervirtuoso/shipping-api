using System.Threading.Tasks;
using Roger.Framework.CQRS;
using Roger.Framework.DomainDrivenDesign.Domain.Engine;
using Roger.Framework.DomainDrivenDesign.Infra.CQRS;
using Roger.ParseTheParcel.Domain.Models.Package.Events;
using Roger.ParseTheParcel.Domain.Models.Package.Repository;
using Roger.ParseTheParcel.Domain.Models.PackageCost.Events;

namespace Roger.ParseTheParcel.Domain.Models.Package.Commands.CommandHandlers
{
    public class PackageCommanndHandler :
        CommandHandler<Package, IPackageReadRepository, IPackageWriteRepository>,
        IHandler<PackageCostQueryCommand, PackageCostQueryCommandResponse>
    {
        public PackageCommanndHandler(IAppEngine engine, IPackageReadRepository readRepository,
            IPackageWriteRepository writeRepository) : base(engine, readRepository, writeRepository)
        {
        }

        public async Task<PackageCostQueryCommandResponse> HandlerAsync(PackageCostQueryCommand request)
        {
            await CommandBus.RaiseEventAsync(new PackageCostQueryEvent());

            var calculatedPackage = CalculatePackage(request);
            return new PackageCostQueryCommandResponse
            {
                Cost = calculatedPackage.Cost,
                PackageType = calculatedPackage.PackageType
            };
        }

        private PackageCostQueryCommandResponse CalculatePackage(PackageCostQueryCommand costPackageRequest)
        {
            if (costPackageRequest.Length <= 200 &&
                costPackageRequest.Breadth <= 300 &&
                costPackageRequest.Height <= 150)
                return new PackageCostQueryCommandResponse
                {
                    PackageType = PackageType.Small,
                    Cost = Package.SmallCost
                };

            if ((costPackageRequest.Length > 200 && costPackageRequest.Length <= 300) &&
                (costPackageRequest.Breadth > 300 && costPackageRequest.Breadth <= 400) &&
                (costPackageRequest.Height > 150 && costPackageRequest.Height <= 200))
                return new PackageCostQueryCommandResponse
                {
                    PackageType = PackageType.Medium,
                    Cost = Package.MediumCost
                };
            if ((costPackageRequest.Length > 300 && costPackageRequest.Length <= 400) &&
                (costPackageRequest.Breadth > 400 && costPackageRequest.Breadth <= 600) &&
                (costPackageRequest.Height > 200 && costPackageRequest.Height <= 250))
                return new PackageCostQueryCommandResponse
                {
                    PackageType = PackageType.Large,
                    Cost = Package.LargeCost
                };
            
            return new PackageCostQueryCommandResponse
            {
                PackageType = PackageType.Undefined,
                Cost = 0
            };
        }
    }
}