using Android.App;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using taller;

namespace taller
{
    [Activity(Label = "View Task")]
    public class ViewTaskActivity : AppCompatActivity
    {
        private TextView mTaskTextView;
        private long mTaskId;
        private TaskDatabaseHelper mDbHelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.view_task);

            mTaskTextView = FindViewById<TextView>(Resource.Id.my_task_text_view);

            mDbHelper = new TaskDatabaseHelper(this);

            mTaskId = Intent.GetLongExtra("taskId", -1);

            DisplayTaskDetails();
        }

        private void DisplayTaskDetails()
        {
            SQLiteDatabase db = mDbHelper.ReadableDatabase;

            string[] projection = {
                TaskContract.TaskEntry.Id,
                TaskContract.TaskEntry.Description,
                TaskContract.TaskEntry.IsCompleted
            };

            string selection = TaskContract.TaskEntry.Id + " = ?";
            string[] selectionArgs = { mTaskId.ToString() };

            ICursor cursor = db.Query(
                TaskContract.TaskEntry.TableName,
                projection,
                selection,
                selectionArgs,
                null,
                null,
                null
            );

            if (cursor.MoveToFirst())
            {
                string description = cursor.GetString(cursor.GetColumnIndex(TaskContract.TaskEntry.Description));
                bool isCompleted = cursor.GetInt(cursor.GetColumnIndex(TaskContract.TaskEntry.IsCompleted)) == 1;
                string status = isCompleted ? "Completada" : "No completada";

                mTaskTextView.Text = description + "\n\n" + "Status: " + status;
            }

            cursor.Close();
        }
    }
}
