using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.ViewModels;

namespace WeatherDemoIOS.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        public string PageTitle { get; set; }
    }
}
