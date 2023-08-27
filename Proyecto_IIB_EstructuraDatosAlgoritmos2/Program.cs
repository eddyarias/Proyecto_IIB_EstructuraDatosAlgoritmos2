namespace Proyecto_IIB_EstructuraDatosAlgoritmos2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormViajePorRio());
        }
    }
}