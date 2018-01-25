using BitCurb.CodeSamples.Core.Entities;
using BitCurb.CodeSamples.Core.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCurb.CodeSamples.Reporting
{
    class Program
    {
        static void Main(string[] args)
        {
            var crunchRuns = GetCrunchRuns();
            var crunchRunsDetails = GetCrunchRunsDetails();
            var crunchRunsGroups = GetGrunchRunsGroupsResults();

            Console.ReadLine();
        }


        private static CrunchRunsResponse GetCrunchRuns()
        {
            CrunchRunsResponse response = Task.Run(async () =>
            {
                ApiClient api = new ApiClient();

                return await api.SendAsyncGet<CrunchRunsResponse>("/ReportData.svc/CrunchRuns");
            }).GetAwaiter().GetResult();

            return response;
        }

        private static CrunchRunsDetailsResponse GetCrunchRunsDetails()
        {
            CrunchRunsDetailsResponse response = Task.Run(async () =>
            {
                ApiClient api = new ApiClient();

                return await api.SendAsyncGet<CrunchRunsDetailsResponse>("/ReportData.svc/CrunchRunsDetails");
            }).GetAwaiter().GetResult();

            return response;
        }

        private static CrunchRunsGroupsResponse GetGrunchRunsGroupsResults()
        {
            CrunchRunsGroupsResponse response = Task.Run(async () =>
            {
                ApiClient api = new ApiClient();

                return await api.SendAsyncGet<CrunchRunsGroupsResponse>("/ReportData.svc/CrunchRunsGroups");
            }).GetAwaiter().GetResult();

            return response;
        }
    }
}
