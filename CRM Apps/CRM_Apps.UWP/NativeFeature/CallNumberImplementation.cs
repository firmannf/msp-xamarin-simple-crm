using CRM_Apps.NativeFeature;
using CRM_Apps.UWP.NativeFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(CallNumberImplementation))]
namespace CRM_Apps.UWP.NativeFeature
{
    public class CallNumberImplementation : ICallNumber
    {
        public void CallNumber(string phoneNumber)
        {
            Device.OpenUri(new Uri(phoneNumber));
        }
    }

}
