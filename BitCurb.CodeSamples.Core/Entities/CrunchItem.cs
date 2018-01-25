using Newtonsoft.Json;

namespace BitCurb.CodeSamples.Core.Entities
{
    public class CrunchItem<T>
    {
        public long Id { get; set; }

        public decimal CrunchValue { get; set; }

        [JsonProperty("Fields")]
        public T Item { get; set; }
    }
}
