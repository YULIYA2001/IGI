using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace WEB_953501_GOLUBOVICH.Blazor.Client.Models
{
    public class DetailsViewModel
    {
        [JsonPropertyName("dishName")]
        public string DishName { get; set; } // название блюда
        [JsonPropertyName("description")]
        public string Description { get; set; } // описание блюда
        [JsonPropertyName("calories")]
        public int Calories { get; set; } // кол-во килокалорий на порцию
        [JsonPropertyName("image")]
        public string Image { get; set; } // имя файла изображения
    }
}
