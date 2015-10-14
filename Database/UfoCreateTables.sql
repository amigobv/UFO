SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `UFO_DB` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `UFO_DB` ;

-- -----------------------------------------------------
-- Table `UFO_DB`.`User`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UFO_DB`.`User` (
    `idUser` INT NOT NULL AUTO_INCREMENT,
    `username` VARCHAR(45) NOT NULL,
    `password` BIGINT NOT NULL,
    `email` VARCHAR(90) NOT NULL,
    PRIMARY KEY (`idUser`)
)  ENGINE=InnoDB;


-- -----------------------------------------------------
-- Table `UFO_DB`.`Category`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UFO_DB`.`Category` (
    `idCategory` INT NOT NULL AUTO_INCREMENT,
    `label` VARCHAR(45) NOT NULL,
    `identifier` VARCHAR(10) NOT NULL,
    PRIMARY KEY (`idCategory`)
)  ENGINE=InnoDB;


-- -----------------------------------------------------
-- Table `UFO_DB`.`Artist`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UFO_DB`.`Artist` (
    `idArtist` INT NOT NULL AUTO_INCREMENT,
    `name` VARCHAR(45) NOT NULL,
    `country` VARCHAR(45) NOT NULL,
    `email` VARCHAR(90) NOT NULL,
    `homepage` VARCHAR(90) NULL,
    `picture` BINARY NULL,
    `video` BINARY NULL,
    `description` MEDIUMTEXT NULL,
    `category` INT(11) NOT NULL,
    PRIMARY KEY (`idArtist`),
    INDEX `fk_category_idx` (`category` ASC),
    CONSTRAINT `fk_category` FOREIGN KEY (`category`)
        REFERENCES `UFO_DB`.`Category` (`idCategory`)
        ON DELETE NO ACTION ON UPDATE NO ACTION
)  ENGINE=InnoDB;


-- -----------------------------------------------------
-- Table `UFO_DB`.`Venue`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UFO_DB`.`Venue` (
    `idVenue` INT NOT NULL AUTO_INCREMENT,
    `label` VARCHAR(45) NOT NULL,
    `identifier` VARCHAR(45) NOT NULL,
    `location` VARCHAR(45) NOT NULL,
    `isFireSafe` BOOLEAN NULL,
    `maxNumOfSpectators` INT(11) NULL,
    PRIMARY KEY (`idVenue`)
)  ENGINE=InnoDB;


-- -----------------------------------------------------
-- Table `UFO_DB`.`Performance`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UFO_DB`.`Performance` (
    `idPerformance` INT NOT NULL AUTO_INCREMENT,
    `startTime` TIME NOT NULL,
    `duration` TIME NOT NULL,
    `description` LONGTEXT NULL,
    `artist` INT(11) NOT NULL,
    `venue` INT(11) NOT NULL,
    PRIMARY KEY (`idPerformance`),
    INDEX `fk_artist_idx` (`artist` ASC),
    INDEX `fk_venue_idx` (`venue` ASC),
    CONSTRAINT `fk_artist` FOREIGN KEY (`artist`)
        REFERENCES `UFO_DB`.`Artist` (`idArtist`)
        ON DELETE NO ACTION ON UPDATE NO ACTION,
    CONSTRAINT `fk_venue` FOREIGN KEY (`venue`)
        REFERENCES `UFO_DB`.`Venue` (`idVenue`)
        ON DELETE NO ACTION ON UPDATE NO ACTION
)  ENGINE=InnoDB;


-- -----------------------------------------------------
-- Table `UFO_DB`.`Schedule`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UFO_DB`.`Schedule` (
    `idSchedule` INT NOT NULL AUTO_INCREMENT,
    `day` DATE NOT NULL,
    `performance` INT(11) NULL,
    PRIMARY KEY (`idSchedule`),
    INDEX `fk_performance_idx` (`performance` ASC),
    CONSTRAINT `fk_performance` FOREIGN KEY (`performance`)
        REFERENCES `UFO_DB`.`Performance` (`idPerformance`)
        ON DELETE NO ACTION ON UPDATE NO ACTION
)  ENGINE=InnoDB;
  
SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
