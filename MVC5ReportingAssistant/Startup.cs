using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MVC5ReportingAssistant.Startup))]

namespace MVC5ReportingAssistant
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
