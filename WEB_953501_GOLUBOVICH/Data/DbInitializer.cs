using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953501_GOLUBOVICH.Entities;

namespace WEB_953501_GOLUBOVICH.Data
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin

                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            // инициализация списка групп и продуктов
            //проверка наличия групп объектов
            if (!context.DishGroups.Any())
            {               
                context.DishGroups.AddRange(new List<DishGroup>
                {
                    new DishGroup {GroupName="Стартеры"},
                    new DishGroup {GroupName="Салаты"},
                    new DishGroup {GroupName="Супы"},
                    new DishGroup {GroupName="Основные блюда"},
                    new DishGroup {GroupName="Напитки"},
                    new DishGroup {GroupName="Десерты"}
                });
                await context.SaveChangesAsync();
            }
            // проверка наличия объектов
            if (!context.Dishes.Any())
            {
                context.Dishes.AddRange(new List<Dish>
                {
                    new Dish { DishName="Суп-харчо", Description="Очень пряный, острый, с обилием чеснока и зелени",
                        Calories =284, DishGroupId=3, Image="sup-harcho.jpg" },
                    new Dish { DishName="Борщ", Description="Традиционное блюдо восточных славян",
                        Calories =235, DishGroupId=3, Image="borshch.jpg" },
                    new Dish { DishName="Котлета пожарская", Description="Курица не менее 80%",
                        Calories =310, DishGroupId=4, Image="kotleta_pozharskaya.jpg" },
                    new Dish { DishName="Макароны по-флотски", Description="Со свежей свининой",
                        Calories =524, DishGroupId=4, Image="makaroni_po_flotski.jpg" },
                    new Dish { DishName="Компот вишневый", Description="Из концентрированного сока",
                        Calories =120, DishGroupId=5, Image="kompot_vishneviy.jpg" },
                    new Dish { DishName="Салат овощной", Description="Томаты, огурцы, перец и свежая зелень",
                        Calories =68, DishGroupId=2, Image="salat_ovoshchnoy.jpg" },
                    new Dish { DishName="Торт Киевский", Description="Белково-ореховые коржи, сливочно-шоколадный крем",
                        Calories =402, DishGroupId=6, Image="tort_kievskiy.jpg" }
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
