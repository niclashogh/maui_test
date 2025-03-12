using maui_test.Services;
using SQLite;

namespace maui_test.Database
{
    public class FilterProfile_Table : DatabaseContext
    {
        public FilterProfile_Table()
        {
            using (SQLiteConnection db = SQLCreateTable())
            {
                db.Execute(@"CREATE TABLE IF NOT EXISTS FilterProfile (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name NVARCHAR(100) NOT NULL
                            );");

                db.Execute(@"CREATE TABLE IF NOT EXISTS FilterProfile_Filter_JunctionTable (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            ProfileId INTEGER,
                            Filter VARCHAR(100) NOT NULL,
                            FOREIGN KEY (ProfileId) REFERENCES FilterProfile(Id) ON DELETE CASCADE
                            );");
            }
        }
    }
}
