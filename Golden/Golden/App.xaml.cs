﻿using Golden.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Golden
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new IndexPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
