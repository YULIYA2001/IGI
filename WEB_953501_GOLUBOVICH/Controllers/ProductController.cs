using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953501_GOLUBOVICH.Entities;
using WEB_953501_GOLUBOVICH.Models;

namespace WEB_953501_GOLUBOVICH.Controllers
{
    public class ProductController : Controller
    {
        List<Dish> _dishes;
        List<DishGroup> _dishGroups;
        int _pageSize;
        public ProductController()
        {
            _pageSize = 3;
            SetupData();
        }
        public IActionResult Index(int? group, int pageNo=1)
        {
            var dishesFiltered = _dishes.Where(d => !group.HasValue || d.DishGroupId == group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _dishGroups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;

            return View(ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize));
        }
        /// <summary>
        /// Инициализация списков
        /// </summary>
        private void SetupData()
        {
            _dishGroups = new List<DishGroup>
            {
                new DishGroup {DishGroupId=1, GroupName="Стартеры"},
                new DishGroup {DishGroupId=2, GroupName="Салаты"},
                new DishGroup {DishGroupId=3, GroupName="Супы"},
                new DishGroup {DishGroupId=4, GroupName="Основные блюда"},
                new DishGroup {DishGroupId=5, GroupName="Напитки"},
                new DishGroup {DishGroupId=6, GroupName="Десерты"}
            };
            _dishes = new List<Dish>
            {
                new Dish {DishId = 1, DishName="Суп-харчо", Description="Очень пряный, острый, с обилием чеснока и зелени",
                    Calories =284, DishGroupId=3, Image="sup-harcho.jpg" },
                new Dish { DishId = 2, DishName="Борщ", Description="Традиционное блюдо восточных славян",
                    Calories =235, DishGroupId=3, Image="borshch.jpg" },
                new Dish { DishId = 3, DishName="Котлета пожарская", Description="Курица не менее 80%",
                    Calories =310, DishGroupId=4, Image="kotleta_pozharskaya.jpg" },
                new Dish { DishId = 4, DishName="Макароны по-флотски", Description="Со свежей свининой",
                    Calories =524, DishGroupId=4, Image="makaroni_po_flotski.jpg" },
                new Dish { DishId = 5, DishName="Компот вишневый", Description="Из концентрированного сока",
                    Calories =120, DishGroupId=5, Image="kompot_vishneviy.jpg" },
                new Dish { DishId = 5, DishName="Салат овощной", Description="Томаты, огурцы, перец и свежая зелень",
                    Calories =68, DishGroupId=2, Image="salat_ovoshchnoy.jpg" },
                new Dish { DishId = 5, DishName="Торт Киевский", Description="Белково-ореховые коржи, сливочно-шоколадный крем",
                    Calories =402, DishGroupId=6, Image="tort_kievskiy.jpg" }
            };

        }
    }
}
