namespace FlapBirDD;

public partial class novojogo : ContentPage
{
	const int gravidade = 15;
	const int tempoEntreFrames = 20;
	const int maxTempoPulando = 3;
	const int forcaPulo = 25;
	const int AberturaMinima = 220;
	bool morto = true;
	bool estaPulando = false;
	double larguraJanela = 15;
	double alturaJanela = 15;
	int velocidade = 25;
	int TempoPulando = 3;
	int score = 0;
	

	public novojogo()
	{
		InitializeComponent();
	}

	async Task Desenhar()
	{
		while (!morto)
		{
			if (estaPulando)
				AplicaPulo();
			else
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
		canod1.WidthRequest=150;
		canod2.WidthRequest=150;
	}

	void GerenciaCanos()
	{
		canod1.TranslationX -= velocidade;
		canod2.TranslationX -= velocidade;
		if (canod2.TranslationX < -larguraJanela)
		{
			canod2.TranslationX = 100;
			canod1.TranslationX = 100;
			score++;
			if(score % 2 == 0)
			velocidade++;
			LabelLP.Text = "canos: " + score.ToString("D4");
			var alturaMax = -100;
			var alturaMin = -canod2.HeightRequest;
			canod1.TranslationY = Random.Shared.Next((int)alturaMin, (int)alturaMax);
			canod2.TranslationY = canod1.TranslationY + AberturaMinima + canod2.HeightRequest;



		}
	}
	void Inicializar()
	{
		canod1.TranslationX = -larguraJanela;
		canod2.TranslationX = -larguraJanela;
		viao.TranslationX = 0;
		viao.TranslationY = 0;
		score = 0;
		GerenciaCanos();
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
		
		{
		      return VerificaColisaoTeto() ||
				VerificaColisaoChao() ||
				VerificaColisaoCanoCima()||
				VerificaColisaoCanoBaixo();
		}
	}
	private bool VerificaColisaoTeto()
	{
		var minY = -alturaJanela / 2;
		if (viao.TranslationY <= minY)

			return true;
		else
			return false;
	}

	bool VerificaColisaoChao()
	{
		var mixY = alturaJanela / 2;
		if (viao.TranslationY >= mixY)
			return true;
		else
			return false;
	}

	bool VerificaColisaoCanoCima()
	{
		var posHviao = (larguraJanela/2)-(viao.WidthRequest/2);
		var posVviao = (alturaJanela/2)-(viao.HeightRequest/2)+viao.TranslationY;
		if (posHviao>= Math.Abs(canod1.TranslationX)-canod1.WidthRequest &&
			posHviao<= Math.Abs(canod1.TranslationX)+canod1.WidthRequest &&
			posVviao<= canod1.HeightRequest + canod1.TranslationY)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	   bool VerificaColisaoCanoBaixo()
	{
		var posHviao = (larguraJanela/2)-(viao.WidthRequest/2);
		var posVviao = (alturaJanela/2) + (viao.HeightRequest/2) + viao.TranslationY;
		var yMaxCano= canod1.HeightRequest + canod1.TranslationY + AberturaMinima;
		if (posHviao >= Math.Abs(canod2.TranslationX) - canod2.WidthRequest &&
			posHviao<= Math.Abs(canod2.TranslationX) + canod2.WidthRequest &&
			posVviao >=yMaxCano)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	void AplicaPulo()
	{
		viao.TranslationY -= forcaPulo;
		TempoPulando++;
		if (TempoPulando >= maxTempoPulando)
		{
			estaPulando = false;
			TempoPulando = 0;
		}
	}
	void OnGridClickd(object s, TappedEventArgs a)
	{
		estaPulando = true;
	}
	
}