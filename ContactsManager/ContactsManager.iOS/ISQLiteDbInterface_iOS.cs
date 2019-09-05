using System;
using Xamarin.Forms;
using System.IO;
using ContactsManager.iOS;
using ContactsManager;
using DesignTask2.iOS;

[assembly: Dependency(typeof(ISQLiteDbInterface_iOS))]
namespace DesignTask2.iOS
{
    public class ISQLiteDbInterface_iOS : ISQLiteInterface
    {
        public SQLite.Net.SQLiteConnection GetSQLiteConnection()
        {
            var fileName = "Student.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);
            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);
            return connection;
        }
    }
}