using AppMobileEscolaDanca.Classes;

namespace AppMobileEscolaDanca.Pages;

public partial class Pacotes : ContentPage
{
    public List<Produto> PacotesAtivos { get; set; }
    public Pacotes()
	{
		InitializeComponent();
        listaprodutos1.ItemsSource = new List<Classes.Produto>
        {
             new Classes.Produto
                {
                    Id = "1",
                    Titulo = "Ballet Clássico",
                    ValorMensal = 400.00m,
                    Descricao = "Aula de ballet para iniciantes",
                    DiaDaSemana = "Segunda-feira e Quinta-Feira",
                    Horario = "18:00",
                    Professor = "Ana Silva",
                    NivelDificuldade = "Iniciante",
                    TipoPlano = "Trimestral",
                    QtdAulas = "30",
                    ImagemUrl = "ballet.png"
                },
                new Classes.Produto
                {
                    Id = "2",
                    Titulo = "Hip Hop",
                    ValorMensal = 300.00m,
                    Descricao = "Dança urbana contemporânea",
                    DiaDaSemana = "Quarta-feira",
                    Horario = "19:30",
                    Professor = "Carlos Santos",
                    NivelDificuldade = "Intermediário",
                    ImagemUrl = "hiphop.png",
                    TipoPlano = "Trimestral",
                    QtdAulas = "15"
                },
                new Classes.Produto
                {
                    Id = "3",
                    Titulo = "Salsa",
                    ValorMensal = 200.00m,
                    Descricao = "Ritmos latinos para todos os níveis",
                    DiaDaSemana = "Sexta-feira",
                    Horario = "20:00",
                    Professor = "María Rodriguez",
                    NivelDificuldade = "Todos os níveis",
                    ImagemUrl = "salsa.png",
                    TipoPlano = "Trimestral",
                    QtdAulas = "15"


                },
        };
    }
  

    private async void DetalhesProduto_Clicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var pacoteSelecionado = button?.CommandParameter as Produto;

        if (pacoteSelecionado != null)
        {
            await Navigation.PushAsync(new DetalhesProduto(pacoteSelecionado));
        }
    }
}