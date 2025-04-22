namespace AppMobileEscolaDanca.Pages;

using AppMobileEscolaDanca.Classes;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using System.Diagnostics;
using System.Text.Json;

public partial class CadastroUsuario : ContentPage
{
    private FirebaseAuthClient authClient;
    public CadastroUsuario()
    {
		InitializeComponent();
        var config = new FirebaseAuthConfig
        {
            ApiKey = "AIzaSyAQEhBNcCGviLcOye-AI5J63s8xNYmRe74",
            AuthDomain = "appmobileescoladanca.firebaseapp.com",
            Providers = new FirebaseAuthProvider[]
            {
                new EmailProvider()
            },
           //UserRepository = new NullUserRepository() // ou NullUserRepository() verficiar o modo de armazenamento local 
        };
        authClient = new FirebaseAuthClient(config);
    }

    private async void OnCadastrarClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string senha = SenhaEntry.Text;
        bool temErro = false;
        string mensagemErro = "";


        var campos = new Dictionary<string, string>
        {
            {"Nome", NomeEntry.Text },
            {"CPF", CpfEntry.Text },
            {"Email", EmailEntry.Text },
            {"Telefone", TelefoneEntry.Text },
        };

        foreach (var campo in campos)
        {
            if (string.IsNullOrEmpty(campo.Value))
            {
                mensagemErro += $"O campo '{campo.Key}' está vazio ou nulo.\n";
                temErro = true;
            }
        }
        if (SenhaEntry.Text != ConfirmarSenhaEntry.Text)
        {
            mensagemErro += "As senhas não coincidem.\n";
            temErro = true;
        }

        if (temErro)
        {
            await DisplayAlert("Erro no Cadastro", mensagemErro, "OK");
        }
        else
        {
            try
            {
                // Realiza o cadastro do usuário no Firebase
                var userCredential = await authClient.CreateUserWithEmailAndPasswordAsync(email, senha);

                // Após o cadastro, obtenha o token de ID do Firebase
                var firebaseUser = userCredential.User;


                var idToken = await firebaseUser.GetIdTokenAsync();

                // Agora envie o token para a API e cadastre o usuário
                var usuario = new Usuario
                {
                    UserIdFirebase = firebaseUser.Uid.ToString(),
                    Nome = NomeEntry.Text,
                    CPF = CpfEntry.Text,
                    Email = EmailEntry.Text,
                    Telefone = TelefoneEntry.Text,
                    DataNascimento = NascimentoPicker.Date
                };

                //teste do envio para api 
                var json = JsonSerializer.Serialize(usuario);
                Debug.WriteLine($"JSON Enviado para API: {json}");

                var sucesso = await CadastrarUsuarioApi(usuario, idToken);

                if (sucesso)
                {
                    await DisplayAlert("Sucesso", "Usuário cadastrado com sucesso!", "OK");
                }
                else
                {
                    await DisplayAlert("Erro", "Erro ao cadastrar o usuário na API", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
    private async Task<bool> CadastrarUsuarioApi(Usuario usuario, string idToken)
    {
        var usuarioService = new ServicoAPI();

        // Envia o token como parte do cabeçalho de autenticação
        return await usuarioService.CadastrarUsuario(usuario, idToken);
    }
}