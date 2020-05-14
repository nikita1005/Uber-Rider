using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Firebase;
using Firebase.Database;


namespace Uber_Rider
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        FirebaseDatabase database;
        Button btntestConnection;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btntestConnection = (Button)FindViewById(Resource.Id.Mybutton);
            btntestConnection.Click += BtntestConnection_Click;
 }
        public void BtntestConnection_Click(object sender, System.EventArgs e) 
        {
            Initializedatabase();
        }
        void Initializedatabase()
        { var app = FirebaseApp.InitializeApp(this);
            if (app == null)
            {
                var options = new FirebaseOptions.Builder()

                    .SetApplicationId("uber-clone-43c35")
                    .SetApiKey("AIzaSyAGgpqc9yzcdiCj3GJ-DWXl3xqdY2RB3tA")
                    .SetDatabaseUrl("https://uber-clone-43c35.firebaseio.com")
                    .SetStorageBucket("uber-clone-43c35.appspot.com")
                    .Build();
                app = FirebaseApp.InitializeApp(this, options);
                database = FirebaseDatabase.GetInstance(app);
            }
            else
            {
                database = FirebaseDatabase.GetInstance(app); 
            }
            DatabaseReference dbref = database.GetReference("UserSupport");
            dbref.SetValue("Ticket1");

            Toast.MakeText(this,"Completed", ToastLength.Short).Show();

        }
    }
}