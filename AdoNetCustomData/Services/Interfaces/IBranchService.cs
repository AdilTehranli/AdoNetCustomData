using AdoNetCustomData.Models;

namespace AdoNetCustomData.Services.Interfaces;

public interface IBranchService
{
    public Task<int> AddAsync(Branch branch);
    public Task<int> AddAsync(List<Branch> branch);
    public Task<List<Branch>> GetAllAsync();
    public Task<Branch> GetByIdAsync(int id);
    public int Delete(int id);
    public Branch Update(int id,Branch branch);
}

