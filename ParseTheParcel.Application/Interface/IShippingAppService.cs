using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roger.ParseTheParcel.Application.Objects.Shipping;

namespace Roger.ParseTheParcel.Application.Interface
{
    public interface IShippingAppService : IDisposable
    {
        Task<IActionResult> GetShippingCost(CostPackageRequest costPackageRequest);

    }
}