using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using Refit;
using App7.Model;

namespace App7.Interface
{
    [Headers("User-Agent: :request:")]
    interface EcommerceApi
    {
        [Get("/api/clientes/")]
        Task<ApiResponse> GetClientes();

    }
}