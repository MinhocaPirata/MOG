using System.Text.Json;
using System.Text.Json.Serialization;


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

			if(Response.IsSuccessStatusCode)
			{
				var Content = await Response.Content.ReadAsStringAsync();
				resposta = JsonSerializer.Deserialize<Resposta>(Content);
				PreencherTela();
			}
		}

		catch(Exception e){
			System.Diagnostics.Debug.WriteLine(e);
		}
	}

	void PreencherTela()
	{
		LabelTemperatura.Text=resposta.results.temp.ToString();
		Chuvanumero.Text=resposta.results.rain.ToString();
		Humidadenumero.Text=resposta.results.humidity.ToString();
		ForcaNumero.Text=resposta.results.wind_speedy.ToString();
		DirecaoNumero.Text=resposta.results.wind_cardinal;
		AmanhecerNumero.Text=resposta.results.sunrise;
		AnoitecerNumero.Text=resposta.results.sunset;
		TLua.Text=resposta.results.moon_phase;
		cloudness.Text=resposta.results.cloudness.ToString();
		


			if(resposta.results.currently == "dia")
		{
			if(resposta.results.rain > 10)
				FotoFundo.Source = "rainyday.jpg";
		
			else if(resposta.results.cloudness > 20)
				FotoFundo.Source = "cloudyday.jpg";

			else
				FotoFundo.Source = "cleanday.jpg";
	}
	else {

			if(resposta.results.rain > 10)
				FotoFundo.Source = "rainynight.jpg";
		
			else if(resposta.results.cloudness > 20)
				FotoFundo.Source = "cloudynight.jpg";

			else
				FotoFundo.Source = "cleannight.jpg";
		 }
  	} 
 }
