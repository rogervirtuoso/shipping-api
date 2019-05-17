using Roger.ParseTheParcel.Domain.Models.Package.Commands.Base;

namespace Roger.ParseTheParcel.Domain.Models.Package.Commands
{
    public class PackageCostQueryCommand : PackageBaseCommand
    {
        public PackageCostQueryCommand()
        {
        }

        public PackageCostQueryCommand(Models.Package.Package package)
        {
            Height = package.Height;
            Length = package.Length;
            Weight = package.Weight;
            Breadth = package.Breadth;
        }
    }
}