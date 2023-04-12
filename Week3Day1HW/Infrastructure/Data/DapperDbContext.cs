using System;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Data
{
	public class DapperDbContext
	{

		IDbConnection dbConnection;

		public DapperDbContext()
		{
			

		}

		public IDbConnection GetConnection()
		{
            dbConnection = new SqlConnection("Server=localhost;Database=DapperTest;Trusted_Connection=false;TrustServerCertificate=True;User Id=sa;Password=Pa$$w0rd2019;");
            return dbConnection;
		}
	}
}

