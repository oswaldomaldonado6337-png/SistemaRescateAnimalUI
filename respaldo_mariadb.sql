/*M!999999\- enable the sandbox mode */ 
-- MariaDB dump 10.19-12.2.2-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: sistemarescateanimaldb
-- ------------------------------------------------------
-- Server version	12.2.2-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*M!100616 SET @OLD_NOTE_VERBOSITY=@@NOTE_VERBOSITY, NOTE_VERBOSITY=0 */;

--
-- Current Database: `sistemarescateanimaldb`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `sistemarescateanimaldb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci */;

USE `sistemarescateanimaldb`;

--
-- Table structure for table `adopciones`
--

DROP TABLE IF EXISTS `adopciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `adopciones` (
  `IdAdopcion` int(11) NOT NULL AUTO_INCREMENT,
  `IdAnimal` varchar(50) NOT NULL,
  `IdAdoptante` int(11) NOT NULL,
  `FechaAdopcion` datetime DEFAULT current_timestamp(),
  `Observaciones` text DEFAULT NULL,
  PRIMARY KEY (`IdAdopcion`),
  KEY `FK_Adopcion_Animal` (`IdAnimal`),
  KEY `FK_Adopcion_Adoptante` (`IdAdoptante`),
  CONSTRAINT `FK_Adopcion_Adoptante` FOREIGN KEY (`IdAdoptante`) REFERENCES `adoptantes` (`IdAdoptante`),
  CONSTRAINT `FK_Adopcion_Animal` FOREIGN KEY (`IdAnimal`) REFERENCES `animales` (`IdAnimal`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adopciones`
--

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `adopciones` WRITE;
/*!40000 ALTER TABLE `adopciones` DISABLE KEYS */;
INSERT INTO `adopciones` VALUES
(3,'101',1,'2026-11-14 22:53:00','Familia verificada y apta para la adopción'),
(4,'101',3,'2026-11-16 17:34:14','Se hicieron las investigaciones pertinentes y todo salio bien'),
(5,'101',3,'2026-11-16 17:55:17','Todo normal'),
(6,'101',3,'2026-11-16 17:55:29','probando errores'),
(7,'102',2,'2026-11-16 17:59:55','probando errores');
/*!40000 ALTER TABLE `adopciones` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;

--
-- Table structure for table `adoptantes`
--

DROP TABLE IF EXISTS `adoptantes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `adoptantes` (
  `IdAdoptante` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) NOT NULL,
  `ApellidoPaterno` varchar(50) NOT NULL,
  `ApellidoMaterno` varchar(50) DEFAULT NULL,
  `Telefono` varchar(20) NOT NULL,
  `Correo` varchar(100) DEFAULT NULL,
  `Calle` varchar(100) NOT NULL,
  `Numero` varchar(20) NOT NULL,
  `Colonia` varchar(100) NOT NULL,
  `Ciudad` varchar(100) NOT NULL,
  PRIMARY KEY (`IdAdoptante`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adoptantes`
--

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `adoptantes` WRITE;
/*!40000 ALTER TABLE `adoptantes` DISABLE KEYS */;
INSERT INTO `adoptantes` VALUES
(1,'Juan','Perez',NULL,'33-1234-5678',NULL,'Av. Vallarta','123','Centro','Zapopan'),
(2,'Juan','Perez',NULL,'33-1234-5678',NULL,'Av. Vallarta','123','Centro','Zapopan'),
(3,'Oswaldo Daniel','Maldonado','Llamas','22334455','oswaldo@gmail.com','glorieta','234','La Paz','guadalajara'),
(4,'Luis Alejandro','Juarez','ALCARAMESSI','2788491211','luisAlejandro@gmail.com','luis Miguel','2','Juarez','Juarez');
/*!40000 ALTER TABLE `adoptantes` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;

--
-- Table structure for table `animales`
--

DROP TABLE IF EXISTS `animales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `animales` (
  `IdAnimal` varchar(50) NOT NULL,
  `Nombre` varchar(80) NOT NULL,
  `Especie` varchar(50) NOT NULL,
  `Peso` decimal(5,2) NOT NULL,
  `FechaNacimientoEstimada` date NOT NULL,
  `UbicacionFisica` varchar(100) NOT NULL,
  `FechaRescate` datetime NOT NULL,
  `LugarHallazgo` varchar(150) DEFAULT NULL,
  `CondicionHallazgo` text DEFAULT NULL,
  `FechaRegistro` datetime DEFAULT current_timestamp(),
  `EsActivo` tinyint(1) DEFAULT 1,
  `RutaImagen` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`IdAnimal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `animales`
--

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `animales` WRITE;
/*!40000 ALTER TABLE `animales` DISABLE KEYS */;
INSERT INTO `animales` VALUES
('101','Firulais','Perro',10.00,'0001-01-01','','0001-01-01 00:00:00','','','2026-11-14 21:23:43',0,''),
('102','Solo Vino','Gato',10.00,'0001-01-01','','0001-01-01 00:00:00','','','2026-11-16 17:37:24',0,'');
/*!40000 ALTER TABLE `animales` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;

--
-- Table structure for table `historialmedico`
--

DROP TABLE IF EXISTS `historialmedico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `historialmedico` (
  `IdConsulta` int(11) NOT NULL AUTO_INCREMENT,
  `IdAnimal` varchar(50) NOT NULL,
  `IdUsuarioVeterinario` int(11) NOT NULL,
  `FechaConsulta` datetime DEFAULT current_timestamp(),
  `Diagnostico` text NOT NULL,
  `Tratamiento` text NOT NULL,
  PRIMARY KEY (`IdConsulta`),
  KEY `FK_Historial_Animal` (`IdAnimal`),
  KEY `FK_Historial_Usuario` (`IdUsuarioVeterinario`),
  CONSTRAINT `FK_Historial_Animal` FOREIGN KEY (`IdAnimal`) REFERENCES `animales` (`IdAnimal`),
  CONSTRAINT `FK_Historial_Usuario` FOREIGN KEY (`IdUsuarioVeterinario`) REFERENCES `usuarios` (`IdUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `historialmedico`
--

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `historialmedico` WRITE;
/*!40000 ALTER TABLE `historialmedico` DISABLE KEYS */;
INSERT INTO `historialmedico` VALUES
(1,'101',1,'2026-11-16 17:04:52','Fiebre alta','se le dio medicamentos'),
(2,'102',1,'2026-11-16 18:00:56','Accidente de trafico','una pierna enyesada'),
(3,'102',1,'2026-11-17 14:13:21','cancer','quimioterapias');
/*!40000 ALTER TABLE `historialmedico` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `IdUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) NOT NULL,
  `ApellidoPaterno` varchar(50) NOT NULL,
  `ApellidoMaterno` varchar(50) DEFAULT NULL,
  `Correo` varchar(100) NOT NULL,
  `ContrasenaHash` varchar(255) NOT NULL,
  `Rol` enum('Administrador','Voluntario') NOT NULL,
  `Activo` tinyint(1) DEFAULT 1,
  PRIMARY KEY (`IdUsuario`),
  UNIQUE KEY `Correo` (`Correo`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

SET @OLD_AUTOCOMMIT=@@AUTOCOMMIT, @@AUTOCOMMIT=0;
LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES
(1,'Oswaldo','Maldonado',NULL,'admin','240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9','Administrador',1);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
COMMIT;
SET AUTOCOMMIT=@OLD_AUTOCOMMIT;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*M!100616 SET NOTE_VERBOSITY=@OLD_NOTE_VERBOSITY */;

-- Dump completed on 2026-11-20 14:11:26
