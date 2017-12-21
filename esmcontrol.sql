-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: 21-Dez-2017 às 15:16
-- Versão do servidor: 5.7.19
-- PHP Version: 5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `esmcontrol`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_login`
--

DROP TABLE IF EXISTS `tb_login`;
CREATE TABLE IF NOT EXISTS `tb_login` (
  `idLogin` int(11) NOT NULL AUTO_INCREMENT,
  `nomeLogin` varchar(12) COLLATE utf8_bin NOT NULL,
  `senhaLogin` varchar(120) COLLATE utf8_bin NOT NULL,
  `dataCadastroLogin` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idLogin`)
) ENGINE=MyISAM AUTO_INCREMENT=21 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Extraindo dados da tabela `tb_login`
--

INSERT INTO `tb_login` (`idLogin`, `nomeLogin`, `senhaLogin`, `dataCadastroLogin`) VALUES
(18, 'halshet', '$2a$10$YYifmRmNRp3FLjfmlwnN7uyghWBlB7pCGF9ARCkvWtJ6ek.t/wn5i', '2017-12-21 14:23:47'),
(19, 'hehe', '$2a$10$AHfuOplwUqHvx4npy0me5OWE.TqynOSXAblBEWwKgsBHpcrQArKtq', '2017-12-21 14:25:25'),
(17, 'JEJE', '$2a$10$Hd4EoTDRqizLTnQSmqJsee2vmZseqdqc1S7f6YDkS7xOqz/0.GAce', '2017-12-21 14:17:06'),
(16, 'hals', '$2a$10$S4iXUtlXmn10KYIR9/W9v.4.AW8uASczHGzU1ot0sIwS7A4VLr21i', '2017-12-21 13:40:40'),
(15, 'hals', '$2a$10$nt64Bnpz0mJUD4tzPjLcsuTgAfqlTlsj.sPfM1LAs3GUb3CuLsm8C', '2017-12-21 13:39:43'),
(14, 'heitor', '$2y$10$aWxwP169kj/y7cKHBUMhTeg.0uJdyYouqZw74ERfe/XvSQ0gkUzuu', '2017-12-21 12:26:13'),
(20, 'lalal', '$2a$10$35dRyAPetzzS7Bu8ZORu5.YOIXSC7tEK0uwKGRsk2dzEcR/JoAJMy', '2017-12-21 14:26:47');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
