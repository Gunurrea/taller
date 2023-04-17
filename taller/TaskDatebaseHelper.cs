using Android.Content;
using Android.Database.Sqlite;

namespace taller
{
    public class TaskDatabaseHelper : SQLiteOpenHelper
    {
        private const string DatabaseName = "Task.db";
        private const int DatabaseVersion = 1;

        public TaskDatabaseHelper(Context context)
            : base(context, DatabaseName, null, DatabaseVersion)
        {
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            string createTable = "CREATE TABLE " + TaskContract.TaskEntry.TableName + " (" +
                                 TaskContract.TaskEntry.Id + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                 TaskContract.TaskEntry.Description + " TEXT NOT NULL, " +
                                 TaskContract.TaskEntry.IsCompleted + " INTEGER NOT NULL DEFAULT 0)";

            db.ExecSQL(createTable);
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL("DROP TABLE IF EXISTS " + TaskContract.TaskEntry.TableName);
            OnCreate(db);
        }
    }
}

