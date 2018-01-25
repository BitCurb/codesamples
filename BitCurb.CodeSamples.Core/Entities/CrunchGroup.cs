using Newtonsoft.Json;
using System;

namespace BitCurb.CodeSamples.Core.Entities
{
    public class CrunchGroup
    {
        #region Fields

        private long[] elements { get; set; }

        #endregion

        #region Properties

        [JsonProperty("Identifier")]
        public Guid Identifier { get; set; }

        [JsonProperty("Elements")]
        public long[] Elements
        {
            get
            {
                if (this.elements == null)
                {
                    this.elements = new long[0];
                }

                return this.elements;
            }
            set
            {
                this.elements = value;
            }
        }

        #endregion
    }
}
