using Android.App;
using Android.Content;
using Android.Database.Sqlite;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using taller;

namespace taller
{
    [Activity(Label = "Modify Task")]
    public class ModifyTaskActivity : AppCompatActivity
    {
        private EditText mTaskEditText;
        private Button mUpdateButton;

        private long mTaskId;
        private TaskDatabaseHelper mDbHelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.modify_task);

            mTaskEditText = FindViewById<EditText>(Resource.Id.modify_task_edit_text);
            mUpdateButton = FindViewById<Button>(Resource.Id.modify_task_button);

            mDbHelper = new TaskDatabaseHelper(this);

            mTaskId = Intent.GetLongExtra("taskId", -1);

            mUpdateButton.Click += UpdateTask;
        }

        private void UpdateTask(object sender, System.EventArgs e)
        {
            string taskDescription = mTaskEditText.Text.Trim();

            if (string.IsNullOrEmpty(taskDescription))
            {
                Toast.MakeText(this, "Descripcion de la tarea", ToastLength.Short).Show();
                return;
            }

            SQLiteDatabase db = mDbHelper.WritableDatabase;

            ContentValues values = new ContentValues();
            values.Put(TaskContract.TaskEntry.Description, taskDescription);

            int rowsAffected = db.Update(TaskContract.TaskEntry.TableName, values, TaskContract.TaskEntry.Id + " = ?", new string[] { mTaskId.ToString() });

            if (rowsAffected == 0)
            {
                Toast.MakeText(this, "No se pudo modificar la tarea", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Tarea modificada", ToastLength.Short).Show();
            }

            Finish();
        }
    }
}
