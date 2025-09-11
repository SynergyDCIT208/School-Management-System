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
-- Table structure for table `academicyear`
--

DROP TABLE IF EXISTS `academicyear`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `academicyear` (
  `YearID` int NOT NULL AUTO_INCREMENT,
  `YearName` varchar(20) NOT NULL,
  PRIMARY KEY (`YearID`),
  UNIQUE KEY `YearName` (`YearName`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `academicyear`
--

LOCK TABLES `academicyear` WRITE;
/*!40000 ALTER TABLE `academicyear` DISABLE KEYS */;
INSERT INTO `academicyear` VALUES (1,'2024/2025'),(2,'2025/2026');
/*!40000 ALTER TABLE `academicyear` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `billing`
--

DROP TABLE IF EXISTS `billing`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `billing` (
  `BillID` int NOT NULL AUTO_INCREMENT,
  `ClassID` int DEFAULT NULL,
  `TermID` int NOT NULL,
  `YearID` int NOT NULL,
  PRIMARY KEY (`BillID`),
  UNIQUE KEY `uq_class_term` (`ClassID`),
  KEY `fk_billing_year` (`YearID`),
  KEY `fk_billing_term_billing` (`TermID`),
  CONSTRAINT `billing_ibfk_1` FOREIGN KEY (`ClassID`) REFERENCES `class` (`ClassID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_billing_term` FOREIGN KEY (`TermID`) REFERENCES `term` (`TermID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_billing_term_billing` FOREIGN KEY (`TermID`) REFERENCES `term` (`TermID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_billing_year` FOREIGN KEY (`YearID`) REFERENCES `academicyear` (`YearID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `billing`
--

LOCK TABLES `billing` WRITE;
/*!40000 ALTER TABLE `billing` DISABLE KEYS */;
INSERT INTO `billing` VALUES (1,3,7,2),(3,1,3,1);
/*!40000 ALTER TABLE `billing` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `billingitems`
--

DROP TABLE IF EXISTS `billingitems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `billingitems` (
  `ItemID` int NOT NULL AUTO_INCREMENT,
  `BillID` int DEFAULT NULL,
  `Description` varchar(255) NOT NULL,
  `Amount` decimal(10,2) NOT NULL,
  PRIMARY KEY (`ItemID`),
  KEY `BillID` (`BillID`),
  CONSTRAINT `billingitems_ibfk_1` FOREIGN KEY (`BillID`) REFERENCES `billing` (`BillID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `billingitems`
--

LOCK TABLES `billingitems` WRITE;
/*!40000 ALTER TABLE `billingitems` DISABLE KEYS */;
INSERT INTO `billingitems` VALUES (1,1,'PTA Levy',200.00),(2,1,'School Fees',2192.29),(3,3,'Transport',213.80),(4,3,'Class Book',1289.00);
/*!40000 ALTER TABLE `billingitems` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `class`
--

DROP TABLE IF EXISTS `class`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `class` (
  `ClassID` int NOT NULL AUTO_INCREMENT,
  `ClassName` varchar(100) NOT NULL,
  PRIMARY KEY (`ClassID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `class`
--

LOCK TABLES `class` WRITE;
/*!40000 ALTER TABLE `class` DISABLE KEYS */;
INSERT INTO `class` VALUES (1,'Class one'),(2,'Class Two'),(3,'Class Three');
/*!40000 ALTER TABLE `class` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payments`
--

DROP TABLE IF EXISTS `payments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payments` (
  `PaymentID` int NOT NULL AUTO_INCREMENT,
  `StudentID` int DEFAULT NULL,
  `BillID` int DEFAULT NULL,
  `AmountPaid` decimal(10,2) NOT NULL,
  `PaymentDate` date NOT NULL,
  `Method` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`PaymentID`),
  KEY `StudentID` (`StudentID`),
  KEY `BillID` (`BillID`),
  CONSTRAINT `payments_ibfk_1` FOREIGN KEY (`StudentID`) REFERENCES `students` (`StudentID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `payments_ibfk_2` FOREIGN KEY (`BillID`) REFERENCES `billing` (`BillID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payments`
--

LOCK TABLES `payments` WRITE;
/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
/*!40000 ALTER TABLE `payments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `religion`
--

DROP TABLE IF EXISTS `religion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `religion` (
  `religionID` int NOT NULL AUTO_INCREMENT,
  `ReligionName` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`religionID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `religion`
--

LOCK TABLES `religion` WRITE;
/*!40000 ALTER TABLE `religion` DISABLE KEYS */;
INSERT INTO `religion` VALUES (1,'Catholic'),(2,'Pentecost'),(3,'Charismatic');
/*!40000 ALTER TABLE `religion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student_status`
--

DROP TABLE IF EXISTS `student_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `student_status` (
  `StatusID` int NOT NULL AUTO_INCREMENT,
  `StatusName` varchar(50) NOT NULL,
  `Description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`StatusID`),
  UNIQUE KEY `StatusName` (`StatusName`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student_status`
--

LOCK TABLES `student_status` WRITE;
/*!40000 ALTER TABLE `student_status` DISABLE KEYS */;
INSERT INTO `student_status` VALUES (1,'Active','Currently enrolled and taking classes'),(2,'Graduated','Completed program successfully'),(3,'Transferred','Moved to another school'),(4,'Withdrawn','Left the school voluntarily');
/*!40000 ALTER TABLE `student_status` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `term`
--

DROP TABLE IF EXISTS `term`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `term` (
  `TermID` int NOT NULL AUTO_INCREMENT,
  `YearID` int NOT NULL,
  `TermName` varchar(50) NOT NULL,
  `TermOrder` int NOT NULL,
  PRIMARY KEY (`TermID`),
  UNIQUE KEY `YearID` (`YearID`,`TermOrder`),
  CONSTRAINT `term_ibfk_1` FOREIGN KEY (`YearID`) REFERENCES `academicyear` (`YearID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `term`
--

LOCK TABLES `term` WRITE;
/*!40000 ALTER TABLE `term` DISABLE KEYS */;
INSERT INTO `term` VALUES (1,1,'First Term',1),(2,1,'Second Term',2),(3,1,'Third Term',3),(7,2,'First Term',1),(8,2,'Second Term',2),(9,2,'Third Term',3);
/*!40000 ALTER TABLE `term` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `role` enum('Admin','Teacher') NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'admin','admin123','Admin'),(2,'teacher1','teach123','Teacher');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-09-11 18:45:16
