using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.I2c;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Leds_RGB_Universal
{
    public sealed partial class MainPage : Page
    {
        private I2cDevice Device;
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            IniciateMonitoring();
        }

        private async void IniciateMonitoring()
        {
            var settings = new I2cConnectionSettings(0x40);
            settings.BusSpeed = I2cBusSpeed.StandardMode;
            string aqs = I2cDevice.GetDeviceSelector();
            var dis = await DeviceInformation.FindAllAsync(aqs);

            Device = await I2cDevice.FromIdAsync(dis[0].Id, settings);

            if (Device == null)
            {
                Debug.WriteLine("Error I2C");
            }
        }

        private void ctrlColorLeft_ColorChanged(object sender, Windows.UI.Color color)
        {
            txtRedLeft.Text = ctrlColorLeft.Color.R.ToString();
            txtGreenLeft.Text = ctrlColorLeft.Color.G.ToString();
            txtBlueLeft.Text = ctrlColorLeft.Color.B.ToString();

            string leftSeriesColor = txtRedLeft.Text + ',' + txtGreenLeft.Text + ',' + txtBlueLeft.Text;
            SendI2CMessage('l', leftSeriesColor);
        }

        private void ctrlColorCentral_ColorChanged(object sender, Windows.UI.Color color)
        {
            txtRedCentral.Text = ctrlColorCentral.Color.R.ToString();
            txtGreenCentral.Text = ctrlColorCentral.Color.G.ToString();
            txtBlueCentral.Text = ctrlColorCentral.Color.B.ToString();

            string centralSeriesColor = txtRedCentral.Text + ',' + txtGreenCentral.Text + ',' + txtBlueCentral.Text;
            SendI2CMessage('c', centralSeriesColor);
        }

        private void ctrlColorRight_ColorChanged(object sender, Windows.UI.Color color)
        {
            txtRedRight.Text = ctrlColorRight.Color.R.ToString();
            txtGreenRight.Text = ctrlColorRight.Color.G.ToString();
            txtBlueRight.Text = ctrlColorRight.Color.B.ToString();

            string rightSeriesColor = txtRedRight.Text + ',' + txtGreenRight.Text + ',' + txtBlueRight.Text;
            SendI2CMessage('r', rightSeriesColor);
        }

        private void SendI2CMessage(char selectedStrip, string stringToSend)
        {
            byte[] toBytes = new byte[12];
            toBytes = Encoding.ASCII.GetBytes(selectedStrip + stringToSend);

            try
            {
                Device.Write(toBytes);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
