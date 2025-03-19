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
        // ������������ ����������� ��� container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        // ������������ ����������� ��� Container
        public static IUnityContainer Container => container.Value;

        public static void RegisterTypes(IUnityContainer container)
        {
            // ����������� ��������
            container.RegisterType<IAuthService, AuthService>(new HierarchicalLifetimeManager());

            // ����������� ������������
            container.RegisterType<AuthController>();
        }
    }
}