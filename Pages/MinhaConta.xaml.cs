namespace AppMobileEscolaDanca.Pages;

public partial class MinhaConta : ContentPage
{
	public MinhaConta()
	{
		InitializeComponent();
    }

    //Salvar altera��es no banco
    private void OnSalvarClicked(object sender, EventArgs e)
    {

    }

    //Cancelar altera��es
    private void OnCancelarClicked(object sender, EventArgs e)
    {

    }

    //Alterar senha
    private async void OnAlterarSenhaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.AlterarSenha());
    }

    // Adicionar dependente
    private void OnAdicionarDependenteClicked(object sender, EventArgs e)
    {

    }
}