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

namespace Wings.Areas.Admin.Setting.Controllers
{

    [Route("api/admin/setting/[controller]/[action]")]
    [ApiController]

    public class PointController : Controller
    {
        public DataContext dataContext { get; set; }
        public PointController(DataContext _data) { this.dataContext = _data; }

        /// <summary>
        /// 查询参数
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpGet]
        public object load(DataSourceLoadOptions options)
        {
            var query = this.dataContext.points;
            return DataSourceLoader.Load(query, options);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="key"></param>
        /// <param name="bodyData"></param>
        /// <returns></returns>
        [HttpPut]
        public object update([FromForm]DevExtremInput bodyData)
        {
            var point = this.dataContext.points.Find(bodyData.key);
            JsonConvert.PopulateObject(bodyData.values, point);
            this.dataContext.SaveChanges();
            return true;
        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="bodyData"></param>
        /// <returns></returns>
        [HttpPost]
        public object insert([FromForm]DevExtremInput bodyData)
        {
            var newPoint = new Point();
            JsonConvert.PopulateObject(bodyData.values, newPoint);

            this.dataContext.points.Add(newPoint);
            this.dataContext.SaveChanges();
            return true;

        }

        /// <summary>
        /// 移除key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete]
        public object delete([FromForm]int key)
        {
            var point = this.dataContext.points.Find(key);
            this.dataContext.points.Remove(point);
            this.dataContext.SaveChanges();
            return true;
        }



    }
}