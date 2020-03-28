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
using Firebase.Iid;

namespace FCMMTWDM.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class FirebaseInstanceIDService : FirebaseInstanceIdService
    {
        const string TAG = "MyFirebaseIIDService";

        // [START refresh_token]
        public override void OnTokenRefresh()
        {
            // Get updated InstanceID token.
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Android.Util.Log.Debug(TAG, "Refreshed token: " + refreshedToken);
            System.Diagnostics.Debug.WriteLine($"######Token######  :  {refreshedToken}");
            Xamarin.Forms.Application.Current.Properties["Fcmtocken"] = FirebaseInstanceId.Instance.Token ?? "";
            Xamarin.Forms.Application.Current.SavePropertiesAsync();
        }
        // [END refresh_token] 
    }
}