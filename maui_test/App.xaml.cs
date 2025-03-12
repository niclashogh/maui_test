using maui_test.Services;

namespace maui_test
{
    public partial class App : Application
    {
        //public static DatabaseService DBService { get; private set; }

        public App()
        {
            InitializeComponent();
            //DBService = new();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}