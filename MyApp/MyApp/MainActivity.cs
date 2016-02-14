using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MyApp.BO.Business;

namespace MyApp
{
    [Activity(Label = "MyApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.MyButton);

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            CharacterSheet cs = CharacterSheet.Load();
            mapCharacToActivity(cs);


            //Button button1 = FindViewById<Button>(Resource.Id.button1);

            //button1.Click += delegate { button.Text = string.Format("Attack rolled a {0} !", cs.simpleAttackRoll(ar, at) ); };
        }

        protected void mapCharacToActivity(CharacterSheet cs)
        {
            TextView TxtViewCharName = FindViewById<TextView>(Resource.Id.textViewCharName);
            TxtViewCharName.Text = cs.Nom;

            TextView TxtViewCharClass = FindViewById<TextView>(Resource.Id.textViewCharClass);
            TxtViewCharClass.Text = cs.ClasseActuelle;

            TextView TxtViewCharRace = FindViewById<TextView>(Resource.Id.textViewCharRace);
            TxtViewCharRace.Text = cs.Race;

            TextView TxtViewCharNiveau = FindViewById<TextView>(Resource.Id.textViewCharNiveau);
            TxtViewCharNiveau.Text = cs.NiveauGlobal.ToString();

            GridView grdChar = FindViewById<GridView>(Resource.Id.gridViewCharac);
            ///grdChar.

        }

    }
}

