namespace AppMobileEscolaDanca.Pages;

public partial class ListaPacotesAdquiridos : ContentPage
{
	public ListaPacotesAdquiridos()
	{
		InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
        listaAulas.ItemsSource = new List<Classes.Aula>
            {
                new Classes.Aula
                {
                    Id = "1",
                    Titulo = "Ballet Clássico",
                    Descricao = "Aula de ballet para iniciantes",
                    DiaDaSemana = "Segunda-feira",
                    Horario = "18:00",
                    Professor = "Ana Silva",
                    NivelDificuldade = "Iniciante",
                    ImagemUrl = "ballet.png"

                },
                new Classes.Aula
                {
                    Id = "1",
                    Titulo = "Ballet Clássico",
                    Descricao = "Aula de ballet para iniciantes",
                    DiaDaSemana = "Quinta-Feira",
                    Horario = "18:00",
                    Professor = "Ana Silva",
                    NivelDificuldade = "Iniciante",
                    ImagemUrl = "ballet.png"

                },
                new Classes.Aula
                {
                    Id = "2",
                    Titulo = "Hip Hop",
                    Descricao = "Dança urbana contemporânea",
                    DiaDaSemana = "Quarta-feira",
                    Horario = "19:30",
                    Professor = "Carlos Santos",
                    NivelDificuldade = "Intermediário",
                    ImagemUrl = "hiphop.png",

                },
                new Classes.Aula
                {
                    Id = "1",
                    Titulo = "Salsa",
                    Descricao = "Ritmos latinos para todos os níveis",
                    DiaDaSemana = "Segunda-feira",
                    Horario = "18:00",
                    Professor = "Ana Silva",
                    NivelDificuldade = "Iniciante",
                    ImagemUrl = "salsa.png"

                },
                new Classes.Aula
                {
                    Id = "1",
                    Titulo = "Salsa",
                    Descricao = "Ritmos latinos para todos os níveis",
                    DiaDaSemana = "Quinta-Feira",
                    Horario = "18:00",
                    Professor = "Ana Silva",
                    NivelDificuldade = "Iniciante",
                    ImagemUrl = "salsa.png"
                }
        };
    }
}