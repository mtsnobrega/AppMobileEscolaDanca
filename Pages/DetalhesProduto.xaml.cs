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
        // Aqui você implementa a lógica de renovação ou redireciona para a página de pagamento
        //await DisplayAlert("Renovar", $"Você escolheu renovar o pacote: {produto.Nome}", "OK");
    }
}