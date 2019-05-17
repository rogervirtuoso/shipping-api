using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Roger.Framework.DomainDrivenDesign.EntityFramework;
using Roger.Framework.EntityFramework.Extensions;
using Roger.Framework.EntityFramework.Log;
using Roger.Framework.Utils.AppSettings;
using Roger.ParseTheParcel.Domain.Models;
using Roger.ParseTheParcel.Domain.Models.Package;
using Roger.ParseTheParcel.Domain.Models.PackageCost;

namespace Roger.ParseTheParcel.Infra.Data.Context
{
    public class ParseTheParcelContext : DbContext
    {
        public const string DefaultSchema = "ParseTheParcel";

        public DbSet<Package> Packages { get; set; }

#if DEBUG
        private static readonly LoggerFactory LoggerFactory;

        static ParseTheParcelContext()
        {
            if (LoggerFactory == null)
            {
                LoggerFactory = new LoggerFactory();
                LoggerFactory.AddProvider(new ConsoleLoggerProvider());
            }
        }
#endif

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DefaultSchema);

            ModelBuilderConfigure.ForSqlServer(modelBuilder);

            #region Configurações

//            modelBuilder.AddConfiguration(new PackageMapping());

            #endregion

            modelBuilder.DisableCascadeDelete();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                AppSettingsUtils.ConnectionString("ParseTheParcel"),
                x => x.MigrationsHistoryTable("__EFMigrationHistory", DefaultSchema));

            optionsBuilder.EnableSensitiveDataLogging();

#if DEBUG
            if (LoggerFactory != null)
                optionsBuilder.UseLoggerFactory(LoggerFactory);
#endif
        }

        public override int SaveChanges()
        {
            DbContextSaveUtils.ConfigureDefaultValues(this, null);
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken())
        {
            DbContextSaveUtils.ConfigureDefaultValues(this, null);
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}