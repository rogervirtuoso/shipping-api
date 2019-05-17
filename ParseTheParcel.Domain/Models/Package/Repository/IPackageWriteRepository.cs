﻿using Roger.Framework.DomainDrivenDesign.Infra.Repository;

namespace Roger.ParseTheParcel.Domain.Models.Package.Repository
{
    public interface IPackageWriteRepository : IWriteOnlyRepository<Package>
    {
    }
}