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




    [Route("api/admin/content/company-face/[action]")]
    public class CompanyFaceController : Controller
    {
        public DataContext dataContext { get; set; }
        public CompanyFaceController(DataContext _dataContext)
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
            var query = from b in this.dataContext.companyFaces select b;
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

            var material = this.dataContext.companyFaces.Find(input.key);
            JsonConvert.PopulateObject(input.values, material);
            this.dataContext.SaveChanges();
            return true;
        }

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public object insert([FromForm] DevExtremInput input)
        {
            var newBanner = new CompanyFace();
            JsonConvert.PopulateObject(input.values, newBanner);
            var count = (from c in this.dataContext.companyFaces where c.showWay == CompanyFaceShowWay.Hover select c).Count();
            if (count < 2)
            {
                this.dataContext.companyFaces.Add(newBanner);
                this.dataContext.SaveChanges();
                return newBanner;

            }
            else
            {
                return "此位置已满.不能再添加,请选择其他位置";
            }


        }
        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete]
        public object delete(int key)
        {
            var article = this.dataContext.companyFaces.Find(key);
            if (article != null)
            {
                this.dataContext.companyFaces.Remove(article);
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