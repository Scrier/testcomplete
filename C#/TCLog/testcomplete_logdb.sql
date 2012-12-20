-- MySQL dump 10.10
--
-- Host: localhost    Database: TestCompleteLog
-- ------------------------------------------------------
-- Server version	5.0.24a

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


--
-- Table structure for table `ITD_ITR`
--
drop database if exists testcompletelog;
create database testcompletelog;

delete from mysql.db where user = 'testcomplete';
delete from mysql.tables_priv where user = 'testcomplete';
delete from mysql.columns_priv where user = 'testcomplete';
delete from mysql.user where user = 'testcomplete';

flush privileges;

use testcompletelog;


DROP TABLE IF EXISTS `ITD_ITR`;
CREATE TABLE `ITD_ITR` (
  `ID` varchar(36) NOT NULL,
  `ITD_ITR` varchar(20) NOT NULL,
  `Started` datetime NOT NULL,
  `Stopped` datetime NOT NULL,
  `Failed` int(10) unsigned NOT NULL default '0',
  `Successful` int(10) unsigned NOT NULL default '0',
  `Warnings` int(10) unsigned NOT NULL default '0',
  `ManualChecks` int(10) unsigned NOT NULL default '0',
  `Version` varchar(45) NOT NULL,
  `Misc` varchar(45) NOT NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


grant select, insert, update, delete on testcompletelog.ITD_ITR to 'testcomplete';
--
-- Dumping data for table `ITD_ITR`
--


/*!40000 ALTER TABLE `ITD_ITR` DISABLE KEYS */;
LOCK TABLES `ITD_ITR` WRITE;
UNLOCK TABLES;
/*!40000 ALTER TABLE `ITD_ITR` ENABLE KEYS */;

--
-- Table structure for table `LOG_ITEM`
--

DROP TABLE IF EXISTS `LOG_ITEM`;
CREATE TABLE `LOG_ITEM` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `SSS` int(10) unsigned default NULL,
  `Status` varchar(25) NOT NULL,
  `Message` varchar(255) default NULL,
  `Screenshot` varchar(1024) default NULL,
  `DateTime` varchar(45) NOT NULL,
  `ITD_ITR_ID` varchar(36) NOT NULL,
  `Signature` varchar(10) default NULL,
  PRIMARY KEY  (`ID`),
  KEY `ITD_ITR_REF` (`ITD_ITR_ID`),
  CONSTRAINT `ITD_ITR_REF` FOREIGN KEY (`ITD_ITR_ID`) REFERENCES `ITD_ITR` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

grant select, insert, update, delete on testcompletelog.LOG_ITEM to 'testcomplete';

SET PASSWORD FOR 'testcomplete' = PASSWORD('testcomplete');

flush privileges;

--
-- Dumping data for table `LOG_ITEM`
--


/*!40000 ALTER TABLE `LOG_ITEM` DISABLE KEYS */;
LOCK TABLES `LOG_ITEM` WRITE;
UNLOCK TABLES;
/*!40000 ALTER TABLE `LOG_ITEM` ENABLE KEYS */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

