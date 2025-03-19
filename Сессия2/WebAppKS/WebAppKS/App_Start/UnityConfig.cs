using System;

using Unity;
using Unity.Lifetime;
using WebAppKS.Controllers;
using WebAppKS;


namespace WebAppKS
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        // Единственное определение для container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        // Единственное определение для Container
        public static IUnityContainer Container => container.Value;

        public static void RegisterTypes(IUnityContainer container)
        {
            // Регистрация сервисов
            container.RegisterType<IAuthService, AuthService>(new HierarchicalLifetimeManager());

            // Регистрация контроллеров
            container.RegisterType<AuthController>();
        }
    }
}