using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Linq2TwitterSample
{
	public partial class Linq2TwitterSampleViewController : UIViewController
	{

		TwitterTableSource tableSource { get; set; }

		public Linq2TwitterSampleViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			RegisterNotifications ();

			tableSource = new TwitterTableSource ();
			tblTwitter.Source = tableSource;

		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			Console.WriteLine ("I'm at DidAppear");
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		protected override void Dispose (bool disposing)
		{
			base.Dispose (disposing);
			UnregisterNotifications ();
		}

		#endregion


		#region Private Methods

		void RegisterNotifications ()
		{
			NSNotificationCenter.DefaultCenter.AddObserver (NSNotificationsNames.NSReloadTableViewNotification, ReloadTableView, null);
		}

		void UnregisterNotifications ()
		{
			NSNotificationCenter.DefaultCenter.RemoveObserver (this, (NSString)NSNotificationsNames.NSReloadTableViewNotification);
		}

		void ReloadTableView (NSNotification notify)
		{
			tblTwitter.ReloadData ();
		}

		#endregion

	}

	public static class NSNotificationsNames
	{
		public static string NSReloadTableViewNotification { get { return "ReloadTableViewNotification"; } }
	}

}

