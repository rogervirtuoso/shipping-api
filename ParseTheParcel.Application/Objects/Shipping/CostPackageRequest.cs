using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using Roger.Framework.DomainDrivenDesign.Domain.Models.Validator;
using Roger.ParseTheParcel.Domain.Models.Languages;

namespace Roger.ParseTheParcel.Application.Objects.Shipping
{
    public class CostPackageRequest
    {
        public Dimensions Dimensions { get; set; }
        public int Weight { get; set; }
    }

    public struct Dimensions
    {
        public int Length { get; set; }
        public int Breadth { get; set; }
        public int Height { get; set; }
    }

    public class CostPackageRequestValidator : AbstractValidator<CostPackageRequest>
    {
        public CostPackageRequestValidator()
        {
            var result = new KeyValuePair<bool, string>();

            RuleFor(c => c)
                .Must(c =>
                {
                    result = ValidatePackageRequest(c);
                    return result.Key;
                }).WithMessage(c => result.Value);
        }

        private KeyValuePair<bool, string> ValidatePackageRequest(CostPackageRequest request)
        {
            // MAIN VALIDATIONS
            if (request.Weight > 25)
            {
                return new KeyValuePair<bool, string>(false,
                    ShippingMessages.PackageTooHeavy);
            }

            if (request.Dimensions.Length > 400 || request.Dimensions.Breadth > 600 || request.Dimensions.Height > 250)
            {
                return new KeyValuePair<bool, string>(false,
                    ShippingMessages.PackageOversized);
            }

            //SECONDARY VALIDATIONS
            if (request.Weight == 0)
            {
                return new KeyValuePair<bool, string>(false,
                    ShippingMessages.InsertValidWeight);
            }

            if (request.Dimensions.Height <= 0)
            {
                return new KeyValuePair<bool, string>(false,
                    ShippingMessages.InsertValidHeight);
            }

            if (request.Dimensions.Length <= 0)
            {
                return new KeyValuePair<bool, string>(false,
                    ShippingMessages.InsertValidLength);
            }

            if (request.Dimensions.Breadth <= 0)
            {
                return new KeyValuePair<bool, string>(false,
                    ShippingMessages.InsertValidBreadth);
            }

            return new KeyValuePair<bool, string>(true, string.Empty);
        }
    }
}