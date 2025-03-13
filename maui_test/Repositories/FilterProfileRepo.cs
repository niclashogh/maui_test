using maui_test.Models;
using maui_test.Services;
using SQLite;
using System.Collections.ObjectModel;

namespace maui_test.Repositories
{
    public class FilterProfileRepo : DatabaseContext
    {
        public async void Add(string name, ObservableCollection<string> filters)
        {
            try
            {
                using (SQLiteConnection db = SQLConnection())
                {
                    db.RunInTransaction(() =>
                    {
                        string filterProfile_Query = $"INSERT INTO FilterProfile (Name) VALUES (?)";
                        db.Execute(filterProfile_Query, name);

                        int profileId = db.ExecuteScalar<int>("SELECT last_insert_rowid();");

                        foreach (string filter in filters)
                        {
                            string filter_Query = $"INSERT INTO FilterProfile_Filter_JunctionTable (ProfileId, Filter) VALUES (?, ?)";
                            db.Execute(filter_Query, profileId, filter);
                        }
                    });
                }
            }
            catch { }
        }

        public async void Remove(int id)
        {
            try
            {
                using (SQLiteConnection db = SQLConnection())
                {
                    string filterProfile_Query = $"DELETE FROM FilterProfile WHERE Id = ?";
                    db.Execute(filterProfile_Query, id);
                }
            }
            catch { }
        }

        public async Task<ObservableCollection<FilterProfileDTO>> Load()
        {
            try
            {
                using (SQLiteConnection db = SQLConnection())
                {
                    string filterProfile_Query = $"SELECT * FROM FilterProfile";
                    List<FilterProfileDTO>? queryResult = db.Query<FilterProfileDTO>(filterProfile_Query) ?? null;

                    if (queryResult != null)
                    {
                        foreach (FilterProfileDTO profile in queryResult)
                        {
                            string filter_Query = $"SELECT Filter FROM FilterProfile_Filter_JunctionTable WHERE ProfileId = ?";
                            profile.Filters = db.Query<FilterDTO>(filter_Query, profile.Id)
                                                    .Select(f => f.Filter).ToList();
                        }
                    }

                    return queryResult != null ? new ObservableCollection<FilterProfileDTO>(queryResult) : new();
                }
            }
            catch { return new(); }
        }

        public async Task<List<string>> LoadFiltersFromId(int id)
        {
            try
            {
                using (SQLiteConnection db = SQLConnection())
                {
                    string filter_Query = $"SELECT Filter FROM FilterProfile_Filter_JunctionTable WHERE ProfileId = ?";
                    List<string> queryResult = db.Query<FilterDTO>(filter_Query, id).Select(f => f.Filter).ToList();

                    return queryResult;
                }
            }
            catch { return new(); }
        }
    }
}
