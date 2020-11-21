using Data.DataUnitOfWork;
using Ninject;
using Services.AddValueToTableService;
using Services.CreatingTableService;
using Services.ShowingTableService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace Factory
{
    public class NinjectController: DefaultControllerFactory
    {
        private IKernel _nenjectkernel;
        public NinjectController()
        {
            _nenjectkernel = new StandardKernel();
            AddBinding();
        }

        void AddBinding()
        {
            _nenjectkernel.Bind<IShowingService>().To<ShowingService>();
            _nenjectkernel.Bind<IAddingService>().To<AddingService>();
            _nenjectkernel.Bind<ICreatingService>().To<CreatingService>();
            _nenjectkernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type ControllerType)
        {
            return ControllerType == null ? null : (IController)_nenjectkernel.Get(ControllerType);
        }
    }
}
