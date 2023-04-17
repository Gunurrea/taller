using Android.Content;
using Android.Database;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace taller
{
    public class TaskCursorAdapter : CursorAdapter
    {
        private readonly LayoutInflater inflater;

        public TaskCursorAdapter(Context context, ICursor cursor)
            : base(context, cursor, 0)
        {
            inflater = LayoutInflater.FromContext(context);
        }

        public override View NewView(Context context, ICursor cursor, ViewGroup parent)
        {
            return inflater.Inflate(Resource.Layout.list_item_task, parent, false);
        }

        public override void BindView(View view, Context context, ICursor cursor)
        {
            TextView descriptionTextView = view.FindViewById<TextView>(Resource.Id.textview_description);
            CheckBox isCompletedCheckBox = view.FindViewById<CheckBox>(Resource.Id.checkbox_is_completed);

            int idIndex = cursor.GetColumnIndex(TaskContract.TaskEntry.Id);
            int descriptionIndex = cursor.GetColumnIndex(TaskContract.TaskEntry.Description);
            int isCompletedIndex = cursor.GetColumnIndex(TaskContract.TaskEntry.IsCompleted);

            long id = cursor.GetLong(idIndex);
            string description = cursor.GetString(descriptionIndex);
            bool isCompleted = cursor.GetInt(isCompletedIndex) == 1;

            descriptionTextView.Text = description;
            isCompletedCheckBox.Checked = isCompleted;
            view.Tag = id;
        }
    }
}
