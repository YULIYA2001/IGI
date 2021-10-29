using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace WEB_953501_GOLUBOVICH.Blazor.Client.Models
{
    public class ListViewModel
    {
        [JsonPropertyName("dishId")]
        public int DishId { get; set; } // id блюда
        [JsonPropertyName("dishName")]
        public string DishName { get; set; } //название блюда
    }
}
