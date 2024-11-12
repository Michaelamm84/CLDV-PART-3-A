using System.Data.SqlClient;
using CLDV_PART_3_A__STUDIO_.Models;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CLDV_PART_3_A__STUDIO_.Services
{
    public class ProductService
    {
        private readonly IConfiguration _configuration;

        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task InsertProductAsync(Product product)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var query = @"INSERT INTO ProductTable (ProductName, Description, Price, Manufacturer)
                          VALUES (@ProductName, @Description, @Price, @Manufacturer)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Manufacturer", product.Manufacturer);

                connection.Open();
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
