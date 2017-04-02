using CRM_Apps.iOS.NativeFeature;
using CRM_Apps.NativeFeature;
using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(CallNumberImplementation))]
namespace CRM_Apps.iOS.NativeFeature
{
    public class CallNumberImplementation : ICallNumber
    {
        public void CallNumber(string phoneNumber)
        {
            UIApplication.SharedApplication.OpenUrl(new NSUrl("telprompt://" + phoneNumber));
        }
    }
}
