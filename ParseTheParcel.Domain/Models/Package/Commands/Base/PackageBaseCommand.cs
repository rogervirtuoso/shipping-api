namespace Roger.ParseTheParcel.Domain.Models.Package.Commands.Base
{
    public class PackageBaseCommand
    {
        public int Length { get; set; }
        public int Breadth { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}