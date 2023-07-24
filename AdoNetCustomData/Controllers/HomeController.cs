using AdoNetCustomData.Helpers;
using AdoNetCustomData.Models;
using AdoNetCustomData.Services.Implements;
using AdoNetCustomData.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdoNetCustomData.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Branch> branches = new List<Branch>();
            DataTable dt = await SqlNetHelper.SelectAsync("SELECT * FROM Branch");
            foreach (DataRow item in dt.Rows)
            {
                branches.Add(new()
                {
                    Id = (int)item[0],
                    Name = (string)item[1]
                });
            }
            return View(branches);


        }
        [HttpPost]
        public async Task<IActionResult> Branch(string name)
        {
            var res = await SqlNetHelper.ExecuteAsync($"INSERT INTO Branch VALUES ('{name}')");
            return Content(res.ToString());
        }
        public async Task<IActionResult> BranchGetAll()
        {
            IBranchService service = new BranchService();
            return Json(await service.GetAllAsync());
        }
        public async Task<IAsyncResult> BranchGetById(int id)
        {
            IBranchService service = new BranchService();
            return (IAsyncResult)Json(await service.GetByIdAsync(id));
        }
      


    }
}
