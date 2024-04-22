-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Creato il: Apr 22, 2024 alle 10:08
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
(18, '2024-04-15T11:09:47.3991292+02:00', '302362-1'),
(19, '2024-04-15T11:09:48.3991292+02:00', '302362-1');

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
(1, 858, 809, '15/04/2024 11:09:50,227', 18),
(2, 857, 807, '15/04/2024 11:09:50,726', 18),
(3, 857, 805, '15/04/2024 11:09:51,226', 18),
(4, 857, 797, '15/04/2024 11:09:51,730', 18),
(5, 857, 819, '15/04/2024 11:09:52,229', 18),
(6, 857, 797, '15/04/2024 11:09:52,729', 18),
(7, 857, 800, '15/04/2024 11:09:53,229', 18),
(8, 857, 801, '15/04/2024 11:09:53,733', 18),
(9, 858, 809, '15/04/2024 11:09:50,227', 19),
(10, 857, 807, '15/04/2024 11:09:50,726', 19),
(11, 857, 805, '15/04/2024 11:09:51,226', 19),
(12, 857, 797, '15/04/2024 11:09:51,730', 19),
(13, 857, 819, '15/04/2024 11:09:52,229', 19),
(14, 857, 797, '15/04/2024 11:09:52,729', 19),
(15, 857, 800, '15/04/2024 11:09:53,229', 19),
(16, 857, 801, '15/04/2024 11:09:53,733', 19);

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
  MODIFY `id_misurazione` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT per la tabella `tipo`
--
ALTER TABLE `tipo`
  MODIFY `Id_valvola` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT per la tabella `valori`
--
ALTER TABLE `valori`
  MODIFY `id_valori` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

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
