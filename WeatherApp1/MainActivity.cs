﻿using Android.App;
using Android.Widget;
using Android.OS;
using SharedProject1;

namespace WeatherApp1
{
    [Activity(Label = "WeatherApp1", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.GetWeatherButton);

            button.Click += delegate
             {
                 EditText ZipCodeEditText = FindViewById<EditText>(Resource.Id.ZipCodeEdit);

                 Weather weather = Core.GetWeather(ZipCodeEditText.Text).Result;

                 if (weather != null)
                 {
                     FindViewById<TextView>(Resource.Id.ResultsTitle).Text = weather.Title;
                     FindViewById<TextView>(Resource.Id.TempText).Text = weather.Temperature;
                     FindViewById<TextView>(Resource.Id.WindText).Text = weather.Wind;
                     FindViewById<TextView>(Resource.Id.VisibilityText).Text = weather.Visibility;
                     FindViewById<TextView>(Resource.Id.HumidityText).Text = weather.Humidity;
                     FindViewById<TextView>(Resource.Id.SunriseText).Text = weather.Sunrise;
                     FindViewById<TextView>(Resource.Id.SunsetText).Text = weather.Sunset;

                     button.Text = "Search Again";

                 }
                 else
                 {
                     FindViewById<TextView>(Resource.Id.ResultsTitle).Text = "Couldn't find anything";
                 }
             };
        }
    }
}

