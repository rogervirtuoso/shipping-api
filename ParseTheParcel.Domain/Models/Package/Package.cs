using System.ComponentModel;
using Roger.Framework.DomainDrivenDesign.Domain.Models;
using Roger.Framework.DomainDrivenDesign.Domain.Models.Validator;

namespace Roger.ParseTheParcel.Domain.Models.Package
{
    public class Package : Entity<Package, int, NotImplementedEntityValidator<Package>>
    {
        #region  Constants

        public const decimal SmallCost = 5.00m;
        public const decimal MediumCost = 7.50m;
        public const decimal LargeCost = 8.50m;

        #endregion

        #region  Fields

        public int Length { get; set; }
        public int Breadth { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        #endregion
    }

    public enum PackageType
    {
        [DisplayName("Undefined")]
        Undefined = 0,
        
        [DisplayName("Small")]
        Small = 1,

        [DisplayName("Medium")]
        Medium = 2,        
        
        [DisplayName("Large")]
        Large = 3
    }
}