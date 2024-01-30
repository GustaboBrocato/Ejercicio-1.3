namespace Ejercicio_1._3
{
    public partial class App : Application
    {
        public static Controllers.PersonasController PersonasController { get; private set; }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            PersonasController = new Controllers.PersonasController();
        }
    }
}
