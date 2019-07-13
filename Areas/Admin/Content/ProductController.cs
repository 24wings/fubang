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

    /// <summary>
    /// 产品验证
    /// </summary>
    public class ProductVerifyInput
    {
        public int productId { get; set; }
        public ProductStatus status { get; set; }
    }

    [Route("api/admin/content/[controller]/[action]")]
    public class ProductController : Controller
    {
        public DataContext dataContext { get; set; }
        public ProductController(DataContext _dataContext)
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
            var query = from b in this.dataContext.products select b;
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

            var material = this.dataContext.products.Find(input.key);
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
            var newBanner = new Product();
            JsonConvert.PopulateObject(input.values, newBanner);

            this.dataContext.products.Add(newBanner);

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
            var article = this.dataContext.products.Find(key);
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
        public object verify([FromBody] ProductVerifyInput input)
        {
            var article = this.dataContext.products.Find(input.productId);
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

        [HttpGet]
        public object loadByTag(string tag)
        {
            var rtn = (from p in this.dataContext.products where p.tags.Contains(tag) select p).ToList();
            return rtn;

        }
    }
}