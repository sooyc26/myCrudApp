﻿ using LyricalOG.Interfaces;
using LyricalOG.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace LyricalOG
{
    public static class WebApiConfig
    {
        [Obsolete]
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.Filters.Add(new AuthorizeAttribute());

            config.MapHttpAttributeRoutes();
            var cors = new EnableCorsAttribute("*", "*", "*");

            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //dependency resolver register
            var container = new UnityContainer();

            container.RegisterType<IUsersProvider>(
                new InjectionFactory(c => new UserService()));

            container.RegisterType<IS3Provider>(
                new InjectionFactory(c => new S3Service()));

            container.RegisterType<ILyricsProvider>(
                 new InjectionFactory(c => new LyricService()));

            container.RegisterType<IBeatProvider>(
                new InjectionFactory(c => new BeatService()));

            container.RegisterType<ISendGridProvider>(
                new InjectionFactory(c => new SendGridService()));
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
