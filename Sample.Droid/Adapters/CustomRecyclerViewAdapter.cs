using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;

namespace Sample.Droid.Adapters
{
    public class CustomRecyclerViewAdapter : RecyclerView.Adapter
    {
        private readonly List<Person> _persons;

        public CustomRecyclerViewAdapter(List<Person> persons)
        {
            _persons = persons;
        }

        public override int ItemCount
        {
            get { return _persons.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var customRecyclerViewHolder = (CustomRecyclerViewHolder)holder;
            customRecyclerViewHolder.FirstName.Text = _persons[position].FirstName;
            customRecyclerViewHolder.LastName.Text = _persons[position].LastName;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var layout = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CustomCell, parent, false);
            return new CustomRecyclerViewHolder(layout);
        }
    }
}