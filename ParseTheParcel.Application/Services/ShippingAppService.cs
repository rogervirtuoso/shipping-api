using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roger.Framework.DomainDrivenDesign.Application.Service;
using Roger.Framework.DomainDrivenDesign.Domain.Engine;
using Roger.Framework.DomainDrivenDesign.Infra.CQRS;
using Roger.Framework.Utils;
using Roger.ParseTheParcel.Application.Interface;
using Roger.ParseTheParcel.Application.Objects.Base;
using Roger.ParseTheParcel.Application.Objects.Shipping;
using Roger.ParseTheParcel.Domain.Models.Languages;
using Roger.ParseTheParcel.Domain.Models.Package;
using Roger.ParseTheParcel.Domain.Models.Package.Commands;
using Roger.ParseTheParcel.Domain.Models.Package.Repository;

namespace Roger.ParseTheParcel.Application.Services
{
    public class ShippingAppService : AppService<Package, IPackageReadRepository, IPackageWriteRepository>,
        IShippingAppService
    {
        public ShippingAppService(IAppEngine engine, IPackageReadRepository readRepository,
            IPackageWriteRepository writeRepository) : base(engine, readRepository, writeRepository)
        {
        }

        public async Task<IActionResult> GetShippingCost(CostPackageRequest costPackageRequest)
        {
            var validationResult = await new CostPackageRequestValidator().ValidateAsync(costPackageRequest);

            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(new ApiResponseBase
                    {Success = false, Message = validationResult.Errors.FirstOrDefault()?.ErrorMessage});
            }

            var command = Mapper.Map<PackageCostQueryCommand>(costPackageRequest);
            var package = await CommandBus.SendCommandAsync<PackageCostQueryCommandResponse>(command);

            var costPackageResponse = package.MapTo<CostPackageResponse>(Mapper);

            if (Notifications.HasErrorsOrValidations)
            {
                costPackageResponse.Success = false;
                costPackageResponse.Message = Notifications.ToApiResponseValidations().FirstOrDefault()?.Message;
            }
            else if (package.PackageType == PackageType.Undefined)
            {
                costPackageResponse.Success = false;
                costPackageResponse.Message = ShippingMessages.UnableIdentifySize;
            }
            else
            {
                costPackageResponse.Success = true;
                costPackageResponse.Message = ShippingMessages.PackageSuccessfullyCalculated;
            }

            if (costPackageResponse.Success)
                return new OkObjectResult(costPackageResponse);

            return new BadRequestObjectResult(new ApiResponseBase
                {Success = false, Message = ShippingMessages.UnableIdentifySize});
        }

        public new void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}