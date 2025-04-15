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
        // Aqui voc� implementa a l�gica de renova��o ou redireciona para a p�gina de pagamento
        await DisplayAlert("Renovar", $"Voc� escolheu renovar o pacote: {_pacote.Nome}", "OK");
    }



}