namespace FlapBirDD;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}
   private void Comessarr(object sender, EventArgs args)
	{
	Application.Current.MainPage = new novojogo();
	}
}

