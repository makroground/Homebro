using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace Homebro.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            btn_login.IsEnabled = false;
            pgr_login.IsActive = true;
            if (string.IsNullOrWhiteSpace(txt_username.Text) || string.IsNullOrWhiteSpace(txt_password.Password))
            {
                btn_login.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                txt_username.Text = "";
                txt_password.Password = "";
            } else
            {
                if (DBConnect.login(txt_username.Text, create_hash(txt_password.Password)))
                {
                    btn_login.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                    txt_username.Text = "";
                    txt_password.Password = "";
                }
                else
                {
                    btn_login.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    txt_username.Text = "";
                    txt_password.Password = "";
                }
            }
            btn_login.IsEnabled = true;
            pgr_login.IsActive = false;
        }

        private string create_hash(string msg)
        {
            // Convert the message string to binary data.
            IBuffer buffMsg = CryptographicBuffer.ConvertStringToBinary(msg, BinaryStringEncoding.Utf8);

            // Create a HashAlgorithmProvider object.
            HashAlgorithmProvider algProv = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha256);

            // Hash the message.
            IBuffer buffHash = algProv.HashData(buffMsg);

            // Verify that the hash length equals the length specified for the algorithm.
            if (buffHash.Length != algProv.HashLength)
            {
                throw new Exception("There was an error creating the hash");
            }

            // Convert the hash to a string (for display).
            String strHashBase64 = CryptographicBuffer.EncodeToHexString(buffHash);

            // Return the encoded string
            return strHashBase64;
        }
    }
}
