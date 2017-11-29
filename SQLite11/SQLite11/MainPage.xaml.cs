using System;
using Xamarin.Forms;

//参考url http://dev-suesan.hatenablog.com/entry/2017/03/06/005206

namespace SQLite11
{
    public partial class MainPage : ContentPage
    {
        /*
        public MainPage()
        {
            InitializeComponent();

            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };

            //Userテーブルに適当なデータを追加
            UserModel.insertUser("鈴木");
            UserModel.insertUser("田中");
            UserModel.insertUser("斎藤");
            //↑この辺をボタンに突っ込む

            //Userテーブルの行データを取得
            var query = UserModel.selectUser();

            foreach (var user in query)
            {
                //Userテーブルの名前列をLabelに書き出します
                layout.Children.Add(new Label { Text = user.Name });
            }

            Content = layout;

        }*/
        public MainPage()
        {
            InitializeComponent();

            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };

            /*
            //Userテーブルに適当なデータを追加する
            UserModel.insertUser("鈴木");
            UserModel.insertUser("田中");
            UserModel.insertUser("斎藤");*/

            //Userテーブルの行データを取得
            var query = UserModel.selectUser();


            var Insert = new Button
            {
                WidthRequest = 60,
                Text = "Insert!",
                TextColor = Color.Red,
                /*HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand*/
            };
            layout.Children.Add(Insert);
            Insert.Clicked += OnButtonClicked;





            foreach (var user in query)
            {

                //Userテーブルの名前列をLabelに書き出す
                layout.Children.Add(new Label { Text = user.Name });
            }

            Content = layout;
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            //Userテーブルに適当なデータを追加する
            UserModel.insertUser("鈴木");
            UserModel.insertUser("田中");
            UserModel.insertUser("斎藤");

        }
    }


}
