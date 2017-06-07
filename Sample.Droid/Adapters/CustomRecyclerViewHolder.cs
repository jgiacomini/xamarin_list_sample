using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Sample.Droid.Adapters
{
    public class CustomRecyclerViewHolder : RecyclerView.ViewHolder
    {
        public TextView FirstName { get; set; }
        public TextView LastName { get; set; }

        public CustomRecyclerViewHolder(View view) : base(view)
        {
            FirstName = view.FindViewById<TextView>(Resource.Id.firstName);
            LastName = view.FindViewById<TextView>(Resource.Id.lastName);
        }
    }
}