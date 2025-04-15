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
                    Titulo = "Ballet Cl�ssico",
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
                    Descricao = "Dan�a urbana contempor�nea",
                    DiaDaSemana = "Quarta-feira",
                    Horario = "19:30",
                    Professor = "Carlos Santos",
                    NivelDificuldade = "Intermedi�rio",

                },
                new Classes.Aula
                {
                    Id = "3",
                    Titulo = "Salsa",
                    Descricao = "Ritmos latinos para todos os n�veis",
                    DiaDaSemana = "Sexta-feira",
                    Horario = "20:00",
                    Professor = "Mar�a Rodriguez",
                    NivelDificuldade = "Todos os n�veis",

                },
                new Classes.Aula
                {
                    Id = "1",
                    Titulo = "Ballet Cl�ssico",
                    Descricao = "Aula de ballet para iniciantes",
                    DiaDaSemana = "Segunda-feira",
                    Horario = "18:00",
                    Professor = "Ana Silva",
                    NivelDificuldade = "Iniciante",

                },
                new Classes.Aula
                {
                    Id = "1",
                    Titulo = "Ballet Cl�ssico",
                    Descricao = "Aula de ballet para iniciantes",
                    DiaDaSemana = "Segunda-feira",
                    Horario = "18:00",
                    Professor = "Ana Silva",
                    NivelDificuldade = "Iniciante",
                }
        };
    }
}