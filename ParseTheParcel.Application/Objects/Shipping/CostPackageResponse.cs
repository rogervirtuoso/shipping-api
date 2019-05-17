using Roger.ParseTheParcel.Application.Objects.Base;

namespace Roger.ParseTheParcel.Application.Objects.Shipping
{
    public class CostPackageResponse : ApiResponseBase
    {
        public string PackageTypeDescription { get; set; }
        public string CostDescription { get; set; }
        public decimal Cost{ get; set; }
    }
}