using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SecureStorageDemo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText editTextU;
        private EditText editTextP;
        private Button buttonL;
        private Button buttonG;
        private Button buttonR;
        private Button buttonRA;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            UIReferences();
            UIClickEvents();
        }

        private void UIClickEvents()
        {
            buttonL.Click += ButtonL_Click;
            buttonG.Click += ButtonG_Click;
            buttonR.Click += ButtonR_Click;
            buttonRA.Click += ButtonRA_Click;
        }

        private void ButtonL_Click(object sender, EventArgs e)
        {
            SecureStorage.SetAsync("username", editTextU.Text);
            SecureStorage.SetAsync("password", editTextP.Text);
            editTextU.Text = string.Empty;
            editTextP.Text = string.Empty;
        }

        private void ButtonG_Click(object sender, EventArgs e)
        {
            _ = GetDetails();
        }

        private async Task GetDetails()
        {
            editTextU.Text = await SecureStorage.GetAsync("username");
            editTextP.Text = await SecureStorage.GetAsync("password");
        }

        private void ButtonR_Click(object sender, EventArgs e)
        {
            SecureStorage.Remove("username");
            SecureStorage.Remove("password");
        }

        private void ButtonRA_Click(object sender, EventArgs e)
        {
            SecureStorage.RemoveAll();
        }

        private void UIReferences()
        {
            buttonL = FindViewById<Button>(Resource.Id.btnLogin);
            buttonG = FindViewById<Button>(Resource.Id.btnGet);
            buttonR = FindViewById<Button>(Resource.Id.btnRemove);
            buttonRA = FindViewById<Button>(Resource.Id.btnRemoveAll);
            editTextU = FindViewById<EditText>(Resource.Id.edtUserName);
            editTextP = FindViewById<EditText>(Resource.Id.edtPassword);
        }
    }
}