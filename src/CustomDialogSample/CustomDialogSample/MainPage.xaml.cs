using System;
using Xamarin.Forms;
using static CustomDialogSample.CustomDialogAlert;

namespace CustomDialogSample
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            CustomDialogAlert1.SelectCommand = new Command<CustomDialogAlertItem>(x => {
                Label1.Text = x.Action.ToString();
                if(x.Action.Equals(ButtonActions.OK))
                {
                    Entry1.Text = x.InputValue;
                }
            });
            Button1.Clicked += async (s, e) =>
            {
                await CustomDialogAlert1.ToVisibleAsync(Entry1.Text);
            };
        }
    }
}
