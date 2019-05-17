using AutoMapper;
using Roger.Framework.Utils;
using Roger.ParseTheParcel.Application.Objects.Shipping;
using Roger.ParseTheParcel.Domain.Models.Package.Commands;

namespace Roger.ParseTheParcel.Application.AutoMapper.Profiles
{
    public class DataTransferObjectMappingsProfile : Profile
    {
        public DataTransferObjectMappingsProfile()
        {
            ShippingMap();
        }

        private void ShippingMap()
        {
            CreateMap<CostPackageRequest, PackageCostQueryCommand>()
                .ForMember(dest => dest.Height, opts => opts.MapFrom(src => src.Dimensions.Height))
                .ForMember(dest => dest.Length, opts => opts.MapFrom(src => src.Dimensions.Length))
                .ForMember(dest => dest.Breadth, opts => opts.MapFrom(src => src.Dimensions.Breadth))
                .ForMember(dest => dest.Weight, opts => opts.MapFrom(src => src.Weight));

            CreateMap<PackageCostQueryCommandResponse, CostPackageResponse>()
                .ForMember(dest => dest.CostDescription,opts => opts.MapFrom(src => src.Cost.FormatMoney()))
                .ForMember(dest => dest.Cost,opts => opts.MapFrom(src => src.Cost))
                .ForMember(dest => dest.PackageTypeDescription,opts => opts.MapFrom(src => src.PackageType.DisplayName()));

        }
    }
}