using AppMobileEscolaDanca.Classes;
namespace AppMobileEscolaDanca.Pages;

public partial class MinhasFinancas : ContentPage
{
    public List<Pacote> PacotesAtivos { get; set; }
    public MinhasFinancas()
	{
		InitializeComponent();
        CarregarPacotes();
    }
    private void CarregarPacotes()
    {
        PacotesAtivos = new List<Pacote>
        {
            new Pacote
            {
                Nome = "Ballet Clássico",
                Descricao = "Aulas semanais de ballet para iniciantes",
                Duracao = "3 meses",
                DataVencimento = DateTime.Today.AddMonths(1),
                Valor = 400.00m
            },
            new Pacote
            {
                Nome = "Hip Hop Avançado",
                Descricao = "Aulas intensas para níveis avançados",
                Duracao = "6 meses",
                DataVencimento = DateTime.Today.AddMonths(2),
                Valor = 720.00m
            }
        };

        listaPacotes.ItemsSource = PacotesAtivos;
    }
    //Navegação entre a pagina
    private async void DetalesPacote_Click(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var pacoteSelecionado = button?.CommandParameter as Pacote;

        if (pacoteSelecionado != null)
        {
            await Navigation.PushAsync(new DetalhesPacote(pacoteSelecionado));
        }
    }
}
