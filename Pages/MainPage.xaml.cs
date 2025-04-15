using Microsoft.Maui.ApplicationModel.Communication;
using System.Text.RegularExpressions;

namespace AppMobileEscolaDanca.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //Remover a barra de navegação da tela atual
            NavigationPage.SetHasNavigationBar(this, false);
        }

        //Navegação entre paginas
        private async void Btnlogin_Clicked(object sender, EventArgs e)
        {
            MensagemLogin.IsVisible = false;
            EnvioProgressBar.IsVisible = true;
            EnvioProgressBar.Progress = 0;

            string email = CampoEmail.Text;


            await EnvioProgressBar.ProgressTo(0.5, 250, Easing.Linear);


            if (string.IsNullOrEmpty(email))
            {
                MostrarMensagem("Por favor, preencha o campo de e-mail.", false);
                return;
            }

            if (email != "adm")
            {
                MostrarMensagem("E-mail inválido. Verifique o formato.", false);
                return;
            }

            // Simula processo final de envio
            await EnvioProgressBar.ProgressTo(1, 250, Easing.Linear);

            // lógica real de envio
            // Sucesso simulado:
            MostrarMensagem("Código enviado com sucesso! Verifique seu e-mail.", true);
            
            await Shell.Current.GoToAsync("//home");

        }

        private async void BtnEsqSenha_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("EsqueciSenha");
        }
        private async void BtnCadastro_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("CadUsuario");
        }


        private void MostrarMensagem(string mensagem, bool sucesso)
        {
            MensagemLogin.Text = mensagem;
            MensagemLogin.TextColor = sucesso ? Colors.Green : Colors.Red;
            MensagemLogin.IsVisible = true;
            EnvioProgressBar.IsVisible = false;
        }




        

        



        private void CliqueVerSenha(object sender, EventArgs e)
        {
            EntradaSenha.IsPassword = !EntradaSenha.IsPassword;

            var tiposenha = (ImageButton)sender;
            tiposenha.Source = EntradaSenha.IsPassword ? "pode_olhar.png" : "nao_pode_olhar.png";
        }

        
    }

}
