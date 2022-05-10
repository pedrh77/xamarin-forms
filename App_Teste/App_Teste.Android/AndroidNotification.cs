using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.Core.App;
using System;
using Xamarin.Forms;
using AndroidApp = Android.App.Application;

[assembly:
    Dependency(typeof(App_Teste.Droid.AndroidNotification))]
namespace App_Teste.Droid
{
    public class AndroidNotification : INotificacaoManager
    {
        const string channelId = "default";
        const string channelName = "Default";
        const string channelDescription = "The default channel for notifications.";
        const int pendingIntentId = 0; public const string TitleKey = "title";
        public const string MessageKey = "message";
        bool channelInitialized = false;
        int messageId = -1;
        NotificationManager manager;


        public event EventHandler NotificacaoRecebida;
        public void Initialize() { CreateNotificationChannel(); }

        public int OrdemNotificacao(string title, string message)
        {
            if (!channelInitialized)
            {
                CreateNotificationChannel();
            }
            messageId++;
            Intent intent = new Intent(AndroidApp.Context, typeof(MainActivity));
            intent.PutExtra(TitleKey, title);
            intent.PutExtra(MessageKey, message);
            PendingIntent pendingIntent = PendingIntent.GetActivity(AndroidApp.Context, pendingIntentId, intent, PendingIntentFlags.OneShot);
            NotificationCompat.Builder builder = new NotificationCompat.Builder(AndroidApp.Context, channelId).SetContentIntent(pendingIntent)
                .SetContentTitle(title).SetContentText(message).SetSmallIcon(Resource.Drawable.img)
                .SetDefaults((int)NotificationDefaults.Sound | (int)NotificationDefaults.Vibrate);
            Notification notification = builder.Build();
            manager.Notify(messageId, notification);
            return messageId;
        }

        void CreateNotificationChannel()
        {
            manager = (NotificationManager)AndroidApp.Context.GetSystemService(AndroidApp.NotificationService);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channelNameJava = new Java.Lang.String(channelName);
                var channel = new NotificationChannel(channelId, channelNameJava, NotificationImportance.Default)
                {
                    Description = channelDescription
                };
                manager.CreateNotificationChannel(channel);
                channelInitialized = true;
            }
        }

        public void ReceberNoficacao(string title, string message)
        {
            var args = new NofificacaoEventArg()
            {
                Title = title,
                Message = message
            };
            NotificacaoRecebida?.Invoke(null, args);
        }
    }
}