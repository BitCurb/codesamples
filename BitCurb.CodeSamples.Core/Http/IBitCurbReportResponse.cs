using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCurb.CodeSamples.Core.Http
{
    public interface IBitCurbReportResponse<T>  where T : class
    {
        List<T> d { get; set; }
    }
}
