using System.Collections.Generic;
using System.Threading.Tasks;
using Piwik.Analytics.NetCore.Date;
using Piwik.Analytics.NetCore.Parameters;
using Piwik.Analytics.NetCore.Results;

namespace Piwik.Analytics.NetCore.Modules
{
    public class VisitorInterest : PiwikAnalytics
    {
        private const string PLUGIN = "VisitorInterest";

        protected override string GetPlugin()
        {
            return PLUGIN;
        }

        public async Task<List<VisitsPerPage>> GetNumberOfVisitsPerPageAsync(int idSite, PiwikPeriod period, IPiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            return await SendRequestAsync<List<VisitsPerPage>>("getNumberOfVisitsPerPage", parameters);
        }

        public async Task<List<VisitsPerVisitCount>> GetNumberOfVisitsByVisitCountAsync(int idSite, PiwikPeriod period, IPiwikDate date,
            string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter(period),
                new PiwikDateParameter(date),
                new SimpleParameter("segment", segment)
            };

            return await SendRequestAsync<List<VisitsPerVisitCount>>("getNumberOfVisitsByVisitCount ", parameters);
        }
    }
}