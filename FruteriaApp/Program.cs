namespace FruteriaApp;

static class Program
{
    // Punto de entrada: lo primero que se ejecuta al abrir la aplicación
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        // Se abre el menú principal; desde él se abren las demás pantallas
        Application.Run(new FormMenu());
    }
}
