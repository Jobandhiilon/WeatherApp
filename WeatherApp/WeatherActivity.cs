using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using static Android.Resource;

namespace WeatherApp
{
    [Activity(Label = "WeatherActivity")]
    public class WeatherActivity : Activity
    {
        //Declaring variables
        private TextView cityName;
        private TextView temperature;
        private TextView pressure;
        private TextView description;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Weather);
            cityName = (TextView)FindViewById(Resource.Id.city_name);
            temperature = (TextView)FindViewById(Resource.Id.temperature1);
            pressure = (TextView)FindViewById(Resource.Id.pressure1);
            description = (TextView)FindViewById(Resource.Id.condition);

            //Setting textviews to retrivied information
            cityName.Text = MainActivity.CityName+", "+MainActivity.Country;
            temperature.Text = "Temperature: " + (Double.Parse(MainActivity.Temperature) - 273.15).ToString()+ "° C";
            pressure.Text = "Pressure       : "+MainActivity.Pressure;
            description.Text = MainActivity.Description;

            //Setting up function for exit button
            var buttonExit = FindViewById<Button>(Resource.Id.Button_Exit_Weather);
            buttonExit.Click += (sender, e) => {
                this.Finish();
            };

            // Setting up function for back button
            var buttonBack = FindViewById<Button>(Resource.Id.Button_Back);
            buttonExit.Click += (sender, e) => {
                MainActivity.SearchButton.Text = "Search";
                this.Finish();
            };
        }
    }
}
