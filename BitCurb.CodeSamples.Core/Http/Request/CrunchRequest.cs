using BitCurb.CodeSamples.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCurb.CodeSamples.Core.Http.Request
{
    public class CrunchRequest<T> : IApiRequest
    {
        [JsonProperty("$1")]
        public CrunchItem<T>[] One { get; set; }

        [JsonProperty("$2")]
        public CrunchItem<T>[] Two { get; set; }

        public Dictionary<string, string> FieldTypes { get; set; }

        public Filter Filter { get; set; }

        public Crunch Crunch { get; set; }

        public int? TemplateId { get; set; }

        public int? RuleId { get; set; }
    }
}
