using System.Text.Json;

namespace MOG;

public partial class MainPage : ContentPage
{
    Resposta resposta;
	const string url =	"https://api.hgbrasil.com/weather?woeid=455927&key=";


	public MainPage()
	{
		InitializeComponent();
		AtualizaTempo();
	}

async void AtualizaTempo(){
		try{
			var HttpClient = new HttpClient();
			var Response = await HttpClient.GetAsync(url);

			if(Response.IsSuccessStatusCode){
				var Content = await Response.Content.ReadAsStringAsync();
				resposta = JsonSerializer.Deserialize<Resposta>(Content);
			}
		}

		catch(Exception e){
			System.Diagnostics.Debug.WriteLine(e);
		}

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
