using Android.Provider;
using Android.Database.Sqlite;
using static Android.Provider.SyncStateContract;

namespace taller
{
    public class TaskContract
    {
        public const string Authority = "com.example.taller.provider";
        public static readonly Android.Net.Uri ContentUri =
            Android.Net.Uri.Parse("content://" + Authority + "/tasks");

        public const string PATH_TASKS = "tasks";

        public class TaskEntry : Java.Lang.Object, IColumns
        {
            public const string TableName = "tasks";
            public static readonly Android.Net.Uri ContentUri =
                Android.Net.Uri.Parse("content://" + Authority + "/tasks");

            public const string Id = "_id";
            public const string Description = "description";
            public const string IsCompleted = "is_completed";

            public static Android.Net.Uri BuildUriWithPath(string path)
            {
                return ContentUri.BuildUpon().AppendPath(path).Build();
            }
        }
    }
}
