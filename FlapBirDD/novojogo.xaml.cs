namespace FlapBirDD;

public partial class novojogo : ContentPage
{
const int Gravidade=5;
const int TempoEntreFrames=40;
bool Imorreu=true;
double LarguraJanela=0;
double AlturaJanela=0;
int velocidade=20;
void iinicializar()
{

}

    public novojogo()
	{
		InitializeComponent();
	}
	void AplicaGravidade()
	{
		viao.TranslationY +=Gravidade;
	}
	

     async Task Desenhar()
	 {
       while (!Imorreu)
       {
		AplicaGravidade();
		await Task.Delay(TempoEntreFrames);
	   }
	 }
   
	//void  OnGameOverClicked(object s, TappedEventArgs a)
	//{
	//	toque.IsVisible = false;
	//	inicializar();
	//	Desenhar();
	//}

}

