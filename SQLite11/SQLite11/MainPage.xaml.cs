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

        }
        */


        private Entry insertEntry; //insertの入力フィールド

        private Entry deleteEntry; //deleteの入力フィールド まだ削除できない
        private int deleteId; //削除Idフィールド

        private static int id = 0; //Idを足していく

        private string sb; //スクロールビューで使うかも

        public MainPage()
        {
            InitializeComponent();

            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };


            //Userテーブルの行データを取得
            var query = UserModel.selectUser(); //中身はSELECT * FROM [User]            
            foreach (var user in query)
            {
                //Userテーブルの名前列をLabelに書き出す
                layout.Children.Add(new Label { Text = user.Name });
            }

            //-------------------------------insertします-------------------------------
            var Insert = new Button
            {
                WidthRequest = 60,
                Text = "Insert!",
                TextColor = Color.Red,
            };
            insertEntry = new Entry
            {
                WidthRequest = 60
            };
            layout.Children.Add(Insert);
            Insert.Clicked += InsertClicked;
            layout.Children.Add(insertEntry);

            //--------------------------------deleteします------------------------------
            var Delete = new Button     //dropしてるだけ
            {
                WidthRequest = 60,
                Text = "Delete!",
                TextColor = Color.Red,
            };
            layout.Children.Add(Delete);
            Delete.Clicked += DeleteClicked;
            /*
            deleteEntry = new Entry
            {
                WidthRequest = 60,
            };
            layout.Children.Add(deleteEntry);
            deleteId = int.Parse(deleteEntry.Text);
            */

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


        //insertイベントハンドラ
        void InsertClicked(object sender, EventArgs e)
        {

            id++;
            
            var InsertName = insertEntry.Text;
            //Userテーブルに適当なデータを追加する
            UserModel.insertUser(InsertName);
            //UserModel.insertUser(id,InsertName);

        }

        //deleteイベントハンドラ
        void DeleteClicked(object sender, EventArgs e)
        {
            //UserModel.deleteUser(deleteId);
            UserModel.deleteUser(1);

        }

        //selectイベントハンドラ
        void SelectClicked(object sender, EventArgs e)
        {
            //selectする
            var Select = new Button
            {
                WidthRequest = 60,
                Text = "Select!",
                TextColor = Color.Red,
            };
            layout.Children.Add(Select);
            Select.Clicked += SelectClicked;
            //insertする
            var Insert = new Button
            {
                WidthRequest = 60,
                Text = "Insert!",
                TextColor = Color.Red,
            };
            insertEntry = new Entry
            {
                WidthRequest = 60
            };
            layout.Children.Add(Insert);
            Insert.Clicked += InsertClicked;
            layout.Children.Add(insertEntry);

            Content = layout;


            /*
                var query = UserModel.selectUser(); //中身はSELECT * FROM [User]
                foreach (var user in query)
                {
                    var sb = new Label { Text = user.Name };
                }
                var scrollView = new ScrollView
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    //ラベルを配置する
                    Content = new Label
                    {
                        Text = sb.ToString(),
                        FontSize = 20,
                        TextColor = Color.Red,
                    }
                };
                Content = scrollView;*/
        }
    }
}
