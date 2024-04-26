-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Creato il: Apr 26, 2024 alle 15:58
-- Versione del server: 10.4.28-MariaDB
-- Versione PHP: 8.2.12

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
  `id_misurazione` int(11) NOT NULL,
  `data_misurazione` varchar(35) NOT NULL,
  `ser_valvola` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `misurazioni`
--

INSERT INTO `misurazioni` (`id_misurazione`, `data_misurazione`, `ser_valvola`) VALUES
(44, '2026-05-16T11:09:47.399122+02:00', '450027-9'),
(45, '2024-05-16T11:09:47.399122+02:00', '302362-1'),
(46, '2025-04-16T11:09:47.399122+02:00', '316027-1'),
(47, '2027-02-16T11:09:47.399122+02:00', '316027-9'),
(48, '2023-05-16T11:09:47.399122+02:00', '886027-1'),
(49, '2022-07-16T11:09:47.399122+02:00', '302362-1'),
(50, '2021-05-16T11:09:47.399122+02:00', '316027-1'),
(51, '2022-05-18T11:09:47.399122+02:00', '450027-9'),
(52, '2021-05-16T11:09:47.399122+02:00', '886027-1');

-- --------------------------------------------------------

--
-- Struttura della tabella `specifiche`
--

CREATE TABLE `specifiche` (
  `ID_spec` int(11) NOT NULL,
  `ID_tipo` int(11) NOT NULL,
  `BTO` int(11) DEFAULT NULL,
  `RUN_op` int(11) DEFAULT NULL,
  `ETO` int(11) DEFAULT NULL,
  `BTC` int(11) DEFAULT NULL,
  `RUN_cl` int(11) DEFAULT NULL,
  `ETC` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `specifiche`
--

INSERT INTO `specifiche` (`ID_spec`, `ID_tipo`, `BTO`, `RUN_op`, `ETO`, `BTC`, `RUN_cl`, `ETC`) VALUES
(1, 1, 106, 40, 78, 106, 40, 65),
(2, 3, 105, 50, 60, 50, 35, 70);

-- --------------------------------------------------------

--
-- Struttura della tabella `tipo`
--

CREATE TABLE `tipo` (
  `Id_valvola` int(11) NOT NULL,
  `VALVE CODE` varchar(100) NOT NULL,
  `VALVE DESCRIPTION` varchar(500) NOT NULL,
  `GEAR MODEL` varchar(100) NOT NULL,
  `M.A. GEAR` int(11) NOT NULL,
  `materiale` varchar(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `tipo`
--

INSERT INTO `tipo` (`Id_valvola`, `VALVE CODE`, `VALVE DESCRIPTION`, `GEAR MODEL`, `M.A. GEAR`, `materiale`) VALUES
(1, 'HAT6TF0064', 'BSE-S 30\" #600-SF LF2/XM19/CF8M/XM-19+RPTFE-P', 'FORCAST EG50K', 287, '000'),
(3, 'V136F89000', 'TOBV 36\" #150 DF RF SERIE.A CRYO GEAR-LD-DRIP.PL-SP.EXT', 'CUM WG400', 157, '000');

-- --------------------------------------------------------

--
-- Struttura della tabella `valori`
--

CREATE TABLE `valori` (
  `id_valori` int(11) NOT NULL,
  `coppia` float NOT NULL,
  `angolo` float NOT NULL,
  `orario_valore` varchar(50) NOT NULL,
  `id_misurazione` int(11) NOT NULL,
  `Fase` varchar(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `valori`
--

INSERT INTO `valori` (`id_valori`, `coppia`, `angolo`, `orario_valore`, `id_misurazione`, `Fase`) VALUES
(282, 250, 1, '15/04/2024 11:09:50,227', 44, 'a'),
(283, 120, 2, '15/04/2024 11:09:50,726', 44, 'a'),
(284, 120, 3, '15/04/2024 11:09:51,226', 44, 'a'),
(285, 125, 4, '15/04/2024 11:09:51,730', 44, 'a'),
(286, 150, 5, '15/04/2024 11:09:52,229', 44, 'a'),
(287, 170, 6, '15/04/2024 11:09:52,729', 44, 'a'),
(288, 200, 7, '15/04/2024 11:09:53,229', 44, 'a'),
(289, 230, 8, '15/04/2024 11:09:53,733', 44, 'a'),
(290, 400, 8, '15/04/2024 11:09:50,227', 44, 'c'),
(291, 280, 7, '15/04/2024 11:09:50,726', 44, 'c'),
(292, 120, 6, '15/04/2024 11:09:51,226', 44, 'c'),
(293, 320, 5, '15/04/2024 11:09:51,730', 44, 'c'),
(294, 110, 4, '15/04/2024 11:09:52,229', 44, 'c'),
(295, 100, 3, '15/04/2024 11:09:52,729', 44, 'c'),
(296, 150, 2, '15/04/2024 11:09:53,229', 44, 'c'),
(297, 20, 1, '15/04/2024 11:09:53,733', 44, 'c'),
(298, 607, 1, '26/04/2024 11:09:50,227', 45, 'a'),
(299, 810, 2, '26/04/2024 11:09:50,726', 45, 'a'),
(300, 557, 3, '26/04/2024 11:09:51,226', 45, 'a'),
(301, 931, 4, '26/04/2024 11:09:51,730', 45, 'a'),
(302, 480, 5, '26/04/2024 11:09:52,229', 45, 'a'),
(303, 704, 6, '26/04/2024 11:09:52,729', 45, 'a'),
(304, 725, 7, '26/04/2024 11:09:53,229', 45, 'a'),
(305, 342, 8, '26/04/2024 11:09:53,733', 45, 'a'),
(306, 615, 8, '26/04/2024 11:09:50,227', 45, 'c'),
(307, 873, 7, '26/04/2024 11:09:50,726', 45, 'c'),
(308, 651, 6, '26/04/2024 11:09:51,226', 45, 'c'),
(309, 779, 5, '26/04/2024 11:09:51,730', 45, 'c'),
(310, 812, 4, '26/04/2024 11:09:52,229', 45, 'c'),
(311, 219, 3, '26/04/2024 11:09:52,729', 45, 'c'),
(312, 881, 2, '26/04/2024 11:09:53,229', 45, 'c'),
(313, 145, 1, '26/04/2024 11:09:53,733', 45, 'c'),
(314, 536, 1, '27/04/2024 11:09:50,227', 46, 'a'),
(315, 792, 2, '27/04/2024 11:09:50,726', 46, 'a'),
(316, 208, 3, '27/04/2024 11:09:51,226', 46, 'a'),
(317, 488, 4, '27/04/2024 11:09:51,730', 46, 'a'),
(318, 328, 5, '27/04/2024 11:09:52,229', 46, 'a'),
(319, 657, 6, '27/04/2024 11:09:52,729', 46, 'a'),
(320, 918, 7, '27/04/2024 11:09:53,229', 46, 'a'),
(321, 743, 8, '27/04/2024 11:09:53,733', 46, 'a'),
(322, 233, 8, '27/04/2024 11:09:50,227', 46, 'c'),
(323, 282, 7, '27/04/2024 11:09:50,726', 46, 'c'),
(324, 962, 6, '27/04/2024 11:09:51,226', 46, 'c'),
(325, 148, 5, '27/04/2024 11:09:51,730', 46, 'c'),
(326, 527, 4, '27/04/2024 11:09:52,229', 46, 'c'),
(327, 662, 3, '27/04/2024 11:09:52,729', 46, 'c'),
(328, 888, 2, '27/04/2024 11:09:53,229', 46, 'c'),
(329, 486, 1, '27/04/2024 11:09:53,733', 46, 'c'),
(330, 691, 1, '28/04/2024 11:09:50,227', 47, 'a'),
(331, 320, 2, '28/04/2024 11:09:50,726', 47, 'a'),
(332, 755, 3, '28/04/2024 11:09:51,226', 47, 'a'),
(333, 847, 4, '28/04/2024 11:09:51,730', 47, 'a'),
(334, 509, 5, '28/04/2024 11:09:52,229', 47, 'a'),
(335, 694, 6, '28/04/2024 11:09:52,729', 47, 'a'),
(336, 726, 7, '28/04/2024 11:09:53,229', 47, 'a'),
(337, 391, 8, '28/04/2024 11:09:53,733', 47, 'a'),
(338, 322, 8, '28/04/2024 11:09:50,227', 47, 'c'),
(339, 289, 7, '28/04/2024 11:09:50,726', 47, 'c'),
(340, 365, 6, '28/04/2024 11:09:51,226', 47, 'c'),
(341, 108, 5, '28/04/2024 11:09:51,730', 47, 'c'),
(342, 625, 4, '28/04/2024 11:09:52,229', 47, 'c'),
(343, 671, 3, '28/04/2024 11:09:52,729', 47, 'c'),
(344, 726, 2, '28/04/2024 11:09:53,229', 47, 'c'),
(345, 161, 1, '28/04/2024 11:09:53,733', 47, 'c'),
(346, 854, 1, '29/04/2024 11:09:50,227', 48, 'a'),
(347, 444, 2, '29/04/2024 11:09:50,726', 48, 'a'),
(348, 922, 3, '29/04/2024 11:09:51,226', 48, 'a'),
(349, 499, 4, '29/04/2024 11:09:51,730', 48, 'a'),
(350, 227, 5, '29/04/2024 11:09:52,229', 48, 'a'),
(351, 833, 6, '29/04/2024 11:09:52,729', 48, 'a'),
(352, 534, 7, '29/04/2024 11:09:53,229', 48, 'a'),
(353, 185, 8, '29/04/2024 11:09:53,733', 48, 'a'),
(354, 914, 8, '29/04/2024 11:09:50,227', 48, 'c'),
(355, 473, 7, '29/04/2024 11:09:50,726', 48, 'c'),
(356, 670, 6, '29/04/2024 11:09:51,226', 48, 'c'),
(357, 570, 5, '29/04/2024 11:09:51,730', 48, 'c'),
(358, 260, 4, '29/04/2024 11:09:52,229', 48, 'c'),
(359, 115, 3, '29/04/2024 11:09:52,729', 48, 'c'),
(360, 295, 2, '29/04/2024 11:09:53,229', 48, 'c'),
(361, 740, 1, '29/04/2024 11:09:53,733', 48, 'c'),
(362, 649, 1, '30/04/2024 11:09:50,227', 49, 'a'),
(363, 520, 2, '30/04/2024 11:09:50,726', 49, 'a'),
(364, 192, 3, '30/04/2024 11:09:51,226', 49, 'a'),
(365, 963, 4, '30/04/2024 11:09:51,730', 49, 'a'),
(366, 807, 5, '30/04/2024 11:09:52,229', 49, 'a'),
(367, 419, 6, '30/04/2024 11:09:52,729', 49, 'a'),
(368, 625, 7, '30/04/2024 11:09:53,229', 49, 'a'),
(369, 378, 8, '30/04/2024 11:09:53,733', 49, 'a'),
(370, 826, 8, '30/04/2024 11:09:50,227', 49, 'c'),
(371, 954, 7, '30/04/2024 11:09:50,726', 49, 'c'),
(372, 211, 6, '30/04/2024 11:09:51,226', 49, 'c'),
(373, 597, 5, '30/04/2024 11:09:51,730', 49, 'c'),
(374, 351, 4, '30/04/2024 11:09:52,229', 49, 'c'),
(375, 269, 3, '30/04/2024 11:09:52,729', 49, 'c'),
(376, 701, 2, '30/04/2024 11:09:53,229', 49, 'c'),
(377, 442, 1, '30/04/2024 11:09:53,733', 49, 'c'),
(378, 949, 1, '01/05/2024 11:09:50,227', 50, 'a'),
(379, 326, 2, '01/05/2024 11:09:50,726', 50, 'a'),
(380, 570, 3, '01/05/2024 11:09:51,226', 50, 'a'),
(381, 194, 4, '01/05/2024 11:09:51,730', 50, 'a'),
(382, 788, 5, '01/05/2024 11:09:52,229', 50, 'a'),
(383, 378, 6, '01/05/2024 11:09:52,729', 50, 'a'),
(384, 872, 7, '01/05/2024 11:09:53,229', 50, 'a'),
(385, 104, 8, '01/05/2024 11:09:53,733', 50, 'a'),
(386, 982, 8, '01/05/2024 11:09:50,227', 50, 'c'),
(387, 241, 7, '01/05/2024 11:09:50,726', 50, 'c'),
(388, 833, 6, '01/05/2024 11:09:51,226', 50, 'c'),
(389, 219, 5, '01/05/2024 11:09:51,730', 50, 'c'),
(390, 513, 4, '01/05/2024 11:09:52,229', 50, 'c'),
(391, 489, 3, '01/05/2024 11:09:52,729', 50, 'c'),
(392, 712, 2, '01/05/2024 11:09:53,229', 50, 'c'),
(393, 874, 1, '01/05/2024 11:09:53,733', 50, 'c'),
(394, 370, 1, '02/05/2024 11:09:50,227', 51, 'a'),
(395, 669, 2, '02/05/2024 11:09:50,726', 51, 'a'),
(396, 890, 3, '02/05/2024 11:09:51,226', 51, 'a'),
(397, 533, 4, '02/05/2024 11:09:51,730', 51, 'a'),
(398, 342, 5, '02/05/2024 11:09:52,229', 51, 'a'),
(399, 778, 6, '02/05/2024 11:09:52,729', 51, 'a'),
(400, 926, 7, '02/05/2024 11:09:53,229', 51, 'a'),
(401, 689, 8, '02/05/2024 11:09:53,733', 51, 'a'),
(402, 295, 8, '02/05/2024 11:09:50,227', 51, 'c'),
(403, 988, 7, '02/05/2024 11:09:50,726', 51, 'c'),
(404, 165, 6, '02/05/2024 11:09:51,226', 51, 'c'),
(405, 235, 5, '02/05/2024 11:09:51,730', 51, 'c'),
(406, 647, 4, '02/05/2024 11:09:52,229', 51, 'c'),
(407, 431, 3, '02/05/2024 11:09:52,729', 51, 'c'),
(408, 839, 2, '02/05/2024 11:09:53,229', 51, 'c'),
(409, 709, 1, '02/05/2024 11:09:53,733', 51, 'c'),
(410, 854, 1, '03/05/2024 11:09:50,227', 52, 'a'),
(411, 444, 2, '03/05/2024 11:09:50,726', 52, 'a'),
(412, 922, 3, '03/05/2024 11:09:51,226', 52, 'a'),
(413, 499, 4, '03/05/2024 11:09:51,730', 52, 'a'),
(414, 227, 5, '03/05/2024 11:09:52,229', 52, 'a'),
(415, 833, 6, '03/05/2024 11:09:52,729', 52, 'a'),
(416, 534, 7, '03/05/2024 11:09:53,229', 52, 'a'),
(417, 185, 8, '03/05/2024 11:09:53,733', 52, 'a'),
(418, 914, 8, '03/05/2024 11:09:50,227', 52, 'c'),
(419, 473, 7, '03/05/2024 11:09:50,726', 52, 'c'),
(420, 670, 6, '03/05/2024 11:09:51,226', 52, 'c'),
(421, 570, 5, '03/05/2024 11:09:51,730', 52, 'c'),
(422, 260, 4, '03/05/2024 11:09:52,229', 52, 'c'),
(423, 115, 3, '03/05/2024 11:09:52,729', 52, 'c'),
(424, 295, 2, '03/05/2024 11:09:53,229', 52, 'c'),
(425, 740, 1, '03/05/2024 11:09:53,733', 52, 'c');

-- --------------------------------------------------------

--
-- Struttura della tabella `valvola`
--

CREATE TABLE `valvola` (
  `SERIAL_NUMBER` varchar(50) NOT NULL,
  `OMB JOB NUMBER` varchar(50) NOT NULL,
  `Tipo_valvola` int(11) NOT NULL
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
-- Indici per le tabelle `specifiche`
--
ALTER TABLE `specifiche`
  ADD PRIMARY KEY (`ID_spec`),
  ADD KEY `id_tipo` (`ID_tipo`);

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
  MODIFY `id_misurazione` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=53;

--
-- AUTO_INCREMENT per la tabella `specifiche`
--
ALTER TABLE `specifiche`
  MODIFY `ID_spec` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT per la tabella `tipo`
--
ALTER TABLE `tipo`
  MODIFY `Id_valvola` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT per la tabella `valori`
--
ALTER TABLE `valori`
  MODIFY `id_valori` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=426;

--
-- Limiti per le tabelle scaricate
--

--
-- Limiti per la tabella `misurazioni`
--
ALTER TABLE `misurazioni`
  ADD CONSTRAINT `ser_valv` FOREIGN KEY (`ser_valvola`) REFERENCES `valvola` (`SERIAL_NUMBER`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limiti per la tabella `specifiche`
--
ALTER TABLE `specifiche`
  ADD CONSTRAINT `id_tipo` FOREIGN KEY (`ID_tipo`) REFERENCES `tipo` (`Id_valvola`) ON DELETE CASCADE ON UPDATE NO ACTION;

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
