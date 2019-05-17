using System.Collections.Generic;
using FluentValidation;
using Roger.ParseTheParcel.Domain.Models.Languages;
using Roger.ParseTheParcel.Domain.Models.Package.Commands;

namespace Roger.ParseTheParcel.Domain.Models.Package.Validator
{
    public class PackageValidator : AbstractValidator<PackageCostQueryCommand>
    {
        public PackageValidator()
        {
            var result = new KeyValuePair<bool, string>();

            RuleFor(c => c)
                .Must(c =>
                {
                    result = ValidatePackageRequest(c);
                    return result.Key;
                }).WithMessage(c => result.Value);
        }

        private KeyValuePair<bool, string> ValidatePackageRequest(PackageCostQueryCommand package)
        {
            // MAIN VALIDATIONS
            if (package.Weight > 25)
            {
                return new KeyValuePair<bool, string>(false,
                    ShippingMessages.PackageTooHeavy);
            }

            if (package.Length > 400 || package.Breadth > 600 || package.Height > 250)
            {
                return new KeyValuePair<bool, string>(false,
                    ShippingMessages.PackageOversized);
            }

            //SECONDARY VALIDATIONS
            if (package.Weight == 0)
            {
                return new KeyValuePair<bool, string>(false,
                    ShippingMessages.InsertValidWeight);
            }

            if (package.Height <= 0)
            {
                return new KeyValuePair<bool, string>(false,
                    ShippingMessages.InsertValidHeight);
            }

            if (package.Length <= 0)
            {
                return new KeyValuePair<bool, string>(false,
                    ShippingMessages.InsertValidLength);
            }

            if (package.Breadth <= 0)
            {
                return new KeyValuePair<bool, string>(false,
                    ShippingMessages.InsertValidBreadth);
            }

            return new KeyValuePair<bool, string>(true, string.Empty);
        }
    }
}