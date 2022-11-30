using LittleRepro.DbContexts;

namespace LittleRepro.Schemas
{
    public class Query
    {
        [UseDbContext(typeof(ManagementDBContext))]
        [UseProjection]
        [UseFiltering]
        public IQueryable<AccountType> GetAll([ScopedService] ManagementDBContext context)
        {
            return context.Accounts.Select(x => new AccountType
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country,
                Email = x.Email
            });
        }

        [UseDbContext(typeof(ManagementDBContext))]
        [UseSingleOrDefault]
        [UseProjection]
        public IQueryable<AccountType> GetById(
            int id,
            [ScopedService] ManagementDBContext context)
        {
            return context.Accounts
                .Where(x => x.Id == id)
                .Select(x => new AccountType
                {
                    Id = x.Id,
                    Name = x.Name,
                    Country = x.Country,
                    Email = x.Email
                });
        }

        [UseDbContext(typeof(ManagementDBContext))]
        [UseProjection]
        public AccountType GetByIdX(
            int id,
            [ScopedService] ManagementDBContext context)
        {
            var x = context.Accounts
               .SingleOrDefault(x => x.Id == id);

            return new AccountType
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country,
                Email = x.Email
            };
        }
    }
}
