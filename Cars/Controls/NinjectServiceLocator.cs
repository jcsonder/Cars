using Ninject;

namespace Cars.Controls
{
    public class NinjectServiceLocator
    {
        private readonly IKernel kernel;

        public NinjectServiceLocator()
        {
            kernel = new StandardKernel(new CarsModule());
        }

        public ICarsViewModel CarsViewModel
        {
            get { return kernel.Get<ICarsViewModel>(); }
        }
    }
}
