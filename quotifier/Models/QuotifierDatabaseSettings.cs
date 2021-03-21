namespace Quotifier.Models
{
	public class QuotifierDatabaseSettings : IQuotifierDatabaseSettings
    {
        public string QuotesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IQuotifierDatabaseSettings
    {
        string QuotesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}