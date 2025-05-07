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
        };
        authClient = new FirebaseAuthClient(config);
    }

    private async void OnCadastrarClicked(object sender, EventArgs e)
    {
    
        string email = EmailEntry.Text;
        string senha = SenhaEntry.Text;
        string confirmarSenha = ConfirmarSenhaEntry.Text;

        // Monta o objeto antes para validar os campos
        var usuario = new Usuario
        {
            Nome = NomeEntry.Text,
            CPF = CpfEntry.Text,
            Email = EmailEntry.Text,
            Telefone = TelefoneEntry.Text,
            DataNascimento = NascimentoPicker.Date,
            TipoUsuario = "Aluno"
        };

        // Validação dos campos antes de tentar criar no Firebase
        string erros = usuario.ValidarCampos(senha, confirmarSenha);

        if (!string.IsNullOrEmpty(erros))
        {
            await DisplayAlert("Erro no Cadastro", erros, "OK");
            return;
        }

        // Instancia a classe que cuida da autenticação
        var auth = new AuthFirebase();

        // Tenta registrar no Firebase
        var resultado = await auth.RegistrarUsuarioAsync(email, senha);

        if (!resultado.Sucesso)
        {
            await DisplayAlert("Erro: O email ja esta sendo utilizado", email, "OK");
            return;
        }

        // Preenche o ID do Firebase no usuário
        usuario.UserIdFirebase = resultado.Uid!;

        // Teste de log
        var json = JsonSerializer.Serialize(usuario);
        Debug.WriteLine($"JSON Enviado para API: {json}");

        // Envia para API
        var sucesso = await CadastrarUsuarioApi(usuario, usuario.UserIdFirebase!);

        if (sucesso)
        {
            await DisplayAlert("Sucesso", "Usuário cadastrado com sucesso!", "OK");
        }
        else
        {
            await DisplayAlert("Erro", "Erro ao cadastrar o usuário na API", "OK");
        }
    }
    private async Task<bool> CadastrarUsuarioApi(Usuario usuario, string idToken)
    {
        var usuarioService = new ServicoAPI();

        // Envia o token como parte do cabeçalho de autenticação
        return await usuarioService.CadastrarUsuario(usuario, idToken);
    }
}