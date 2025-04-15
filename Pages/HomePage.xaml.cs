namespace AppMobileEscolaDanca.Pages;

public partial class HomePage : ContentPage
{
    private string[] predefinedImages = ["thanossmile.jpg", "julius.jpeg", "latrel.jpg"];
    private int currentImageIndex = 0;
    public HomePage()
	{
		InitializeComponent();
        LoadDefaultProfileImage();
    }

    //Navega��o para outras paginas
    private async void BtnMinhaConta_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MinhaConta");
    }
    private async void BtnMinhasFinancas_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MinhasFinancas");
    }
    private async void BtnNovosPacotes_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Pacotes");
    }


    //Definindo a imagem padr�o do sistema
    //IMPLEMENTAR LOGICA QUE PERMITE ESCOLHER IMAGEM PADR�O E SALVAR A ESCOLHA NO BANCO
    private void LoadDefaultProfileImage()
    {
        ProfileImage.Source = ImageSource.FromFile(predefinedImages[currentImageIndex]);
    }

    //Definir a imagem de perfil do usuario
    private async void OnChangePhotoClicked(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("Escolha uma op��o", "Cancelar", null, "Usar Imagem Padr�o");

        if (action == "Usar Imagem Padr�o")
        {
            currentImageIndex = (currentImageIndex + 1) % predefinedImages.Length;
            ProfileImage.Source = ImageSource.FromFile(predefinedImages[currentImageIndex]);
        }
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
        //Calculo para identificar a representa��o do progresso * a largura para transforma em pixels
        double progresso = (AulasCompletas / (double)TotalAulas) * LarguraMaximaBarra;

        //Garante que a barra nunca ultrapasse o tamanho m�ximo do fundo,
        progresso = Math.Min(progresso, LarguraMaximaBarra);
        progressBar.WidthRequest = progresso;

        //verificando se a ImageGame.Source foi carregada de um arquivo local 
        //logo em seguida faz um cast seguro para FileImageSource, e guarda isso na vari�vel source

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
}