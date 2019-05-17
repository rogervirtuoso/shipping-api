namespace Roger.ParseTheParcel.Domain.Models.Package.Events.Base
{
    public class PackageBaseEvent
    {
        public int Length { get; set; }
        public int Breadth { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}