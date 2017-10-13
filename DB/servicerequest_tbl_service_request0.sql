-- MySQL dump 10.13  Distrib 5.6.23, for Win64 (x86_64)
--
-- Host: localhost    Database: servicerequest
-- ------------------------------------------------------
-- Server version	5.6.24-log

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
-- Table structure for table `tbl_service_request`
--

DROP TABLE IF EXISTS `tbl_service_request`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_service_request` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idsr` varchar(45) NOT NULL,
  `title` varchar(45) DEFAULT NULL,
  `category` varchar(45) DEFAULT NULL,
  `sub_category` varchar(45) DEFAULT NULL,
  `description` mediumtext,
  `priority` varchar(45) DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `createddate` datetime DEFAULT NULL,
  `updateddate` datetime DEFAULT NULL,
  `createdby` varchar(45) DEFAULT NULL,
  `updatedby` varchar(45) DEFAULT NULL,
  `userId` int(11) NOT NULL,
  PRIMARY KEY (`id`,`userId`),
  UNIQUE KEY `idsr_UNIQUE` (`idsr`),
  KEY `fk_tbl_service_request_tbl_user1_idx` (`userId`),
  KEY `fk_tbl_service_request_status_idx` (`status`),
  CONSTRAINT `fk_tbl_service_request_status` FOREIGN KEY (`status`) REFERENCES `tbl_sr_status` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_tbl_service_request_tbl_user1` FOREIGN KEY (`userId`) REFERENCES `tbl_user` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_service_request`
--

LOCK TABLES `tbl_service_request` WRITE;
/*!40000 ALTER TABLE `tbl_service_request` DISABLE KEYS */;
INSERT INTO `tbl_service_request` VALUES (2,'78956548','Create an admin email','Email Creation','admin email','Please Create an emailid as amitverma@minditsystems.com','High',3,NULL,NULL,NULL,NULL,2),(3,'78958465','Installation required','Software Installation','photoshop','Please Install Latest Photoshop on my machine.','Medium',3,NULL,NULL,NULL,NULL,3),(4,'78956865','RAM','Hardware Support','upgrade ram','Please upgrade my machine ram to 4gb','low',3,NULL,NULL,NULL,NULL,3),(34,'70838925','My system Just stopped','software installation','driver installation','sound driver not working, please install.','low',3,NULL,NULL,NULL,NULL,3);
/*!40000 ALTER TABLE `tbl_service_request` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-10-13 15:01:16
