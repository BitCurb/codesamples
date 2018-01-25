using BitCurb.CodeSamples.Core.Entities;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCurb.CodeSamples.Core
{
    public abstract class CsvParser<T>
    {
        private string file;

        public CsvParser(string file)
        {
            this.file = file;
        }

        public List<T> Parse()
        {
            TextFieldParser parser = new TextFieldParser(this.file);
            parser.Delimiters = new string[] { "," };

            string[] fieldNames = parser.ReadFields();
            List<T> items = new List<T>();

            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                T item = ParseItem(fields, fieldNames);

                items.Add(item);
            }

            return items;
        }

        public abstract T ParseItem(string[] fields, string[] fieldNames);
    }
}
