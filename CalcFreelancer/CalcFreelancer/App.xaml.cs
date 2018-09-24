using CommonServiceLocator;
using System;
using Unity;
using Unity.ServiceLocation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace CalcFreelancer
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            var unityContainer = new UnityContainer();

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unityContainer));

            MainPage = new NavigationPage(new HomePage());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
