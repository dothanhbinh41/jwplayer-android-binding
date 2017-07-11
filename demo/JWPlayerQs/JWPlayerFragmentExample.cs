﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Com.Longtailvideo.Jwplayer;
using Com.Longtailvideo.Jwplayer.Configuration;

namespace JWPlayerQs
{
    public class JWPlayerFragmentExample : AppCompatActivity
    {
        private JWPlayerSupportFragment mPlayerFragment;
        private JWPlayerView mPlayerView;
        private JWEventHandler mEventHandler;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_fragment);

            TextView outputTextView = FindViewById<TextView>(Resource.Id.output);

            mPlayerFragment = JWPlayerSupportFragment.NewInstance(new PlayerConfig.Builder()
                    .File("http://playertest.longtailvideo.com/adaptive/bipbop/gear4/prog_index.m3u8")
                    .Build());

            Android.Support.V4.App.FragmentManager fm = this.SupportFragmentManager;
            Android.Support.V4.App.FragmentTransaction ft = fm.BeginTransaction();
            ft.Add(Resource.Id.fragment_container, mPlayerFragment);
            ft.Commit();
            fm.ExecutePendingTransactions();

            mPlayerView = mPlayerFragment.Player;

            new KeepScreenOnHandler(mPlayerView, Window);

            mEventHandler = new JWEventHandler(mPlayerView, outputTextView);
        }
    }
}