using System.Collections.Generic;

namespace Price.Query.EventHandler.BackgroundJob.Options
{
    public class OracleQueryOptions
    {
        public string AggregatorContractAddress { get; set; }
        public int AggregateThreshold { get; set; } = 1;
        public List<string> DesignatedNodes { get; set; } = new();
    }

    public class ExchangeQueryOptions: OracleQueryOptions
    {
        public string DataSourceUrl { get; set; }
    }

    public class TokenSwapQueryOptions: OracleQueryOptions
    {
        public string TokenSwapAddress { get; set; }
    }
}