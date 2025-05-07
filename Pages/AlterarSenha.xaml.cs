using AppMobileEscolaDanca.Classes;
using System.Text.RegularExpressions;

namespace AppMobileEscolaDanca.Pages;

public partial class AlterarSenha : ContentPage
{
	public AlterarSenha()
	{
		InitializeComponent();
       
    }

    private async void EnviarEmailTrocaSenha(object sender, EventArgs e)
    {
        string email = entryEmail.Text;
        var authService = new AuthFirebase();
        var user = await authService.EnviarLinkRecuperacaoAsync(email);

        // Limpa mensagens anteriores e mostra o loader
        lblMensagem.IsVisible = false;
        EnvioProgressBar.IsVisible = true;
        EnvioProgressBar.Progress = 0;

        // Simula carregamento
        await EnvioProgressBar.ProgressTo(0.5, 250, Easing.Linear);

        // Validações
        if (string.IsNullOrEmpty(email))
        {
            MostrarMensagem("Por favor, preencha o campo de e-mail.", false);
            return;
        }

        if (!IsEmailValido(email))
        {
            MostrarMensagem("E-mail inválido. Verifique o formato.", false);
            return;
        }

        // Simula processo final de envio
        await EnvioProgressBar.ProgressTo(1, 250, Easing.Linear);

        // lógica real de envio
        // Sucesso simulado:
        MostrarMensagem($"Código enviado com sucesso! Verifique seu e-mail.", true);
    }
    private void MostrarMensagem(string mensagem, bool sucesso)
    {
        lblMensagem.Text = mensagem;
        lblMensagem.TextColor = sucesso ? Colors.Green : Colors.Red;
        lblMensagem.IsVisible = true;
        EnvioProgressBar.IsVisible = false;
    }
    private bool IsEmailValido(string email)
    {
        // Validação simples com regex
        return Regex.IsMatch(email,
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.IgnoreCase);
    }
}