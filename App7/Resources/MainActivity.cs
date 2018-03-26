using Android.App;
using Android.Widget;
using Android.OS;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using App7.Interface;
using App7.Model;
using System.Collections.Generic;
using System;
using Refit;

namespace App7
{
    [Activity(Label = "App7", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EcommerceApi gitHubApi;
        List<Cliente> clientes = new List<Cliente>();
        List<String> cliente_names = new List<String>();
        Button cake_lyf_button;
        IListAdapter ListAdapter;
        ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = { new StringEnumConverter() }
            };

            gitHubApi = RestService.For<EcommerceApi>("https://aqueous-anchorage-88955.herokuapp.com");

            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            cake_lyf_button = FindViewById<Button>(Resource.Id.btn_list_clientes);
            listView = FindViewById<ListView>(Resource.Id.listview_clientes);
            cake_lyf_button.Click += Cake_lyf_button_Click;


        }

        private async void getClientes()
        {
            try
            {
                ApiResponse response = await gitHubApi.GetClientes();
                clientes = response.items;

                foreach (Cliente cliente in clientes)
                {
                    cliente_names.Add(cliente.ToString());
                }
                ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, cliente_names);
                listView.Adapter = ListAdapter;
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.StackTrace, ToastLength.Long).Show();

            }
        }

        private void Cake_lyf_button_Click(object sender, EventArgs e)
        {
            getClientes();
        }
    }
}

