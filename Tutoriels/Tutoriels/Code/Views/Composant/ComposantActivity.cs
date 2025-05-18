using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using System.Reflection;
using Tutoriels.Code.Activities;
using Tutoriel;

namespace Tutoriels.Code.Activities.Composant
{
    [Activity(Label = "Tutorial")]
    public class ComposantActivity : BaseActivity
    {
        #region Overall

        /// <summary>
        /// Layout de notre activité
        /// </summary>
        protected override int LayoutResourceId => Resource.Layout.ComposantActivity;

        #endregion

        #region Life cycle

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            EditText edittext = FindViewById<EditText>(Resource.Id.edittext);
            edittext.KeyPress += (object sender, View.KeyEventArgs e) =>
            {
                e.Handled = false;
                if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                {
                    Toast.MakeText(this, edittext.Text, ToastLength.Short).Show();
                    e.Handled = true;
                }
            };

            RadioButton radio_red = FindViewById<RadioButton>(Resource.Id.radio_red);
            RadioButton radio_blue = FindViewById<RadioButton>(Resource.Id.radio_blue);

            radio_red.Click += OnClickRadioButton;
            radio_blue.Click += OnClickRadioButton;


            RatingBar ratingbar = FindViewById<RatingBar>(Resource.Id.ratingbar);
            ratingbar.RatingBarChange += (o, e) =>
            {
                Toast.MakeText(this, "New Rating: " + ratingbar.Rating.ToString(), ToastLength.Short).Show();
            };

            Switch switchbutton = FindViewById<Switch>(Resource.Id.switchButton);
            switchbutton.Click += (o, e) =>
            {
                // Perform action on clicks
                if (switchbutton.Checked)
                    Toast.MakeText(this, "Checked", ToastLength.Short).Show();
                else
                    Toast.MakeText(this, "Not checked", ToastLength.Short).Show();
            };

            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(OnItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.planets_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;


        }

        #endregion

        #region User Interface

        private void OnItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private void OnClickRadioButton(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            Toast.MakeText(this, rb.Text, ToastLength.Short).Show();
        }

        #endregion
    }
}