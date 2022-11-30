using LittleRepro.DTOs;
using Microsoft.EntityFrameworkCore;

namespace LittleRepro.DbContexts
{
    public class ManagementDBContext : DbContext
    {
        public ManagementDBContext(DbContextOptions<ManagementDBContext> options)
            : base(options) 
        {
        }

        public DbSet<AccountDTO> Accounts { get; set; }
    }
}
