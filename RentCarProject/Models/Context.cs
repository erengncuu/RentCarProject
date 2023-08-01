using Microsoft.EntityFrameworkCore;

namespace RentCarProject.Models
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-H6BPHOP\\SQLEXPRESS; database=RentACar;integrated security=true;TrustServerCertificate=True");
		}
		DbSet<Cars> cars {set; get; }


	}
}
