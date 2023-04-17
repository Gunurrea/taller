using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Database;
using Android.Net;

namespace taller
{
    [Activity(Label = "Add Task")]
    public class AddTaskActivity : Activity
    {
        private EditText taskDescriptionEditText;
        private Button addTaskButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.add_task);

            taskDescriptionEditText = FindViewById<EditText>(Resource.Id.task_description_edittext);
            addTaskButton = FindViewById<Button>(Resource.Id.add_task_button);
            addTaskButton.Click += AddTaskButton_Click;
        }

        private void AddTaskButton_Click(object sender, System.EventArgs e)
        {
            string taskDescription = taskDescriptionEditText.Text;
            if (!string.IsNullOrEmpty(taskDescription))
            {
                ContentValues values = new ContentValues();
                values.Put(TaskContract.TaskEntry.Description, taskDescription);

                ContentResolver.Insert(TaskContract.TaskEntry.ContentUri, values);

                Finish();
            }
            else
            {
                Toast.MakeText(this, "Descripcion de la tarea", ToastLength.Short).Show();
            }
        }
    }
}
