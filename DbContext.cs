using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication1.Model;

namespace Wings.Projects.Web
{
    [Table("leave")]
    public class Leave
    {
        public int id { get; set; }
        public string username { get; set; }
        public DateTime createTime { get; set; } = DateTime.Now;
        public DateTime startTime { get; set; }
        public DateTime returnTime { get; set; }
        public int userId { get; set; }
        public string remark { get; set; }
        public LeaveStatus status { get; set; } = LeaveStatus.Submit;
        public int companyId { get; set; }
        public int orgId { get; set; }
    }

    public enum LeaveStatus
    {
        Submit,
        Approve,
        Return
    }


    [Table("routine")]
    public class Routine
    {
        public int id { get; set; }
        public int subjectId { get; set; }
        public DateTime datetime { get; set; }
        public DateTime createTime { get; set; } = DateTime.Now;
        public RoutineStatus status { get; set; } = RoutineStatus.Submit;
        public int userId { get; set; }
        public int companyId { get; set; }
        public int orgId { get; set; }

        [NotMapped]
        public Subject subject { get; set; }
    }
    public enum RoutineStatus
    {
        Submit,
        Aprrove,
        Expire
    }
    [Table("subject")]
    public class Subject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string summary { get; set; }
        public DateTime startTime { get; set; } = DateTime.Now;
        public DateTime endTime { get; set; } = DateTime.Now;
        public DateTime createTime { get; set; } = DateTime.Now;
        public int companyId { get; set; }
        public SubjectStatus status { get; set; } = SubjectStatus.Active;
        /// <summary>
        /// 日期
        /// </summary>
        /// <value></value>
        public string fullDates { get; set; }

    }

    public enum SubjectStatus
    {
        Active,
        Deprecated
    }



    /// <summary>
    /// 航空数据环境
    /// </summary>
    public partial class DataContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DataContext() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        /// <summary>
        /// 用户表
        /// </summary>
        /// <value></value>
        public DbSet<User> users { get; set; }

        public DbSet<Org> orgs { get; set; }

        public DbSet<Company> companys { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Menu> menus { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Routine> routine { get; set; }
        /// <summary>
        /// 请假列表
        /// </summary>
        /// <value></value>
        public DbSet<Leave> leaves { get; set; }

        public DbSet<SystemDicationary> dicts { get; set; }
        /// <summary>
        /// 文章
        /// </summary>
        /// <value></value>
        public DbSet<Article> articles { get; set; }
        public DbSet<WebsiteMenu> websiteMenus { get; set; }
        /// <summary>
        /// 素材
        /// </summary>
        /// <value></value>
        public DbSet<Material> materials { get; set; }
        /// <summary>
        /// 发展点
        /// </summary>
        /// <value></value>
        public DbSet<Point> points { get; set; }
        /// <summary>
        /// 广告横幅
        /// </summary>
        /// <value></value>
        public DbSet<Banner> banners { get; set; }
        /// <summary>
        /// 合作伙伴
        /// </summary>
        /// <value></value>
        public DbSet<Partner> partners { get; set; }

        public DbSet<ProductResolve> productResolves { get; set; }
        /// <summary>
        /// 公司荣誉
        /// </summary>
        /// <value></value>
        public DbSet<Honor> honors { get; set; }

        public DbSet<Team> teams { get; set; }
        public DbSet<TeamMember> teamMembers { get; set; }
        /// <summary>
        /// 公司办公位置显示
        /// </summary>
        /// <value></value>
        public DbSet<CompanyFace> companyFaces { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        /// <value></value>
        public DbSet<Job> jobs { get; set; }
        /// <summary>
        /// 差评
        /// </summary>
        /// <value></value>
        public DbSet<Product> products { get; set; }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        /// <summary>
        /// 数据库实体创建时
        /// 1.null 扫描Wings.Hk 命名空间下的所有表
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

}