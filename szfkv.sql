-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Dec 16. 18:41
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `szfkv`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szfkv`
--

CREATE TABLE `szfkv` (
  `hely` int(255) NOT NULL,
  `nev` varchar(255) NOT NULL,
  `elsoLeng` float NOT NULL,
  `masoLeng` float NOT NULL,
  `harmLeng` float NOT NULL,
  `legjob` float GENERATED ALWAYS AS (greatest(`elsoLeng`,`masoLeng`,`harmLeng`)) STORED,
  `id` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `szfkv`
--

INSERT INTO `szfkv` (`hely`, `nev`, `elsoLeng`, `masoLeng`, `harmLeng`, `id`) VALUES
(3, 'bela', 8.73, 2.24, 1.54, 1),
(4, 'alma', 1.42, 0.91, 9.56, 2),
(2, 'kecske', 4.65, 7.43, 2.53, 3),
(1, 'abéls', 6.76, 2.23, 1.2, 4);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `szfkv`
--
ALTER TABLE `szfkv`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `szfkv`
--
ALTER TABLE `szfkv`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
