using BitCurb.CodeSamples.Core.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCurb.CodeSamples.Core.Entities
{
    public class CrunchRunsGroups
    {
        public long ID { get; set; }
        public long CrunchHistoryID { get; set; }
        public Guid GroupIdentifier { get; set; }
        public decimal VarianceValue { get; set; }
        public string GroupElementIDs { get; set; }
        public Guid TenantID { get; set; }
    }

    public class CrunchRunsGroupsResponse : IBitCurbReportResponse<CrunchRunsGroups>
    {
        public List<CrunchRunsGroups> d { get; set; }
    }
   
}
