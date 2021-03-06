﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Support.V4.Content;

namespace Insane.Notifications.Droid.GCM.GcmClient
{
	public abstract class GcmBroadcastReceiverBase<TIntentService> : WakefulBroadcastReceiver where TIntentService : GcmServiceBase
	{
        public GcmBroadcastReceiverBase(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        } 

        public GcmBroadcastReceiverBase()
        {
        }

		public override void OnReceive(Context context, Intent intent)
		{
			Logger.Debug("OnReceive: " + intent.Action);
			var className = context.PackageName + Constants.DEFAULT_INTENT_SERVICE_CLASS_NAME;

			Logger.Debug("GCM IntentService Class: " + className);

			GcmServiceBase.RunIntentInService(context, intent, typeof(TIntentService));
			SetResult(Result.Ok, null, null);
		}
	}
}