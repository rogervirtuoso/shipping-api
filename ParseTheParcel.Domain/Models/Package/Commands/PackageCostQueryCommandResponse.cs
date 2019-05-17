using Roger.ParseTheParcel.Domain.Models.Package.Commands.Base;

namespace Roger.ParseTheParcel.Domain.Models.Package.Commands
{
    public class PackageCostQueryCommandResponse : PackageBaseCommand
    {
        public PackageType PackageType { get; set; }
        public decimal Cost { get; set; }
    }
}