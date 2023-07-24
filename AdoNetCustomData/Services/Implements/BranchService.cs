using AdoNetCustomData.Helpers;
using AdoNetCustomData.Models;
using AdoNetCustomData.Services.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace AdoNetCustomData.Services.Implements;

public class BranchService : IBranchService
{
    public async Task<int> AddAsync(Branch branch)
    {
      return await  SqlNetHelper.ExecuteAsync($"INSERT INTO Branch VALUES ('{branch.Name}')");
    }

    public async Task<int> AddAsync(List<Branch> branch)
    {
        string query = "INSERT INTO Branch VALUES";
        foreach (Branch branch1 in branch)
        {
            query += $"(N'{branch1.Name})";
        }
        return await SqlNetHelper.ExecuteAsync(query.Substring(0,query.Length-1));
    }

    public int Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Branch>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Branch> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Branch Update(int id, Branch branch)
    {
        throw new NotImplementedException();
    }
}
