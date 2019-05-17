using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roger.Framework.DomainDrivenDesign.Domain.Models.Api;
using Roger.ParseTheParcel.Application.Interface;
using Roger.ParseTheParcel.Application.Objects.Base;
using Roger.ParseTheParcel.Application.Objects.Shipping;

namespace Roger.ParseTheParcel.Api.Controllers
{
    /// <inheritdoc />
    [Route("Shipping")]
    public class ShippingController : ControllerBase
    {
        private readonly IShippingAppService _appService;

        /// <inheritdoc />
        public ShippingController(IShippingAppService appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// Returns the cost and type of package required
        /// </summary>
        /// <param name="costPackageRequest">Dimensions and weight of the package.
        /// <li>Dimensions: length x breadth x height</li>
        /// <li>weight: weight of the package</li>
        /// </param>
        /// <returns>The object that represents the cost return</returns>
        [HttpPost("Calculate")]
        public async Task<IActionResult> Calculate([FromBody] CostPackageRequest costPackageRequest)
        {
            return await _appService.GetShippingCost(costPackageRequest);
        }
    }
}