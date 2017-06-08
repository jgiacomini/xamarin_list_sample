﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Sample.iOS
{
    public partial class SimpleListViewController : UIViewController
    {

        UIRefreshControl _refreshControl;
        List<string> _items;


        public SimpleListViewController()
        {
			Title = "Exemple liste simple";
			View.BackgroundColor = UIColor.White;
			this.EdgesForExtendedLayout = UIRectEdge.None;
        }

        public UITableView TableView
        {
            get;
            set;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableView = new UITableView();
            TableView.Frame = new CGRect(0, 0, View.Frame.Width, View.Frame.Height);

            View.AddSubview(TableView);

			_refreshControl = new UIRefreshControl();
			_refreshControl.ValueChanged += _refreshControl_ValueChanged;
			_refreshControl.AttributedTitle = new NSAttributedString("Chargement");
			TableView.RefreshControl = _refreshControl;

			_items = new List<string>();
			_items.Add("Jérôme");
			_items.Add("Maxime");
			_items.Add("Thomas");
			_items.Add("Mickaël");

			TableView.Source = new TableSource(_items);
            TableView.Delegate = new ActionsDelegate();
        }

        async void _refreshControl_ValueChanged(object sender, EventArgs e)
        {
			_refreshControl.BeginRefreshing();
            await Task.Delay(4000);
            //On ajoute une valeur à la liste
            _items.Add("Nouvelle valeur");

            //On recharge les données du tableau
            TableView.ReloadData();
            _refreshControl.EndRefreshing();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

    }


	public class TableSource : UITableViewSource
	{

        protected List<string> _items;
		protected string cellIdentifier = "IdentifiantCellule";

        public TableSource(List<string> items)
		{
            _items = items;
		}

	
		public override nint RowsInSection(UITableView tableview, nint section)
		{
            // Retourne le nombre de ligne pour la section courante (dans notre cas nous avons qu'une seule section)
            return _items.Count;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
            Console.WriteLine($"Ligne {indexPath.Row} seletionnée :  {_items[indexPath.Row]})");
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

			return cell;
		}

	}

	public class ActionsDelegate : UITableViewDelegate
	{
		public ActionsDelegate()
		{
		}

		public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewRowAction deleteButton = UITableViewRowAction.Create(
                UITableViewRowActionStyle.Default,
				"Supprimer",
				delegate
				{
					Console.WriteLine("Suppression...");
				});
			UITableViewRowAction masquerButton = UITableViewRowAction.Create(
                UITableViewRowActionStyle.Destructive,
				"Masquer",
				delegate
				{
					Console.WriteLine("Masquage");
				});
            masquerButton.BackgroundColor = UIColor.Blue;

			return new UITableViewRowAction[] { deleteButton , masquerButton };
		}
	}
}