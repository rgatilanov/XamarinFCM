using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace FCMMTWDM
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnSend_Clicked(object sender, EventArgs e)
        {
            try
            {
                var FCMToken = Application.Current.Properties.Keys.Contains("Fcmtocken");
                if (FCMToken)
                {
                    var FCMTockenValue = Application.Current.Properties["Fcmtocken"].ToString();
                    FCMBody body = new FCMBody();
                    FCMNotification notification = new FCMNotification();
                    notification.title = "Mi primer notificación con Firebase";
                    notification.body = "Hola clase MTWDM 2020 desde FCM";
                    FCMData data = new FCMData();
                    data.key1 = "";
                    data.key2 = "";
                    data.key3 = "";
                    data.key4 = "";
                    body.registration_ids = new[] { FCMTockenValue };
                    body.notification = notification;
                    body.data = data;
                    var isSuccessCall = SendNotification(body).Result;
                    if (isSuccessCall)
                    {
                        DisplayAlert("Alert", "Notifications Send Successfully", "Ok");
                    }
                    else
                    {
                        DisplayAlert("Alert", "Notifications Send Failed", "Ok");
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<bool> SendNotification(FCMBody fcmBody)
        {
            try
            {
                var httpContent = JsonConvert.SerializeObject(fcmBody);
                var client = new HttpClient();
                var authorization = string.Format("key={0}", "AAAAJsApTRo:APA91bG8y6TIk7Aro7_sBp3sK4V5kGmE7KGwXVuA75kTEdYTIaNoQAOBG9zjWW9lYYaGEgCH0OLkd3kb1M3FUVHDeav0zw4ybR1YtYxGPdVRhqM9xoDz4Y5H_QTjOhDF4F-PuT9fEI9_"); //Se copia de Firebase -> Configuración del proyecto -> Mensajería en la nube -> "Clave del Servidor"
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authorization);
                var stringContent = new StringContent(httpContent);
                stringContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                string uri = "https://fcm.googleapis.com/fcm/send";
                var response = await client.PostAsync(uri, stringContent).ConfigureAwait(false);
                var result = response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (TaskCanceledException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
