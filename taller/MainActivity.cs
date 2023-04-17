using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Database;
using Android.Database.Sqlite;

namespace taller
{
    [Activity(Label = "MainActivity")]
    public class MainActivity : Activity
    {
        private SQLiteDatabase db;
        private ListView taskListView;
        private TaskCursorAdapter taskAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            TaskDatabaseHelper dbHelper = new TaskDatabaseHelper(this);
            db = dbHelper.WritableDatabase;

            taskListView = FindViewById<ListView>(Resource.Id.task_list);
            taskAdapter = new TaskCursorAdapter(this, null);
            taskListView.Adapter = taskAdapter;

            ReloadTasks();

            Button addTaskButton = FindViewById<Button>(Resource.Id.add_task_button);
            addTaskButton.Click += delegate { StartActivity(typeof(AddTaskActivity)); };
        }

        protected override void OnResume()
        {
            base.OnResume();

            ReloadTasks();
        }

        private void ReloadTasks()
        {
            ICursor cursor = db.Query(TaskContract.TaskEntry.TableName,
                           new string[] { TaskContract.TaskEntry.Id,
                                          TaskContract.TaskEntry.Description,
                                          TaskContract.TaskEntry.IsCompleted },
                           null, null, null, null, null);


        }
    }
}
