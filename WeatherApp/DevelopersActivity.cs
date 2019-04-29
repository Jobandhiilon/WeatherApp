
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

namespace WeatherApp
{
    [Activity(Label = "DevelopersActivity")]
    public class DevelopersActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Initialising a seperate activity
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Developers);
        }
    }
}
