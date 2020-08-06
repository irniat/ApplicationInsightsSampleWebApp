namespace ApplicationInsightsSampleWebApp
{
    using System;
    using System.Globalization;
    using System.Security.Claims;
    using Microsoft.ApplicationInsights.Channel;
    using Microsoft.ApplicationInsights.DataContracts;
    using Microsoft.ApplicationInsights.Extensibility;
    using Microsoft.AspNetCore.Http;

    public class AdditionalQosPropertiesInitializer : ITelemetryInitializer
    {
        readonly IHttpContextAccessor httpContextAccessor;

        public AdditionalQosPropertiesInitializer(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public void Initialize(ITelemetry telemetry)
        {
            if (httpContextAccessor.HttpContext != null)
            {
                //telemetry.Context.Operation.Name = "AfafafA";
                Console.WriteLine("Have reached here");
            }
        }
    }
}
