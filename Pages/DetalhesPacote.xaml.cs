namespace AppMobileEscolaDanca.Pages;
using AppMobileEscolaDanca.Classes;

public partial class DetalhesPacote : ContentPage
{
    private Pacote _pacote;

    public DetalhesPacote(Pacote pacote)
    {
        InitializeComponent();
        _pacote = pacote;
        BindingContext = _pacote;
    }

    private async void OnRenovarClicked(object sender, EventArgs e)
    {
        // Aqui você implementa a lógica de renovação ou redireciona para a página de pagamento
        await DisplayAlert("Renovar", $"Você escolheu renovar o pacote: {_pacote.Nome}", "OK");
    }



}