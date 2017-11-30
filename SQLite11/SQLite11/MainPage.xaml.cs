using System;
using Xamarin.Forms;

//参考url http://dev-suesan.hatenablog.com/entry/2017/03/06/005206

namespace SQLite11
{
    public partial class MainPage : ContentPage
    {
        //http://www.atmarkit.co.jp/ait/articles/1612/28/news021.html　ScrollView
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
        private Entry insertEntry; //insertの入力フィールド
        private Entry deleteEntry; //deleteの入力フィールド

        public MainPage()
        {
            InitializeComponent();

            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };

            //-------------------------------insertします-------------------------------
            var Insert = new Button
            {
                WidthRequest = 60,
                Text = "Insert!",
                TextColor = Color.Red,
            };
            var insertEntry = new Entry
            {
                WidthRequest = 60
            };
            layout.Children.Add(Insert);
            Insert.Clicked += InsertClicked;
            
            //--------------------------------deleteします------------------------------
            var Delete = new Button
            {
                WidthRequest = 60,
                Text = "Delete!",
                TextColor = Color.Red,
            };
            deleteEntry = new Entry
            {
                WidthRequest = 60,
            };
            layout.Children.Add(Delete);
            Delete.Clicked += DeleteClicked;
            
            //--------------------------------selectします------------------------------
            var Select = new Button
            {
                WidthRequest = 60,
                Text = "Select!",
                TextColor = Color.Red,
            };
            layout.Children.Add(Select);
            Select.Clicked += SelectClicked;

            Content = layout;
        }

        //insertメソッド
        void InsertClicked(object sender, EventArgs e)
        {
            
            var text = insertEntry.Text;
            //Userテーブルに適当なデータを追加する
            UserModel.insertUser(text);

        }

        //deleteメソッド
        void DeleteClicked(object sender, EventArgs e)
        {
            UserModel.deleteUser(1);

        }
        //selectメソッド
        void SelectClicked(object sender, EventArgs e)
        {
            //Userテーブルの行データを取得
            var query = UserModel.selectUser(); //中身はSELECT * FROM [User]
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
            foreach (var user in query)
            {
                //Userテーブルの名前列をLabelに書き出す
                layout.Children.Add(new Label { Text = user.Name });
            }
            Content = layout;
        }
    }


}
