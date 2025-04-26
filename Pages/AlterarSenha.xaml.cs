using AppMobileEscolaDanca.Classes;

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

        lblMensagem.IsVisible = false;
        EnvioProgressBar.IsVisible = true;
        EnvioProgressBar.Progress = 0;

        // Simula carregamento
        await EnvioProgressBar.ProgressTo(0.5, 250, Easing.Linear);

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
}