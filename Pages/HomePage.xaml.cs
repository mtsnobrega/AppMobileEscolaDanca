using AppMobileEscolaDanca.Classes;

namespace AppMobileEscolaDanca.Pages;

public partial class HomePage : ContentPage
{
    private string[] predefinedImages = ["perfil1.png", "perfil2.png", "perfil3.png"];
    private int currentImageIndex = 0;
    public HomePage()
	{
		InitializeComponent();
        LoadDefaultProfileImage();
        if (Sessao.Cliente != null)
        {
            var nome = Sessao.Cliente.Nome;
            Saudacao.Text = $"Bem vindo de Volta, {nome}";
        }
        else
        {
            Saudacao.Text = "Bem vindo!";
        }
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
            var imagemAtual = source.File;

            if (AulasCompletas <= 4 && imagemAtual != "game1.png")
            {
                ImageGame.Source = "game1.png";
            }
            else if (AulasCompletas > 4 && AulasCompletas < 8 && imagemAtual != "game2.png")
            {
                ImageGame.Source = "game2.png";
            }
            else if (AulasCompletas >= 10 && AulasCompletas < 14 && imagemAtual != "game3.png")
            {
                ImageGame.Source = "game3.png";
            }
            else if (AulasCompletas >= 15 && imagemAtual != "game4.png")
            {
                ImageGame.Source = "game4.png";
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