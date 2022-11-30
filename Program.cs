using LittleRepro.DbContexts;
using LittleRepro.Schemas;
using Microsoft.EntityFrameworkCore;

namespace LittleRepro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddPooledDbContextFactory<ManagementDBContext>(
                o => o.UseSqlite(connectionString));

            builder.Services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddFiltering()
                .AddProjections()
                .InitializeOnStartup();

            var app = builder.Build();

            using (IServiceScope scope = app.Services.CreateScope())
            {
                IDbContextFactory<ManagementDBContext> contextFactory =
                    scope.ServiceProvider.GetRequiredService<IDbContextFactory<ManagementDBContext>>();

                using (ManagementDBContext context = contextFactory.CreateDbContext())
                {
                    context.Database.Migrate();

                    if (!context.Accounts.Any())
                    {
                        context.Accounts.AddRange(new DTOs.AccountDTO[]
                        {
                            new DTOs.AccountDTO(
                                id: 0,
                                name: "First account",
                                country: "First country",
                                email: "first@email.com",
                                createdAt: DateTime.Now,
                                lastChangedAt: null),

                            new DTOs.AccountDTO(
                                id: 0,
                                name: "Second account",
                                country: "Second country",
                                email: "second@email.com",
                                createdAt: DateTime.Now,
                                lastChangedAt: null),

                            new DTOs.AccountDTO(
                                id: 0,
                                name: "Third account",
                                country: "Third country",
                                email: "third@email.com",
                                createdAt: DateTime.Now,
                                lastChangedAt: null),
                        });

                        context.SaveChanges();
                    }
                }
            }

            app.MapGraphQL(); //Add GraphQL endpoint to the endpoint configuration

            app.Run();
        }
    }
}