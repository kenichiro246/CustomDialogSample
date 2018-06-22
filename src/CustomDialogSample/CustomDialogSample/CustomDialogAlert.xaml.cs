using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomDialogSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomDialogAlert : ContentView
    {
        private const int SHOW_LENGTH = 300;

        public CustomDialogAlert()
        {
            InitializeComponent();
            this.IsVisible = false;
            BoxViewBackground.IsVisible = false;
            FrameDialogAlert.Scale = 0;
        }

        public enum ButtonActions
        {
            OK,
            Cancel,
            NotAction
        }

        public Command<CustomDialogAlertItem> SelectCommand { get; set; }

        private async Task ButtonCancel_Clicked(object sender, EventArgs e)
        {
            await ToVisibleAsync(false);
            var item = new CustomDialogAlertItem();
            item.Action = ButtonActions.Cancel;
            item.InputValue= Entry1.Text;
            SelectCommand?.Execute(item);
        }

        private async Task ButtonOk_Clicked(object sender, EventArgs e)
        {
            await ToVisibleAsync(false);
            var item = new CustomDialogAlertItem();
            item.Action = ButtonActions.OK;
            item.InputValue = Entry1.Text;
            SelectCommand?.Execute(item);
        }

        private async Task ToVisibleAsync(bool visible)
        {
            var scale = visible ? 1 : 0;
            if (visible)
            {
                this.IsVisible = visible;
                BoxViewBackground.IsVisible = visible;
                await FrameDialogAlert.ScaleTo(scale, SHOW_LENGTH, Easing.CubicIn);
            }
            else
            {
                await FrameDialogAlert.ScaleTo(scale, SHOW_LENGTH, Easing.CubicIn);
                BoxViewBackground.IsVisible = visible;
                this.IsVisible = visible;
            }
        }

        public async Task ToVisibleAsync(string value)
        {
            Entry1.Text = value;
            await ToVisibleAsync(true);
        }

        public class CustomDialogAlertItem
        {
            public ButtonActions Action { get; set; }
            public string InputValue { get; set; }
        }
    }
}