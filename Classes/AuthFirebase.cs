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

        //Autenticação de Login
        public async Task<User?> LoginAsync(string email, string senha)
        {
            try
            {
                var userCredential = await authClient.SignInWithEmailAndPasswordAsync(email, senha);
                return userCredential.User;
            }
            catch (FirebaseAuthException ex)
            {
                Console.WriteLine($"Erro: {ex.Reason}, {ex.Message}");
                return null;
            }
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


