using Xamarin.Forms;

namespace SQLite11
{
    public partial class App : Application
    {
        //データベースのパスを格納
        public static string dbPath;


        public App(string dbPath)
        {
            //AppのdbPathに引数のパスを設定します
            App.dbPath = dbPath;


            InitializeComponent();

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
