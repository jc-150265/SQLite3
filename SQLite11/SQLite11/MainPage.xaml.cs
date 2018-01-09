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


        private Entry insertEntry; //insertの入力フィールド 入力した値をinsert

        private Entry deleteEntry; //deleteの入力フィールド 入力した値でdelete

        private Entry selectEntry; //selectの入力フィールド 入力した値で検索(where LIKE %?%)

        public MainPage()
        {
            InitializeComponent();

            var layout2 = new StackLayout { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
            var scroll = new ScrollView { Orientation = ScrollOrientation.Vertical };
            layout2.Children.Add(scroll);
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
            scroll.Content = layout;

            //--------------------------------selectします------------------------------
            var Select = new Button
            {
                WidthRequest = 60,
                Text = "Select!",
                TextColor = Color.Red,
            };
            selectEntry = new Entry
            {
                Placeholder = "Select",
                PlaceholderColor = Color.Gray,
                WidthRequest = 130
            };
            layout.Children.Add(Select);
            Select.Clicked += SelectClicked;
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
                HorizontalOptions = LayoutOptions.FillAndExpand,
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

            Content = layout2;
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
            int no = int.Parse(DeleteName);

            if (DeleteName != null)
            {
                //UserModel.deleteUser(1);
                UserModel.deleteUser(no);
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

            //Userテーブルの行データを取得

            String x = selectEntry.Text; //入力された文字を習得

            var layout2 = new StackLayout { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
            var scroll = new ScrollView { Orientation = ScrollOrientation.Vertical };
            layout2.Children.Add(scroll);
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
            scroll.Content = layout;

            //--------------------ボタン再配置--------------------------
            //selectボタン
            var Select = new Button
            {
                WidthRequest = 60,
                Text = "Select!",
                TextColor = Color.Red,
            };
            selectEntry = new Entry
            {
                Placeholder = "Select",
                PlaceholderColor = Color.Gray,
                WidthRequest = 130
            };
            layout.Children.Add(Select);
            Select.Clicked += SelectClicked;
            layout.Children.Add(selectEntry);
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
            //--------------------ボタン再配置--------------------------
                        
            if (x != null) //selectEntryが入力されてたら検索   nullなら全部表示
            {
                if (UserModel.selectUser(x) != null)
                {
                    var query = UserModel.selectUser(x); //中身はSELECT * FROM [User] where [Name] like "% x %" limit 15

                    foreach (var user in query)
                    {
                        //Userテーブルの名前列をLabelに書き出します
                        layout.Children.Add(new Label { Text = user.Id.ToString() });
                        layout.Children.Add(new Label { Text = user.Name });
                    }
                }
                else
                {
                    DisplayAlert("表がないエラー", "表がありません", "OK");
                }
            }
            else if (UserModel.selectUser() != null) //全部表示
            {
                var query = UserModel.selectUser(); //中身はSELECT * FROM [User] limit 15

                foreach (var user in query)
                {
                    //Userテーブルの名前列をLabelに書き出します
                    layout.Children.Add(new Label { Text = user.Id.ToString() });
                    layout.Children.Add(new Label { Text = user.Name });
                }
            }
            else
            {
                DisplayAlert("表がないエラー", "表がありません", "OK");
            }

            Content = layout2;
        }
    }
}