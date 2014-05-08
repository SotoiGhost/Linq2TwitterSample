using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using LinqToTwitter;

namespace Linq2TwitterSample
{
	public class TwitterTableSource : UITableViewSource
	{

		const string CellID = "TweetCell";
		List<Status> tweets { get; set; }

		public TwitterTableSource ()
		{
			tweets = new List<Status> ();
			GetTweets ();
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return tweets.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (CellID);

			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Subtitle, CellID);

			cell.TextLabel.Text = tweets [indexPath.Row].ScreenName;
			cell.DetailTextLabel.Text = tweets [indexPath.Row].Text;
			return cell;
		}

		async void GetTweets ()
		{
			await GetTweetsAsync ();
			NSNotificationCenter.DefaultCenter.PostNotificationName (NSNotificationsNames.NSReloadTableViewNotification, null);
		}

		async Task GetTweetsAsync()
		{

			var auth = new PinAuthorizer
			{
				CredentialStore = new InMemoryCredentialStore
				{
					ConsumerKey = TwitterCredentialStore.ApiKey,
					ConsumerSecret = TwitterCredentialStore.ApiSecret,
					OAuthToken = TwitterCredentialStore.AccessToken,
					OAuthTokenSecret = TwitterCredentialStore.AccessTokenSecret,
				},
			};

			var twitterContext = new TwitterContext(auth);

			tweets = await (from tweet in twitterContext.Status
				where tweet.Type == LinqToTwitter.StatusType.User 
				select tweet).ToListAsync ();
						
		}

	}
}

