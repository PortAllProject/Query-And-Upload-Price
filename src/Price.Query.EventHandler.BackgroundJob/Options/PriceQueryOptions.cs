using System.Collections.Generic;

namespace Price.Query.EventHandler.BackgroundJob.Options
{
    public class PriceQueryOptions
    {
        public bool IsQuery { get; set; }
        public bool IsCommitData { get; set; }
        public string NodeUrl { get; set; }
        public string AccountAddress { get; set; }
        public string AccountPassword { get; set; }
        public string PriceContractAddress { get; set; }
        public string OracleContractAddress { get; set; }
        public List<TokenPair> ExchangeTokenPairs { get; set; } = new();
    }

    public class TokenPair
    {
        public string TokenSymbol { get; set; }
        public string UnderlyingTokenSymbol { get; set; }
    }
}