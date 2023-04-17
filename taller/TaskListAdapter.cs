using Android.Content;
using Android.Views;
using Android.Widget;
using Java.Lang;
using System.Collections.Generic;

namespace taller
{
    public class TaskListAdapter : BaseAdapter
    {
        private readonly List<Task> tasks;
        private readonly LayoutInflater inflater;

        public TaskListAdapter(Context context, List<Task> tasks)
        {
            this.tasks = tasks;
            inflater = LayoutInflater.FromContext(context);
        }

        public override int Count
        {
            get { return tasks.Count; }
        }

        public override Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return tasks[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = inflater.Inflate(Resource.Layout.list_item_task, null);
            }

            TextView descriptionTextView = view.FindViewById<TextView>(Resource.Id.textview_description);
            CheckBox isCompletedCheckBox = view.FindViewById<CheckBox>(Resource.Id.checkbox_is_completed);

            Task task = tasks[position];

            descriptionTextView.Text = task.Description;
            isCompletedCheckBox.Checked = task.IsCompleted;

            return view;
        }
    }
}
