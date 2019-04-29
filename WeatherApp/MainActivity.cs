using Android.App;
using Android.Widget;
using Android.OS;
using System.Net;
using System.IO;
using System;
using Newtonsoft.Json.Linq;
using Android.Content;

namespace WeatherApp
{
    [Activity(Label = "WeatherApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        //Declaring variables
        public string JSONresponse;
        public static string Temperature;
        public static string Pressure;
        public static string Country;
        public static string CityName;
        public static string Description;
        public static Button SearchButton;
        private EditText editText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            SearchButton = FindViewById<Button>(Resource.Id.Button_Search);
            editText = (EditText)FindViewById(Resource.Id.cityname);

            //Setting up function for search button
            SearchButton.Click += delegate {
                SearchButton.Text = "Please Wait. Fetching info.";
                StartActivity(new Intent(this, typeof(WeatherActivity)));
                WeatherData(editText.Text.Replace(" ","+"));
                StartActivity(new Intent(this, typeof(WeatherActivity)));
            };

            //Setting up function for exit button
            var buttonExit = FindViewById<Button>(Resource.Id.Button_Exit);
            buttonExit.Click += (sender, e) => {
                this.Finish();
            };

            //Setting up function for about developers' button
            var buttonAbout = FindViewById<Button>(Resource.Id.Button_About);
            buttonAbout.Click += delegate {

                StartActivity(new Intent(this, typeof(DevelopersActivity)));
            };
        }

        private void WeatherData(string city)
        {
            //Creating a HttpWebRequest object
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q="+city+"&appid=c2675cc27e2d55338119291273f23807");
            try
            {
                //Recieving response from the API
                WebResponse response = httpWebRequest.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    JSONresponse = reader.ReadToEnd();

                    dynamic data = JObject.Parse(JSONresponse);

                    try
                    {
                        //Getting data from JSON
                        Temperature = data.main.temp;
                        Pressure = data.main.pressure;
                        Country = data.sys.country;
                        CityName = data.name;
                        Description = data.weather[0].description;

                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }


            catch (WebException ex)
            {
                SearchButton.Text = "Failed";
            }

        }

    }
}

