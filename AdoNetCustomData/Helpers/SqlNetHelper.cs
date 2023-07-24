using Microsoft.Data.SqlClient;
using System.Data;

namespace AdoNetCustomData.Helpers
{
    public class SqlNetHelper
    {
        private string _connectionStr = "Server=MSI\\SQLEXPRESS;Database=ObaMarket;Trusted_Connection=True;Encrypt=false";

		public string ConnectionStr 
		{
			get { return _connectionStr ; }
			
		}

		public async Task<DataTable>  SelectAsync(string query)
		{
			using(SqlConnection conn  = new SqlConnection(ConnectionStr))
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
	}
}