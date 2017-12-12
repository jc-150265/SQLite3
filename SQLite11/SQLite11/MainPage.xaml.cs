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

        private Entry selectEntry;

        private string sb; //スクロールビューで使うかも

        public MainPage()
        {
            InitializeComponent();

            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 30 } };

            //--------------------------------selectします------------------------------
            var Select = new Button
            {
                WidthRequest = 60,
                Text = "Select!",
                TextColor = Color.Red,
            };
            layout.Children.Add(Select);
            Select.Clicked += SelectClicked;


            selectEntry = new Entry
            {
                Placeholder = "Delete",
                PlaceholderColor = Color.Gray,
                WidthRequest = 130
            };
            layout.Children.Add(selectEntry);

            //-------------------------------insertします-------------------------------
            var Insert = new Button
            {
                WidthRequest = 60,
                Text = "Insert!",
                TextColor = Color.Red,
            };
            insertEntry = new Entry
            {
                Placeholder = "Insert",
                PlaceholderColor = Color.Gray,
                WidthRequest = 130
            };
            layout.Children.Add(Insert);
            Insert.Clicked += InsertClicked;
            layout.Children.Add(insertEntry);

            //--------------------------------deleteします------------------------------
            var Delete = new Button
            {
                WidthRequest = 60,
                Text = "Delete!",
                TextColor = Color.Red,
            };
            deleteEntry = new Entry
            {
                Placeholder = "Delete",
                PlaceholderColor = Color.Gray,
                WidthRequest = 130
            };
            layout.Children.Add(Delete);
            Delete.Clicked += DeleteClicked;
            layout.Children.Add(deleteEntry);
            
            Content = layout;
        }


        //insertイベントハンドラ
        void InsertClicked(object sender, EventArgs e)
        {
            var InsertName = insertEntry.Text;
            //Userテーブルに適当なデータを追加する
            UserModel.insertUser(1, InsertName);
        }

        //deleteイベントハンドラ
        void DeleteClicked(object sender, EventArgs e)
        {
            var DeleteName = deleteEntry.Text;
            if (DeleteName != null)
            {
                //UserModel.deleteUser(1);
                UserModel.deleteUser(int.Parse(DeleteName));
            }
            else
            {
                //アラート関連で参考になりそう https://dev.classmethod.jp/smartphone/xamarin-forms-alert/
                DisplayAlert("DeleteIdが選択されていません", "TextBoxに入力してください", "OK");
            }
        }

        //selectイベントハンドラ
        void SelectClicked(object sender, EventArgs e)
        {
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 30 } };

            //selectボタン
            var Select = new Button
            {
                WidthRequest = 60,
                Text = "Select!",
                TextColor = Color.Red,
            };
            layout.Children.Add(Select);
            Select.Clicked += SelectClicked;
            //insertボタン
            var Insert = new Button
            {
                WidthRequest = 60,
                Text = "Insert!",
                TextColor = Color.Red,
            };
            insertEntry = new Entry
            {
                Placeholder = "Insert",
                PlaceholderColor = Color.Gray,
                WidthRequest = 130
            };
            layout.Children.Add(Insert);
            Insert.Clicked += InsertClicked;
            layout.Children.Add(insertEntry);
            //deleteボタン
            var Delete = new Button
            {
                WidthRequest = 60,
                Text = "Delete!",
                TextColor = Color.Red,
            };
            deleteEntry = new Entry
            {
                Placeholder = "Delete",
                PlaceholderColor = Color.Gray,
                WidthRequest = 130
            };
            layout.Children.Add(Delete);
            Delete.Clicked += DeleteClicked;
            layout.Children.Add(deleteEntry);

            //Userテーブルの行データを取得

            string x = selectEntry.Text;

            if (UserModel.selectUser(x) != null)
            {
                var query = UserModel.selectUser(x); //中身はSELECT * FROM [User] limit 15

                foreach (var user in query)
                {
                    //Userテーブルの名前列をLabelに書き出します
                    layout.Children.Add(new Label { Text = user.Id.ToString() });
                    layout.Children.Add(new Label { Text = user.Name });
                }
            }
            else
            {
                DisplayAlert("表がないエラー", "表がないよー", "OK");
            }
            Content = layout;
        }
    }
}