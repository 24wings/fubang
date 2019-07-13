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
    /// 重置伙伴位置
    /// </summary>
    public class ResetPartnerInput
    {
        public int partnerId { get; set; }
    }



    [Route("api/admin/content/partner/[action]")]
    public class PartnerController : Controller
    {
        public DataContext dataContext { get; set; }
        public PartnerController(DataContext _dataContext)
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
            var query = from b in this.dataContext.partners orderby b.sort select b;
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

            var material = this.dataContext.partners.Find(input.key);
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
            var newPartner = new Partner();
            JsonConvert.PopulateObject(input.values, newPartner);
            this.dataContext.partners.Add(newPartner);
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
            var article = this.dataContext.partners.Find(key);
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

        [HttpPost]
        public object reset2Top([FromBody] ResetPartnerInput input)
        {
            var partner = this.dataContext.partners.Find(input.partnerId);
            Console.WriteLine(input.partnerId);
            if (partner != null)
            {
                var firstPartner = (from p in this.dataContext.partners orderby p.sort select p).FirstOrDefault();
                partner.sort = firstPartner.sort - 1;
                this.dataContext.SaveChanges();
                return Rtn<bool>.Success(true, "置顶成功");

            }
            else
            {
                return Rtn<bool>.Success(false, "伙伴不存在");
            }
        }
        [HttpPost]
        public object reset2Bottom([FromBody] ResetPartnerInput input)
        {
            var partner = this.dataContext.partners.Find(input.partnerId);
            if (partner != null)
            {
                var bottomPartner = (from p in this.dataContext.partners orderby p.sort descending select p).FirstOrDefault();
                partner.sort += 1;
                this.dataContext.SaveChanges();
                return Rtn<bool>.Success(true, "置底成功");
            }
            else
            {
                return Rtn<bool>.Error("重置到底部");
            }
        }
        /// <summary>
        /// 前置
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public Rtn<bool> pre([FromBody] ResetPartnerInput input)
        {
            var partner = this.dataContext.partners.Find(input.partnerId);
            if (partner != null)
            {
                var prePartners = (from p in this.dataContext.partners where p.sort <= partner.sort select p).ToList();
                var preFirstPartner = (from p in prePartners orderby p.sort descending select p).FirstOrDefault();
                if (preFirstPartner != null)
                {
                    if (preFirstPartner.sort == partner.sort)
                    {
                        partner.sort -= 1;
                        this.dataContext.SaveChanges();
                        return Rtn<bool>.Success(true, "前置成功");
                    }
                    else
                    {
                        var currentSort = partner.sort;
                        partner.sort = preFirstPartner.sort;
                        preFirstPartner.sort = currentSort;
                        this.dataContext.SaveChanges();
                        return Rtn<bool>.Success(true, "前置成功");
                    }
                }
                else
                {
                    return Rtn<bool>.Error("已经顶部了");
                }
            }
            else
            {
                return Rtn<bool>.Error("信息不存");
            }
        }
        /// <summary>
        /// 合作伙伴后置
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public Rtn<bool> next([FromBody] ResetPartnerInput input)
        {
            var partner = this.dataContext.partners.Find(input.partnerId);
            if (partner != null)
            {
                var nextPartners = (from p in this.dataContext.partners where p.sort >= partner.sort select p).ToList();
                var nextFirsetPartner = (from p in nextPartners orderby p.sort select p).FirstOrDefault();
                if (nextFirsetPartner != null)
                {
                    Console.WriteLine("current:" + partner.sort + "  next:" + nextFirsetPartner.sort);
                    if (nextFirsetPartner.sort == partner.sort)
                    {
                        partner.sort += 1;
                        this.dataContext.SaveChanges();
                    }
                    else
                    {
                        var currentSort = partner.sort;
                        partner.sort = nextFirsetPartner.sort;
                        nextFirsetPartner.sort = currentSort;
                        this.dataContext.SaveChanges();
                    }
                    return Rtn<bool>.Success(true, "后置成功");

                }
                else
                {
                    return Rtn<bool>.Error("伙伴已置底");
                }

            }
            else
            {
                return Rtn<bool>.Error("伙伴不存在");
            }
        }



    }
}