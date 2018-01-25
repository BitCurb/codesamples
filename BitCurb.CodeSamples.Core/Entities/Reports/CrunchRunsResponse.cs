using BitCurb.CodeSamples.Core.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCurb.CodeSamples.Core.Entities
{
  
    public class CrunchRun
    {
        public string ID { get; set; }
        public Guid TenantID { get; set; }
        public string CrunchTemplateName { get; set; }
        public string TemplateSourceType { get; set; }
        public string RuleBody { get; set; }
        public string VarianceExpression { get; set; }
        public string ConsumerType { get; set; }
        public int LeftCount { get; set; }
        public int RightCount { get; set; }
        public int TotalCount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTimeUtc { get; set; }
    }

    public class CrunchRunsResponse : IBitCurbReportResponse<CrunchRun>
    {  
        public List<CrunchRun> d { get; set; }
    }


   

}
