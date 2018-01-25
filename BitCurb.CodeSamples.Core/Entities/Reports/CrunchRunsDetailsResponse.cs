using BitCurb.CodeSamples.Core.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCurb.CodeSamples.Core.Entities
{
    public class CrunchRunsDetails
    {
        public long ID { get; set; }
        public long CrunchHistoryID { get; set; }
        public bool IsFilter { get; set; }
        public int LeftCount { get; set; }
        public int RightCount { get; set; }
        public int? GroupCount { get; set; }
        public int? VarianceCount { get; set; }
        public long TimeInMilliseconds { get; set; }
        public bool IsSuccessful { get; set; }
        public DateTime CreatedTimeUtc { get; set; }
        public Guid CorrelationID { get; set; }
        public Guid TenantID { get; set; }
    }

    public class CrunchRunsDetailsResponse : IBitCurbReportResponse<CrunchRunsDetails>
    {
        public List<CrunchRunsDetails> d { get; set; }
    }
   
}
