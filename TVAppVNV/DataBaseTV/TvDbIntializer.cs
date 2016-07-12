using System.Data.Entity;

namespace TVAppVNV.DataBaseTV
{
    public class TvDbIntializer : CreateDatabaseIfNotExists<TvDBContext> // this class used only when database is creating
    {
        protected override void Seed(TvDBContext context)
        {
            

            base.Seed(context);
        }
    }
}