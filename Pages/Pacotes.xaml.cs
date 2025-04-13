namespace AppMobileEscolaDanca.Pages;

public partial class Pacotes : ContentPage
{
	public Pacotes()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        listaprodutos.ItemsSource = new List<Classes.Produtos>
        {
             new Classes.Produtos
                {
                    Id = "1",
                    Titulo = "Ballet Clássico",
                    Descricao = "Aula de ballet para iniciantes",
                    DiaDaSemana = "Segunda-feira",
                    Horario = "18:00",
                    Professor = "Ana Silva",
                    NivelDificuldade = "Iniciante",
                    ImagemUrl = "latrel.jpg"
                },
                new Classes.Produtos
                {
                    Id = "2",
                    Titulo = "Hip Hop",
                    Descricao = "Dança urbana contemporânea",
                    DiaDaSemana = "Quarta-feira",
                    Horario = "19:30",
                    Professor = "Carlos Santos",
                    NivelDificuldade = "Intermediário",
                    ImagemUrl = "latrel.jpg"
                },
                new Classes.Produtos
                {
                    Id = "3",
                    Titulo = "Salsa",
                    Descricao = "Ritmos latinos para todos os níveis",
                    DiaDaSemana = "Sexta-feira",
                    Horario = "20:00",
                    Professor = "María Rodriguez",
                    NivelDificuldade = "Todos os níveis",
                    ImagemUrl = "latrel.jpg"
                },
                new Classes.Produtos
                {
                    Id = "1",
                    Titulo = "Ballet Clássico",
                    Descricao = "Aula de ballet para iniciantes",
                    DiaDaSemana = "Segunda-feira",
                    Horario = "18:00",
                    Professor = "Ana Silva",
                    NivelDificuldade = "Iniciante",
                    ImagemUrl = "latrel.jpg"
                },
                new Classes.Produtos
                {
                    Id = "1",
                    Titulo = "Ballet Clássico",
                    Descricao = "Aula de ballet para iniciantes",
                    DiaDaSemana = "Segunda-feira",
                    Horario = "18:00",
                    Professor = "Ana Silva",
                    NivelDificuldade = "Iniciante",
                    ImagemUrl = "latrel.jpg"
                }
        };
    }

    //logica de comprar pacote selecionado 
    private void ComprarPacotes(object sender, EventArgs e)
    {

    }
}