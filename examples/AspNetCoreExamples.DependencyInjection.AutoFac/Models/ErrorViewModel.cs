using System;

namespace AspNetCoreExamples.DependencyInjection.AutoFac.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
