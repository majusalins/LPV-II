using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AppInventario.Data
{
    public class AppInventarioContext(DbContextOptions<AppInventarioContext> options) : IdentityDbContext<IdentityUser>(options)
    {
    }
}
