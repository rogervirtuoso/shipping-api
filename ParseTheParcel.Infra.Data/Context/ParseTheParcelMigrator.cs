using Roger.Framework.EntityFramework.Migrations;
using Roger.Framework.EntityFramework.Seed;

namespace Roger.ParseTheParcel.Infra.Data.Context
{
    public class ParseTheParcelMigrator : DbContextMigrator<ParseTheParcelContext>
    {
        public ParseTheParcelMigrator()
        {
            EnableContextLogging = false;
        }

        public override void Dispose()
        {
        }

        protected override ISeed<ParseTheParcelContext>[] GetSeeds()
        {
            return new ISeed<ParseTheParcelContext>[] { };
        }

        protected override ParseTheParcelContext CreateConnection()
        {
            return new ParseTheParcelContext();
        }
    }
}
