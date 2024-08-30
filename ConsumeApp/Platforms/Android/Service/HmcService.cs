using Android.App;
using Android.OS;
using Android.Util;
using Huawei.Hms.Push;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    [Service(Exported = true)]
    [IntentFilter(new[] { "com.huawei.push.action.MESSAGING_EVENT" })]
    public class MyMessagingService : HmsMessageService
    {
        private static readonly string TAG = "My Messaging Service";

        public override void OnNewToken(string token, Bundle bundle)
        {
            Log.Info(TAG, "receive token :" + token);
        }

        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Info(TAG, "OnMessageReceived is called");
            if (message == null)
            {
                Log.Error(TAG, "Received message entity is null!");
                return;
            }

            Log.Info(TAG, "CollapseKey: " + message.CollapseKey
                    + "\n Data: " + message.Data
                    + "\n From: " + message.From
                    + "\n To: " + message.To
                    + "\n MessageId: " + message.MessageId
                    + "\n OriginalUrgency: " + message.OriginalUrgency
                    + "\n Urgency: " + message.Urgency
                    + "\n SendTime: " + message.SentTime
                    + "\n MessageType: " + message.MessageType
                    + "\n Ttl: " + message.Ttl);

            RemoteMessage.Notification notification = message.GetNotification();
            if (notification != null)
            {
                Log.Info(TAG, "\n ImageUrl: " + notification.ImageUrl
                        + "\n Title: " + notification.Title
                        + "\n TitleLocalizationKey: " + notification.TitleLocalizationKey
                        + "\n Body: " + notification.Body
                        + "\n BodyLocalizationKey: " + notification.BodyLocalizationKey
                        + "\n Icon: " + notification.Icon
                        + "\n Sound: " + notification.Sound
                        + "\n Tag: " + notification.Tag
                        + "\n Color: " + notification.Color
                        + "\n ClickAction: " + notification.ClickAction
                        + "\n ChannelId: " + notification.ChannelId
                        + "\n Link: " + notification.Link
                        + "\n NotifyId: " + notification.NotifyId);
            }
        }

        public override void OnMessageSent(string msgId)
        {
            Log.Info(TAG, "onMessageSent called, Message id:" + msgId);
        }

        public override void OnSendError(string msgId, Java.Lang.Exception exception)
        {
            Log.Info(TAG, "onSendError called, message id:" + msgId + ", ErrCode:"
                    + ((SendException)exception).ErrorCode + ", description:" + exception.Message);
        }
    }
}
