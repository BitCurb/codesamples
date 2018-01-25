namespace BitCurb.CodeSamples.Core.Entities
{
    public class Crunch
    {
        public string Type { get; set; }

        public string Direction { get; set; }

        public string FieldName { get; set; }

        public bool CreateVariance { get; set; }

        public string VarianceOperator { get; set; }

        public decimal? VarianceValue { get; set; }
    }
}
