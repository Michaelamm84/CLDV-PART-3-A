using Azure;
using Azure.Data.Tables;
using System;

namespace CLDV_PART_3_A__STUDIO_.Models
{
    public class Product : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        // Product properties
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }

        public Product()
        {
            PartitionKey = "Product";
            RowKey = Guid.NewGuid().ToString();
        }
    }
}
