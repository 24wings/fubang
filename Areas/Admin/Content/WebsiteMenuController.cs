using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Model;
using Wings.Base.Common.DTO;
using Wings.Projects.Web;


namespace Wings.Areas.Admin.Content
{
    [Route("api/admin/content/website-menu/[action]")]
    public class WebsiteMenuController : Controller
    {
        public DataContext dataContext { get; set; }
        public WebsiteMenuController(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        /// <summary>
        /// 查询文章
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpGet]
        public object load(DataSourceLoadOptions options)
        {
            var query = this.dataContext.websiteMenus;
            return DataSourceLoader.Load(query, options);
        }
        /// <summary>
        /// 查询未预览文章
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpGet]
        public object loadNotPreview(DataSourceLoadOptions options)
        {
            var query = this.dataContext.websiteMenus;
            return DataSourceLoader.Load(query, options);
        }

        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public object update([FromForm] DevExtremInput input)
        {

            var websiteMenu = this.dataContext.websiteMenus.Find(input.key);
            JsonConvert.PopulateObject(input.values, websiteMenu);
            if (websiteMenu.link == String.Empty || websiteMenu.link == null)
            {
                websiteMenu.link = "/pc/content/" + websiteMenu.id;
            }
            this.dataContext.SaveChanges();
            return true;


        }

        /// <summary>
        /// 发布文章
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public object insert([FromForm] DevExtremInput input)
        {
            var newWebsiteMenu = new WebsiteMenu();

            var parent = this.dataContext.websiteMenus.Find(newWebsiteMenu.parentId);
            JsonConvert.PopulateObject(input.values, newWebsiteMenu);
            Console.WriteLine("parentId" + newWebsiteMenu.parentId);
            if (parent != null && newWebsiteMenu.parentId != 0)
            {
                newWebsiteMenu.path = parent.path + "," + parent.id;
                newWebsiteMenu.level = parent.level + 1;
            }

            var rtn = this.dataContext.websiteMenus.Add(newWebsiteMenu);
            if (rtn.Entity.link == String.Empty || rtn.Entity.link == null)
            {
                rtn.Entity.link = "/pc/content/" + rtn.Entity.id;
            }

            this.dataContext.SaveChanges();
            return newWebsiteMenu;

        }
        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete]
        public object delete(int key)
        {
            var websiteMenu = this.dataContext.websiteMenus.Find(key);
            if (websiteMenu != null)
            {
                this.dataContext.Remove(websiteMenu);
                this.dataContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }


        }
        [HttpGet]
        public object loadActive(DataSourceLoadOptions options)
        {
            var websiteMenus = (from m in this.dataContext.websiteMenus select m);
            return DataSourceLoader.Load(websiteMenus, options);
        }
    }
}