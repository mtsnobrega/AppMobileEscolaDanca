using AppMobileEscolaDanca.Classes;

namespace AppMobileEscolaDanca.Pages;

public partial class DetalhesProduto : ContentPage
{
    private Produto produto;

    public DetalhesProduto(Produto pac)
    {
        InitializeComponent();
        produto = pac;
        BindingContext = produto;
    }

    private async void OnRenovarClicked(object sender, EventArgs e)
    {
        // Aqui voc� implementa a l�gica de renova��o ou redireciona para a p�gina de pagamento
        //await DisplayAlert("Renovar", $"Voc� escolheu renovar o pacote: {produto.Nome}", "OK");
    }
}