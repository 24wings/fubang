-- MySQL dump 10.13  Distrib 8.0.15, for Win64 (x86_64)
--
-- Host: 39.97.180.241    Database: app
-- ------------------------------------------------------
-- Server version	8.0.16

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Position to start replication or point-in-time recovery from
--

-- CHANGE MASTER TO MASTER_LOG_FILE='iZ4h7p5iwzmtcpZ-bin.000006', MASTER_LOG_POS=155;

--
-- Table structure for table `article`
--

DROP TABLE IF EXISTS `article`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `article` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(45) DEFAULT NULL,
  `charNum` int(11) DEFAULT NULL,
  `userId` int(11) DEFAULT NULL,
  `lastModifyAt` datetime DEFAULT NULL,
  `createAt` datetime DEFAULT NULL,
  `markdown` text,
  `html` text,
  `bannerImageUrl` varchar(100) DEFAULT NULL COMMENT '封面地址',
  `author` varchar(45) DEFAULT NULL COMMENT '作者',
  `sourceType` int(11) DEFAULT NULL COMMENT '来源类型 0 原创 1 转载',
  `summary` varchar(4500) DEFAULT NULL COMMENT '简述',
  `useAudio` tinyint(4) DEFAULT NULL COMMENT '是否启用音频',
  `audioUrl` varchar(450) DEFAULT NULL,
  `englishContent` text COMMENT '英文内容',
  `languageType` int(11) DEFAULT NULL,
  `tags` varchar(100) DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `lastModifyBy` varchar(45) DEFAULT NULL COMMENT '最后修改人',
  `publishUser` varchar(45) DEFAULT NULL COMMENT '文章发布人',
  `articlecol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='文章';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `article`
--

LOCK TABLES `article` WRITE;
/*!40000 ALTER TABLE `article` DISABLE KEYS */;
INSERT INTO `article` VALUES (12,'test2',1329,1,'2019-05-30 16:00:59','2019-04-25 19:44:08','# 标题\n\n**粗体** \n*斜体*\n <u>下划线</u> ~~删除线~~\n    \n  > 引用内容 \n\n   ```\n        < !--代码块 -->\n            <link rel=\"stylesheet\" href = \"assets/prism.css\" />\n                <pre><code class=\"language-javascript\" >\n                    console.log(\'Test\');\n</code></pre >\n    <script src=\"assets/prism.css\" > </script>\n```\n![alt](http://cucr.oss-cn-beijing.aliyuncs.com/img/QQ%E5%9B%BE%E7%89%8720190425084322.jpg)\n\n1. 有序列表\n2. 有序列表\n\n    \n ![alt](http://cucr.oss-cn-beijing.aliyuncs.com/img/QQ%E5%9B%BE%E7%89%8720190425084322.jpg)\n\n* 无序列表1\n* 无序列表2\n    \n    [链接](http://baidu.com \"链接提示\")\n    \n    ![图片](http://placehold.it/140x140 \"图片提示\")\n    \n    分隔线\n    \n    ---\n    \n    ## 表格\n\n\ncolumn1 | column2 | column3\n    ------- | ------- | -------\n    column1 | column2 | column3\n    column1 | column2 | column3\n    column1 | column2 | column3','<h2>标题</h2><p><strong>粗体</strong> <i>斜体</i> 下划线 删除线</p><blockquote><p>引用内容dsad</p></blockquote><p>&nbsp; &nbsp; &nbsp; &nbsp; &lt; !--代码块 --&gt;\n &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;link rel=\"stylesheet\" href = \"assets/prism.css\" /&gt;\n &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;pre&gt;&lt;code class=\"language-javascript\" &gt;\n &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;console.log(\'Test\');\n&lt;/code&gt;&lt;/pre &gt;\n &nbsp; &nbsp;&lt;script src=\"assets/prism.css\" &gt; &lt;/script&gt;\n</p><figure class=\"image\"><img src=\"http://cucr.oss-cn-beijing.aliyuncs.com/img/QQ%E5%9B%BE%E7%89%8720190425084322.jpg\" alt=\"alt\"></figure><ol><li>有序列表</li><li>有序列表</li></ol><figure class=\"image\"><img src=\"http://cucr.oss-cn-beijing.aliyuncs.com/img/QQ%E5%9B%BE%E7%89%8720190425084322.jpg\" alt=\"alt\"></figure><ul><li>无序列表1</li></ul><p>无序列表2</p><p><a href=\"http://baidu.com\">链接</a></p><figure class=\"image\"><img src=\"http://placehold.it/140x140\" alt=\"图片\"></figure><p>分隔线</p><h2>表格</h2><figure class=\"table\"><table><thead><tr><th>column1</th><th>column2</th><th>column3</th></tr></thead><tbody><tr><td>column1</td><td>column2</td><td>column3</td></tr><tr><td>column1</td><td>column2</td><td>column3</td></tr><tr><td>column1</td><td>column2</td><td>column3</td></tr></tbody></table></figure>','123','123123',1,'123',NULL,NULL,NULL,2,',,',0,NULL,NULL,NULL),(13,'asd',11,1,'2019-05-30 16:01:29','2019-04-25 21:06:30','\n# 标题\n\n**粗体** \n*斜体*\n <u>下划线</u> ~~删除线~~\n    \n  > 引用内容 \n\n   ```\n        < !--代码块 -->\n            <link rel=\"stylesheet\" href = \"assets/prism.css\" />\n                <pre><code class=\"language-javascript\" >\n                    console.log(\'Test\');\n</code></pre >\n    <script src=\"assets/prism.css\" > </script>\n```\n![alt](http://cucr.oss-cn-beijing.aliyuncs.com/img/QQ%E5%9B%BE%E7%89%8720190425084322.jpg)\n\n1. 有序列表\n2. 有序列表\n\n    \n ![alt](http://cucr.oss-cn-beijing.aliyuncs.com/img/QQ%E5%9B%BE%E7%89%8720190425084322.jpg)\n\n* 无序列表1\n* 无序列表2\n    \n    [链接](http://baidu.com \"链接提示\")\n    \n    ![图片](http://placehold.it/140x140 \"图片提示\")\n    \n    分隔线\n    \n    ---\n    \n    ## 表格\n\n\ncolumn1 | column2 | column3\n    ------- | ------- | -------\n    column1 | column2 | column3\n    column1 | column2 | column3\n    column1 | column2 | column3','<p>dasd</p>',NULL,'',0,'',NULL,NULL,NULL,2,'4144,eeqa',0,NULL,NULL,NULL),(14,NULL,823,1,'2019-04-25 21:06:30','2019-04-25 21:06:30','\n# 标题\n\n**粗体** \n*斜体*\n <u>下划线</u> ~~删除线~~\n    \n  > 引用内容 \n\n   ```\n        < !--代码块 -->\n            <link rel=\"stylesheet\" href = \"assets/prism.css\" />\n                <pre><code class=\"language-javascript\" >\n                    console.log(\'Test\');\n</code></pre >\n    <script src=\"assets/prism.css\" > </script>\n```\n![alt](http://cucr.oss-cn-beijing.aliyuncs.com/img/QQ%E5%9B%BE%E7%89%8720190425084322.jpg)\n\n1. 有序列表\n2. 有序列表\n\n    \n ![alt](http://cucr.oss-cn-beijing.aliyuncs.com/img/QQ%E5%9B%BE%E7%89%8720190425084322.jpg)\n\n* 无序列表1\n* 无序列表2\n    \n    [链接](http://baidu.com \"链接提示\")\n    \n    ![图片](http://placehold.it/140x140 \"图片提示\")\n    \n    分隔线\n    \n    ---\n    \n    ## 表格\n\n\ncolumn1 | column2 | column3\n    ------- | ------- | -------\n    column1 | column2 | column3\n    column1 | column2 | column3\n    column1 | column2 | column3',NULL,NULL,'',0,'',NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,NULL),(15,NULL,823,1,'2019-04-25 21:06:31','2019-04-25 21:06:31','\n# 标题\n\n**粗体** \n*斜体*\n <u>下划线</u> ~~删除线~~\n    \n  > 引用内容 \n\n   ```\n        < !--代码块 -->\n            <link rel=\"stylesheet\" href = \"assets/prism.css\" />\n                <pre><code class=\"language-javascript\" >\n                    console.log(\'Test\');\n</code></pre >\n    <script src=\"assets/prism.css\" > </script>\n```\n![alt](http://cucr.oss-cn-beijing.aliyuncs.com/img/QQ%E5%9B%BE%E7%89%8720190425084322.jpg)\n\n1. 有序列表\n2. 有序列表\n\n    \n ![alt](http://cucr.oss-cn-beijing.aliyuncs.com/img/QQ%E5%9B%BE%E7%89%8720190425084322.jpg)\n\n* 无序列表1\n* 无序列表2\n    \n    [链接](http://baidu.com \"链接提示\")\n    \n    ![图片](http://placehold.it/140x140 \"图片提示\")\n    \n    分隔线\n    \n    ---\n    \n    ## 表格\n\n\ncolumn1 | column2 | column3\n    ------- | ------- | -------\n    column1 | column2 | column3\n    column1 | column2 | column3\n    column1 | column2 | column3',NULL,NULL,'',0,'',NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,NULL),(16,NULL,823,1,'2019-04-25 21:06:32','2019-04-25 21:06:32','\n# 标题\n\n**粗体** \n*斜体*\n <u>下划线</u> ~~删除线~~\n    \n  > 引用内容 \n\n   ```\n        < !--代码块 -->\n            <link rel=\"stylesheet\" href = \"assets/prism.css\" />\n                <pre><code class=\"language-javascript\" >\n                    console.log(\'Test\');\n</code></pre >\n    <script src=\"assets/prism.css\" > </script>\n```\n![alt](http://cucr.oss-cn-beijing.aliyuncs.com/img/QQ%E5%9B%BE%E7%89%8720190425084322.jpg)\n\n1. 有序列表\n2. 有序列表\n\n    \n ![alt](http://cucr.oss-cn-beijing.aliyuncs.com/img/QQ%E5%9B%BE%E7%89%8720190425084322.jpg)\n\n* 无序列表1\n* 无序列表2\n    \n    [链接](http://baidu.com \"链接提示\")\n    \n    ![图片](http://placehold.it/140x140 \"图片提示\")\n    \n    分隔线\n    \n    ---\n    \n    ## 表格\n\n\ncolumn1 | column2 | column3\n    ------- | ------- | -------\n    column1 | column2 | column3\n    column1 | column2 | column3\n    column1 | column2 | column3',NULL,NULL,'',0,'',NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,NULL),(17,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'文章标签',0,NULL,NULL,NULL),(18,'1231',NULL,1,'2019-05-30 15:35:04','2019-05-30 15:35:04',NULL,'<p>文章内容dasd</p>',NULL,NULL,NULL,NULL,NULL,NULL,'<p>article content </p>',1,',',0,NULL,NULL,NULL),(19,'44444',NULL,1,'2019-05-30 15:35:50','2019-05-30 15:35:50',NULL,'<p>文章内容dasd</p>',NULL,NULL,NULL,NULL,NULL,NULL,'<p>article content </p>',1,',',0,NULL,NULL,NULL),(20,'555555555',NULL,1,'2019-05-30 15:36:19','2019-05-30 15:36:19',NULL,'<p>文章内容</p>',NULL,NULL,NULL,NULL,NULL,NULL,'<p>article content </p>',1,',',0,NULL,NULL,NULL),(21,'das',11,1,'2019-06-06 10:39:59','2019-06-06 10:39:59',NULL,'<p>dasd</p>',NULL,NULL,NULL,NULL,NULL,NULL,'<p>dasddsad</p>',1,'热门,据点分类',0,NULL,NULL,NULL);
/*!40000 ALTER TABLE `article` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `banner`
--

DROP TABLE IF EXISTS `banner`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `banner` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `imgUrl` varchar(700) DEFAULT NULL,
  `orderNo` int(11) DEFAULT NULL COMMENT '排序',
  `createTime` datetime DEFAULT NULL,
  `status` int(11) DEFAULT NULL COMMENT '状态',
  `title1` varchar(450) DEFAULT NULL,
  `title2` varchar(450) DEFAULT NULL,
  `title3` varchar(450) DEFAULT NULL,
  `title4` varchar(450) DEFAULT NULL,
  `labels` varchar(450) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='预览图管理';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `banner`
--

LOCK TABLES `banner` WRITE;
/*!40000 ALTER TABLE `banner` DISABLE KEYS */;
INSERT INTO `banner` VALUES (3,'',123,'2019-06-06 15:34:26',0,'123','234','435','',NULL),(4,'http://image.fubang.airuanjian.vip/1559835395.73406QQ图片20190603161917.jpg',2,'2019-06-06 15:37:11',0,'1','2','3','4',NULL),(5,'',0,'2019-06-06 16:01:36',0,'','','','',NULL);
/*!40000 ALTER TABLE `banner` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `company`
--

DROP TABLE IF EXISTS `company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `company` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `status` int(11) DEFAULT '0',
  `lat` decimal(16,10) DEFAULT NULL,
  `lng` decimal(16,10) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `company`
--

LOCK TABLES `company` WRITE;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
INSERT INTO `company` VALUES (1,'富邦有限公司','2019-05-14 16:00:00',0,30.5843550000,114.2985720000),(3,'ddd',NULL,0,NULL,NULL);
/*!40000 ALTER TABLE `company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `leave`
--

DROP TABLE IF EXISTS `leave`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `leave` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(450) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `startTime` datetime DEFAULT NULL,
  `returnTime` datetime DEFAULT NULL,
  `userId` int(11) DEFAULT NULL,
  `remark` varchar(4500) DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `companyId` int(11) DEFAULT NULL,
  `orgId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `leave`
--

LOCK TABLES `leave` WRITE;
/*!40000 ALTER TABLE `leave` DISABLE KEYS */;
INSERT INTO `leave` VALUES (6,'月影','2019-05-18 18:48:27','2019-05-02 10:48:24','2019-06-07 10:48:24',1,'3123',2,1,12),(7,'月影','2019-05-18 18:48:29','2019-05-02 10:48:24','2019-06-07 10:48:24',1,'31235435',2,1,12),(8,'月影','2019-05-18 19:08:14','2019-05-15 11:08:04','2019-06-12 11:08:04',1,'肚子不舒服',2,1,12),(9,'月影','2019-05-18 19:09:04','2019-05-02 11:08:55','2019-06-12 11:08:55',1,'想玩几天',2,1,12),(10,'月影','2019-05-18 19:11:26','2019-05-23 11:11:23','2019-06-11 11:11:23',1,'dsad',2,1,12);
/*!40000 ALTER TABLE `leave` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `material`
--

DROP TABLE IF EXISTS `material`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `material` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `url` varchar(200) DEFAULT NULL,
  `type` int(11) DEFAULT NULL COMMENT '1 图片 2.视频',
  `ext` varchar(45) DEFAULT NULL COMMENT '文件扩展名',
  `size` int(11) DEFAULT NULL,
  `createAt` datetime DEFAULT NULL,
  `status` int(11) DEFAULT NULL COMMENT '素材状态',
  `userId` int(11) DEFAULT NULL COMMENT '上传用户',
  `ossId` int(11) DEFAULT NULL,
  `materialcol` varchar(45) DEFAULT NULL,
  `bannerUrl` varchar(64) DEFAULT NULL,
  `filename` varchar(450) DEFAULT NULL COMMENT '源文件名',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='素材库';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `material`
--

LOCK TABLES `material` WRITE;
/*!40000 ALTER TABLE `material` DISABLE KEYS */;
INSERT INTO `material` VALUES (2,'','http://image.fubang.airuanjian.vip/1559241452.71422bannerBg.jpg',1,'jpg',60061,'2019-05-30 18:37:33',0,NULL,NULL,NULL,NULL,'1559241452.71422bannerBg.jpg'),(3,'indexImager.png','http://image.fubang.airuanjian.vip/1559242678.32861indexImager.png',1,'png',1925095,'2019-05-30 18:57:58',0,NULL,NULL,NULL,NULL,'1559242678.32861indexImager.png'),(4,'1.png','http://image.fubang.airuanjian.vip/1559296997.974581.png',1,'png',2838,'2019-05-31 10:03:18',0,NULL,NULL,NULL,NULL,'1559296997.974581.png'),(6,'dsad','http://image.fubang.airuanjian.vip/1559820577.86377flower.mp4',2,'mp4',1128375,'2019-06-06 11:29:38',0,NULL,NULL,NULL,NULL,'1559820577.86377flower.mp4'),(7,'视频','http://image.fubang.airuanjian.vip/1559821305.61017flower.mp4',2,'mp4',1128375,'2019-06-06 11:41:46',0,NULL,NULL,NULL,NULL,'1559821305.61017flower.mp4'),(8,'QQ图片20190603161917.jpg','http://image.fubang.airuanjian.vip/1559833756.03066QQ图片20190603161917.jpg',1,'jpg',48746,'2019-06-06 15:09:16',0,NULL,NULL,NULL,NULL,'1559833756.03066QQ图片20190603161917.jpg'),(9,'QQ图片20190603161917.jpg','http://image.fubang.airuanjian.vip/1559833767.2522QQ图片20190603161917.jpg',1,'jpg',48746,'2019-06-06 15:09:27',0,NULL,NULL,NULL,NULL,'1559833767.2522QQ图片20190603161917.jpg'),(10,'QQ图片20190603161917.jpg','http://image.fubang.airuanjian.vip/1559833846.50786QQ图片20190603161917.jpg',1,'jpg',48746,'2019-06-06 15:10:47',0,NULL,NULL,NULL,NULL,'1559833846.50786QQ图片20190603161917.jpg'),(11,'QQ图片20190603161917.jpg','http://image.fubang.airuanjian.vip/1559833895.35018QQ图片20190603161917.jpg',1,'jpg',48746,'2019-06-06 15:11:35',0,NULL,NULL,NULL,NULL,'1559833895.35018QQ图片20190603161917.jpg'),(12,'point.png','http://image.fubang.airuanjian.vip/1559834880.05622point.png',1,'png',73114,'2019-06-06 15:28:00',0,NULL,NULL,NULL,NULL,'1559834880.05622point.png'),(13,'QQ图片20190603161917.jpg','http://image.fubang.airuanjian.vip/1559835297.5117QQ图片20190603161917.jpg',1,'jpg',48746,'2019-06-06 15:34:58',0,NULL,NULL,NULL,NULL,'1559835297.5117QQ图片20190603161917.jpg'),(14,'QQ图片20190603161917.jpg','http://image.fubang.airuanjian.vip/1559835339.28736QQ图片20190603161917.jpg',1,'jpg',48746,'2019-06-06 15:35:39',0,NULL,NULL,NULL,NULL,'1559835339.28736QQ图片20190603161917.jpg'),(15,'QQ图片20190603161917.jpg','http://image.fubang.airuanjian.vip/1559835372.21311QQ图片20190603161917.jpg',1,'jpg',48746,'2019-06-06 15:36:12',0,NULL,NULL,NULL,NULL,'1559835372.21311QQ图片20190603161917.jpg'),(16,'QQ图片20190603161917.jpg','http://image.fubang.airuanjian.vip/1559835395.73406QQ图片20190603161917.jpg',1,'jpg',48746,'2019-06-06 15:36:36',0,NULL,NULL,NULL,NULL,'1559835395.73406QQ图片20190603161917.jpg');
/*!40000 ALTER TABLE `material` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu`
--

DROP TABLE IF EXISTS `menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `menu` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `parentId` int(11) DEFAULT NULL,
  `text` varchar(45) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `link` varchar(450) DEFAULT NULL,
  `menuIds` varchar(4500) DEFAULT NULL,
  `code` varchar(45) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `path` varchar(4500) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='菜单';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu`
--

LOCK TABLES `menu` WRITE;
/*!40000 ALTER TABLE `menu` DISABLE KEYS */;
INSERT INTO `menu` VALUES (10,0,'系统','2019-05-13 08:59:57','',NULL,NULL,0,''),(11,10,'角色权限','2019-05-13 09:05:58','',NULL,NULL,1,',10,'),(12,10,'课程','2019-05-13 09:06:56','',NULL,NULL,1,',10,'),(13,10,'菜单','2019-05-13 09:07:23','',NULL,NULL,1,',10,'),(20,11,'公司','2019-05-13 15:41:35','/rbac/company',NULL,NULL,2,',10,,11,'),(21,11,'用户','2019-05-13 16:07:43','/rbac/user',NULL,NULL,2,',10,,11,'),(22,11,'组织','2019-05-13 16:08:12','/rbac/org',NULL,NULL,2,',10,,11,'),(23,11,'菜单','2019-05-13 16:08:20','/rbac/menu',NULL,NULL,2,',10,,11,'),(24,11,'角色','2019-05-13 16:08:34','/rbac/role',NULL,NULL,2,',10,,11,'),(25,12,'大纲','2019-05-13 16:09:53','/study/subject',NULL,NULL,2,',10,,12,');
/*!40000 ALTER TABLE `menu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `org`
--

DROP TABLE IF EXISTS `org`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `org` (
  `orgId` int(11) NOT NULL AUTO_INCREMENT,
  `orgName` varchar(45) DEFAULT NULL,
  `parentId` int(11) DEFAULT '0',
  `createTime` datetime DEFAULT NULL,
  `companyId` int(11) DEFAULT NULL,
  `path` varchar(4500) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  PRIMARY KEY (`orgId`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `org`
--

LOCK TABLES `org` WRITE;
/*!40000 ALTER TABLE `org` DISABLE KEYS */;
INSERT INTO `org` VALUES (12,'顶级机构',0,'2019-05-11 15:34:26',1,NULL,0),(16,'二级机构',12,'2019-05-11 15:38:46',1,',12',1),(17,'三级机构',16,'2019-05-11 15:38:58',1,',12,16',2),(24,'asdad',0,'2019-05-12 16:39:47',NULL,NULL,0),(25,'sddd',0,'2019-05-12 16:41:15',NULL,NULL,0),(26,'dsada',0,'2019-05-12 16:42:27',NULL,NULL,0),(27,'dasfa',0,'2019-05-12 16:42:46',NULL,NULL,0);
/*!40000 ALTER TABLE `org` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `point`
--

DROP TABLE IF EXISTS `point`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `point` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `offsetX` int(11) DEFAULT NULL,
  `offsetY` int(11) DEFAULT NULL,
  `publishAt` datetime DEFAULT NULL,
  `labels` varchar(450) DEFAULT NULL,
  `createAt` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `point`
--

LOCK TABLES `point` WRITE;
/*!40000 ALTER TABLE `point` DISABLE KEYS */;
INSERT INTO `point` VALUES (2,'中国-武汉',610,146,'2019-06-05 09:01:08',',大数据农业,科学农业','2019-06-05 17:01:26');
/*!40000 ALTER TABLE `point` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `role` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `roleName` varchar(45) DEFAULT NULL,
  `menuIds` varchar(4500) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `orgId` int(11) DEFAULT NULL,
  `companyId` int(11) DEFAULT NULL,
  `roleType` int(11) DEFAULT '2',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (10,'管理员','11,20,21,22,23,24,11,20,21,22,23,24','2019-05-13 10:40:50',12,1,NULL),(11,'学生','12,10','2019-05-13 17:00:35',12,1,NULL);
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `routine`
--

DROP TABLE IF EXISTS `routine`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `routine` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `subjectId` int(11) DEFAULT NULL,
  `datetime` datetime DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `userId` int(11) DEFAULT NULL,
  `companyId` int(11) DEFAULT NULL,
  `orgId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='学习计划';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `routine`
--

LOCK TABLES `routine` WRITE;
/*!40000 ALTER TABLE `routine` DISABLE KEYS */;
INSERT INTO `routine` VALUES (1,5,'2019-05-08 04:37:30','2019-05-14 12:37:31',0,1,1,12),(2,5,'2019-05-08 04:37:30','2019-05-14 12:38:12',0,1,1,12),(3,5,'2019-05-15 04:39:44','2019-05-14 12:39:46',0,1,1,12),(4,5,'2019-05-15 04:39:44','2019-05-14 13:34:32',0,1,1,12),(5,5,'2019-06-01 04:39:44','2019-05-14 13:34:48',0,1,1,12),(6,5,'2019-06-01 04:39:44','2019-05-14 13:52:30',0,1,1,12),(7,5,'2019-05-14 06:13:30','2019-05-14 14:13:34',1,1,1,12),(8,8,'2019-05-18 14:56:09','2019-05-18 14:56:09',0,1,1,12);
/*!40000 ALTER TABLE `routine` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subject`
--

DROP TABLE IF EXISTS `subject`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `subject` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `companyId` int(11) DEFAULT NULL,
  `name` varchar(400) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `summary` varchar(4500) DEFAULT NULL,
  `startTime` datetime DEFAULT NULL,
  `endTime` datetime DEFAULT NULL,
  `fullDates` varchar(4500) DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='课程';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subject`
--

LOCK TABLES `subject` WRITE;
/*!40000 ALTER TABLE `subject` DISABLE KEYS */;
INSERT INTO `subject` VALUES (5,1,'生物学','2019-05-13 14:44:51',0,NULL,'2019-05-22 06:44:47','2019-05-15 06:44:49',NULL),(8,1,'天文学','2019-05-18 12:43:28',0,NULL,'2019-05-01 04:43:10','2019-05-31 04:43:12','2019-05-17,2019-05-18,2019-05-10,2019-05-01,2019-05-02,2019-05-03,2019-05-07,2019-05-08,2019-05-09,2019-05-13,2019-05-14,2019-05-15,2019-05-16,2019-05-24,2019-05-23,2019-05-22,2019-05-21,2019-05-20,2019-05-27,2019-05-28,2019-05-29,2019-05-30,2019-05-31');
/*!40000 ALTER TABLE `subject` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_dicationary`
--

DROP TABLE IF EXISTS `sys_dicationary`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sys_dicationary` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `parentId` int(11) DEFAULT NULL,
  `code` varchar(45) DEFAULT NULL COMMENT '速查代码',
  `level` int(11) DEFAULT NULL,
  `path` varchar(450) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `isDelete` tinyint(4) DEFAULT '0',
  `value` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='字典';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_dicationary`
--

LOCK TABLES `sys_dicationary` WRITE;
/*!40000 ALTER TABLE `sys_dicationary` DISABLE KEYS */;
INSERT INTO `sys_dicationary` VALUES (11,'文章标签',0,'article_tag',0,'','2019-05-30 11:38:02',0,NULL),(12,'热门',11,'hot',1,NULL,'2019-05-30 00:00:00',0,'hot'),(13,'据点分类',11,'point_labels',2,'','2019-05-30 11:44:27',0,'据点分类'),(14,'1111',11,'111',2,'','2019-05-30 11:47:23',0,NULL),(15,'eeqa',12,'ewqeqw',3,'','2019-05-30 11:49:44',0,NULL),(16,'444',15,'444',4,',15','2019-05-30 11:56:22',0,NULL),(17,'大数据农业',13,'大数据农业',3,',13','2019-06-05 15:10:23',0,NULL),(18,'科学农业',13,'科学农业',3,',13','2019-06-05 15:10:34',0,NULL),(19,'土壤检测',13,'土壤检测',3,',13','2019-06-05 15:11:18',0,NULL);
/*!40000 ALTER TABLE `sys_dicationary` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nickname` varchar(45) DEFAULT NULL,
  `orgId` int(11) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `username` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `roleType` int(11) DEFAULT NULL COMMENT '角色类型 0 游客 1 普通用户,2管理员',
  `wxUserId` int(11) DEFAULT NULL,
  `headimg` varchar(450) DEFAULT NULL,
  `companyId` int(11) DEFAULT NULL,
  `roleIds` varchar(4500) DEFAULT NULL,
  `subjectIds` varchar(450) DEFAULT NULL,
  `status` int(11) DEFAULT NULL COMMENT '0有效1离校',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'月影',12,'2018-02-04 00:00:00','100001','1234',0,1,'http://cucr.oss-cn-beijing.aliyuncs.com/img/QQ%E5%9B%BE%E7%89%8720190425084322.jpg',1,',10,',',5,8',1),(11,'kkk',12,'2019-05-13 12:02:01','student0001','444',NULL,NULL,NULL,1,',10,',NULL,NULL),(13,'ciyue',12,'2019-05-19 20:16:25','111111','111111',2,NULL,NULL,1,'',NULL,0),(14,'admin',12,'2019-05-19 20:25:01','11211112','111111',2,NULL,NULL,1,'',NULL,0),(15,'123456',12,'2019-05-19 20:25:49','1111111','1111111',2,NULL,NULL,1,'',NULL,0),(16,'dfas',12,'2019-05-19 20:27:53','1111115','1111115',2,NULL,NULL,1,'',NULL,0),(17,'1234567',12,'2019-05-19 20:28:40','user001','1111115',2,NULL,NULL,1,'',NULL,0),(18,'123456',12,'2019-05-20 18:00:59','123456','qwebnm123456',2,NULL,NULL,1,'',NULL,0),(19,'123456',12,'2019-05-20 18:01:00','123456','qwebnm123456',2,NULL,NULL,1,'',NULL,0);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `website_menu`
--

DROP TABLE IF EXISTS `website_menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `website_menu` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `text` varchar(45) DEFAULT NULL,
  `i18` varchar(45) DEFAULT NULL,
  `link` varchar(45) DEFAULT NULL,
  `createAt` datetime DEFAULT NULL,
  `lastModifyAt` datetime DEFAULT NULL,
  `parentId` int(11) DEFAULT NULL,
  `code` varchar(45) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `path` varchar(450) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='网站菜单';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `website_menu`
--

LOCK TABLES `website_menu` WRITE;
/*!40000 ALTER TABLE `website_menu` DISABLE KEYS */;
INSERT INTO `website_menu` VALUES (2,'首页',NULL,'/','2019-05-31 10:02:53',NULL,0,NULL,0,''),(3,'产品',NULL,'/products','2019-05-31 10:03:04',NULL,2,NULL,0,'');
/*!40000 ALTER TABLE `website_menu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wx_user`
--

DROP TABLE IF EXISTS `wx_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `wx_user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nicknamee` varchar(45) DEFAULT NULL,
  `openId` varchar(45) DEFAULT NULL,
  `headimg` varchar(450) DEFAULT NULL,
  `createAt` datetime DEFAULT NULL,
  `lastLoginAt` datetime DEFAULT NULL,
  `province` varchar(45) DEFAULT NULL,
  `companyId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='微信用户';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wx_user`
--

LOCK TABLES `wx_user` WRITE;
/*!40000 ALTER TABLE `wx_user` DISABLE KEYS */;
INSERT INTO `wx_user` VALUES (1,'月影','123','http://cucr.oss-cn-beijing.aliyuncs.com/img/QQ%E5%9B%BE%E7%89%8720190425084322.jpg',NULL,NULL,'湖北省',NULL);
/*!40000 ALTER TABLE `wx_user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-06-06 16:43:08
