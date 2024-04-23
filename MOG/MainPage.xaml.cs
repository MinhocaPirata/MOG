namespace MOG;

public partial class MainPage : ContentPage
{
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
		LabelChuvax.Text=results.Rain.ToString();





	}

	void TestLayout()
	{
		results=new Results();
		  results.Temp=44;
		  results.Rain=25;


	}

}

