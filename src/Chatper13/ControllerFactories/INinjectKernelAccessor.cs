using Ninject;

namespace ControllerFactories
{
    public interface INinjectKernelAccessor
    {
        IKernel Kernel { get; }
    }
}