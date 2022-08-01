using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using WeatherDemoIOS.Core.ViewModels.Main;
using UIKit;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Plugin.Visibility;

namespace WeatherDemoIOS.iOS.Views.Main
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public class MainViewController : BaseViewController<MainViewModel>
    {
        private UILabel _labelWelcome;
        private UITextField _cityTextBox;
        private UIButton _searchButton;
        private UILabel _labelSummary;
        private UIButton _moreButton;
        private UIButton _saveCityButton;

        protected override void CreateView()
        {
            //create UI
            _labelWelcome = new UILabel
            {
                TextAlignment = UITextAlignment.Center
            };
            Add(_labelWelcome);

            _cityTextBox = new UITextField
            {
                Placeholder = "Enter a city to search for",
                TextAlignment = UITextAlignment.Center
            };
            Add(_cityTextBox);

            _searchButton = new UIButton(UIButtonType.System);
            _searchButton.SetTitle("Search", UIControlState.Normal);
            Add(_searchButton);

            _labelSummary = new UILabel
            {
                TextAlignment = UITextAlignment.Center
            };
            Add(_labelSummary);

            _moreButton = new UIButton(UIButtonType.System);
            _moreButton.SetTitle("More Info", UIControlState.Normal);
            Add(_moreButton);

            _saveCityButton = new UIButton(UIButtonType.System);
            _saveCityButton.SetTitle("Save City in Settings", UIControlState.Normal);
            Add(_saveCityButton);

            //Bind UI to viewmodel
            SetBindings();
        }

        private void SetBindings()
        {
            //setup bindings
            MvxFluentBindingDescriptionSet<IMvxIosView<MainViewModel>, MainViewModel> set = CreateBindingSet();
            set.Bind(_labelWelcome).For(v => v.Text).To(vm => vm.PageTitle);
            set.Bind(_cityTextBox).To(vm => vm.City);
            set.Bind(_searchButton).To(vm => vm.SearchCommand);
            set.Bind(_moreButton).For("Visibility").To(vm => vm.ShowMoreButton).WithConversion<MvxVisibilityValueConverter>();
            set.Bind(_labelSummary).To(vm => vm.WeatherSummary);
            set.Bind(_moreButton).To(vm => vm.MoreInfoCommand);
            set.Bind(_saveCityButton).To(vm => vm.SaveCityCommand);
            set.Apply();
        }

        protected override void LayoutView()
        {
            View.AddConstraints(new FluentLayout[]
           {
                _labelWelcome.WithSameCenterX(View),
                _labelWelcome.WithSameCenterY(View),

                _saveCityButton.Below(_labelWelcome, 10f),
                _saveCityButton.WithSameWidth(View),

                _cityTextBox.Below(_saveCityButton, 10f),
                _cityTextBox.WithSameWidth(View),

                _searchButton.Below(_cityTextBox, 10f),
                _searchButton.WithSameWidth(View),

                _labelSummary.Below(_searchButton, 10f),
                _labelSummary.WithSameWidth(View),

                _moreButton.Below(_labelSummary, 10f),
                _moreButton.WithSameWidth(View)
           });
        }
    }
}
