using maui_test.Database;
using SQLite;

namespace maui_test.Services
{
    public class DatabaseService : DatabaseContext
    {
        public DatabaseService()
        {
            if (!File.Exists(this.UserDB))
            {
                using (SQLiteConnection db = SQLCreateDB()) { }
            }

            FilterProfile_Table table = new();
        }
    }
}
