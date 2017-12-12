using System;
using System.Collections.Generic;
using SQLite;

//参考url http://dev-suesan.hatenablog.com/entry/2017/03/06/005206
//SQLメソッドの参考url https://www.tmp1024.com/programming/use-sqlite

namespace SQLite11
{      
    //テーブル名を指定
    [Table("User")]
    public class UserModel
    {
        //プライマリキー　自動採番されます
        [PrimaryKey, AutoIncrement, Column("_id")]
        //[PrimaryKey, AutoIncrement]
        //↓カラムは列と同じ
        //idカラム
        public int Id { get; set; }
        //名前カラム
        public string Name { get; set; }

        //Userテーブルに行追加するメソッドです
            //------------------------Insert文的なの--------------------------
        public static void insertUser(string name)
        {
            //データベースに接続
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {

                    
                    //データベースにUserテーブルを作成します
                    db.CreateTable<UserModel>();
                    
                    //Userテーブルに行追加します
                    db.Insert(new UserModel() { Name = name });

                    db.Commit();

                }
                catch (Exception e)
                {

                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);

                }
            }
        }
        
        //id name オーバーロード
        public static void insertUser(int id, string name)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにUserテーブルを作成する
                    db.CreateTable<UserModel>();

                    db.Insert(new UserModel() { Id = id, Name = name });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }


        //Userテーブルのuserを削除するメソッド
        //削除メソッド参考サイト https://qiita.com/alzybaad/items/9356b5a651603a548278
        //--------------------------delete文的なの--------------------------
        public static void deleteUser(int id)
        {

            //データベースに接続
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {                
                try
                {
                    //データベースにUserテーブルを作成する
                    db.CreateTable<UserModel>();

                    //db.DropTable<UserModel>(); 怒りのドロップテーブル！

                    db.Delete<UserModel>(id);
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }

        }

        /*
        //Userテーブルの行データを取得します
        //--------------------------select文的なの--------------------------
        public static List<UserModel> selectUser()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //db.DropTable<UserModel>(); //怒りのドロップテーブル！

                    //データベースに指定したSQLを発行します

                    return db.Query<UserModel>("SELECT * FROM [User] where [Name] LIKE '%あ%' limit 15");                    
                    //return db.Query<UserModel>("SELECT * FROM [User]　ORDER BY [Name] DESC LIMIT 15");
                    //return db.Query<UserModel>("SELECT * FROM [User] limit 15");
                } //no such column: Id
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    
                    return null;
                }
            }
        }
        */

        //Userテーブルの行データを取得します
        //--------------------------select文的なの--------------------------
        public static List<UserModel> selectUser()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //db.DropTable<UserModel>(); //怒りのドロップテーブル！

                    //データベースに指定したSQLを発行します

                    return db.Query<UserModel>("SELECT * FROM [User] limit 15");
                    //return db.Query<UserModel>("SELECT * FROM [User]　ORDER BY [Name] DESC LIMIT 15");
                    //return db.Query<UserModel>("SELECT * FROM [User] limit 15");
                } //no such column: Id
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);

                    return null;
                }
            }
        }

        //オーバーロード 文字入力があったらその文字を検索
        public static List<UserModel> selectUser(string x)
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //db.DropTable<UserModel>(); //怒りのドロップテーブル！

                    //データベースに指定したSQLを発行します

                    return db.Query<UserModel>("SELECT * FROM [User] where [Name] LIKE '%" + x + "%' limit 15");
                    //return db.Query<UserModel>("SELECT * FROM [User]　ORDER BY [Name] DESC LIMIT 15");
                    //return db.Query<UserModel>("SELECT * FROM [User] limit 15");
                } //no such column: Id
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);

                    return null;
                }
            }
        }

    }    
}
