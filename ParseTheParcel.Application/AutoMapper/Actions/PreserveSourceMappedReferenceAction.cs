using AutoMapper;
using Roger.Framework.DomainDrivenDesign.Application.ViewModel;

namespace Roger.ParseTheParcel.Application.AutoMapper.Actions
{
    public class PreserveSourceMappedReferenceAction<TSource, TDestination> : IMappingAction<TSource, TDestination>
    {
        public void Process(TSource source, TDestination destination)
        {
            if (destination is IPreservableObjectInfo<TSource> reference && reference.InfoProvider != null)
                reference.InfoProvider.SourceReference = source;
        }
    }
}
