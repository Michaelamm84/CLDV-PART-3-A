using Azure;
using Azure.Data.Tables;
using System;

namespace CLDV_PART_3_A__STUDIO_.Models
{
    public class Order : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        // Order properties
        public string CustomerId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }

        public Order()
        {
            PartitionKey = "Order";
            RowKey = Guid.NewGuid().ToString();
        }
    }
}
