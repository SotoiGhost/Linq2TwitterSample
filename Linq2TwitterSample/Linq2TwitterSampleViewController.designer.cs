// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace Linq2TwitterSample
{
	[Register ("Linq2TwitterSampleViewController")]
	partial class Linq2TwitterSampleViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView tblTwitter { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (tblTwitter != null) {
				tblTwitter.Dispose ();
				tblTwitter = null;
			}
		}
	}
}
