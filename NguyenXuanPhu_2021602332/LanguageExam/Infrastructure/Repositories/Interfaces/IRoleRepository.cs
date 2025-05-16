using Domain.Entities;


namespace Infrastructure.Repositories.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        public Task<Guid> GetIdByName(string name);
        public Task<List<Role>> GetUserRole();
    }
}
