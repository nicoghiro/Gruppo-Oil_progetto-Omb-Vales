-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Creato il: Apr 23, 2024 alle 18:45
-- Versione del server: 8.0.32
-- Versione PHP: 8.0.22

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `my_ombvalvesdata`
--

-- --------------------------------------------------------

--
-- Struttura della tabella `misurazioni`
--

CREATE TABLE `misurazioni` (
  `id_misurazione` int NOT NULL,
  `data_misurazione` varchar(35) COLLATE utf8mb4_general_ci NOT NULL,
  `ser_valvola` varchar(50) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `misurazioni`
--

INSERT INTO `misurazioni` (`id_misurazione`, `data_misurazione`, `ser_valvola`) VALUES
(35, '2026-05-16T11:09:47.399122+02:00', '302362-1'),
(36, '2025-05-16T11:09:47.399122+02:00', '302362-1'),
(37, '2024-05-16T11:09:47.399122+02:00', '316027-1'),
(38, '2025-05-16T11:09:47.399122+02:00', '316027-1'),
(39, '2025-05-16T11:09:47.399122+02:00', '450027-9'),
(40, '2026-05-16T11:09:47.399122+02:00', '450027-9');

-- --------------------------------------------------------

--
-- Struttura della tabella `tipo`
--

CREATE TABLE `tipo` (
  `Id_valvola` int NOT NULL,
  `VALVE CODE` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `VALVE DESCRIPTION` varchar(500) COLLATE utf8mb4_general_ci NOT NULL,
  `GEAR MODEL` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `M.A. GEAR` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `tipo`
--

INSERT INTO `tipo` (`Id_valvola`, `VALVE CODE`, `VALVE DESCRIPTION`, `GEAR MODEL`, `M.A. GEAR`) VALUES
(1, 'HAT6TF0064000', 'BSE-S 30\" #600-SF LF2/XM19/CF8M/XM-19+RPTFE-P', 'FORCAST EG50K', 287),
(3, 'V136F89000000', 'TOBV 36\" #150 DF RF SERIE.A CRYO GEAR-LD-DRIP.PL-SP.EXT', 'CUM WG400', 157);

-- --------------------------------------------------------

--
-- Struttura della tabella `valori`
--

CREATE TABLE `valori` (
  `id_valori` int NOT NULL,
  `coppia` float NOT NULL,
  `angolo` float NOT NULL,
  `orario_valore` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `id_misurazione` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `valori`
--

INSERT INTO `valori` (`id_valori`, `coppia`, `angolo`, `orario_valore`, `id_misurazione`) VALUES
(186, 858, 809, '15/04/2024 11:09:50,227', 35),
(187, 857, 807, '15/04/2024 11:09:50,726', 35),
(188, 857, 805, '15/04/2024 11:09:51,226', 35),
(189, 857, 797, '15/04/2024 11:09:51,730', 35),
(190, 857, 819, '15/04/2024 11:09:52,229', 35),
(191, 857, 797, '15/04/2024 11:09:52,729', 35),
(192, 857, 800, '15/04/2024 11:09:53,229', 35),
(193, 857, 801, '15/04/2024 11:09:53,733', 35),
(194, 858, 809, '15/04/2024 11:09:50,227', 36),
(195, 857, 807, '15/04/2024 11:09:50,726', 36),
(196, 857, 805, '15/04/2024 11:09:51,226', 36),
(197, 857, 797, '15/04/2024 11:09:51,730', 36),
(198, 857, 819, '15/04/2024 11:09:52,229', 36),
(199, 857, 797, '15/04/2024 11:09:52,729', 36),
(200, 857, 800, '15/04/2024 11:09:53,229', 36),
(201, 857, 801, '15/04/2024 11:09:53,733', 36),
(202, 858, 809, '15/04/2024 11:09:50,227', 37),
(203, 857, 807, '15/04/2024 11:09:50,726', 37),
(204, 857, 805, '15/04/2024 11:09:51,226', 37),
(205, 857, 797, '15/04/2024 11:09:51,730', 37),
(206, 857, 819, '15/04/2024 11:09:52,229', 37),
(207, 857, 797, '15/04/2024 11:09:52,729', 37),
(208, 857, 800, '15/04/2024 11:09:53,229', 37),
(209, 857, 801, '15/04/2024 11:09:53,733', 37),
(210, 858, 809, '15/04/2024 11:09:50,227', 38),
(211, 857, 807, '15/04/2024 11:09:50,726', 38),
(212, 857, 805, '15/04/2024 11:09:51,226', 38),
(213, 857, 797, '15/04/2024 11:09:51,730', 38),
(214, 857, 819, '15/04/2024 11:09:52,229', 38),
(215, 857, 797, '15/04/2024 11:09:52,729', 38),
(216, 857, 800, '15/04/2024 11:09:53,229', 38),
(217, 857, 801, '15/04/2024 11:09:53,733', 38),
(218, 858, 809, '15/04/2024 11:09:50,227', 39),
(219, 857, 807, '15/04/2024 11:09:50,726', 39),
(220, 857, 805, '15/04/2024 11:09:51,226', 39),
(221, 857, 797, '15/04/2024 11:09:51,730', 39),
(222, 857, 819, '15/04/2024 11:09:52,229', 39),
(223, 857, 797, '15/04/2024 11:09:52,729', 39),
(224, 857, 800, '15/04/2024 11:09:53,229', 39),
(225, 857, 801, '15/04/2024 11:09:53,733', 39),
(226, 858, 809, '15/04/2024 11:09:50,227', 40),
(227, 857, 807, '15/04/2024 11:09:50,726', 40),
(228, 857, 805, '15/04/2024 11:09:51,226', 40),
(229, 857, 797, '15/04/2024 11:09:51,730', 40),
(230, 857, 819, '15/04/2024 11:09:52,229', 40),
(231, 857, 797, '15/04/2024 11:09:52,729', 40),
(232, 857, 800, '15/04/2024 11:09:53,229', 40),
(233, 857, 801, '15/04/2024 11:09:53,733', 40);

-- --------------------------------------------------------

--
-- Struttura della tabella `valvola`
--

CREATE TABLE `valvola` (
  `SERIAL_NUMBER` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `OMB JOB NUMBER` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `Tipo_valvola` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `valvola`
--

INSERT INTO `valvola` (`SERIAL_NUMBER`, `OMB JOB NUMBER`, `Tipo_valvola`) VALUES
('302362-1', '01/2300053', 3),
('316027-1', '01/2300349', 1),
('316027-9', '71/2300053', 3),
('450027-9', '69/2300053', 3),
('886027-1', '15/2300349', 3);

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `misurazioni`
--
ALTER TABLE `misurazioni`
  ADD PRIMARY KEY (`id_misurazione`),
  ADD KEY `ser_valv` (`ser_valvola`);

--
-- Indici per le tabelle `tipo`
--
ALTER TABLE `tipo`
  ADD PRIMARY KEY (`Id_valvola`);

--
-- Indici per le tabelle `valori`
--
ALTER TABLE `valori`
  ADD PRIMARY KEY (`id_valori`),
  ADD KEY `rif_misurazioni` (`id_misurazione`);

--
-- Indici per le tabelle `valvola`
--
ALTER TABLE `valvola`
  ADD PRIMARY KEY (`SERIAL_NUMBER`),
  ADD KEY `Tipo_valvola` (`Tipo_valvola`);

--
-- AUTO_INCREMENT per le tabelle scaricate
--

--
-- AUTO_INCREMENT per la tabella `misurazioni`
--
ALTER TABLE `misurazioni`
  MODIFY `id_misurazione` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT per la tabella `tipo`
--
ALTER TABLE `tipo`
  MODIFY `Id_valvola` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT per la tabella `valori`
--
ALTER TABLE `valori`
  MODIFY `id_valori` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=234;

--
-- Limiti per le tabelle scaricate
--

--
-- Limiti per la tabella `misurazioni`
--
ALTER TABLE `misurazioni`
  ADD CONSTRAINT `ser_valv` FOREIGN KEY (`ser_valvola`) REFERENCES `valvola` (`SERIAL_NUMBER`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limiti per la tabella `valori`
--
ALTER TABLE `valori`
  ADD CONSTRAINT `rif_misurazioni` FOREIGN KEY (`id_misurazione`) REFERENCES `misurazioni` (`id_misurazione`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limiti per la tabella `valvola`
--
ALTER TABLE `valvola`
  ADD CONSTRAINT `Tipo_valvola` FOREIGN KEY (`Tipo_valvola`) REFERENCES `tipo` (`Id_valvola`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
