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

            await Shell.Current.GoToAsync("//home");

            /*
             * original  
             * 
             * 
            string email = EntradaEmail.Text;
            string senha = EntradaSenha.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MostrarMensagem("Preencha todos os campos.", false);
                return;
            }

            try
            {
                var authService = new AuthFirebase();
                var resultado = await authService.LoginAsync(email, senha);

                MensagemLogin.IsVisible = false;
                EnvioProgressBar.IsVisible = true;
                EnvioProgressBar.Progress = 0;
                await EnvioProgressBar.ProgressTo(0.5, 250, Easing.Linear);

                if (resultado.Sucesso && resultado.Uid != null)
                {
                    var firebaseId = resultado.Uid;
                    var userInfoApi = new ServicoAPI();
                    var usuario = await userInfoApi.ObterUsuarioPorUid(firebaseId);

                    await DisplayAlert("Debug", $"UID usado: {firebaseId}", "OK");

                    if (usuario != null)
                    {
                        Sessao.Cliente = usuario;
                        await DisplayAlert("Sucesso", $"Bem-vindo(a), {usuario.Nome}", "OK");
                        await EnvioProgressBar.ProgressTo(1, 250, Easing.Linear);
                        await Shell.Current.GoToAsync("//home");
                    }
                    else
                    {
                        await DisplayAlert("Erro", "Usuário não encontrado na API.", "OK");
                    }
                }
                else
                {
                    MostrarMensagem(resultado.MensagemErro ?? "E-mail ou senha inválidos.", false);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Ocorreu um erro: {ex.Message}", "OK");
            }

            */










            /*
            string email = EntradaEmail.Text;
            string senha = EntradaSenha.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MostrarMensagem("Preencha todos os campos.", false);
                return;
            }
            else
            {
                try
                {


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
                        await DisplayAlert("Debug", $"UID usado: {firebaseId}", "OK");

                        if (usuario != null)
                        {
                            Sessao.Cliente = usuario;
                            await DisplayAlert("Sucesso", $"Bem-vindo(a), {user.Info.Email}", "OK");
                            await EnvioProgressBar.ProgressTo(1, 250, Easing.Linear);
                            await Shell.Current.GoToAsync("//home");
                        }
                        else
                        {
                            await DisplayAlert("Erro", "Usuário não encontrado na API.", "OK");
                        }
                    }
                    else
                    {
                        MostrarMensagem("E-mail ou senha inválidos.", false);
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", $"Ocorreu um erro: {ex.Message}", "OK");
                }
            }
            */
        }
        private void MostrarMensagem(string mensagem, bool sucesso)
        {
            MensagemLogin.Text = mensagem;
            MensagemLogin.TextColor = sucesso ? Colors.Green : Colors.Red;
            MensagemLogin.IsVisible = true;
            EnvioProgressBar.IsVisible = false;
        }
        //await Shell.Current.GoToAsync("//home");
        //await Shell.Current.GoToAsync("MinhaConta");

        /*
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
            await DisplayAlert("Debug", $"UID usado: {firebaseId}", "OK");

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
        */



        private async void BtnEsqSenha_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("EsqueciSenha");
        }
        private async void BtnCadastro_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("CadUsuario");
        }


        




        

        



        private void CliqueVerSenha(object sender, EventArgs e)
        {
            EntradaSenha.IsPassword = !EntradaSenha.IsPassword;

            var tiposenha = (ImageButton)sender;
            tiposenha.Source = EntradaSenha.IsPassword ? "nao_pode_olhar.png" : "pode_olhar.png";
        }

        
    }

}
