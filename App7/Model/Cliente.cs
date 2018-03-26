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
using Newtonsoft.Json;

namespace App7.Model
{
    public class Cliente
    {
       
        [JsonProperty(PropertyName = "nome")]
        public string nome { get; set; }

        public override string ToString()
        {
            return nome;
        }

    }
}