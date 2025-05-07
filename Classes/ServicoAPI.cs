using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppMobileEscolaDanca.Classes
{
    internal class ServicoAPI
    {
        private readonly HttpClient _httpClient;

        public ServicoAPI()
        {
            _httpClient = new HttpClient
            {

                BaseAddress = new Uri("https://apiescoladanca20250430175356-c0afdfgpd8e9bybz.canadacentral-01.azurewebsites.net/")
                //BaseAddress = new Uri("http://localhost:7266/")
            };
        }

        public async Task<Usuario?> ObterUsuarioPorUid(string uid)
        {
            try
            {
                var response = await _httpClient.GetAsync($"usuarios/{uid}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Usuario>();
                }
                return null;
            }
            catch (Exception ex)
            {
                // Trate o erro (exibir mensagem, log, etc.)
                return null;
            }
        }

        public async Task<bool> CadastrarUsuario(Usuario usuario, string idToken)
        {
            try
            {
                var json = JsonSerializer.Serialize(usuario);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Adiciona o token no header, se necessário
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", idToken);

                var response = await _httpClient.PostAsync("usuarios", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Log  da resposta da API
                    var respostaErro = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"Erro API: {respostaErro}");
                    await Application.Current.MainPage.DisplayAlert("Erro na API", respostaErro, "OK");
                    return false;
                }
            }
            catch (Exception ex)
            {
                //Captura erros de rede ou formatação
                Debug.WriteLine($"Erro Exception: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Exceção", ex.Message, "OK");
                return false;
            }
            
        }
    }
}
