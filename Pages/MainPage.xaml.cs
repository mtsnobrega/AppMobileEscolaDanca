using Microsoft.Maui.ApplicationModel.Communication;
using System.Text.RegularExpressions;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using AppMobileEscolaDanca.Classes;

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
            string email = EntradaEmail.Text;
            string senha = EntradaSenha.Text;
            var authService = new AuthFirebase();
            var user = await authService.LoginAsync(email, senha);


            MensagemLogin.IsVisible = false;
            EnvioProgressBar.IsVisible = true;
            EnvioProgressBar.Progress = 0;

            await EnvioProgressBar.ProgressTo(0.5, 250, Easing.Linear);

            if (user != null)
            {
                string firebaseId = user.Uid;

                var UserInfoApi = new ServicoAPI();
                var usuario = await UserInfoApi.ObterUsuarioPorUid(firebaseId);
                //await DisplayAlert("Debug", $"UID usado: {firebaseId}", "OK");

                if (usuario != null)
                {
                    Sessao.Cliente = usuario;
                    await DisplayAlert("Sucesso", $"Bem-vindo(a), {user.Info.Email}", "OK");
                    // Redireciona para Home
                    // Simula processo final de envio
                    await EnvioProgressBar.ProgressTo(1, 250, Easing.Linear);


                    await Shell.Current.GoToAsync("//home");
                }
                else
                {
                    await DisplayAlert("Sucesso", $"Errooooooo, {user.Info.Email}", "OK");
                }

                
            }
            else
            {
                MostrarMensagem("Por favor, preencha o campo de e-mail.", false);
                return;
            }
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
            tiposenha.Source = EntradaSenha.IsPassword ? "nao_pode_olhar.png" : "pode_olhar.png";
        }

        
    }

}
