using Ftsoft.Storage;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Project.Startup
{
    public static class RepositoryExtensions
    {
        public static RepositoryRegistrator<TRepository> RegisterRepository<TRepository, TRepositoryImpl>(this 
        IServiceCollection serviceCollection) 
            where TRepository: class
            where TRepositoryImpl : TRepository
        {
            var repositoryType = typeof(TRepository);
            var readonlyImplementation = repositoryType.GetInterface(typeof(IReadOnlyRepository<>).Name);

            serviceCollection.RegisterRepositoryInternal(repositoryType
                , readonlyImplementation
                , typeof(TRepositoryImpl));
            
            return new RepositoryRegistrator<TRepository>(serviceCollection);
        }

        public static RepositoryRegistrator<TRepository> RegisterRepository<TRepository, TReadOnlyRepository, TRepositoryImpl>(
            this IServiceCollection serviceCollection)
            where TRepository : class
            where TReadOnlyRepository: class
            where TRepositoryImpl : TRepository
        {
            serviceCollection.RegisterRepositoryInternal(typeof(TRepository)
                , typeof(TReadOnlyRepository)
                , typeof(TRepositoryImpl));
            
            return new RepositoryRegistrator<TRepository>(serviceCollection);
        }

        private static void RegisterRepositoryInternal(this IServiceCollection serviceCollection
            , Type repository
            , Type readonlyRepository
            , Type repositoryImpl)
        {
            serviceCollection.AddTransient(repositoryImpl);
            serviceCollection.AddTransient(repository, repositoryImpl);
            serviceCollection.AddTransient(readonlyRepository, x =>
            {
                var repImpl = x.GetService(repositoryImpl);
                
                var property = repImpl.GetType().GetProperty("ReadOnly");
                property.SetValue(repImpl, true);
                
                return repImpl;
            });
        }
        
        public class RepositoryRegistrator<TRepository> where TRepository : class
        {
            private readonly IServiceCollection _serviceCollection;

            public RepositoryRegistrator(IServiceCollection serviceCollection)
            {
                _serviceCollection = serviceCollection;
            }

            public RepositoryRegistrator<TRepository> AddDecorator<TDecorator>() where TDecorator : class, TRepository
            {
                _serviceCollection.Replace(ServiceDescriptor.Transient<TRepository, TDecorator>());
                return this;
            }
            
            public RepositoryRegistrator<TRepository> AddDecorator<TDecorator>(Func<IServiceProvider,TDecorator> factory) 
                where TDecorator : class, TRepository
            {
                _serviceCollection.AddTransient<TRepository, TDecorator>(factory);
                return this;
            }
        }
    }
}