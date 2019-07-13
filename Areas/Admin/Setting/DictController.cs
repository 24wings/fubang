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

    [Route("api/admin/setting/dict/[action]")]
    [ApiController]

    public class DictController : Controller
    {
        public DataContext dataContext { get; set; }
        public DictController(DataContext _data) { this.dataContext = _data; }

        /// <summary>
        /// 查询参数
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpGet]
        public object load(DataSourceLoadOptions options)
        {
            var query = this.dataContext.dicts;
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
            var dict = this.dataContext.dicts.Find(bodyData.key);
            JsonConvert.PopulateObject(bodyData.values, dict);
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
            var newDict = new SystemDicationary();
            JsonConvert.PopulateObject(bodyData.values, newDict);
            var parent = this.dataContext.dicts.Find(newDict.parentId);
            if (parent != null)
            {
                newDict.level = parent.level + 1;
                newDict.path = parent.path + "," + parent.id;

            }


            this.dataContext.dicts.Add(newDict);
            this.dataContext.SaveChanges();
            return true;

        }

        /// <summary>
        /// 移除key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete]
        public object delete([FromForm] int key)
        {
            var dict = this.dataContext.dicts.Find(key);
            if (dict != null)
            {
                this.dataContext.Remove(dict);
                this.dataContext.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 加载字典以及子类
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object loadChildren(DataSourceLoadOptions options)
        {
            var query = this.dataContext.dicts;
            var result = DataSourceLoader.Load(query, options);
            var dicts = result.data.Cast<SystemDicationary>();
            if (dicts.Count() != 0)
            {
                var dict = dicts.FirstOrDefault();
                if (dict != null)
                {
                    var children = from d in this.dataContext.dicts where d.parentId == dict.id select d;
                    return new { data = new { dict = dict, children = children } };
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 加载字典以及所有子类
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public Rtn<object> loadChildrenAll(string name)
        {
            var dict = (from d in this.dataContext.dicts where d.name == name select d).FirstOrDefault();
            if (dict != null)
            {

                var chilrenDicts = (from d in this.dataContext.dicts where d.parentId == dict.id select d).ToList();

                foreach (var d in chilrenDicts)
                {
                    d.children = (from subDict in this.dataContext.dicts where subDict.parentId == d.id select subDict).ToList();
                    foreach (var subDict in dict.children)
                    {
                        subDict.children = (from thirdDict in this.dataContext.dicts where thirdDict.parentId == subDict.id select thirdDict).ToList();
                    }
                }


                dict.children = chilrenDicts;

                return Rtn<object>.Success(dict);
            }
            else
            {
                return Rtn<object>.Error("字典不存在");
            }


        }

    }
}