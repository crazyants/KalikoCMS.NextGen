﻿namespace KalikoCMS.Mvc.Extensions {
#if NETCORE
    using Framework;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.AspNetCore.Routing;
    using ServiceLocation;
    using Services.Content.Interfaces;

    public static class RouteBuilderExtensions {
        public static void MapCms(this IRouteBuilder routeBuilder) {
            var actionInvokerFactory = routeBuilder.ServiceProvider.GetService(typeof(IActionInvokerFactory)) as IActionInvokerFactory;
            var actionSelector = routeBuilder.ServiceProvider.GetService(typeof(IActionSelector)) as IActionSelector;
            var actionContextAccessor = routeBuilder.ServiceProvider.GetService(typeof(IActionContextAccessor)) as IActionContextAccessor;
            var urlResolver = ServiceLocator.Current.GetInstance<IUrlResolver>();

            routeBuilder.Routes.Insert(0, new CmsRoute(actionSelector, actionInvokerFactory, actionContextAccessor, urlResolver));
        }
    }
#endif
}