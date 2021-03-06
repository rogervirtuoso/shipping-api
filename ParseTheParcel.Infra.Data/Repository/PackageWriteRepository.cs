﻿using Roger.ParseTheParcel.Domain.Models;
using Roger.ParseTheParcel.Domain.Models.Package;
using Roger.ParseTheParcel.Domain.Models.Package.Repository;
using Roger.ParseTheParcel.Domain.Models.PackageCost;
using Roger.ParseTheParcel.Infra.Data.Context;
using Roger.ParseTheParcel.Infra.Data.Repository.Base;

namespace Roger.ParseTheParcel.Infra.Data.Repository
{
    public class PackageWriteRepository : WriteOnlyRepository<Package>, IPackageWriteRepository
    {
        public PackageWriteRepository(ParseTheParcelContext context) : base(context)
        {
        }
    }
}