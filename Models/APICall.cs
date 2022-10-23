using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;


namespace AvaloniaApplication1.Models
{
    public class Root
    {
        public MarketData market_data { get; set; }
    }

    public class MarketData
    {
        public CurrentPrice current_price { get; set; }
    }

    public class CurrentPrice
    {
        // [JsonProperty("eur")] --> ermöglicht andere Bennenung der Klassenvariablen
        public double eur { get; set; }
    }

}



