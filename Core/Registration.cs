using Funq;

namespace Core
{
    public class Registration : IFunqRegistrationModule
    {
        public void RegisterDependencies(Container container)
        {
            container.Register<IDataConnectionProvider>(
                c => new DataConnectionProvider(DataConnectionProvider.Connectionstring));
        }
    }
}
