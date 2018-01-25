using BitCurb.CodeSamples.Core.Entities;
using Newtonsoft.Json;

namespace BitCurb.CodeSamples.Core.Http.Response
{
    public class CrunchResponse : IApiResponse
    {
        #region Fields

        private CrunchGroup[] groups;

        #endregion

        #region Properties

        [JsonProperty("Groups")]
        public CrunchGroup[] Groups
        {
            get
            {
                if (this.groups == null)
                {
                    this.groups = new CrunchGroup[0];
                }

                return this.groups;
            }
            set
            {
                this.groups = value;
            }
        }

        #endregion
    }
}
