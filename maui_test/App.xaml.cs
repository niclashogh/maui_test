using maui_test.Services;

namespace maui_test
{
    public partial class App : Application
    {
        public static DatabaseService DBService { get; private set; } = new(false);

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}