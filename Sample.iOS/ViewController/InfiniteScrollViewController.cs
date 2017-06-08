using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace Sample.iOS
{
    public class InfiniteScrollViewController : UITableViewController
    {
	
        public InfiniteScrollViewController()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


			var items = new List<string>();

            for (int i = 0; i < 50; i++)
            {
                items.Add($"Index page 0, élèment {i}");
            }

            var source = new InfiniteTableSource(items);
            source.NeedReloadTableView+= Source_NeedReloadTableView;

            TableView.Source = source;
        }

        void Source_NeedReloadTableView(object sender, EventArgs e)
        {
            TableView.ReloadData();
        }
    }

    public class InfiniteTableSource : UITableViewSource
	{
		const int _nombreDeCellulesParPages = 30;
        int _indexDeLaPage;
        bool _isLoading;
      	protected List<string> _items;
		protected string cellIdentifier = "IdentifiantCellule";

        public event EventHandler NeedReloadTableView;

        public InfiniteTableSource(List<string> items)
		{
			_items = items;
		}


		public override nint RowsInSection(UITableView tableview, nint section)
		{
			// Retourne le nombre de ligne pour la section courante (dans notre cas nous avons qu'une seule section)
			return _items.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
			string item = _items[indexPath.Row];


			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
			}

			cell.TextLabel.Text = item;

            if (!_isLoading && indexPath.Row > _items.Count * 0.8)
			{
                _isLoading = true;
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                this.LoadMoreAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }

			return cell;
		}


        private async Task LoadMoreAsync()
		{
            _indexDeLaPage++;

            var liste = await GetPageDataAsync(_indexDeLaPage, _nombreDeCellulesParPages);
            _items.AddRange(liste);

            InvokeOnMainThread(() =>  NeedReloadTableView?.Invoke(this, EventArgs.Empty));
            _isLoading = false;
		}


        private async Task<List<string>> GetPageDataAsync(int indexDeLaPage, int nombreDeCellulesParPages)
        {
            List<string> liste = new List<string>();
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
            await System.Threading.Tasks.Task.Delay(100);
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;

			for (int i = 0; i < nombreDeCellulesParPages; i++)
            {
                liste.Add($"Index Page {indexDeLaPage}, élèment {i}");
            }

            return liste;
        }
	}
}

