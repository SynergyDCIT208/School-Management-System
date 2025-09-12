-- MySQL dump 10.13  Distrib 8.0.43, for Win64 (x86_64)
--
-- Host: localhost    Database: schooldb
-- ------------------------------------------------------
-- Server version	8.0.43

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
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `students` (
  `StudentID` int NOT NULL AUTO_INCREMENT,
  `LastName` varchar(50) NOT NULL,
  `OtherNames` varchar(100) NOT NULL,
  `DateOfBirth` date NOT NULL,
  `Sex` enum('Male','Female') NOT NULL,
  `ImagePath` varchar(255) DEFAULT NULL,
  `ReligionID` int DEFAULT NULL,
  `ClassID` int DEFAULT NULL,
  `StatusID` int DEFAULT '1',
  PRIMARY KEY (`StudentID`),
  KEY `fk_students_religion` (`ReligionID`),
  KEY `ClassID` (`ClassID`),
  KEY `fk_student_status` (`StatusID`),
  CONSTRAINT `ClassID` FOREIGN KEY (`ClassID`) REFERENCES `class` (`ClassID`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `fk_student_status` FOREIGN KEY (`StatusID`) REFERENCES `student_status` (`StatusID`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_students_religion` FOREIGN KEY (`ReligionID`) REFERENCES `religion` (`religionID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` VALUES (1,'Nyarko','Stephen','1999-06-30','Male','C:\\Users\\Stephen\\School-Management-System\\SchoolMS\\SchoolMS\\bin\\Debug\\Images\\f70b4e4c-1691-4365-b4dd-190e5d048abe.PNG',1,NULL,1),(2,'Codjoe','Carl','1998-10-28','Male','C:\\Users\\Stephen\\Desktop\\blessing1.JPG',2,NULL,1),(3,'Dauda ','Ismael','2009-07-23','Male','C:\\Users\\Stephen\\School-Management-System\\SchoolMS\\SchoolMS\\bin\\Debug\\Images\\c4fc44fb-5494-4025-89df-6efda51a75c5.JPG',1,3,1),(5,'Clarke','David','2025-09-09','Male','C:\\Users\\Stephen\\School-Management-System\\SchoolMS\\SchoolMS\\bin\\Debug\\Images\\4eb1b2ec-efe4-47fa-b20e-57e8cc06fa55.PNG',3,3,1),(6,'Manu','Kwaku','2025-09-09','Male','C:\\Users\\Stephen\\AppData\\Local\\Temp\\Rar$EXa8856.11391.rartemp\\Images\\95f9b7d7-f5f4-47e8-a7fc-ac4a05378974.jpg',2,2,1);
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-09-12 12:06:24
