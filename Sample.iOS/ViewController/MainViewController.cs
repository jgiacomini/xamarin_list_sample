﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Sample.iOS
{
    public partial class MainViewController : UIViewController
    {

     
        public MainViewController()
        {
			Title = "Exemple liste simple";
			View.BackgroundColor = UIColor.White;
			EdgesForExtendedLayout = UIRectEdge.None;
		}


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			var listeSimpleButton = UIButton.FromType(UIButtonType.System);
			listeSimpleButton.SetTitle("Liste simple", UIControlState.Normal);
            listeSimpleButton.TouchUpInside += ListeSimpleButton_TouchUpInside;
			listeSimpleButton.Frame = new CGRect(10, 10, View.Bounds.Width - 20, 40);

			var infiniteScrollListeButton = UIButton.FromType(UIButtonType.System);
			infiniteScrollListeButton.SetTitle("Infinite scroll", UIControlState.Normal);
            infiniteScrollListeButton.TouchUpInside += InfiniteScrollListeButton_TouchUpInside;;
			infiniteScrollListeButton.Frame = new CGRect(10, 60, View.Bounds.Width - 20, 40);

            View.AddSubviews(listeSimpleButton, infiniteScrollListeButton);
		}


        void ListeSimpleButton_TouchUpInside(object sender, EventArgs e)
        {
            this.NavigationController.PushViewController(new SimpleListViewController(),true);
        }

        void InfiniteScrollListeButton_TouchUpInside(object sender, EventArgs e)
        {
            this.NavigationController.PushViewController(new InfiniteScrollViewController(), true);
		}
    }

}