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



    [Route("api/admin/content/team-member/[action]")]
    public class TeamMemberController : Controller
    {
        public DataContext dataContext { get; set; }
        public TeamMemberController(DataContext _dataContext)
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
            var query = from b in this.dataContext.teamMembers select b;
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

            var material = this.dataContext.teamMembers.Find(input.key);
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
            var newPartner = new TeamMember();
            JsonConvert.PopulateObject(input.values, newPartner);
            this.dataContext.teamMembers.Add(newPartner);
            this.dataContext.SaveChanges();
            return newPartner;

        }
        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete]
        public object delete(int key)
        {
            var article = this.dataContext.teamMembers.Find(key);
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


    }
}