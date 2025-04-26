using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;

namespace AppMobileEscolaDanca.Classes
{
    public class AuthFirebase
    {
        private FirebaseAuthClient authClient;
        private readonly FirebaseAuthProvider authProvider;

        public AuthFirebase()
        {
            // Definindo o caminho local para o repositório de usuários
            string localPath = FileSystem.AppDataDirectory;

            // Configuração do Firebase Auth
            var config = new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyAQEhBNcCGviLcOye-AI5J63s8xNYmRe74",
                AuthDomain = "appmobileescoladanca.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    //definindo o provedor utilizado => email e senha
                    new EmailProvider()
                },
                UserRepository = new FileUserRepository(localPath)
            };

            authClient = new FirebaseAuthClient(config);
        }

        // Cadastro de novo usuário
        public async Task<(bool Sucesso, string? MensagemErro, string? Uid, string? IdToken)> RegistrarUsuarioAsync(string email, string senha)
        {
            try
            {
                var userCredential = await authClient.CreateUserWithEmailAndPasswordAsync(email, senha);
                var user = userCredential.User;

                var idToken = await user.GetIdTokenAsync();

                return (true, null, user.Uid, idToken);
            }
            catch (FirebaseAuthException ex)
            {
                return (false, ex.Message, null, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, null);
            }
        }

        public class ResultadoLogin
        {
            public bool Sucesso { get; set; }
            public string? Uid { get; set; }
            public string? IdToken { get; set; }
            public string? MensagemErro { get; set; }
        }



        //Autenticação de Login
        public async Task<ResultadoLogin> LoginAsync(string email, string senha)
        {
            var resultado = new ResultadoLogin();

            try
            {
                var userCredential = await authClient.SignInWithEmailAndPasswordAsync(email, senha);
                var user = userCredential.User;
                var idToken = await user.GetIdTokenAsync();

                resultado.Sucesso = true;
                resultado.Uid = user.Uid;
                resultado.IdToken = idToken;
            }
            catch (FirebaseAuthException ex)
            {
                resultado.Sucesso = false;
                resultado.MensagemErro = $"Erro: {ex.Reason}, {ex.Message}";
            }

            return resultado;
        }

        //Recuperação de senha 
        public async Task<bool> EnviarLinkRecuperacaoAsync(string email)
        {
            try
            {
                await authClient.ResetEmailPasswordAsync(email);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar e-mail de recuperação: {ex.Message}");
                return false;
            }
        }

        /*
        public User? UsuarioAtual()
        {
            return authClient.CurrentUser;
        }

        public async Task LogoutAsync()
        {
            await authClient.SignOutAsync();
        }

        */

    }
}


