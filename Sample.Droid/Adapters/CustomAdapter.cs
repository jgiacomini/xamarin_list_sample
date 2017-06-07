using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace Sample.Droid.Adapters
{
    public class CustomAdapter : BaseAdapter<Person>
    {
        private readonly Activity _context;
        private readonly List<Person> _persons;

        public CustomAdapter(Activity context, List<Person> persons)
        {
            _context = context;
            _persons = persons;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            // Réutilisation d'une vue si elle existe
            View view = convertView;

            // Création d'une nouvelle vue si ce n'est pas le cas
            if (view == null)
            {
                view = _context.LayoutInflater.Inflate(Resource.Layout.Main, parent, false);
            }

            Person person = this[position];
            view.FindViewById<TextView>(Resource.Id.firstName).Text = person.FirstName;
            view.FindViewById<TextView>(Resource.Id.lastName).Text = person.LastName;

            return view;
        }

        public override int Count
        {
            get { return _persons.Count; }
        }

        public override Person this[int position]
        {
            get { return _persons[position]; }
        }
    }
}