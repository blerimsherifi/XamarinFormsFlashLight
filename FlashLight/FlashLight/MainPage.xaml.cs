using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FlashLight
{
    public partial class MainPage : ContentPage
    {
        private bool TurnOn = true;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnTurnLight_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (TurnOn)
                {
                    TurnOn = false;
                    btnTurnLight.Image = "OFF.png";
                    // Turn On
                    await Flashlight.TurnOnAsync();
                    Vibration.Vibrate();
                }
                else
                {
                    TurnOn = true;
                    btnTurnLight.Image = "ON.png";
                    // Turn Off
                    await Flashlight.TurnOffAsync();
                    Vibration.Vibrate();
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to turn on/off flashlight
            }
        }
    }
}
