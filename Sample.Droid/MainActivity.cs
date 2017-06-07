using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Sample.Droid.Adapters;
using Sample.Droid.Listener;

namespace Sample.Droid
{
    [Activity(Label = "Sample.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private RecyclerView _recyclerView;
        private SwipeRefreshLayout _swipeRefreshLayout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            var persons = new List<Person>();
            for (int i = 0; i < 50; i++)
            {
                var person = new Person
                {
                    FirstName = $"FirstName {i}",
                    LastName = $"LastName {i}"
                };

                persons.Add(person);
            }

            var linearLayoutManager = new LinearLayoutManager(this);
            var adapter = new CustomRecyclerViewAdapter(persons);

            var onScrollListener = new RecyclerViewOnScrollListener(linearLayoutManager);
            onScrollListener.LoadMoreEvent += OnLoadMore;

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            _recyclerView.HasFixedSize = true;
            _recyclerView.AddOnScrollListener(onScrollListener);
            _recyclerView.SetLayoutManager(linearLayoutManager);
            _recyclerView.SetAdapter(adapter);

            _swipeRefreshLayout = FindViewById<SwipeRefreshLayout>(Resource.Id.swipeRefreshLayout);
            _swipeRefreshLayout.Refresh += OnRefresh;
        }

        private async void OnLoadMore(object sender, EventArgs args)
        {
            try
            {
                // Chargement des nouvelles données via un Web Service ou un appel à une base de données
                await LoadMoreDataAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private async Task LoadMoreDataAsync()
        {
            // On simule le temps d'appel 
            await Task.Delay(2000);
        }

        private async void OnRefresh(object sender, EventArgs e)
        {
            try
            {
                _swipeRefreshLayout.Refreshing = true;

                // Rechargement des données via un Web Service ou un appel à une base de données
                await RefreshDataAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                _swipeRefreshLayout.Refreshing = false;
            }
        }

        private async Task RefreshDataAsync()
        {
            // On simule le temps d'appel 
            await Task.Delay(2000);
        }
    }
}
