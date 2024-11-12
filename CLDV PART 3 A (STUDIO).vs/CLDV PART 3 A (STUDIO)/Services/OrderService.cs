using System.Data.SqlClient;
using CLDV_PART_3_A__STUDIO_.Models;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CLDV_PART_3_A__STUDIO_.Services
{
    public class OrderService
    {
        private readonly IConfiguration _configuration;

        public OrderService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task InsertOrderAsync(Order order)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var query = @"INSERT INTO OrderTable (CustomerId, ProductId, Quantity, OrderDate)
                          VALUES (@CustomerId, @ProductId, @Quantity, @OrderDate)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                command.Parameters.AddWithValue("@ProductId", order.ProductId);
                command.Parameters.AddWithValue("@Quantity", order.Quantity);
                command.Parameters.AddWithValue("@OrderDate", order.OrderDate);

                connection.Open();
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
