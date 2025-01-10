namespace Presentation_ContactsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());

            window.Width = DeviceDisplay.MainDisplayInfo.Width;
            window.Height = DeviceDisplay.MainDisplayInfo.Height;
            window.X = 0;
            window.Y = 0;

            return window;
        }
    }
}