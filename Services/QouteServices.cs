using Dapper;
using Npgsql;
using Domain;
namespace Services;


public class QouteServices
{


    private string _connectionString;
    public QouteServices()
    {
        _connectionString = "Server=127.0.0.1;Port=5432;Database=ExamApi;User Id=postgres;Password=882003421sb.;";
    }

    public async Task<List<Quote>> GetAuthors()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();

            var response = await connection.QueryAsync<Quote>($"select * from Authors ;");
            return response.ToList();
        }
    }


    public async Task<int> AddQuote(Quote quote)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection())
        {
            connection.Open();
            string? sql = $"Insert into quotee (Name,Id) VAlUES ('{quote.Author}','{quote.Category}')";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }
    }
    public async Task<int> DeleteQuote(int id)
    {
        // Add contact to database
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"delete from Quote where id = '{id}';";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }
    }
    public async Task<int> UpdateQuote(Quote quote)
    {
        // Add contact to database
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"UPDATE Quote SET Author = '{quote.Author}', Category = '{quote.Category}' WHERE CategoryId = {quote.Category};";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }
    }
}

