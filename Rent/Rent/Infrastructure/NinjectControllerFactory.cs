using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Ninject;
using System.Web.Mvc;
using Rent.Services.Interfaces;
using Rent.Services;

namespace Rent.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {

        private IKernel _kernel;

        public NinjectControllerFactory()
        {
            _kernel = new StandardKernel();
            AddBindings();

        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)this._kernel.Get(controllerType);
        }


        private void AddBindings()
        {
            this._kernel.Bind<IUser>().To<UserService>();
            this._kernel.Bind<ILocation>().To<LocationService>();

        }
    }
}