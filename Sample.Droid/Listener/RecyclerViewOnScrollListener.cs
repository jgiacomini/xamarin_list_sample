using System;
using Android.Support.V7.Widget;

namespace Sample.Droid.Listener
{
    public class RecyclerViewOnScrollListener : RecyclerView.OnScrollListener
    {
        private readonly LinearLayoutManager _linearLayoutManager;

        public delegate void LoadMoreEventHandler(object sender, EventArgs args);
        public event LoadMoreEventHandler LoadMoreEvent;

        public RecyclerViewOnScrollListener(LinearLayoutManager linerLayoutManager)
        {
            _linearLayoutManager = linerLayoutManager;
        }

        public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
        {
            base.OnScrolled(recyclerView, dx, dy);

            var childCount = recyclerView.ChildCount;
            var itemCount = recyclerView.GetAdapter().ItemCount;
            var firstVisibleItemPosition = _linearLayoutManager.FindFirstVisibleItemPosition();

            if (childCount + firstVisibleItemPosition >= itemCount)
            {
                if (LoadMoreEvent != null)
                {
                    LoadMoreEvent(this, null);
                }
            }
        }
    }
}