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
                Titulo = "Ballet Cl�ssico",
                DataVencimento = "01/11/2025",
                Valor = 400.00m,

                DataCompra = "08/05/2025",
                Descricao = "Aulas semanais de ballet para iniciantes",
                TipoPlano = "3 meses",
                NivelDificuldade = "Iniciante",
                DiaDaSemana = "Segunda-feira e Quinta-Feira",
                Horario = "18:00",
                Professor = "Ana Silva",
                QtdAulas = "30",
},
            new Pacote
            {
                Titulo = "Hip Hop",
                DataVencimento = "28/11/2025",
                Valor = 200.00m,

                DataCompra = "08/05/2025",
                Descricao = "Aulas semanais de ballet para iniciantes",
                TipoPlano = "3 meses",
                NivelDificuldade = "Intermedi�rio",
                DiaDaSemana = "Quarta-feira",
                Horario = "19:30",
                Professor = "Carlos Santos",
                QtdAulas = "15"
            }
        };

        listaPacotes.ItemsSource = PacotesAtivos;
    }
    //Navega��o entre a pagina
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
