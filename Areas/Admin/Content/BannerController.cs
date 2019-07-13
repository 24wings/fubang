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

    public class BannerVerifyInput
    {
        public int bannerId { get; set; }
        /// <summary>
        /// 要修改的状态
        /// </summary>
        /// <value></value>
        public BannerStatus status { get; set; }

    }


    [Route("api/admin/content/[controller]/[action]")]
    public class BannerController : Controller
    {
        public DataContext dataContext { get; set; }
        public BannerController(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpGet]
        public object load(DataSourceLoadOptions options)
        {
            var query = from b in this.dataContext.banners orderby b.orderNo select b;
            return DataSourceLoader.Load(query, options);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public object update([FromForm] DevExtremInput input)
        {

            var material = this.dataContext.banners.Find(input.key);
            JsonConvert.PopulateObject(input.values, material);
            this.dataContext.SaveChanges();
            return true;


        }

        /// <summary>
        /// 发布文章
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public object insert([FromForm] DevExtremInput input)
        {
            var newBanner = new Banner();
            JsonConvert.PopulateObject(input.values, newBanner);
            this.dataContext.banners.Add(newBanner);
            this.dataContext.SaveChanges();
            return newBanner;

        }
        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete]
        public object delete(int key)
        {
            var article = this.dataContext.banners.Find(key);
            if (article != null)
            {
                this.dataContext.Remove(article);
                this.dataContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }


        }

        /// <summary>
        /// banner审核
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public object verify([FromBody] BannerVerifyInput input)
        {
            var article = this.dataContext.banners.Find(input.bannerId);
            if (article != null)
            {
                article.status = input.status;
                this.dataContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}