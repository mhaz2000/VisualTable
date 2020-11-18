﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Visual.Services.TableAddingValueService;
using Visual.Services.TableCreationService;
using Visual.Services.TableShowingService;

namespace Visual.Controllers
{
    public class NinjectController : DefaultControllerFactory
    {
        private IKernel _nenjectkernel;
        public NinjectController()
        {
            _nenjectkernel = new StandardKernel();
            AddBinding();
        }

        void AddBinding()
        {
            _nenjectkernel.Bind<IShowTableService>().To<ShowTableService>();
            _nenjectkernel.Bind<IAddValueTableService>().To<AddValueTableService>();
            _nenjectkernel.Bind<ICreationService>().To<CreationService>();
        }
        protected override IController GetControllerInstance(RequestContext requestContext,Type ControllerType)
        {
            return ControllerType == null ? null : (IController)_nenjectkernel.Get(ControllerType);
        }
    }
}