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
            string connstr = "Server=MSI\\SQLEXPRESS;Database=ObaMarket;Trusted_Connection=True;Encrypt=false";
            List<Branch> branches = new List<Branch>();
          SqlNetHelper sqlHelper = new SqlNetHelper();
            DataTable dt = await  sqlHelper.SelectAsync("SELECT * FROM Branch");
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
            string connstr = "Server=MSI\\SQLEXPRESS;Database=ObaMarket;Trusted_Connection=True;Encrypt=false";
            List<Branch> branches = new List<Branch>();
            using SqlConnection conn = new SqlConnection(connstr);
            
                await conn.OpenAsync();
            using SqlCommand command = new SqlCommand($"INSERT INTO Branch VALUES ('{name}')", conn);
                
                 int res =  await command.ExecuteNonQueryAsync();
                
            return Content(name);
        }
    }
}
