namespace AppMobileEscolaDanca.Pages;

using Microsoft.Maui.ApplicationModel.DataTransfer;
using Microsoft.Maui.Storage;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;

public partial class Home : TabbedPage
{
    private string[] predefinedImages = ["thanossmile.jpg", "julius.jpeg", "latrel.jpg"];
    private int currentImageIndex = 0;
    public Home()
	{
		InitializeComponent();
        LoadDefaultProfileImage();
        NavigationPage.SetHasNavigationBar(this, false);

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

    private void LoadDefaultProfileImage()
    {
        ProfileImage.Source = ImageSource.FromFile(predefinedImages[currentImageIndex]);
    }


    private async void OnChangePhotoClicked(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("Escolha uma opção", "Cancelar", null, "Usar Imagem Padrão", "Selecionar da Galeria");

        if (action == "Usar Imagem Padrão")
        {
            currentImageIndex = (currentImageIndex + 1) % predefinedImages.Length;
            ProfileImage.Source = ImageSource.FromFile(predefinedImages[currentImageIndex]);
        }
        else if (action == "Selecionar da Galeria")
        {
            var fileResult = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Escolha uma foto"
            });
            if (fileResult != null)
            {
                Console.WriteLine("Caminho do arquivo: " + fileResult.FullPath);
            }
            else
            {
                Console.WriteLine("Nenhum arquivo selecionado.");
            }
    
        }
    }
  


    //Navegação para outras paginas
    private async void BtnMinhaConta_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.MinhaConta());
    }
    private async void BtnMinhasFinancas_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.MinhasFinancas());
    }



    private int TotalAulas = 20;
    private int AulasCompletas = 0;
    private int aulas;
    private double LarguraMaximaBarra;


    // Executado quando a barra de fundo for renderizada ou alterada
    private void Barra_para_progredir(object sender, EventArgs e)
    {
        if (Barraprogresso.Width > 0)
        {
            LarguraMaximaBarra = Barraprogresso.Width;
            AtualizarProgresso();
        }
    }

    private void AtualizarProgresso()
    {
        //Calculo para identificar a representação do progresso * a largura para transforma em pixels
        double progresso = (AulasCompletas / (double)TotalAulas) * LarguraMaximaBarra;

        //Garante que a barra nunca ultrapasse o tamanho máximo do fundo,
        progresso = Math.Min(progresso, LarguraMaximaBarra);
        progressBar.WidthRequest = progresso;

        //verificando se a ImageGame.Source foi carregada de um arquivo local 
        //logo em seguida faz um cast seguro para FileImageSource, e guarda isso na variável source
        
        if (ImageGame.Source is FileImageSource source)
        {
            //dessa forma podemos pegar o nome da imagem que ocupa o ImageGame
            var imagemAtual = source.File;

            if (AulasCompletas < 10 && imagemAtual != "latrel.jpg")
            {
                ImageGame.Source = "latrel.jpg";
            }
            else if (AulasCompletas >= 10 && imagemAtual != "thanossmile.jpg")
            {
                ImageGame.Source = "thanossmile.jpg";
            }
        }

        labelAulas.Text = $"Aulas Completas: {AulasCompletas}/{TotalAulas}";
    }

    private void OnAulaCompleta(object sender, EventArgs e)
    {
        if (AulasCompletas < TotalAulas)
        {
            AulasCompletas++;
            aulas++;
            AtualizarProgresso();
        }
    }

    private void OnAul(object sender, EventArgs e)
    {
        if (AulasCompletas > 0)
        {
            AulasCompletas--;
            aulas--;
            AtualizarProgresso();
        }
    }

    private async void OnComprarClicked(object sender, EventArgs e)
    {
        await DisplayActionSheet("Escolha uma opção", "Cancelar", null, "Usar Imagem Padrão", "Selecionar da Galeria");
    }
}