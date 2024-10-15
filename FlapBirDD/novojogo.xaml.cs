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
			if (VerificaColisao())
			{
				morto = true;
				frameGameOver.IsVisible = true;
				break;
			}
			await Task.Delay(tempoEntreFrames);
		}
	}
	void AplicarGravidade()
	{
		viao.TranslationY += gravidade;
	}

	protected override void OnSizeAllocated(double width, double height)
	{
		base.OnSizeAllocated(width, height);
		larguraJanela = width;
		alturaJanela = height;
	}

	void GerenciaCanos()
	{
		canod1.TranslationX -= velocidade;
		canod2.TranslationX -= velocidade;
		if (canod2.TranslationX < -larguraJanela)
		{
			canod2.TranslationX = 100;
			canod1.TranslationX = 100;
		}
	}
	void Inicializar()
	{
		morto = false;
		viao.TranslationY = 0;
	}

	void OnGameOverClicked(object s, TappedEventArgs a)
	{
		frameGameOver.IsVisible = false;
		Inicializar();
		Desenhar();

	}

	bool VerificaColisao()
	{
		if (!morto)
		{
			if (VerificaColisaoTeto() ||
				VerificaColisaoChao())
			{
				return true;
			}
				
		}
		return false;
	}
	 private bool VerificaColisaoTeto()
	{
		var minY =-alturaJanela/2;
		if (viao.TranslationY <=minY)

	 	    return true;
	    else
			return false;
	}

	bool VerificaColisaoChao()
	{
		var mixY = alturaJanela/2 - chaoo.HeightRequest;
		if (viao.TranslationY >=mixY)
	 		return true;
	 else
			return false;
	}

}