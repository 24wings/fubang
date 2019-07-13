
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    /// <summary>
    /// 原点
    /// </summary>
    [Table("point")]
    public class Point
    {
        public int id { get; set; }
        public string name { get; set; }
        public int offsetX { get; set; }
        public int offsetY { get; set; }
        public DateTime publishAt { get; set; } = DateTime.Now;
        public string labels { get; set; }
        public DateTime createAt { get; set; } = DateTime.Now;
        public string englishName { get; set; }
        public string englishLabels { get; set; }
    }
    /// <summary>
    /// 系统参数
    /// </summary>
    [Table("sys_dicationary")]
    public class SystemDicationary
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// <value></value>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// 参数显示
        /// </summary>
        /// <value></value>
        public string name { get; set; }
        /// <summary>
        /// 父id
        /// </summary>
        /// <value></value>
        public int parentId { get; set; } = 0;
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value></value>
        public DateTime createTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 是否移除
        /// </summary>
        /// <value></value>
        public bool? isDelete { get; set; } = false;
        /// <summary>
        /// 参数速查代码
        /// </summary>
        /// <value></value>
        public string code { get; set; }
        /// <summary>
        /// 树路径
        /// </summary>
        /// <value></value>

        public string path { get; set; } = "";
        /// <summary>
        /// 级别
        /// </summary>
        /// <value></value>
        public int level { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        /// <value></value>
        public string value { get; set; }
        public bool canDelete { get; set; } = true;

        [NotMapped]
        public List<SystemDicationary> children { get; set; } = new List<SystemDicationary>();
    }
}
