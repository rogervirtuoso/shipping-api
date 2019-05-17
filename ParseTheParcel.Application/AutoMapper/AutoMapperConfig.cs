using AutoMapper;
using Roger.ParseTheParcel.Application.AutoMapper.Profiles;
using Roger.Framework.DomainDrivenDesign.Application.AutoMapper;

namespace Roger.ParseTheParcel.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        private static MapperConfiguration _configuration;
        public static MapperConfiguration RegisterMappings()
        {
            if (_configuration != null)
                return _configuration;

            _configuration = new MapperConfiguration(p =>
            {
                p.AddProfile(new DomainMappingsProfile());
                p.AddProfile(new DataTransferObjectMappingsProfile());
                p.AllowNullCollections = true;
            });

            return _configuration;
        }
    }
}