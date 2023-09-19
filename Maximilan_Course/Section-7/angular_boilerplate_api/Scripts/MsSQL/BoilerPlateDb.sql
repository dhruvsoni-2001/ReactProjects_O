use BoilerPlateDB;

CREATE TABLE menu (
  "id" int NOT NULL IDENTITY,
  "parentId" int NOT NULL DEFAULT '0',
  "label" varchar(250) NOT NULL,
  "menu_link" varchar(250) DEFAULT NULL,
  "role_id" varchar(250) DEFAULT NULL,
  "module" int DEFAULT NULL,
  "sequence" smallint DEFAULT NULL,
  "bootstrap_class" varchar(255) DEFAULT NULL,
  "icon_class" varchar(255) DEFAULT NULL,
  "status" smallint NOT NULL,
  "created_at" datetime2(0) NULL DEFAULT NULL,
  "updated_at" datetime2(0) NULL DEFAULT NULL,
  "deleted_at" datetime2(0) NULL DEFAULT NULL,
  PRIMARY KEY ("id")
);


INSERT INTO menu VALUES (0,'Dashboard','dashboard','1',0,1,'home-outline',NULL,1,'2020-10-08 17:12:23',NULL,NULL),
(0,'Roles/Permissions','roles','1',1,2,'settings-2-outline',NULL,1,'2020-10-08 17:38:11',NULL,NULL),
(0,'Users','users','1',4,2,'people-outline',NULL,1,'2020-10-08 17:39:55',NULL,NULL),
(0, 'Product', 'product', '1', 5, 2, 'gift-outline',NULL, 1, '2020-10-08 17:39:55', NULL, NULL),
(0, 'Email Template', 'email-template', '1', 6, 2, 'email-outline',NULL, 1, '2020-10-08 17:39:55', NULL, NULL),
(0, 'CMS', 'cms', '1', 7, 2, 'file-text-outline',NULL, 1, '2020-10-08 17:39:55', NULL, NULL),
(0,'Settings','settings','1',3,10,'settings-2-outline',NULL,1,'2020-10-08 17:39:55',NULL,NULL),
(7,'General Settings','settings','1',3,11,'settings-2-outline',NULL,1,'2020-10-08 17:39:55',NULL,NULL);



CREATE TABLE "module" (
  "id" int NOT NULL IDENTITY,
  "label" varchar(250) NOT NULL,
  "name" varchar(250) NOT NULL,
  "status" smallint NOT NULL,
  "created_at" datetime2(0) NULL DEFAULT NULL,
  "updated_at" datetime2(0) NULL DEFAULT NULL,
  "deleted_at" datetime2(0) NULL DEFAULT NULL,
  PRIMARY KEY ("id")
);


INSERT INTO "module" VALUES ('ROLE','role',1,'2020-10-09 06:02:19',NULL,NULL),
('PERMISSION','permission',1,'2020-10-09 06:02:19',NULL,NULL),
('SETTINGS','settings',1,'2020-10-09 06:06:12',NULL,NULL),
('USERS','users',1,'2020-10-09 06:06:44',NULL,NULL),
('PRODUCT', 'products', 1, '2020-10-09 06:06:12', NULL, NULL),
('EMAIL TEMPLATE', 'email template', 1, '2020-10-09 06:06:44', NULL, NULL),
('CMS', 'cms', 1, '2020-10-09 06:06:44', NULL, NULL);



CREATE TABLE "permission" (
  "id" int NOT NULL IDENTITY,
  "label" varchar(250) NOT NULL,
  "name" varchar(250) NOT NULL,
  "description" varchar(250) DEFAULT NULL,
  "module" int NOT NULL,
  "status" smallint NOT NULL,
  "created_at" datetime2(0) NULL DEFAULT NULL,
  "updated_at" datetime2(0) NULL DEFAULT NULL,
  "deleted_at" datetime2(0) NULL DEFAULT NULL,
  PRIMARY KEY ("id")
);


INSERT INTO "permission" VALUES ('Update','can_update','Update Permission for Role',1,1,'2020-10-09 06:18:03',NULL,NULL),
('View','can_view','View Permission for Role',1,1,'2023-07-10 12:06:06',NULL,NULL),
('Create','can_create','Create Permission for Role',1,1,'2020-10-09 06:18:03',NULL,NULL),
('Delete','can_delete','Delete Permission for Role',1,1,'2020-10-09 06:18:03',NULL,NULL),
('Update','can_update','Update Permission for Settings',3,1,'2020-10-09 06:18:03',NULL,NULL),
('View','can_view','View Permission for Settings',3,1,'2020-10-09 06:18:03',NULL,NULL),
('Create','can_create','Create Permission for Settings',3,1,'2020-10-09 06:18:03',NULL,NULL),
('Delete','can_delete','Delete Permission for Settings',3,1,'2020-10-09 06:18:03',NULL,NULL),
('Update','can_update','Update Permission for Users',4,1,'2020-10-09 06:18:03',NULL,NULL),
('View','can_view','View Permission for Users',4,1,'2020-10-09 06:18:03',NULL,NULL),
('Create','can_create','Create Permission for Users',4,1,'2020-10-09 06:18:03',NULL,NULL),
('Delete','can_delete','Delete Permission for Users',4,1,'2020-10-09 06:18:03',NULL,NULL),
('Update','can_update','Update Permission for Permission',2,1,'2017-12-13 01:30:00','2017-12-13 01:30:00',NULL),
('View','can_view','View Permission for Permission',2,1,'2017-12-13 01:30:00','2017-12-13 01:30:00',NULL),
('Create','can_create','Create Permission for Permission',2,1,'2017-12-14 01:30:00','2017-12-14 01:30:00',NULL),
('Delete','can_delete','Delete Permission for Permission',2,1,'2017-12-13 01:30:00','2017-12-13 01:30:00',NULL),
('Update','can_update','Update Permission for Product',5,1,'2017-12-13 01:30:00','2017-12-13 01:30:00',NULL),
('View','can_view','View Permission for Product',5,1,'2017-12-13 01:30:00','2017-12-13 01:30:00',NULL),
('Create','can_create','Create Permission for Product',5,1,'2017-12-14 01:30:00','2017-12-14 01:30:00',NULL),
('Delete','can_delete','Delete Permission for Product',5,1,'2017-12-13 01:30:00','2017-12-13 01:30:00',NULL),
('Update','can_update','Update Permission for Email Template',6,1,'2017-12-13 01:30:00','2017-12-13 01:30:00',NULL),
('View','can_view','View Permission for Email Template',6,1,'2017-12-13 01:30:00','2017-12-13 01:30:00',NULL),
('Create','can_create','Create Permission for Email Template',6,1,'2017-12-14 01:30:00','2017-12-14 01:30:00',NULL),
('Delete','can_delete','Delete Permission for Email Template',6,1,'2017-12-13 01:30:00','2017-12-13 01:30:00',NULL),
('Update','can_update','Update Permission for CMS',7,1,'2017-12-13 01:30:00','2017-12-13 01:30:00',NULL),
('View','can_view','View Permission for CMS',7,1,'2017-12-13 01:30:00','2017-12-13 01:30:00',NULL),
('Create','can_create','Create Permission for CMS',7,1,'2017-12-14 01:30:00','2017-12-14 01:30:00',NULL),
('Delete','can_delete','Delete Permission for Email Template',7,1,'2017-12-13 01:30:00','2017-12-13 01:30:00',NULL)
;


CREATE TABLE "role" (
  "id" int check ("id" > 0) NOT NULL IDENTITY,
  "title" varchar(255) NOT NULL,
  "status" smallint DEFAULT '1',
  "created_at" datetime2(0) NULL DEFAULT NULL,
  "updated_at" datetime2(0) NULL DEFAULT NULL,
  "deleted_at" datetime2(0) NULL DEFAULT NULL,
  PRIMARY KEY ("id")
);

INSERT INTO "role" VALUES ('Super Admin',0,'2023-07-10 10:26:31',NULL,NULL);


CREATE TABLE "role_permission" (
  "id" int NOT NULL IDENTITY,
  "role_id" int NOT NULL,
  "permission_id" int NOT NULL,
  "created_at" datetime2(0) NULL DEFAULT NULL,
  "updated_at" datetime2(0) NULL DEFAULT NULL,
  "deleted_at" datetime2(0) NULL DEFAULT NULL,
  PRIMARY KEY ("id")
);


INSERT INTO "role_permission" VALUES 
(1,3,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,1,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,2,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,4,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,7,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,5,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,6,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,8,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,11,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,9,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,10,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,12,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,13,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,14,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,15,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,16,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,17,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,18,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,19,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,20,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,21,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,22,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,23,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,24,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,25,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,26,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,27,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL),
(1,28,'2022-02-16 20:09:49','2022-02-16 20:09:49',NULL)
;



CREATE TABLE "users" (
  "id" int check ("id" > 0) NOT NULL IDENTITY,
  "first_name" varchar(255) NOT NULL,
  "last_name" varchar(255) DEFAULT NULL,
  "contact_number" varchar(20) DEFAULT NULL,
  "email" varchar(255) NOT NULL,
  "email_verified_at" datetime2(0) NULL DEFAULT NULL,
  "password" varchar(255) NOT NULL,
  "remember_token" varchar(100) DEFAULT NULL,
  "created_by" int DEFAULT NULL,
  "updated_by" int DEFAULT NULL,
  "update_password_date" datetime2(0) NULL DEFAULT NULL,
  "created_at" datetime2(0) NULL DEFAULT NULL,
  "updated_at" datetime2(0) NULL DEFAULT NULL,
  "deleted_at" datetime2(0) NULL DEFAULT NULL,
  "avatar" varchar(255) DEFAULT NULL,
  "provider" varchar(20) DEFAULT NULL,
  "provider_id" varchar(255) DEFAULT NULL,
  "access_token" varchar(255) DEFAULT NULL,
  "iama" varchar(255) DEFAULT NULL,
  "journeyAgainst" varchar(50) DEFAULT NULL,
  "state" int DEFAULT NULL,
  "city" int DEFAULT NULL,
  "patientAge" varchar(255) DEFAULT NULL,
  "gender" int DEFAULT NULL ,
  "status" int DEFAULT '1',
  PRIMARY KEY ("id"),
  CONSTRAINT "users_email_unique" UNIQUE  ("email")
);


INSERT INTO "users" VALUES 
('Super','Admin','9979214252','admin@demo.com','2021-06-24 07:00:00','Admin@111','UetN5y2I2irqk1xOw5tWaecuNrVaxavHjkoFZlR40pKhVMVIbfV4OkULVgdg',NULL,NULL,'2022-11-22 07:02:16','2021-06-24 07:00:00','2023-01-03 08:07:47',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1);



CREATE TABLE "user_roles" (
  "id" int NOT NULL IDENTITY,
  "user_id" int NOT NULL,
  "role_id" int NOT NULL, 
  "status" smallint NOT NULL,
  "created_at" datetime2(0) NULL DEFAULT NULL,
  "updated_at" datetime2(0) NULL DEFAULT NULL,
  "deleted_at" datetime2(0) NULL DEFAULT NULL,
  PRIMARY KEY ("id")
);


INSERT INTO "user_roles" VALUES 
(1,1,1,'2020-11-26 17:06:10','2020-11-26 17:06:10',NULL);


CREATE TABLE emailtemplate (
  id int CHECK (id > 0) NOT NULL IDENTITY,
  template_title varchar(255) NOT NULL,
  subject varchar(max),
  content varchar(max) NOT NULL,
  file_name varchar(255) DEFAULT NULL,
  creative_format_id int DEFAULT NULL,
  status smallint NOT NULL DEFAULT '1',
  created_at datetime2(0) NULL DEFAULT NULL,
  updated_at datetime2(0) NULL DEFAULT NULL,
  deleted_at datetime2(0) NULL DEFAULT NULL
);


CREATE TABLE cms (
  id int NOT NULL IDENTITY,
  page_name varchar(255) DEFAULT NULL,
  slug varchar(255) DEFAULT NULL,
  description varchar(max),
  content varchar(max),
  meta_title varchar(255) DEFAULT NULL,
  meta_keyword varchar(255) DEFAULT NULL,
  meta_description varchar(max),
  status smallint DEFAULT '1',
  created_at datetime2(0) NULL DEFAULT NULL,
  updated_at datetime2(0) NULL DEFAULT NULL,
  deleted_at datetime2(0) NULL DEFAULT NULL
);


CREATE TABLE products (
  id int NOT NULL IDENTITY,
  name varchar(255) DEFAULT NULL,
  status smallint NOT NULL DEFAULT '1',
  created_at datetime2(0) NULL DEFAULT NULL,
  updated_at datetime2(0) NULL DEFAULT NULL,
  deleted_at datetime2(0) NULL DEFAULT NULL
);

INSERT INTO products (name, status, created_at, updated_at, deleted_at)
VALUES
    ('ss', 1, '2023-07-03 06:11:43', '2023-07-03 06:11:43', NULL),
    ('test12', 1, '2023-01-03 18:45:10', '2023-07-03 05:47:11', NULL),
    ('sample product11', 1, '2022-11-18 12:04:21', '2022-12-20 15:19:17', NULL),
    ('Sample Product 4', 1, '2022-02-18 22:14:42', '2022-11-15 16:17:32', NULL),
    ('Sample Product 2', 1, '2022-02-18 14:11:29', '2022-02-18 14:11:29', NULL),
    ('Sample Product 1', 1, '2022-02-18 13:02:50', '2022-02-18 22:14:28', NULL);

CREATE TABLE settings (
  id int NOT NULL IDENTITY,
  label varchar(255) DEFAULT NULL,
  name varchar(255) DEFAULT NULL,
  value varchar(500) DEFAULT NULL,
  description varchar(max),
  type smallint NOT NULL DEFAULT 0,
  field_type varchar(50) NOT NULL DEFAULT 'input',
  field_type_value varchar(50) NOT NULL DEFAULT 'text',
  seq_no smallint DEFAULT NULL,
  created_by int DEFAULT NULL,
  updated_by int DEFAULT NULL ,
  created_at datetime2(0) NULL DEFAULT NULL,
  updated_at datetime2(0) NULL DEFAULT NULL,
  deleted_at datetime2(0) NULL DEFAULT NULL
);

INSERT INTO settings (label, name, value, description, type, field_type, field_type_value, seq_no, created_by, updated_by, created_at, updated_at, deleted_at)
VALUES
   ('Site Email', 'Email', 'info@ut.com', NULL, 1, 'input', 'email', 1, 1, 1, '2017-09-14 09:00:00', '2022-02-18 22:13:40', NULL),
   ('From Email', 'from_email', 'info@ut.coms', NULL, 1, 'input', 'email', 2, 1, 1, '2017-10-03 14:30:00', '2023-01-03 07:36:46', NULL),
   ('Allowed IPs', 'allowed_ips', NULL, NULL, 1, 'textarea', 'textarea', 3, 1, 1, '2017-09-14 14:30:00', '2020-10-23 11:24:06', NULL),
   ('Host', 'host', 'smtp.gmail.com', NULL, 2, 'input', 'text', 1, 1, 1, '2017-09-14 21:30:00', '2020-10-23 11:24:44', NULL),
   ('Username', 'username', 'fidam27353@gmail.com', NULL, 2, 'input', 'text', 2, 1, 1, '2017-09-15 03:00:00', '2018-01-25 08:38:30', NULL),
   ('Password', 'password', 'abcd@1234', NULL, 2, 'input', 'text', 3, 1, 1, '2017-12-25 01:30:00', '2018-04-24 15:23:13', NULL),
   ('Port', 'port', '587', NULL, 2, 'input', 'number', 4, 1, 1, '2017-10-04 03:00:00', '2020-10-14 13:08:08', NULL),
   (NULL, NULL, NULL, '<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n    <tr>\r\n        <td align=\"center\" valign=\"top\" bgcolor=\"#f5821f\" style=\"padding-top:5px; padding-bottom:5px;\">\r\n            <table width=\"92%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n                <tr>\r\n                    <td width=\"70\" align=\"left\" valign=\"top\" style=\"padding-bottom: 10px;\" ><img src=\"u_logo\" width=\"250px\" height=\"70px\" alt=\"Logo\" /></td>\r\n                    <td align=\"left\" valign=\"top\">\r\n                        <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n                            <tr>\r\n                                <td align=\"right\" style=\"font-family:Arial, Verdana; font-size:12px; color:#FFFFFF; padding-top:22px;\"><b>u_sendOn</b></td>\r\n                            </tr>\r\n                        </table>\r\n                    </td>\r\n                </tr>\r\n            </table>\r\n        </td>\r\n    </tr>\r\n\r\n    <tr>\r\n        <td align=\"center\" valign=\"top\" style=\"padding-top:20px; padding-bottom:20px;\">\r\n            <table width=\"92%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">\r\n                <tr>\r\n                    <td align=\"left\" valign=\"top\" style=\"font-family:Arial, Verdana; font-size:13px; color:#666666; line-height:15px; padding-bottom:10px;\">\r\n                        Hello u_name,<br /><br/>\r\n                        Forgotten your password? Don&#39;t worry, Below is your new password.<br />\r\n                        <br />\r\n                        <b>New Password:</b> u_password <br />\r\n                        <br />\r\n                        If you have any question or encounter any problem while login, please contact our support team.<br />\r\n                        <br />\r\n                        <br />\r\n                        <em>Thanks</em>,<br />\r\n                        <b>AI Emails Team</b>\r\n                    </td>\r\n                </tr>\r\n            </table>\r\n        </td>\r\n    </tr>\r\n\r\n    <tr align=\"center\" valign=\"top\">\r\n        <td style=\"font-family:Arial, Verdana; font-size:13px; color:#666666; line-height:15px;  border-top:1px solid #CCC; padding-top:20px; padding-bottom:20px;\">© current_year All Rights Reserved</td>\r\n    </tr>\r\n</table>', 5, 'input', 'text', NULL, NULL, NULL, NULL, NULL, NULL),
   ('New Credentials', 'New Credentials', 'New Credentials', '<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n    <tr>\r\n        <td align=\"center\" valign=\"top\" bgcolor=\"#f5821f\" style=\"padding-top:5px; padding-bottom:5px;\">\r\n            <table width=\"92%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n                <tr>\r\n                    <td width=\"70\" align=\"left\" valign=\"top\" style=\"padding-bottom: 10px;\" ><img src=\"u_logo\" width=\"250px\" height=\"70px\" alt=\"Logo\" /></td>\r\n                    <td align=\"left\" valign=\"top\">\r\n                        <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n                            <tr>\r\n                                <td align=\"right\" style=\"font-family:Arial, Verdana; font-size:12px; color:#FFFFFF; padding-top:22px;\"><b>u_sendOn</b></td>\r\n                            </tr>\r\n                        </table>\r\n                    </td>\r\n                </tr>\r\n            </table>\r\n        </td>\r\n    </tr>\r\n\r\n    <tr>\r\n        <td align=\"center\" valign=\"top\" style=\"padding-top:20px; padding-bottom:20px;\">\r\n            <table width=\"92%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">\r\n                <tr>\r\n                    <td align=\"left\" valign=\"top\" style=\"font-family:Arial, Verdana; font-size:13px; color:#666666; line-height:15px; padding-bottom:10px;\">\r\n                        Hello u_name,<br /><br/>\r\n                        Below is your user credentials to login into the website.<br />\r\n                        <br />\r\n                        <b>Site Login URL:</b> <a href=\"u_url\">u_url</a><br />\r\n						<br />\r\n                        <b>Username:</b> u_username <br />\r\n                        <br />\r\n						<b>Password:</b> u_password <br />\r\n                        <br />\r\n                        If you have any question or encounter any problem while login, please contact our support team.<br />\r\n                        <br />\r\n                        <br />\r\n                        <em>Thanks</em>,<br />\r\n                        <b>AI Emails Team</b>\r\n                    </td>\r\n                </tr>\r\n            </table>\r\n        </td>\r\n    </tr>\r\n\r\n    <tr align=\"center\" valign=\"top\">\r\n        <td style=\"font-family:Arial, Verdana; font-size:13px; color:#666666; line-height:15px;  border-top:1px solid #CCC; padding-top:20px; padding-bottom:20px;\">© current_year All Rights Reserved</td>\r\n    </tr>\r\n</table>', 5, 'input', 'text', NULL, NULL, NULL, '2020-04-16 14:17:58', '2020-04-16 14:17:58', '2020-04-16 14:17:58'),
   ( 'AI Retrain Url', 'ai_retrain_url', 'http://52.66.227.245:80/retrain', 'AI Retrain Url', 1, 'input', 'text', 6, NULL, NULL, '2020-05-06 16:44:57', NULL, NULL),
   ( 'AI Retrain Status', 'ai_retrain_status', '0', 'AI Retrain Status', 1, 'input', 'text', 5, NULL, NULL, '2020-05-06 10:54:43', '2020-05-15 10:29:47', NULL),
   ( 'AI Url', 'ai_backend_url', 'http://10.81.234.32:8000', NULL, 1, 'input', 'text', 4, 1, 1, '2017-12-24 18:30:00', '2020-10-23 11:23:46', NULL);
