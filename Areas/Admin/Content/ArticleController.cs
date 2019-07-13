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
    public class ArticleTopInput
    {
        public int articleId { get; set; }
        public bool isTop { get; set; }
    }

    public class ArticleVerifyInput
    {
        /// <summary>
        /// 文章id
        /// </summary>
        /// <value></value>
        public int articleId { get; set; }
        /// <summary>
        /// 文章状态
        /// </summary>
        /// <value></value>
        public ArticleStatus status { get; set; }
    }

    [Route("api/admin/content/[controller]/[action]")]
    public class ArticleController : Controller
    {
        public DataContext dataContext { get; set; }
        public ArticleController(DataContext _dataContext)
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
            options.RequireTotalCount = true;

            var query = from a in this.dataContext.articles orderby a.createAt descending orderby a.isTop descending select a;
            return DataSourceLoader.Load(query, options);

        }
        /// <summary>
        /// 查询未预览的文章
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpGet]
        public object loadNotPreview(DataSourceLoadOptions options)
        {
            options.RequireTotalCount = true;

            var query = from a in this.dataContext.articles where a.status != ArticleStatus.Preview && a.status == ArticleStatus.Publish orderby a.createAt descending orderby a.isTop descending select a;
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

            var material = this.dataContext.articles.Find(input.key);
            JsonConvert.PopulateObject(input.values, material);
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
            var newArticle = new Article();
            JsonConvert.PopulateObject(input.values, newArticle);
            this.dataContext.articles.Add(newArticle);
            this.dataContext.SaveChanges();
            return newArticle;

        }
        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete]
        public object delete(int key)
        {
            var article = this.dataContext.articles.Find(key);
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
        /// 文章审核
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public object verify([FromBody] ArticleVerifyInput input)
        {
            var article = this.dataContext.articles.Find(input.articleId);
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

        public object top([FromBody] ArticleTopInput input)
        {
            var article = this.dataContext.articles.Find(input.articleId);
            if (article != null)
            {
                article.isTop = input.isTop;
                this.dataContext.SaveChanges();

                return Rtn<bool>.Success(true);
            }
            else
            {
                return Rtn<bool>.Error("不存在的文章");
            }

        }

        [HttpGet]
        public Rtn<DevExtreme.AspNet.Data.ResponseModel.LoadResult> loadTop([FromQuery] DataSourceLoadOptions options)
        {
            var query = (from a in this.dataContext.articles where a.isTop == true select a).ToList();
            var data = DataSourceLoader.Load(query, options);
            return Rtn<DevExtreme.AspNet.Data.ResponseModel.LoadResult>.Success(data);
        }

    }
}