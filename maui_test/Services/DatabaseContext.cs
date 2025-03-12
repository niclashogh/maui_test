using SQLite;

namespace maui_test.Services
{
    public class DatabaseContext
    {
        public string UserDB { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "user_data.db");

        internal SQLiteConnection SQLConnection()
        {
            SQLiteConnection db = new(UserDB, SQLiteOpenFlags.ReadWrite);
            //db.Execute("PRAGMA foreign_keys = ON;");
            return db;
        }

        internal SQLiteConnection SQLCreateTable()
        {
            SQLiteConnection db = new(UserDB, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);
            //db.Execute("PRAGMA foreign_keys = ON;");
            return db;
        }

        internal SQLiteConnection SQLCreateDB()
        {
            SQLiteConnection db = new(UserDB, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);
            //db.EnableWriteAheadLogging();
            db.ExecuteScalar<string>("PRAGMA foreign_keys = ON;"); // ON, OFF
            db.ExecuteScalar<string>("PRAGMA journal_mode = DELETE;"); // WAL, DELETE
            db.ExecuteScalar<string>("PRAGMA synchronous = OFF;"); // OFF, NORMAL, FULL
            return db;
        }
    }
}
