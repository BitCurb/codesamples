using BitCurb.CodeSamples.Core.Entities;
using BitCurb.CodeSamples.Core.Http;
using BitCurb.CodeSamples.Core.Http.Request;
using BitCurb.CodeSamples.Core.Http.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BitCurb.CodeSamples.Crunch
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Transaction> bankTransactions = LoadTransactions("bank.csv");
            List<Transaction> glTransactions = LoadTransactions("gl.csv");

            int count = 1;

            List<CrunchItem<Transaction>> bankItems = new List<CrunchItem<Crunch.Transaction>>();
            foreach (Transaction bankTran in bankTransactions)
            {
                CrunchItem<Transaction> tranItem = new CrunchItem<Crunch.Transaction>();
                tranItem.Id = count++;
                tranItem.CrunchValue = bankTran.Amount;
                tranItem.Item = bankTran;

                bankItems.Add(tranItem);
            }

            List<CrunchItem<Transaction>> glItems = new List<CrunchItem<Crunch.Transaction>>();
            foreach (Transaction glTran in glTransactions)
            {
                CrunchItem<Transaction> tranItem = new CrunchItem<Crunch.Transaction>();
                tranItem.Id = count++;
                tranItem.CrunchValue = glTran.Amount;
                tranItem.Item = glTran;

                glItems.Add(tranItem);
            }

            var oneToManyWithoutVarianceGroups = FindOneToManyWithoutVariance(bankItems, glItems);
            var oneToManyWithVarianceGroups = FindOneToManyWithVariance(bankItems, glItems);
            var oneToOneGroups = FindOneToOneGroups(bankItems, glItems);

            var groups = RunTemplate(bankItems, glItems);
        }

        private static CrunchResponse FindOneToManyWithoutVariance(List<CrunchItem<Transaction>> bankItems, List<CrunchItem<Transaction>> glItems)
        {
            CrunchRequest<Transaction> request = new CrunchRequest<Transaction>();
            request.One = glItems.ToArray();
            request.Two = bankItems.ToArray();
            request.Filter = new Filter() { Expression = @"$1.AccountIdentification == $2.AccountIdentification AND $1.TransactionValueDate == $2.TransactionValueDate AND 
                $1.TransactionType == $2.TransactionType AND FIND($2.AccountServingInstitution, $1.AccountServingInstitution) >= 1" };
            request.Crunch = new Core.Entities.Crunch() { Type = "1ToMany", Direction = "$1To$2", FieldName = "Amount", CreateVariance = false };
            request.FieldTypes = typeof(Transaction).GetProperties()
                                    .SelectMany(p => p.GetCustomAttributes(typeof(JsonPropertyAttribute), false).Cast<JsonPropertyAttribute>())
                                    .ToDictionary(p => p.PropertyName, p => p.PropertyName == "Amount" ? "Decimal" : "String");

            CrunchResponse response = Task.Run(async () =>
            {
                ApiClient api = new ApiClient();

                return await api.SendAsync<CrunchRequest<Transaction>, CrunchResponse>(request, "/api/1.0/crunch/run");
            }).GetAwaiter().GetResult();

            return response;
        }

        private static CrunchResponse FindOneToManyWithVariance(List<CrunchItem<Transaction>> bankItems, List<CrunchItem<Transaction>> glItems)
        {
            CrunchRequest<Transaction> request = new CrunchRequest<Transaction>();
            request.One = glItems.ToArray();
            request.Two = bankItems.ToArray();
            request.Filter = new Filter() { Expression = @"$1.AccountIdentification == $2.AccountIdentification AND $1.TransactionValueDate == $2.TransactionValueDate AND 
                $1.TransactionType == $2.TransactionType AND $1.AccountServingInstitution == $2.AccountServingInstitution" };
            request.Crunch = new Core.Entities.Crunch() { Type = "1ToMany", Direction = "$1To$2", FieldName = "Amount", CreateVariance = true, VarianceOperator = "<", VarianceValue = 20M };
            request.FieldTypes = typeof(Transaction).GetProperties()
                                    .SelectMany(p => p.GetCustomAttributes(typeof(JsonPropertyAttribute), false).Cast<JsonPropertyAttribute>())
                                    .ToDictionary(p => p.PropertyName, p => p.PropertyName == "Amount" ? "Decimal" : "String");

            CrunchResponse response = Task.Run(async () =>
            {
                ApiClient api = new ApiClient();

                return await api.SendAsync<CrunchRequest<Transaction>, CrunchResponse>(request, "/api/1.0/crunch/run");
            }).GetAwaiter().GetResult();

            return response;
        }

        private static CrunchResponse FindOneToOneGroups(List<CrunchItem<Transaction>> bankItems, List<CrunchItem<Transaction>> glItems)
        {
            CrunchRequest<Transaction> request = new CrunchRequest<Transaction>();
            request.One = glItems.ToArray();
            request.Two = bankItems.ToArray();
            request.Filter = new Filter() { Expression = "$1.AccountServingInstitution == $2.AccountServingInstitution AND $1.Amount == $2.Amount" };
            request.Crunch = new Core.Entities.Crunch() { Type = "1To1", Direction = "$1To$2", FieldName = "Amount", CreateVariance = false };
            request.FieldTypes = typeof(Transaction).GetProperties()
                                    .SelectMany(p => p.GetCustomAttributes(typeof(JsonPropertyAttribute), false).Cast<JsonPropertyAttribute>())
                                    .ToDictionary(p => p.PropertyName, p => p.PropertyName == "Amount" ? "Decimal" : "String");

            CrunchResponse response = Task.Run(async () =>
            {
                ApiClient api = new ApiClient();

                return await api.SendAsync<CrunchRequest<Transaction>, CrunchResponse>(request, "/api/1.0/crunch/run");
            }).GetAwaiter().GetResult();

            return response;
        }

        private static CrunchResponse RunTemplate(List<CrunchItem<Transaction>> bankItems, List<CrunchItem<Transaction>> glItems)
        {
            CrunchRequest<Transaction> request = new CrunchRequest<Transaction>();
            request.One = glItems.ToArray();
            request.Two = bankItems.ToArray();

            // In case you want to run a template with multiple rules set the TemplateId property to the Id of the template.
            // Otherwise if you run a single rule set the RuleId property. You can either have the TemplateId or the RuleId set at any given time not both.
            request.TemplateId = 2;

            CrunchResponse response = Task.Run(async () =>
            {
                ApiClient api = new ApiClient();

                return await api.SendAsync<CrunchRequest<Transaction>, CrunchResponse>(request, "/api/1.0/crunch/run");
            }).GetAwaiter().GetResult();

            return response;
        }

        private static List<Transaction> LoadTransactions(string file)
        {
            CrunchCsvParser parser = new CrunchCsvParser(GetSourceDirectory() + "\\" + file);

            return parser.Parse();
        }

        private static string GetSourceDirectory()
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo dirInfo = new DirectoryInfo(dir);

            return dirInfo.Parent.Parent.FullName;
        }
    }
}
