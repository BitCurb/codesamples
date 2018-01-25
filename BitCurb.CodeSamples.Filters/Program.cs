using BitCurb.CodeSamples.Core;
using BitCurb.CodeSamples.Core.Entities;
using BitCurb.CodeSamples.Core.Http;
using BitCurb.CodeSamples.Core.Http.Request;
using BitCurb.CodeSamples.Core.Http.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Serialization;

namespace BitCurb.CodeSamples.Filters
{
    class Program
    {
        static void Main(string[] args)
        {
            FilterCsvParser parser = new FilterCsvParser(GetSourceDirectory() + "\\" + "phones_spec.csv");
            List<MobilePhone> phones = parser.Parse();

            int count = 1;
            List<CrunchItem<MobilePhone>> phoneItems = new List<CrunchItem<MobilePhone>>();
            foreach (MobilePhone phone in phones)
            {
                CrunchItem<MobilePhone> phoneItem = new CrunchItem<MobilePhone>();
                phoneItem.Id = count++;
                phoneItem.Item = phone;

                phoneItems.Add(phoneItem);
            }

            var dualSimPhones = FindDualSimPhones(phoneItems);
            var mostDurableBatteryPhones = FindMostDurableBatteryPhones(phoneItems);
            var bestHardwareAndCameraPhones = FindBestHardwareAndCameraPhones(phoneItems);

            var foundPhones = RunTemplate(phoneItems);
        }

        private static string GetSourceDirectory()
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo dirInfo = new DirectoryInfo(dir);

            return dirInfo.Parent.Parent.FullName;
        }

        private static FilterResponse<MobilePhone> FindDualSimPhones(List<CrunchItem<MobilePhone>> phoneItems)
        {
            CrunchRequest<MobilePhone> request = new CrunchRequest<MobilePhone>();
            request.One = phoneItems.ToArray();
            request.Filter = new Filter() { Expression = "$1.status != \"Discontinued\" AND FIND(\"Dual SIM\", $1.sim) >= 1 AND $1.card_slot != \"No\"" };
            request.FieldTypes = typeof(MobilePhone).GetProperties()
                                    .SelectMany(p => p.GetCustomAttributes(typeof(JsonPropertyAttribute), false).Cast<JsonPropertyAttribute>())
                                    .ToDictionary(p => p.PropertyName, p => "String");

            FilterResponse<MobilePhone> response = Task.Run(async () =>
            {
                ApiClient api = new ApiClient();

                return await api.SendAsync<CrunchRequest<MobilePhone>, FilterResponse<MobilePhone>>(request, "/api/1.0/crunch/run");
            }).GetAwaiter().GetResult();    

            return response;
        }

        private static FilterResponse<MobilePhone> FindMostDurableBatteryPhones(List<CrunchItem<MobilePhone>> phoneItems)
        {
            CrunchRequest<MobilePhone> request = new CrunchRequest<MobilePhone>();
            request.One = phoneItems.ToArray();
            request.Filter = new Filter() { Expression = "$1.status != \"Discontinued\" AND ISBLANK($1.stand_by_hours) == FALSE AND ISBLANK($1.talk_time_hours) == FALSE " +
                "AND TONUMBER($1.stand_by_hours) >= 400 AND TONUMBER($1.talk_time_hours) >= 10"
            };
            request.FieldTypes = typeof(MobilePhone).GetProperties()
                                    .SelectMany(p => p.GetCustomAttributes(typeof(JsonPropertyAttribute), false).Cast<JsonPropertyAttribute>())
                                    .ToDictionary(p => p.PropertyName, p => "String");

            FilterResponse<MobilePhone> response = Task.Run(async () =>
            {
                ApiClient api = new ApiClient();

                return await api.SendAsync<CrunchRequest<MobilePhone>, FilterResponse<MobilePhone>>(request, "/api/1.0/crunch/run");
            }).GetAwaiter().GetResult();

            return response;
        }

        private static FilterResponse<MobilePhone> FindBestHardwareAndCameraPhones(List<CrunchItem<MobilePhone>> phoneItems)
        {
            CrunchRequest<MobilePhone> request = new CrunchRequest<MobilePhone>();
            request.One = phoneItems.ToArray();
            request.Filter = new Filter() { Expression = "$1.status != \"Discontinued\" AND ISBLANK($1.internal_memory_mb) == FALSE AND ISBLANK($1.primary_camera_mp) == FALSE AND TONUMBER($1.internal_memory_mb) >= 8192 AND TONUMBER($1.primary_camera_mp) >= 8" };
            request.FieldTypes = typeof(MobilePhone).GetProperties()
                                    .SelectMany(p => p.GetCustomAttributes(typeof(JsonPropertyAttribute), false).Cast<JsonPropertyAttribute>())
                                    .ToDictionary(p => p.PropertyName, p => "String");

            FilterResponse<MobilePhone> response = Task.Run(async () =>
            {
                ApiClient api = new ApiClient();

                return await api.SendAsync<CrunchRequest<MobilePhone>, FilterResponse<MobilePhone>>(request, "/api/1.0/crunch/run");
            }).GetAwaiter().GetResult();

            return response;
        }

        private static FilterResponse<MobilePhone> RunTemplate(List<CrunchItem<MobilePhone>> phoneItems)
        {
            CrunchRequest<MobilePhone> request = new CrunchRequest<MobilePhone>();
            request.One = phoneItems.ToArray();

            // In case you want to run a template with multiple rules set the TemplateId property to the Id of the template.
            // Otherwise if you run a single rule set the RuleId property. You can either have the TemplateId or the RuleId set at any given time not both.
            request.TemplateId = 1;
            // request.RuleId = 4; 

            FilterResponse<MobilePhone> response = Task.Run(async () =>
            {
                ApiClient api = new ApiClient();

                return await api.SendAsync<CrunchRequest<MobilePhone>, FilterResponse<MobilePhone>>(request, "/api/1.0/crunch/run");
            }).GetAwaiter().GetResult();

            return response;
        }
    }
}
