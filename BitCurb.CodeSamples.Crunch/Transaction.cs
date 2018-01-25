using Newtonsoft.Json;

namespace BitCurb.CodeSamples.Crunch
{
    public class Transaction
    {
        [JsonProperty("TransactionReferenceNumber")]
        public string TransactionReferenceNumber { get; set; }

        [JsonProperty("AccountIdentification")]
        public string AccountIdentification { get; set; }

        [JsonProperty("OpeningBalanceType")]
        public string OpeningBalanceType { get; set; }

        [JsonProperty("Currency")]
        public string Currency { get; set; }

        [JsonProperty("TransactionValueDate")]
        public string TransactionValueDate { get; set; }

        [JsonProperty("TransactionEntryDate")]
        public string TransactionEntryDate { get; set; }

        [JsonProperty("TransactionType")]
        public string TransactionType { get; set; }

        [JsonProperty("Amount")]
        public decimal Amount { get; set; }

        [JsonProperty("TransactionInformation")]
        public string TransactionInformation { get; set; }

        [JsonProperty("AccountServingInstitution")]
        public string AccountServingInstitution { get; set; }

        [JsonProperty("ClosingBalanceType")]
        public string ClosingBalanceType { get; set; }

        [JsonProperty("ReceivingAccountIdentification")]
        public string ReceivingAccountIdentification { get; set; }
    }
}
