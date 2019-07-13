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



    [Route("api/pc/product-resolve/[action]")]
    public class ProductResolveController : Controller
    {
        public DataContext dataContext { get; set; }
        public ProductResolveController(DataContext _dataContext)
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
            var query = from b in this.dataContext.productResolves select b;
            return Rtn<DevExtreme.AspNet.Data.ResponseModel.LoadResult>.Success(DataSourceLoader.Load(query, options));
        }



    }
}