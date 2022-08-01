using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using UIKit;
using WeatherDemoIOS.ViewModels;

namespace WeatherDemoIOS.iOS.Views.Weather
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public class WeatherDetailsViewController : BaseViewController<WeatherDetailsViewModel>
    {
        private UILabel _labelWelcome, _labelMessage;
        protected UIBarButtonItem _backPageNavButton;
        private UILabel _labelSummary;
        private UILabel _labelFeelsLike;
        private UILabel _labelTempMin;
        private UILabel _labelTempMax;
        private UILabel _labelPressure;
        private UILabel _labelHumidity;

        protected override void CreateView()
        {
            _labelWelcome = new UILabel
            {
                TextAlignment = UITextAlignment.Center
            };
            Add(_labelWelcome);
            _labelSummary = new UILabel
            {
                TextAlignment = UITextAlignment.Center
            };
            Add(_labelSummary);
            _labelFeelsLike = new UILabel
            {
                TextAlignment = UITextAlignment.Center
            };
            Add(_labelFeelsLike);

            _labelTempMin = new UILabel
            {
                TextAlignment = UITextAlignment.Center
            };
            Add(_labelTempMin);

            _labelTempMax = new UILabel
            {
                TextAlignment = UITextAlignment.Center
            };
            Add(_labelTempMax);
            _labelPressure = new UILabel
            {
                TextAlignment = UITextAlignment.Center
            };
            Add(_labelPressure);
            _labelHumidity = new UILabel
            {
                TextAlignment = UITextAlignment.Center
            };
            Add(_labelHumidity);

            SetupBackButton();

            SetBindings();
        }

        private void SetBindings()
        {
            //setup bindings
            MvxFluentBindingDescriptionSet<IMvxIosView<WeatherDetailsViewModel>, WeatherDetailsViewModel> set = CreateBindingSet();
            set.Bind(_backPageNavButton).To(vm => vm.GoBackCommand);
            set.Bind(_labelSummary).To(vm => vm.WeatherSummary);
            set.Bind(_labelFeelsLike).To(vm => vm.FeelsLike);
            set.Bind(_labelTempMin).To(vm => vm.TempMin);
            set.Bind(_labelTempMax).To(vm => vm.TempMax);
            set.Bind(_labelPressure).To(vm => vm.Pressure);
            set.Bind(_labelHumidity).To(vm => vm.Humidity);
            set.Apply();
        }

        protected override void LayoutView()
        {
            View.AddConstraints(new FluentLayout[]
           {
                _labelWelcome.WithSameCenterX(View),
                _labelWelcome.WithSameCenterY(View),

                _labelSummary.Below(_labelWelcome, 10f),
                _labelSummary.WithSameWidth(View),

                _labelFeelsLike.Below(_labelSummary, 10f),
                _labelFeelsLike.WithSameWidth(View),

                _labelTempMin.Below(_labelFeelsLike, 10f),
                _labelTempMin.WithSameWidth(View),

                _labelTempMax.Below(_labelTempMin, 10f),
                _labelTempMax.WithSameWidth(View),

                _labelPressure.Below(_labelTempMax, 10f),
                _labelPressure.WithSameWidth(View),

                _labelHumidity.Below(_labelPressure, 10f),
                _labelHumidity.WithSameWidth(View),
           });
        }

        protected void SetupBackButton(string title = "Back", bool animated = true)
        {
            _backPageNavButton = new UIBarButtonItem
            {
                Title = title
            };

            NavigationItem.SetHidesBackButton(true, false);
            NavigationItem.SetLeftBarButtonItem(_backPageNavButton, animated);
        }
    }
}
