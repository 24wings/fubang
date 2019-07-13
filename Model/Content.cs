using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{

    /// <summary>
    /// 产品状态
    /// </summary>
    public enum ProductStatus
    {
        Disabled,
        Active

    }

    /// <summary>
    /// 产品表
    /// </summary>
    [Table("product")]
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public DateTime? publishAt { get; set; } = DateTime.Now;
        public DateTime? createAt { get; set; } = DateTime.Now;
        public string bannerImageUrl { get; set; }
        public string tags { get; set; }

        public ProductStatus status { get; set; } = ProductStatus.Active;

        public string html { get; set; }
        public string englishHtml { get; set; }
        public string summary { get; set; }
        public string englishSummary { get; set; }
        public string englishName { get; set; }
        // public string englishHtml { get; set; }
    }

    /// <summary>
    /// 职位
    /// </summary>
    [Table("job")]
    public class Job
    {
        public int id { get; set; }
        public string jobName { get; set; }
        public string jobType { get; set; }
        public string address { get; set; }
        public DateTime publishAt { get; set; } = DateTime.Now;
        public string req { get; set; }
        public DateTime createAt { get; set; } = DateTime.Now;
        public string detailAddress { get; set; }
        public string task { get; set; }
        public string englishTask { get; set; }
        public string englishJobName { get; set; }
        public string englishJobType { get; set; }
        public string englishReq { get; set; }
        public string tags { get; set; }
        public string englishTags { get; set; }

    }

    /// <summary>
    /// 公司办公环境显示
    /// </summary>
    public enum CompanyFaceShowWay
    {
        Banner,
        Hover,
        Sidebar
    }

    [Table("company-face")]
    public class CompanyFace
    {
        public int id { get; set; }
        public string title { get; set; }
        public string summary { get; set; }

        public string imageUrl { get; set; }

        public CompanyFaceShowWay showWay { get; set; } = CompanyFaceShowWay.Banner;
        public DateTime createAt { get; set; } = DateTime.Now;
        public string englishTitle { get; set; }
        public string englishSummary { get; set; }
    }

    [Table("team_member")]
    public class TeamMember
    {
        public int id { get; set; }
        public string name { get; set; }
        public string job { get; set; }
        public string summary { get; set; }
        public string headImageUrl { get; set; }
        public DateTime createAt { get; set; } = DateTime.Now;
        public string englishSummary { get; set; }
        public string englishName { get; set; }
        public string englishJob { get; set; }
    }

    [Table("team")]
    public class Team
    {
        public int id { get; set; }
        public string title { get; set; }
        public string remark { get; set; }
        public string imageUrl { get; set; }
        public DateTime createAt { get; set; } = DateTime.Now;
        public string englishTitle { get; set; }
        public string englishRemark { get; set; }

    }
    /// <summary>
    /// 公司荣誉
    /// </summary>
    [Table("honor")]
    public class Honor
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime publishAt { get; set; } = DateTime.Now;
        public DateTime createAt { get; set; } = DateTime.Now;
        public string englishTitle { get; set; }
        public string englishContent { get; set; }
    }

    [Table("product-resolve")]
    public class ProductResolve
    {
        public int id { get; set; }
        public string name { get; set; }
        public string tagName { get; set; }
        public string englishTagName { get; set; }
        // public string englishName { get; set; }
        public DateTime createAt { get; set; } = DateTime.Now;
        public int sort { get; set; } = 0;
        public string imageUrl { get; set; }
        public string title { get; set; }
        public string englishTitle { get; set; }

        public string remark { get; set; }
        public string link { get; set; }
        public string englishRemark { get; set; }
        public string summary { get; set; }
        public string englishSummary { get; set; }
    }

    [Table("partner")]
    public class Partner
    {
        public int id { get; set; }
        public string name { get; set; }

        public DateTime createAt { get; set; } = DateTime.Now;
        public string logoUrl { get; set; }
        public string link { get; set; }
        public int sort { get; set; }
        public string englishName { get; set; }
    }

    [Table("banner")]
    public class Banner
    {
        public int id { get; set; }
        public string imgUrl { get; set; }
        public int orderNo { get; set; } = 0;
        public DateTime createTime { get; set; } = DateTime.Now;
        public BannerStatus status { get; set; } = BannerStatus.Active;
        public string title1 { get; set; }
        public string title2 { get; set; }
        public string title3 { get; set; }
        public string title4 { get; set; }
        public string englishTitle1 { get; set; }
        public string englishTitle2 { get; set; }
        public string englishTitle3 { get; set; }
        public string englishTitle4 { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        /// <value></value>
        public string link { get; set; }
    }
    public enum BannerStatus
    {

        Active,
        Disabled
    }

    [Table("material")]
    public class Material
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public MaterialType type { get; set; } = MaterialType.Image;
        public string ext { get; set; }
        public int size { get; set; }
        public DateTime createAt { get; set; } = DateTime.Now;
        public MaterialStatus status { get; set; } = MaterialStatus.Submit;
        public int? userId { get; set; }
        /// <summary>
        /// oss存储对象Id
        /// </summary>
        /// <value></value>
        public int? ossId { get; set; }
        /// <summary>
        /// 原文件名
        /// </summary>
        /// <value></value>
        public string filename { get; set; }
        // public string tags { get; set; }
    }
    /// <summary>
    /// 素材状态
    /// </summary>
    public enum MaterialStatus
    {
        Submit,
        Approve,
        Fail
    }

    /// <summary>
    /// 素材类型
    /// </summary>
    public enum MaterialType
    {
        Image = 1,
        Video
    }

    [Table("website_menu")]

    public class WebsiteMenu
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
        public DateTime createAt { get; set; } = DateTime.Now;
        public string title { get; set; }
        public string summary { get; set; }
        public string englishTitle { get; set; }
        public string englishSummary { get; set; }
        public string englishText { get; set; }
        public string bannerUrl { get; set; }
        public string content { get; set; }
        public string englishContent { get; set; }
        public bool canDelete { get; set; } = true;
        public bool canUpdate { get; set; } = true;
        public bool isArticle { get; set; } = true;
        public bool canUpdateText { get; set; } = true;

    }

    [Table("article")]
    public class Article
    {
        public int id { get; set; }
        public string title { get; set; }
        public int? charNum { get; set; }
        public int? userId { get; set; }
        public DateTime? lastModifyAt { get; set; } = DateTime.Now;
        public DateTime? createAt { get; set; } = DateTime.Now;
        public string markdown { get; set; }
        public string html { get; set; }
        public string bannerImageUrl { get; set; }
        public string author { get; set; }
        public int? sourceType { get; set; }
        public string summary { get; set; }
        /// <summary>
        /// 英文内容
        /// </summary>
        /// <value></value>
        public string englishContent { get; set; }
        /// <summary>
        /// 文章状态
        /// </summary>
        /// <value></value>
        public ArticleStatus? status { get; set; } = ArticleStatus.Submit;
        public LanguageType? languageType { get; set; } = LanguageType.Chinese;
        /// <summary>
        /// 文章标签
        /// </summary>
        /// <value></value>
        public string tags { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>
        /// <value></value>
        public bool isTop { get; set; } = false;
        public string englishTitle { get; set; }
        public string englishSummary { get; set; }
    }

    /// <summary>
    /// 文章状态
    /// </summary>
    public enum ArticleStatus
    {
        Submit,
        Publish,
        Reject,
        Preview
    }
    public enum LanguageType
    {
        Chinese,
        Engilish,
        ChineseEnglish
    }
}