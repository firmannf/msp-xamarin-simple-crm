using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using CRM_Apps.Android.NativeFeature;
using CRM_Apps.NativeFeature;

[assembly: Dependency(typeof(CallNumberImplementation))]
namespace CRM_Apps.Droid.NativeFeature
{
    public class CallNumberImplementation : ICallNumber
    {
        public void CallNumber(string phoneNumber)
        {
            var intent = new Intent(Intent.ActionDial, Uri.Parse("tel:" + phoneNumber));
            var ctx = Forms.Context;
            ctx.StartActivity(intent);
        }

    }

}