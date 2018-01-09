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
        //プライマリキー,自動で増える値
        [PrimaryKey, AutoIncrement]
        //id列
        public int Id { get; set; }

        //名前列
        public string Name { get; set; }

        //Userテーブルに行追加するメソッド
        //------------------------Insertメソッド--------------------------
        public static List<UserModel> insertUser(int id, string name)
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
                    return db.Query<UserModel>("SELECT * FROM [User] DESC LIMIT 15");
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        //Userテーブルのuserを削除するメソッド
        //--------------------------deleteメソッド--------------------------
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
        public static List<UserModel> deleteUser(string name)
        {

            //データベースに接続
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにUserテーブルを作成する
                    db.CreateTable<UserModel>();

                    var no = db.Query<UserModel>("SELECT Id FROM [User] WHERE [Name] ="+ name);

                    db.Delete<UserModel>(no);
                    db.Commit();
                    return db.Query<UserModel>("SELECT * FROM [User] DESC LIMIT 15");
                }
                catch (Exception e)
                {
                    db.Rollback();
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
                    return db.Query<UserModel>("SELECT * FROM [User] ORDER BY [Id] DESC LIMIT 15"); //主キーでORDER BYできるやん！
                    //return db.Query<UserModel>("SELECT * FROM [User] limit 15");                    
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);

                    return null;
                }
            }
        }

        //オーバーロード 文字入力があったらその文字を検索
        public static List<UserModel> selectUser(string search)
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    return db.Query<UserModel>("SELECT * FROM [User] where [Name] LIKE '%" + search + "%' limit 15");
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);

                    return null;
                }
            }
        }

    }    
}
