namespace AppMobileEscolaDanca
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Criando as rotas de navegação shell

            //Navegação na pagina de login
            Routing.RegisterRoute("EsqueciSenha", typeof(Pages.EsqueciSenha));
            Routing.RegisterRoute("CadUsuario", typeof(Pages.CadastroUsuario));

            //Navegação a partir da página inicial
            Routing.RegisterRoute("HomePage", typeof(Pages.HomePage));
            
            Routing.RegisterRoute("Pacotes", typeof(Pages.Pacotes));
            Routing.RegisterRoute("DetalhesProduto", typeof(Pages.DetalhesProduto));

            Routing.RegisterRoute("MinhasFinancas", typeof(Pages.MinhasFinancas));
            Routing.RegisterRoute("DetalhesPacote", typeof(Pages.DetalhesPacote));

            Routing.RegisterRoute("MinhaConta", typeof(Pages.MinhaConta));
            Routing.RegisterRoute("AlterSenha", typeof(Pages.AlterarSenha));
        }
    }
}
