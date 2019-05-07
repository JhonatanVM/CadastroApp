using Autofac;
using CadastroApp.Dado.Interfaces;
using CadastroApp.Dado.Servicos;
using CadastroApp.Negocio.Interfaces;
using CadastroApp.Negocio.Servicos;

namespace CadastroApp.UI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CadastroNegocio>().As<ICadastroNegocio>();
            builder.RegisterType<CadastroDados>().As<ICadastroDados>();
            builder.RegisterType<Form1>();

            return builder.Build();
        }
    }
}
