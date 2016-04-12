using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using System.Web.Routing;

namespace Web
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        public IWindsorContainer Container { get; set; }

        public CustomControllerFactory(IWindsorContainer container)
        {
            if (container != null)
                Container = container;
            else
            {
                throw new ArgumentNullException(nameof(container), "container parameter was null");
            }
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return Container.Resolve(controllerType) as IController;
        }

        public override void ReleaseController(IController controller)
        {
            var controllerToDispose = controller as IDisposable;

            if (controllerToDispose != null)
                controllerToDispose.Dispose();

            Container.Release(controller);
        }
    }
}