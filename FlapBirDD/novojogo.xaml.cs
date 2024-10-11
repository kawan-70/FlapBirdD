namespace FlapBirDD;

public partial class novojogo : ContentPage
{
	const int gravidade = 3;
	const int tempoEntreFrames = 25;
	bool morto = true;
	double larguraJanela = 0;
	double alturaJanela = 0;
	int velocidade = 20;


	public novojogo()
	{
		InitializeComponent();
	}

	async Task Desenhar()
	{
		while (!morto)
		{
			AplicarGravidade();
			await Task.Delay(tempoEntreFrames);
			GerenciaCanos();
		}
	}
	void AplicarGravidade()
	{
		viao.TranslationY += gravidade;
	}

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
		larguraJanela=width;
		alturaJanela=height;
    }

	void GerenciaCanos ()
	{
		canoD1.TranslationX-= velocidade;
		canoD2.TranslationX-= velocidade;
		if (canoD2.TranslationX<-larguraJanela)
		{
			canoD2.TranslationX=100;
			canoD1.TranslationX=100;
		}
	}
	void Inicializar()
	{
		morto=false;
	    viao.TranslationY=0;
	}

	void OnGameOverClicked(object s, TappedEventArgs a)
	{
		frameGameOver.IsVisible=false;
		Inicializar();
		Desenhar();

	}


}