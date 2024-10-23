namespace Ag12;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {

		try
		{
			List<DadosUsuario> list = new List<DadosUsuario>
			{
				new DadosUsuario()
				{
					Usuario = "igor",
					Senha = "123"
				},
				new DadosUsuario()
				{
					Usuario = "Tainá",
					Senha = "1234"
				}
			};

			DadosUsuario dadosDigitados = new DadosUsuario()
			{ 
				Usuario = txt_usuario.Text,
				Senha = txt_senha.Text
			};

			bool encontrado = list.Any(digitado => 
									dadosDigitados.Usuario == digitado.Usuario &&
									dadosDigitados.Senha == digitado.Senha);

            if (encontrado)
            {
				await SecureStorage.Default.SetAsync("usuario_logado", dadosDigitados.Usuario);

				App.Current.MainPage = new Protegida();

            } else
			{
				throw new Exception("Usuário e Senha incorreto.");
			}

        } catch (Exception ex)
		{
			await DisplayAlert("Erro", ex.Message, "Fechar");
		}

    }
}