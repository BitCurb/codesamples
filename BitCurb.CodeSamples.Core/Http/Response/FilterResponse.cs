using BitCurb.CodeSamples.Core.Entities;
using Newtonsoft.Json;

namespace BitCurb.CodeSamples.Core.Http.Response
{
    public class FilterResponse<T> : IApiResponse
    {
        [JsonProperty("$1")]
        public CrunchItem<T>[] One { get; set; }

        [JsonProperty("$2")]
        public CrunchItem<T>[] Two { get; set; }
    }
}
