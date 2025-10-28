namespace Core.IoC
{
    // ReSharper disable once InconsistentNaming
    public static class DIInjectionTool
    {
        private static IServiceProvider _serviceProvider;

        public static void CopyServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static TServiceType GetService<TServiceType>() where TServiceType : class =>
            (TServiceType)_serviceProvider.GetService(typeof(TServiceType));
    }
}