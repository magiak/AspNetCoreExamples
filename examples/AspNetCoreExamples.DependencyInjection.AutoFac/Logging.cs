using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreExamples.DependencyInjection.AutoFac
{
    public class Logging : ILogging
    {
    }

    public class DebugLogging : ILogging
    {
    }

    public interface ILogging
    {
    }
}
