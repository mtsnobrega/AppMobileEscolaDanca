using AppMobileEscolaDanca.Classes;

namespace AppMobileEscolaDanca.Pages;

public partial class MinhaConta : ContentPage
{
	public MinhaConta()
	{
		InitializeComponent();
        var cpf = Sessao.Cliente.CPF;
        var data = Sessao.Cliente.DataNascimento;
        var nome = Sessao.Cliente.Nome;
        var email = Sessao.Cliente.Email;
        var telefone = Sessao.Cliente.Telefone;

        entryCPF.Text = cpf;
        entryDataNascimento.Text = data.ToString();
        entryEmail.Text = email;
        entryNome.Text = nome;
        entryTelefone.Text = telefone;
    }

    //Salvar alterações no banco
    private void OnSalvarClicked(object sender, EventArgs e)
    {

    }

    //Cancelar alterações
    private void OnCancelarClicked(object sender, EventArgs e)
    {

    }

    //Alterar senha
    private async void OnAlterarSenhaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.AlterarSenha());
    }
}