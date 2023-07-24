using AdoNetCustomData.Helpers;
using AdoNetCustomData.Models;
using AdoNetCustomData.Services.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;

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

    public async Task<int>  Delete(int id)
    {
        await GetByIdAsync(id);
        return await SqlNetHelper.ExecuteAsync("DELETE * FROM Branch =" +  id);
    }

    public async Task<List<Branch>> GetAllAsync()
    {
        List<Branch> list = new List<Branch>();
        DataTable dt = await SqlNetHelper.SelectAsync("SELECT * FROM Branch");
        foreach (DataRow item in dt.Rows)
        {
            list.Add(new Branch
            {
                Id = (int)item["Id"],
                Name = (string)item["Name"]
            });
        }
        return list;
    }

    public async Task<Branch> GetByIdAsync(int id)
    {
       DataTable dt = await SqlNetHelper.SelectAsync("SELECT * FROM Branch where Id = " + id);
        if (dt.Rows.Count != 1) throw new Exception("Error");
        return new Branch
        {
            Id = (int)dt.Rows[0]["Id"],
            Name = (string)dt.Rows[0]["Name"]
        };

    }

    public Task<Branch>  Update(int id, Branch branch)
    {
        throw new NotImplementedException();
    }
}
