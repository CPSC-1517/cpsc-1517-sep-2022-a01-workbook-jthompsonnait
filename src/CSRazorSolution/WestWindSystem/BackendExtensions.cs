#region Additional Namespace
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WestWindSystem.DAL;
#endregion


namespace WestWindSystem
{
    public static class BackendExtensions
    {
        public static void WWBackendDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            //  Within this method, we will register all the services that will
            //      be used by the system (context setup) and will be provided by
            //      the system.
            services.AddDbContext<WestWindContext>(options);
        }
    }
}
