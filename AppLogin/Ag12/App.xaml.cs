
namespace Ag12;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        VerificaUsuario();

    }

    protected async Task VerificaUsuario()
    {
        try
        {
            String? usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

            if (usuario_logado == null)
            {
                MainPage = new Login();
            }
            else
            {
                MainPage = new Protegida();
            }

        }
        catch (System.Runtime.InteropServices.COMException ex)
        {
            Console.WriteLine("Erro ao acessar um componente COM:");
            Console.WriteLine($"Mensagem de Erro: {ex.Message}");
            Console.WriteLine($"Código de Erro (HRESULT): {ex.ErrorCode}");
            Console.WriteLine($"Detalhes: {ex.StackTrace}");
        }

    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        window.Width = 400;
        window.Height = 700;

        return window;
    }

}
