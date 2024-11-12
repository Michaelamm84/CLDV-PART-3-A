
namespace CLDV_PART_3_A__STUDIO_.Functions
{
    internal class TableServiceClient
    {
        private string? connectionString;

        public TableServiceClient(string? connectionString)
        {
            this.connectionString = connectionString;
        }

        internal object GetTableClient(string tableName)
        {
            throw new NotImplementedException();
        }
    }
}