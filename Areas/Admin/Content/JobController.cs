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




    [Route("api/admin/content/job/[action]")]
    public class JobController : Controller
    {
        public DataContext dataContext { get; set; }
        public JobController(DataContext _dataContext)
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
            var query = from b in this.dataContext.jobs select b;
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

            var material = this.dataContext.jobs.Find(input.key);
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
            var newBanner = new Job();
            JsonConvert.PopulateObject(input.values, newBanner);
            this.dataContext.jobs.Add(newBanner);
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
            var article = this.dataContext.jobs.Find(key);
            if (article != null)
            {
                this.dataContext.jobs.Remove(article);
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