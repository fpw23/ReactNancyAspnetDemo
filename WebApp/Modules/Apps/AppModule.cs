using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace WebApp.Modules.App
{
    public class AppModule: Nancy.NancyModule
    {
        private IConfigProvider _config;

        public AppModule(IConfigProvider config)
        {
            this._config = config;

            Get["/"] = this.Start;
            
        }

        private dynamic Start(dynamic parms)
        {
            ViewBag.PageTitle = "Main";
            return View["Modules/Apps/Start"];
        }


    }
}