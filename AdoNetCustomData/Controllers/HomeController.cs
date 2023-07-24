using AdoNetCustomData.Helpers;
using AdoNetCustomData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdoNetCustomData.Controllers
{
    public class HomeController:Controller
    {
        public async Task<IActionResult>  Index()
        {
            List<Branch> branches = new List<Branch>();
            DataTable dt = await  SqlNetHelper.SelectAsync("SELECT * FROM Branch");
                    foreach ( DataRow item in dt.Rows)
                    {
                        branches.Add(new()
                        {
                            Id = (int)item[0],
                            Name =(string)item[1]
                        });
                    }
            return View(branches);
                

        }
        [HttpPost]
        public async Task<IActionResult> Branch(string name)
        {
          var res=  await SqlNetHelper.ExecuteAsync($"INSERT INTO Branch VALUES ('{name}')");
            return Content(res.ToString());
        }
    }
}
