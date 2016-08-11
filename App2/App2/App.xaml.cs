using App2.Database.Managers;

using Xamarin.Forms;

namespace App2
{
    public partial class App : Application
    {
        public static BooksManager _bookManager;
        public App()
        {
            InitializeComponent();
            _bookManager = new BooksManager("books.db");
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
