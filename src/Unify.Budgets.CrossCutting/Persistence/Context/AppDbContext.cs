using System.Data.Entity;

namespace Unify.Budgets.CrossCutting.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
