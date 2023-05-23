using System.Data;
using Microsoft.Data.SqlClient;

namespace Interview.Infrastructure.Data;

public class InterviewDbConnect
{
    private readonly string _connectionString;

    public InterviewDbConnect(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}