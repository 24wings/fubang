using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Model;
using Wings.Base.Common;
using Wings.Base.Common.DTO;
using Wings.Base.Common.Services;
using Wings.Projects.Web;


namespace Wings.Areas.Admin.Content
{
    /// <summary>
    /// 上传素材输入
    /// </summary>
    public class UploadMarialInput
    {
        /// <summary>
        /// 素材名
        /// </summary>
        /// <value></value>
        public string name { get; set; }
        /// <summary>
        /// 素材大小
        /// </summary>
        /// <value></value>
        public int size { get; set; }
        /// <summary>
        /// 素材文件
        /// </summary>
        /// <value></value>
        public IFormFile file { get; set; }
        public string filename { get; set; }
    }

    [Route("api/admin/content/[controller]/[action]")]
    public class MaterialController : Controller
    {
        public DataContext dataContext { get; set; }
        public MaterialController(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        /// <summary>
        /// 查询文章
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpGet]
        public object load(DataSourceLoadOptions options)
        {
            var query = this.dataContext.materials;
            return DataSourceLoader.Load(query, options);
        }

        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public object update([FromForm] DevExtremInput input)
        {

            var material = this.dataContext.materials.Find(input.key);
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
            var newMaterial = new Material();
            JsonConvert.PopulateObject(input.values, newMaterial);
            this.dataContext.materials.Add(newMaterial);
            this.dataContext.SaveChanges();
            return newMaterial;

        }
        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete]
        public object delete(int key)
        {
            var article = this.dataContext.materials.Find(key);
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
        /// 上传素材
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object uploadMaterial([FromForm] UploadMarialInput input)
        {
            var newMaterial = new Material();

            var filename = DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds + input.name;
            //将源文件 读取成文件流
            Stream fromFile = input.file.OpenReadStream();
            var response = OSSService.uploadFile(fromFile, filename);
            var url = "http://image.fubang.airuanjian.vip/" + filename;
            Console.WriteLine(response);
            newMaterial.url = url;
            newMaterial.filename = filename;
            newMaterial.name = input.filename;
            newMaterial.size = input.size;
            var ext = input.filename.Split(".").Last();
            switch (ext.ToLower())
            {
                case "mp4":
                    newMaterial.type = MaterialType.Video;
                    break;
                case "jpg":
                case "png":
                    newMaterial.type = MaterialType.Image;
                    break;
            }
            newMaterial.ext = ext;
            this.dataContext.materials.Add(newMaterial);
            this.dataContext.SaveChanges();
            return Rtn<Material>.Success(newMaterial);

        }
    }
}