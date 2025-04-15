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

                },
                new Classes.Aula
                {
                    Id = "3",
                    Titulo = "Salsa",
                    Descricao = "Ritmos latinos para todos os níveis",
                    DiaDaSemana = "Sexta-feira",
                    Horario = "20:00",
                    Professor = "María Rodriguez",
                    NivelDificuldade = "Todos os níveis",

                },
                new Classes.Aula
                {
                    Id = "1",
                    Titulo = "Ballet Clássico",
                    Descricao = "Aula de ballet para iniciantes",
                    DiaDaSemana = "Segunda-feira",
                    Horario = "18:00",
                    Professor = "Ana Silva",
                    NivelDificuldade = "Iniciante",

                },
                new Classes.Aula
                {
                    Id = "1",
                    Titulo = "Ballet Clássico",
                    Descricao = "Aula de ballet para iniciantes",
                    DiaDaSemana = "Segunda-feira",
                    Horario = "18:00",
                    Professor = "Ana Silva",
                    NivelDificuldade = "Iniciante",
                }
        };
    }
}