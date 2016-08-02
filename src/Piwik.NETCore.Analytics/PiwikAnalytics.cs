using System;
using Piwik.NETCore.Analytics.Services;
using Piwik.NETCore.Analytics.ServicesImpl;

namespace Piwik.NETCore.Analytics
{
    public class PiwikAnalytics
    {
        public static PiwikAnalytics CreateClient(string url, string tokenAuth)
        {
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                throw new ArgumentException(nameof(url), @"url must be well formed");
            }
            
            if (string.IsNullOrWhiteSpace(tokenAuth))
            {
                throw new ArgumentException(nameof(tokenAuth), @"tokenAuth cannot be empty");
            }
            
            return CreateClient(new Uri(url), tokenAuth);
        }
        
        public static PiwikAnalytics CreateClient(Uri uri, string tokenAuth)
        {
            if (uri == null)
            {
                throw new ArgumentException(nameof(uri), @"uri cannot be null");
            }
            
            if (string.IsNullOrWhiteSpace(tokenAuth))
            {
                throw new ArgumentException(nameof(tokenAuth), @"tokenAuth cannot be empty");
            }
            
            return new PiwikAnalytics(uri, tokenAuth);
        }
        
        public Uri Uri { get; }

        private IServiceLocator _services { get; }

        private PiwikAnalytics(Uri uri, string tokenAuth)
        {
            Uri = uri;
            
            var client = new PiwikAnalyticsClient(uri, tokenAuth);
            _services = new ServiceLocator();
            RegisterServices(_services, client);

        }

        private static void RegisterServices(IServiceLocator services, IPiwikAnalyticsClient client)
        {
            services.Register<IActionsService>(() => new ActionsService(client));
            services.Register<IReferrersService>(() => new ReferrersService(client));
            services.Register<IScheduledReportsService>(() => new ScheduledReportsService(client));
            services.Register<ISitesManagerService>(() => new SitesManagerService(client));
            services.Register<IVisitFrequencyService>(() => new VisitFrequencyService(client));
            services.Register<IVisitorInterestService>(() => new VisitorInterestService(client));
            services.Register<IVisitsSummaryService>(() => new VisitsSummaryService(client));
        }

        public IActionsService ActionsService
        {
            get
            {
                return _services.Get<IActionsService>();
            }
        }

        public IReferrersService ReferrersService
        {
            get
            {
                return _services.Get<IReferrersService>();
            }
        }

        public IScheduledReportsService ScheduledReportsService
        {
            get
            {
                return _services.Get<IScheduledReportsService>();
            }
        }

        public ISitesManagerService SitesManagerService
        {
            get
            {
                return _services.Get<ISitesManagerService>();
            }
        }

        public IVisitFrequencyService VisitFrequencyService
        {
            get
            {
                return _services.Get<IVisitFrequencyService>();
            }
        }

        public IVisitorInterestService VisitorInterestService
        {
            get
            {
                return _services.Get<IVisitorInterestService>();
            }
        }

        public IVisitsSummaryService VisitsSummaryService
        {
            get
            {
                return _services.Get<IVisitsSummaryService>();
            }
        }
    }
}