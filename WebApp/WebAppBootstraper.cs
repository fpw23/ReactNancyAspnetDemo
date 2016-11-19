using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Business.Interfaces;
using WebApp.Classes;

namespace WebApp
{
    public class WebAppBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<IConfigProvider, WebAppConfigProvider>();
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
           
            base.ApplicationStartup(container, pipelines);
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);

            var config = container.Resolve<IConfigProvider>();

            pipelines.BeforeRequest.AddItemToEndOfPipeline(c =>
            {
                c.ViewBag.IsProduction = config.GetAppSetting("Debug.IsProduction").ToBool();

                return null;
            });
        }


    }
}

