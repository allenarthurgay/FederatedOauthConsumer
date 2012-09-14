using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core
{
    public class ServiceRegistration
    {
        public static void RegisterAllContainers(Funq.Container container)
        {
            var regModules = GetAssembliesCurrentlyExecuting().ToArray()
                .SelectMany(GetTypes)
                .Where(p => p.IsClass && typeof(IFunqRegistrationModule).IsAssignableFrom(p))
                .ToList();

            foreach (var type in regModules)
            {
                var regModule = Activator.CreateInstance(type) as IFunqRegistrationModule;
                regModule.RegisterDependencies(container);
            }
        }

        public static IEnumerable<Type> GetTypes(Assembly assembly)
        {
            try
            {
                var t = assembly.GetTypes();
                return t;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Type>();
            }
        }
        public static IEnumerable<Assembly> GetAssembliesCurrentlyExecuting()
        {
            var x = GetAssemblyPaths(
                GetExecutingDirectory(Assembly.GetExecutingAssembly()));

            return x.Select(LoadAssembly).Where(a => a != null);
        }

        private static string GetExecutingDirectory(Assembly assembly)
        {
            string path = new Uri(assembly.CodeBase).LocalPath;
            return Path.GetDirectoryName(path);
        }

        public static IEnumerable<string> GetAssemblyPaths(string binDir)
        {
            return Directory.GetFiles(binDir, "*.dll");
        }

        private static Assembly LoadAssembly(string path)
        {
            try
            {
                return AppDomain.CurrentDomain.Load(Path.GetFileNameWithoutExtension(path));
            }
            catch
            {
            }
            return null;
        }
    }
}
