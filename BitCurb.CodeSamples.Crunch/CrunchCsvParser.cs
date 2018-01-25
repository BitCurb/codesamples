using BitCurb.CodeSamples.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCurb.CodeSamples.Crunch
{
    public class CrunchCsvParser : CsvParser<Transaction>
    {
        public CrunchCsvParser(string file) : base(file)
        {
        }

        public override Transaction ParseItem(string[] fields, string[] fieldNames)
        {
            Transaction transaction = new Transaction();

            for (int i = 0; i < fieldNames.Length; i++)
            {
                string fieldName = fieldNames[i];
                string fieldValue = fields[i];

                switch (fieldName)
                {
                    case "Transaction Reference Number":
                        transaction.TransactionReferenceNumber = fieldValue;
                        break;
                    case "Account Identification":
                        transaction.AccountIdentification = fieldValue;
                        break;
                    case "Opening Balance Type":
                        transaction.OpeningBalanceType = fieldValue;
                        break;
                    case "Currency":
                        transaction.Currency = fieldValue;
                        break;
                    case "Transaction Value Date":
                        transaction.TransactionValueDate = fieldValue;
                        break;
                    case "Transaction Entry Date":
                        transaction.TransactionEntryDate = fieldValue;
                        break;
                    case "Transaction Type":
                        transaction.TransactionType = fieldValue;
                        break;
                    case "Amount":
                        transaction.Amount = Convert.ToDecimal(fieldValue);
                        break;
                    case "Transaction Information":
                        transaction.TransactionInformation = fieldValue;
                        break;
                    case "Account Serving Institution":
                        transaction.AccountServingInstitution = fieldValue;
                        break;
                    case "Closing Balance Type":
                        transaction.ClosingBalanceType = fieldValue;
                        break;
                    case "Receiving Account Identification":
                        transaction.ReceivingAccountIdentification = fieldValue;
                        break;
                }
            }

            return transaction;
        }
    }
}
