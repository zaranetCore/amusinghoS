CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `amusingHosUsers` (
    `userId` char(36) NOT NULL,
    `Name` varchar(16) CHARACTER SET utf8mb4 NULL,
    `PassWord` varchar(18) CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_amusingHosUsers` PRIMARY KEY (`userId`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200218084642_Init', '3.1.0');

CREATE TABLE `amusingArticles` (
    `articleId` char(36) NOT NULL,
    `Title` longtext CHARACTER SET utf8mb4 NULL,
    `Image` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_amusingArticles` PRIMARY KEY (`articleId`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200220043038_2020021230', '3.1.0');

ALTER TABLE `amusingArticles` ADD `CreateTime` longtext CHARACTER SET utf8mb4 NULL;

ALTER TABLE `amusingArticles` ADD `CreateUserId` longtext CHARACTER SET utf8mb4 NULL;

ALTER TABLE `amusingArticles` ADD `DeleteId` longtext CHARACTER SET utf8mb4 NULL;

ALTER TABLE `amusingArticles` ADD `DeleteTime` longtext CHARACTER SET utf8mb4 NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200220043238_addbase', '3.1.0');

ALTER TABLE `amusingArticles` ADD `Description` longtext CHARACTER SET utf8mb4 NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200220103503_20201834', '3.1.0');

ALTER TABLE `amusingArticles` MODIFY COLUMN `articleId` varchar(255) CHARACTER SET utf8mb4 NOT NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200221095510_ad', '3.1.0');

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200224041041_1210', '3.1.0');

ALTER TABLE `amusingArticles` MODIFY COLUMN `Title` longtext CHARACTER SET utf8mb4 NOT NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200224041550_1215', '3.1.0');

ALTER TABLE `amusingArticles` MODIFY COLUMN `Title` varchar(36) NOT NULL;

ALTER TABLE `amusingArticles` MODIFY COLUMN `Image` varchar(130) NULL;

ALTER TABLE `amusingArticles` MODIFY COLUMN `Description` varchar(200) NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200224042518_202224', '3.1.0');

ALTER TABLE `amusingArticles` MODIFY COLUMN `DeleteTime` datetime(6) NOT NULL;

ALTER TABLE `amusingArticles` MODIFY COLUMN `CreateTime` datetime(6) NOT NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200224042738_adddate', '3.1.0');

ALTER TABLE `amusingArticles` DROP COLUMN `DeleteTime`;

ALTER TABLE `amusingArticles` ADD `DelTime` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000';

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200224042841_updatDelTim', '3.1.0');

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200224043300_aaaaa', '3.1.0');

