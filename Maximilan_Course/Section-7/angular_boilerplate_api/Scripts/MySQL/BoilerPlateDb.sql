use boilerplatedb;

-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: boilerplatedb
-- ------------------------------------------------------
-- Server version	8.0.33

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `menu`
--

DROP TABLE IF EXISTS `menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menu` (
  `id` int NOT NULL AUTO_INCREMENT,
  `parentId` int NOT NULL DEFAULT '0',
  `label` varchar(250) NOT NULL,
  `menu_link` varchar(250) DEFAULT NULL,
  `role_id` varchar(250) DEFAULT NULL,
  `module` int DEFAULT NULL,
  `sequence` tinyint DEFAULT NULL COMMENT 'Manage sequence of menu in admin',
  `bootstrap_class` varchar(255) DEFAULT NULL,
  `icon_class` varchar(255) DEFAULT NULL,
  `status` tinyint(1) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu`
--

LOCK TABLES `menu` WRITE;
/*!40000 ALTER TABLE `menu` DISABLE KEYS */;
INSERT INTO `menu` VALUES (1,0,'Dashboard','dashboard','1',0,1,'home-outline',NULL,1,'2020-10-08 11:42:23',NULL,NULL),
(2,0,'Roles/Permissions','roles','1',1,2,'settings-2-outline',NULL,1,'2020-10-08 12:08:11',NULL,NULL),
(3,0,'Users','users','1',4,2,'people-outline',NULL,1,'2020-10-08 12:09:55',NULL,NULL),
(4, 0, 'Product', 'product', '1', 5, 2, 'gift-outline',NULL, 1, '2020-10-08 17:39:55', NULL, NULL),
(5, 0, 'Email Template', 'email-template', '1', 6, 2, 'email-outline',NULL, 1, '2020-10-08 17:39:55', NULL, NULL),
(6, 0, 'CMS', 'cms', '1', 7, 2, 'file-text-outline',NULL, 1, '2020-10-08 17:39:55', NULL, NULL),
(7,0,'Settings','settings','1',3,10,'settings-2-outline',NULL,1,'2020-10-08 12:09:55',NULL,NULL),
(8,7,'General Settings','settings','1',3,11,'settings-2-outline',NULL,1,'2020-10-08 12:09:55',NULL,NULL);
/*!40000 ALTER TABLE `menu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `module`
--

DROP TABLE IF EXISTS `module`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `module` (
  `id` int NOT NULL AUTO_INCREMENT,
  `label` varchar(250) NOT NULL,
  `name` varchar(250) NOT NULL,
  `status` tinyint(1) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `module`
--

LOCK TABLES `module` WRITE;
/*!40000 ALTER TABLE `module` DISABLE KEYS */;
INSERT INTO `module` VALUES (1,'ROLE','role',1,'2020-10-09 00:32:19',NULL,NULL),
(2,'PERMISSION','permission',1,'2020-10-09 00:32:19',NULL,NULL),
(3,'SETTINGS','settings',1,'2020-10-09 00:36:12',NULL,NULL),
(4,'USERS','users',1,'2020-10-09 00:36:44',NULL,NULL),
(5,'PRODUCT','products',1,'2020-10-09 00:36:44',NULL,NULL),
(6,'EMAIL TEMPLATE','email template',1,'2020-10-09 00:36:44',NULL,NULL),
(7,'CMS','cms',1,'2020-10-09 00:36:44',NULL,NULL);
/*!40000 ALTER TABLE `module` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permission`
--

DROP TABLE IF EXISTS `permission`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `permission` (
  `id` int NOT NULL AUTO_INCREMENT,
  `label` varchar(250) NOT NULL,
  `name` varchar(250) NOT NULL,
  `description` varchar(250) DEFAULT NULL,
  `module` int NOT NULL,
  `status` tinyint(1) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permission`
--

LOCK TABLES `permission` WRITE;
/*!40000 ALTER TABLE `permission` DISABLE KEYS */;
INSERT INTO `permission` VALUES (1,'Update','can_update','Update Permission for Role',1,1,'2020-10-09 00:48:03',NULL,NULL),
(2,'View','can_view','View Permission for Role',1,1,'2023-07-10 06:36:06',NULL,NULL),
(3,'Create','can_create','Create Permission for Role',1,1,'2020-10-09 00:48:03',NULL,NULL),
(4,'Delete','can_delete','Delete Permission for Role',1,1,'2020-10-09 00:48:03',NULL,NULL),
(5,'Update','can_update','Update Permission for Settings',3,1,'2020-10-09 00:48:03',NULL,NULL),
(6,'View','can_view','View Permission for Settings',3,1,'2020-10-09 00:48:03',NULL,NULL),
(7,'Create','can_create','Create Permission for Settings',3,1,'2020-10-09 00:48:03',NULL,NULL),
(8,'Delete','can_delete','Delete Permission for Settings',3,1,'2020-10-09 00:48:03',NULL,NULL),
(9,'Update','can_update','Update Permission for Users',4,1,'2020-10-09 00:48:03',NULL,NULL),
(10,'View','can_view','View Permission for Users',4,1,'2020-10-09 00:48:03',NULL,NULL),
(11,'Create','can_create','Create Permission for Users',4,1,'2020-10-09 00:48:03',NULL,NULL),
(12,'Delete','can_delete','Delete Permission for Users',4,1,'2020-10-09 00:48:03',NULL,NULL),
(13,'Update','can_update','Update Permission for Permission',2,1,'2017-12-12 20:00:00','2017-12-12 20:00:00',NULL),
(14,'View','can_view','View Permission for Permission',2,1,'2017-12-12 20:00:00','2017-12-12 20:00:00',NULL),
(15,'Create','can_create','Create Permission for Permission',2,1,'2017-12-13 20:00:00','2017-12-13 20:00:00',NULL),
(16,'Delete','can_delete','Delete Permission for Permission',2,1,'2017-12-12 20:00:00','2017-12-12 20:00:00',NULL),
(17,'Update','can_update','Update Permission for Product',5,1,'2017-12-12 20:00:00','2017-12-12 20:00:00',NULL),
(18,'View','can_view','View Permission for Product',5,1,'2017-12-12 20:00:00','2017-12-12 20:00:00',NULL),
(19,'Create','can_create','Create Permission for Product',5,1,'2017-12-13 20:00:00','2017-12-13 20:00:00',NULL),
(20,'Delete','can_delete','Delete Permission for Product',5,1,'2017-12-12 20:00:00','2017-12-12 20:00:00',NULL),
(21,'Update','can_update','Update Permission for Email Template',6,1,'2017-12-12 20:00:00','2017-12-12 20:00:00',NULL),
(22,'View','can_view','View Permission for Email Template',6,1,'2017-12-12 20:00:00','2017-12-12 20:00:00',NULL),
(23,'Create','can_create','Create Permission for Email Template',6,1,'2017-12-13 20:00:00','2017-12-13 20:00:00',NULL),
(24,'Delete','can_delete','Delete Permission for Email Template',6,1,'2017-12-12 20:00:00','2017-12-12 20:00:00',NULL),
(25,'Update','can_update','Update Permission for CMS',7,1,'2017-12-12 20:00:00','2017-12-12 20:00:00',NULL),
(26,'View','can_view','View Permission for CMS',7,1,'2017-12-12 20:00:00','2017-12-12 20:00:00',NULL),
(27,'Create','can_create','Create Permission for CMS',7,1,'2017-12-13 20:00:00','2017-12-13 20:00:00',NULL),
(28,'Delete','can_delete','Delete Permission for CMS',7,1,'2017-12-12 20:00:00','2017-12-12 20:00:00',NULL);
/*!40000 ALTER TABLE `permission` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `title` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  `status` tinyint DEFAULT '1' COMMENT '0=Inactive, 1=Active',
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'Super Admin',1,'2023-07-10 04:56:31',NULL,NULL);
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role_permission`
--

DROP TABLE IF EXISTS `role_permission`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role_permission` (
  `id` int NOT NULL AUTO_INCREMENT,
  `role_id` int NOT NULL,
  `permission_id` int NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8mb3 ROW_FORMAT=REDUNDANT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role_permission`
--

LOCK TABLES `role_permission` WRITE;
/*!40000 ALTER TABLE `role_permission` DISABLE KEYS */;
INSERT INTO `role_permission` VALUES (1,1,3,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(2,1,1,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(3,1,2,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(4,1,4,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(5,1,7,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(6,1,5,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(7,1,6,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(8,1,8,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(9,1,11,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(10,1,9,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(11,1,10,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(12,1,12,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(13,1,13,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(14,1,14,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(15,1,15,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(16,1,16,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(17,1,17,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(18,1,18,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(19,1,19,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(20,1,20,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(21,1,21,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(22,1,22,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(23,1,23,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(24,1,24,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(25,1,25,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(26,1,26,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(27,1,27,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL),
(28,1,28,'2022-02-16 14:39:49','2022-02-16 14:39:49',NULL);
/*!40000 ALTER TABLE `role_permission` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_roles`
--

DROP TABLE IF EXISTS `user_roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_roles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `role_id` int NOT NULL,
  `status` tinyint(1) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_roles`
--

LOCK TABLES `user_roles` WRITE;
/*!40000 ALTER TABLE `user_roles` DISABLE KEYS */;
INSERT INTO `user_roles` VALUES (1,1,1,1,'2020-11-26 11:36:10','2020-11-26 11:36:10',NULL);
/*!40000 ALTER TABLE `user_roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `first_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `last_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `contact_number` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `email_verified_at` timestamp NULL DEFAULT NULL,
  `password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `remember_token` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_by` int DEFAULT NULL,
  `updated_by` int DEFAULT NULL,
  `update_password_date` timestamp NULL DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
  `avatar` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `provider` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `provider_id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `access_token` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `iama` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `journeyAgainst` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `state` int DEFAULT NULL COMMENT 'Reference to state table',
  `city` int DEFAULT NULL COMMENT 'Reference to city table',
  `patientAge` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `gender` int DEFAULT NULL COMMENT 'reference to master table',
  `status` int DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE KEY `users_email_unique` (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Super','Admin','9979214252','admin@demo.com','2021-06-24 01:30:00','Admin@111','UetN5y2I2irqk1xOw5tWaecuNrVaxavHjkoFZlR40pKhVMVIbfV4OkULVgdg',NULL,NULL,'2022-11-22 01:32:16','2021-06-24 01:30:00','2023-01-03 02:37:47',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;


CREATE TABLE `emailtemplate` (
  `id` int UNSIGNED NOT NULL  AUTO_INCREMENT,
  `template_title` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  `subject` text CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci,
  `content` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `file_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `creative_format_id` int DEFAULT NULL,
  `status` tinyint NOT NULL DEFAULT '1' COMMENT '0-Active 1-Active',
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
   PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `cms` (
  `id` int NOT NULL  AUTO_INCREMENT,
  `page_name` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci DEFAULT NULL,
  `slug` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci DEFAULT NULL,
  `description` text CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci,
  `content` text CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci,
  `meta_title` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci DEFAULT NULL,
  `meta_keyword` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci DEFAULT NULL,
  `meta_description` text CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci,
  `status` tinyint DEFAULT '1' COMMENT '0 - Inactive, 1 - Active',
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
   PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;

CREATE TABLE `products` (
  `id` int NOT NULL  AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `status` tinyint NOT NULL DEFAULT '1',
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
   PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

INSERT INTO Products (id, name, status, created_at, updated_at, deleted_at)
VALUES
    (1, 'ss', 1, '2023-07-03 06:11:43', '2023-07-03 06:11:43', NULL),
    (2, 'test12', 1, '2023-01-03 18:45:10', '2023-07-03 05:47:11', NULL),
    (3, 'sample product11', 1, '2022-11-18 12:04:21', '2022-12-20 15:19:17', NULL),
    (4, 'Sample Product 4', 1, '2022-02-18 22:14:42', '2022-11-15 16:17:32', NULL),
    (5, 'Sample Product 2', 1, '2022-02-18 14:11:29', '2022-02-18 14:11:29', NULL),
    (6, 'Sample Product 1', 1, '2022-02-18 13:02:50', '2022-02-18 22:14:28', NULL);

CREATE TABLE `settings` (
  `id` int NOT NULL  AUTO_INCREMENT,
  `label` varchar(255) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `value` varchar(500) DEFAULT NULL,
  `description` longtext,
  `type` tinyint(1) NOT NULL COMMENT '1 = Site Settings',
  `field_type` varchar(50) NOT NULL DEFAULT 'input',
  `field_type_value` varchar(50) NOT NULL DEFAULT 'text',
  `seq_no` tinyint DEFAULT NULL,
  `created_by` int DEFAULT NULL COMMENT 'Reference of user table	',
  `updated_by` int DEFAULT NULL COMMENT 'Reference of user table',
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT NULL,
   PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

INSERT INTO Settings (id, label, name, value, description, type, field_type, field_type_value, seq_no, created_by, updated_by, created_at, updated_at, deleted_at)
VALUES
   (1, 'Site Email', 'Email', 'info@ut.com', NULL, 1, 'input', 'email', 1, 1, 1, '2017-09-14 09:00:00', '2022-02-18 22:13:40', NULL),
   (2, 'From Email', 'from_email', 'info@ut.coms', NULL, 1, 'input', 'email', 2, 1, 1, '2017-10-03 14:30:00', '2023-01-03 07:36:46', NULL),
   (3, 'Allowed IPs', 'allowed_ips', NULL, NULL, 1, 'textarea', 'textarea', 3, 1, 1, '2017-09-14 14:30:00', '2020-10-23 11:24:06', NULL),
   (4, 'Host', 'host', 'smtp.gmail.com', NULL, 2, 'input', 'text', 1, 1, 1, '2017-09-14 21:30:00', '2020-10-23 11:24:44', NULL),
   (5, 'Username', 'username', 'fidam27353@gmail.com', NULL, 2, 'input', 'text', 2, 1, 1, '2017-09-15 03:00:00', '2018-01-25 08:38:30', NULL),
   (6, 'Password', 'password', 'abcd@1234', NULL, 2, 'input', 'text', 3, 1, 1, '2017-12-25 01:30:00', '2018-04-24 15:23:13', NULL),
   (7, 'Port', 'port', '587', NULL, 2, 'input', 'number', 4, 1, 1, '2017-10-04 03:00:00', '2020-10-14 13:08:08', NULL),
   (8, NULL, NULL, NULL, '<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n    <tr>\r\n        <td align=\"center\" valign=\"top\" bgcolor=\"#f5821f\" style=\"padding-top:5px; padding-bottom:5px;\">\r\n            <table width=\"92%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n                <tr>\r\n                    <td width=\"70\" align=\"left\" valign=\"top\" style=\"padding-bottom: 10px;\" ><img src=\"u_logo\" width=\"250px\" height=\"70px\" alt=\"Logo\" /></td>\r\n                    <td align=\"left\" valign=\"top\">\r\n                        <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n                            <tr>\r\n                                <td align=\"right\" style=\"font-family:Arial, Verdana; font-size:12px; color:#FFFFFF; padding-top:22px;\"><b>u_sendOn</b></td>\r\n                            </tr>\r\n                        </table>\r\n                    </td>\r\n                </tr>\r\n            </table>\r\n        </td>\r\n    </tr>\r\n\r\n    <tr>\r\n        <td align=\"center\" valign=\"top\" style=\"padding-top:20px; padding-bottom:20px;\">\r\n            <table width=\"92%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">\r\n                <tr>\r\n                    <td align=\"left\" valign=\"top\" style=\"font-family:Arial, Verdana; font-size:13px; color:#666666; line-height:15px; padding-bottom:10px;\">\r\n                        Hello u_name,<br /><br/>\r\n                        Forgotten your password? Don&#39;t worry, Below is your new password.<br />\r\n                        <br />\r\n                        <b>New Password:</b> u_password <br />\r\n                        <br />\r\n                        If you have any question or encounter any problem while login, please contact our support team.<br />\r\n                        <br />\r\n                        <br />\r\n                        <em>Thanks</em>,<br />\r\n                        <b>AI Emails Team</b>\r\n                    </td>\r\n                </tr>\r\n            </table>\r\n        </td>\r\n    </tr>\r\n\r\n    <tr align=\"center\" valign=\"top\">\r\n        <td style=\"font-family:Arial, Verdana; font-size:13px; color:#666666; line-height:15px;  border-top:1px solid #CCC; padding-top:20px; padding-bottom:20px;\">© current_year All Rights Reserved</td>\r\n    </tr>\r\n</table>', 5, 'input', 'text', NULL, NULL, NULL, NULL, NULL, NULL),
   (9, 'New Credentials', 'New Credentials', 'New Credentials', '<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n    <tr>\r\n        <td align=\"center\" valign=\"top\" bgcolor=\"#f5821f\" style=\"padding-top:5px; padding-bottom:5px;\">\r\n            <table width=\"92%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n                <tr>\r\n                    <td width=\"70\" align=\"left\" valign=\"top\" style=\"padding-bottom: 10px;\" ><img src=\"u_logo\" width=\"250px\" height=\"70px\" alt=\"Logo\" /></td>\r\n                    <td align=\"left\" valign=\"top\">\r\n                        <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n                            <tr>\r\n                                <td align=\"right\" style=\"font-family:Arial, Verdana; font-size:12px; color:#FFFFFF; padding-top:22px;\"><b>u_sendOn</b></td>\r\n                            </tr>\r\n                        </table>\r\n                    </td>\r\n                </tr>\r\n            </table>\r\n        </td>\r\n    </tr>\r\n\r\n    <tr>\r\n        <td align=\"center\" valign=\"top\" style=\"padding-top:20px; padding-bottom:20px;\">\r\n            <table width=\"92%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">\r\n                <tr>\r\n                    <td align=\"left\" valign=\"top\" style=\"font-family:Arial, Verdana; font-size:13px; color:#666666; line-height:15px; padding-bottom:10px;\">\r\n                        Hello u_name,<br /><br/>\r\n                        Below is your user credentials to login into the website.<br />\r\n                        <br />\r\n                        <b>Site Login URL:</b> <a href=\"u_url\">u_url</a><br />\r\n						<br />\r\n                        <b>Username:</b> u_username <br />\r\n                        <br />\r\n						<b>Password:</b> u_password <br />\r\n                        <br />\r\n                        If you have any question or encounter any problem while login, please contact our support team.<br />\r\n                        <br />\r\n                        <br />\r\n                        <em>Thanks</em>,<br />\r\n                        <b>AI Emails Team</b>\r\n                    </td>\r\n                </tr>\r\n            </table>\r\n        </td>\r\n    </tr>\r\n\r\n    <tr align=\"center\" valign=\"top\">\r\n        <td style=\"font-family:Arial, Verdana; font-size:13px; color:#666666; line-height:15px;  border-top:1px solid #CCC; padding-top:20px; padding-bottom:20px;\">© current_year All Rights Reserved</td>\r\n    </tr>\r\n</table>', 5, 'input', 'text', NULL, NULL, NULL, '2020-04-16 14:17:58', '2020-04-16 14:17:58', '2020-04-16 14:17:58'),
   (10, 'AI Retrain Url', 'ai_retrain_url', 'http://52.66.227.245:80/retrain', 'AI Retrain Url', 1, 'input', 'text', 6, NULL, NULL, '2020-05-06 16:44:57', NULL, NULL),
   (11, 'AI Retrain Status', 'ai_retrain_status', '0', 'AI Retrain Status', 1, 'input', 'text', 5, NULL, NULL, '2020-05-06 10:54:43', '2020-05-15 10:29:47', NULL),
   (12, 'AI Url', 'ai_backend_url', 'http://10.81.234.32:8000', NULL, 1, 'input', 'text', 4, 1, 1, '2017-12-24 18:30:00', '2020-10-23 11:23:46', NULL);


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-07-31 18:06:54

