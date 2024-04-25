namespace MOG;

public partial class MainPage : ContentPage


{
    Resposta resposta;
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
		LabelTemperatura.Text=resposta.results.Temp.ToString();
		Chuvanumero.Text=resposta.results.Rain.ToString();
		Humidadenumero.Text=resposta.results.Humidity.ToString();
		ForcaNumero.Text=resposta.results.WindSpeedy.ToString();
		DirecaoNumero.Text=resposta.results.wind_cardinal;
		AmanhecerNumero.Text=resposta.results.Sunrise.ToString();
		AnoitecerNumero.Text=resposta.results.Sunset.ToString();
		TLua.Text=resposta.results.MoonPhase;
		cloudness.Text=resposta.results.Cloudness.ToString();
		




	}

	void TestLayout()
	{
		  results=new Results();
		  resposta.results.Temp=44;
		  resposta.results.Rain=25;
		  resposta.results.Humidity=13;
		  resposta.results.WindSpeedy=22;
		  resposta.results.wind_cardinal="09";
		  resposta.results.Sunrise=07;
		  resposta.results.Sunset=10;
		  resposta.results.MoonPhase="Full";
		  resposta.results.Cloudness=55;
		  resposta.results.Currently="10";


			if(resposta.results.Currently == "dia")
		{
			if(resposta.results.Rain > 10)
				FotoFundo.Source = "rainyday.jpg";
		
			else if(resposta.results.Cloudness > 20)
				FotoFundo.Source = "cloudyday.jpg";

			else
				FotoFundo.Source = "cleanday.jpg";
	}
	else {

			if(resposta.results.Rain > 10)
				FotoFundo.Source = "rainynight.jpg";
		
			else if(resposta.results.Cloudness > 20)
				FotoFundo.Source = "cloudynight.jpg";

			else
				FotoFundo.Source = "cleannight.jpg";
		 }
  
  } 

}