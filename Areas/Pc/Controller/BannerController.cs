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


namespace Wings.Areas.Pc
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


    [Route("api/pc/[controller]/[action]")]
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
            var query = from b in this.dataContext.banners orderby b.orderNo where b.status == BannerStatus.Active select b;
            return Rtn<DevExtreme.AspNet.Data.ResponseModel.LoadResult>.Success(DataSourceLoader.Load(query, options));
        }



    }
}