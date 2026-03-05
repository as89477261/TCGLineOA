using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using ReportApp.Models;

namespace ReportApp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : DbContext(options)
    {
        private readonly string _connectionString = configuration.GetConnectionString("DB_CustomerHealthCheck");

        public async Task<List<object>> GetReportDataAsync(string reportType)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                var query = "EXEC dbo.GetReportPROMKHUM @ReportType";
                var parameters = new { ReportType = reportType };
                var result = await connection.QueryAsync<object>(query, parameters, commandType: CommandType.Text);
                return result.AsList();
            }

        }

        public async Task<List<TPT_ReportAppConfig>> GetReportAppConfigAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM TPT_ReportAppConfig WITH(NOLOCK)";
                var result = await connection.QueryAsync<TPT_ReportAppConfig>(query);
                return result.ToList(); 
            }
        }

    }



}
