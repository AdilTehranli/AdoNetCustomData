using Microsoft.Data.SqlClient;
using System.Data;

namespace AdoNetCustomData.Helpers
{
    public static class SqlNetHelper
    {
        private const string _connectionStr = "Server=MSI\\SQLEXPRESS;Database=ObaMarket;Trusted_Connection=True;Encrypt=false";


		public static async Task<DataTable>  SelectAsync(string query)
		{
			using(SqlConnection conn  = new SqlConnection(_connectionStr))
			{
				await conn.OpenAsync();
				using (SqlDataAdapter sda = new SqlDataAdapter(query,conn))
				{
					DataTable dt = new DataTable();
					sda.Fill(dt);
					return dt;
				}
			}
		}
		public static async Task<int> ExecuteAsync(string command)
		{
			using (SqlConnection conn = new SqlConnection(_connectionStr))
			{
				await conn.OpenAsync();
				using (SqlCommand cmd = new SqlCommand(command,conn))
				{  return await cmd.ExecuteNonQueryAsync(); }
			}
		}
	}
}