namespace MOG;

public partial class MainPage : ContentPage


{
  
	const string url =	"https://api.hgbrasil.com/weather?woeid=455927&key=";

Results results;

	public MainPage()
	{
		InitializeComponent();
		TestLayout();
		PreencherTela();

	}

	void PreencherTela()
	{
		LabelTemperatura.Text=results.Temp.ToString();
		Chuvanumero.Text=results.Rain.ToString();
		Humidadenumero.Text=results.Humidity.ToString();
		ForcaNumero.Text=results.WindSpeedy.ToString();
		DirecaoNumero.Text=results.wind_cardinal;





	}

	void TestLayout()
	{
		results=new Results();
		  results.Temp=44;
		  results.Rain=25;
		  results.Humidity=13;
		  results.WindSpeedy=22;
		  results.wind_cardinal=09;

	}

  
}

