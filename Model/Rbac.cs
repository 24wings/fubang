using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{

    [Table("menu")]
    public class Menu
    {
        public int id { get; set; }
        public string text { get; set; }
        public string link { get; set; }
        public int level { get; set; } = 0;
        public string path { get; set; } = "";
        /// <summary>
        /// 权限编码
        /// </summary>
        /// <value></value>
        public string code { get; set; }
        public int parentId { get; set; } = 0;
        public DateTime createTime { get; set; } = DateTime.Now;

    }




    [Table("role")]
    public class Role
    {
        [Key]
        public int id { get; set; }
        public string roleName { get; set; }
        public string menuIds { get; set; } = "";
        public DateTime createTime { get; set; } = DateTime.Now;
        public int orgId { get; set; }
        public int companyId { get; set; }
        [NotMapped]
        public Org org { get; set; }

    }

    [Table("user")]
    public class User
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public int orgId { get; set; } = 0;
        /// <summary>
        /// 昵称
        /// </summary>
        /// <value></value>
        public string nickname { get; set; }
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <value></value>
        public string roleIds { get; set; } = "";
        public string password { get; set; }
        [NotMapped]
        public Org org { get; set; }

        public DateTime createTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 公司Id
        /// </summary>
        /// <value></value>
        public int companyId { get; set; }
        public string subjectIds { get; set; }
        [NotMapped]
        public List<Role> roles { get; set; } = new List<Role>();
        [NotMapped]
        public List<Menu> menus { get; set; } = new List<Menu>();

        public UserStatus? status { get; set; } = UserStatus.Active;

        public RoleType roleType { get; set; } = RoleType.Student;



    }
    public enum RoleType
    {
        Teacher = 1,
        Student = 2
    }
    public enum UserStatus
    {
        Active,
        /// <summary>
        /// 离校
        /// </summary>
        Disabled
    }
    [Table("org")]
    public class Org
    {

        public int orgId { get; set; }
        public string orgName { get; set; }
        public DateTime? createTime { get; set; } = DateTime.Now;
        public int? companyId { get; set; }
        public int parentId { get; set; } = 0;
        /// <summary>
        /// 存储上级id路径
        /// </summary>
        /// <value></value>
        public string path { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        /// <value></value>
        public int level { get; set; } = 0;

        [NotMapped]

        public int roleNum { get; set; } = 0;
        [NotMapped]
        public int userNum { get; set; } = 0;


    }
    [Table("company")]
    public class Company
    {

        public int id { get; set; }
        public string name { get; set; }
        public DateTime? createTime { get; set; }
        public decimal? lat { get; set; } = 0;
        public decimal? lng { get; set; } = 0;
        public string teamSummary { get; set; }
        public string teamDetail { get; set; }
        public int? teamNum { get; set; }
        public int? studyNum { get; set; }
        public string peopleIdea { get; set; }
        public string phone { get; set; }
        public string logoUrl { get; set; }
        public string email { get; set; }
        public string partnerEmail { get; set; }
        public string customerTime { get; set; }
        public string qrcodeUrl { get; set; }
        public string companySummary { get; set; }
        public string englishCompanySummary { get; set; }

        public int? area { get; set; } = 0;
    }

}