using GameStore.Models;
using GameStore.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStore.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        //Cколько товаров должно отображаться на странице
        private int pageSize = 4;

        /*
        int.Parse пробует получить число из его строкового представления, в случае успеха возвращает число, иначе же бросает FormatException
        int.TryParse проверяет, можно ли получить число из строки. Если это возможно - возвращает true
        
            Коллекция QueryString получает значения переменных их HTTP-строки запроса
            directory-lookup.asp?name=fred
            Добро пожаловать, <%= Request.QueryString("name") %>.
        */
        protected int CurrentPage
        {
            get
            {
                int page;
                page = int.TryParse(Request.QueryString["page"], out page) ? page : 1;
                return page > MaxPage ? MaxPage : page;
            }
        }

        // Новое свойство, возвращающее наибольший номер допустимой страницы
        //Math.Ceiling Возвращает наименьшее целое число, которое больше или равно заданному десятичному числу
        protected int MaxPage
        {
            get
            {
                return (int)Math.Ceiling((decimal)repository.Games.Count() / pageSize);
            }
        }

        protected IEnumerable<Game> GetGames() {
            return repository.Games
                .OrderBy(g=>g.GameId)
                .Skip((CurrentPage-1)*pageSize)
                .Take(pageSize);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}