using Microsoft.EntityFrameworkCore;
using RazorFatih.Models; // HomeContent modelinizin bulunduğu namespace

namespace RazorFatih.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<HomeContent> HomeContents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HomeContent>().HasData(
                new HomeContent
                {
                    Id = 1,
                    Title = "Hoş Geldiniz!",
                    Content = "RazorFatih uygulamanıza hoş geldiniz. Bu sayfanın içeriğini " +
                              "kolayca düzenleyebilir ve uygulamanız hakkında bilgi verebilirsiniz. " +
                              "Gelecekteki güncellemeler ve özellikler için bizi takipte kalın!"
                }
            );
        }
    }
}