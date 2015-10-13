SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `UFO_DB` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `UFO_DB` ;

-- -----------------------------------------------------
-- Table `UFO_DB`.`User`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UFO_DB`.`User` (
  `idUser` INT NOT NULL,
  `username` VARCHAR(45) NOT NULL,
  `password` BIGINT NOT NULL,
  `email` VARCHAR(90) NOT NULL,
  PRIMARY KEY (`idUser`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UFO_DB`.`Category`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UFO_DB`.`Category` (
  `idCategory` INT NOT NULL,
  `label` VARCHAR(45) NULL,
  `identifier` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`idCategory`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UFO_DB`.`Artist`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UFO_DB`.`Artist` (
  `idArtist` INT NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  `country` VARCHAR(45) NOT NULL,
  `email` VARCHAR(90) NOT NULL,
  `homePage` VARCHAR(90) NULL,
  `picture` BINARY NULL,
  `video` BINARY NULL,
  `description` MEDIUMTEXT NULL,
  `category` INT(11) NOT NULL,
  PRIMARY KEY (`idArtist`),
  INDEX `fk_category_idx` (`category` ASC),
  CONSTRAINT `fk_category`
    FOREIGN KEY (`category`)
    REFERENCES `UFO_DB`.`Category` (`idCategory`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UFO_DB`.`Venue`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UFO_DB`.`Venue` (
  `idVenue` INT NOT NULL,
  `label` VARCHAR(45) NOT NULL,
  `identifier` VARCHAR(45) NOT NULL,
  `location` VARCHAR(45) NOT NULL,
  `isFireSafe` BOOLEAN NULL,
  `maxNumOfSpectators` VARCHAR(45) NULL,
  PRIMARY KEY (`idVenue`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UFO_DB`.`Performance`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UFO_DB`.`Performance` (
  `idPerformance` INT NOT NULL,
  `start` TIME NOT NULL,
  `duration` TIME NOT NULL,
  `description` LONGTEXT NULL,
  `artist` INT(11) NOT NULL,
  `venue` INT(11) NOT NULL,
  PRIMARY KEY (`idPerformance`),
  INDEX `fk_artist_idx` (`artist` ASC),
  INDEX `fk_venue_idx` (`venue` ASC),
  CONSTRAINT `fk_artist`
    FOREIGN KEY (`artist`)
    REFERENCES `UFO_DB`.`Artist` (`idArtist`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_venue`
    FOREIGN KEY (`venue`)
    REFERENCES `UFO_DB`.`Venue` (`idVenue`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UFO_DB`.`Schedule`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UFO_DB`.`Schedule` (
  `idSchedule` INT NOT NULL,
  `date` DATE NOT NULL,
  `performance` INT(11) NULL,
  PRIMARY KEY (`idSchedule`),
  INDEX `fk_performance_idx` (`performance` ASC),
  CONSTRAINT `fk_performance`
    FOREIGN KEY (`performance`)
    REFERENCES `UFO_DB`.`Performance` (`idPerformance`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


INSERT INTO  `UFO_DB`.`User` (`username`, `password`, email) VALUES ("swk5", "4f2b5f43810fa5d42eda33aa5f4b5c34c7bea3e2", "s1310307036@students.fh-hagenberg.at");
INSERT INTO  `UFO_DB`.`User` (`username`, `password`, email) VALUES  ("s1310307036", "646b777fea9041ed328941e02c4c914182a67a12", "daniell.rotaru@gmail.com");

INSERT INTO `UFO_DB`.`Category` (`label`, `identifier`) VALUES ("Akrobatik");
INSERT INTO `UFO_DB`.`Category` (`label`, `identifier`) VALUES ("Komedy");
INSERT INTO `UFO_DB`.`Category` (`label`, `identifier`) VALUES ("Feuershow");
INSERT INTO `UFO_DB`.`Category` (`label`, `identifier`) VALUES ("Jonglage");
INSERT INTO `UFO_DB`.`Category` (`label`, `identifier`) VALUES ("LuftAkrobatik");
INSERT INTO `UFO_DB`.`Category` (`label`, `identifier`) VALUES ("Musik");
INSERT INTO `UFO_DB`.`Category` (`label`, `identifier`) VALUES ("Samba");
INSERT INTO `UFO_DB`.`Category` (`label`, `identifier`) VALUES ("Tanz");
INSERT INTO `UFO_DB`.`Category` (`label`, `identifier`) VALUES ("Figurentheater");

INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Dreifaltigkeitssäule", "H1", "Hauptpplatz", true, 100);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Mader Reisen", "H2", "Hauptpplatz", true, 150);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Haltestelle", "H3", "Hauptpplatz", true, 110);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Altes Rathaus", "H4", "Hauptpplatz", true, 120);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Fa. Mammut", "H5", "Hauptpplatz", true, 100);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Bank Austria", "H6", "Hauptpplatz", true, 120);

INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Keplersalon", "P1", "Pfarrplatz und Domgasse", false, 80);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Adalbert-Stifter-Platz", "P2", "Pfarrplatz und Domgasse", false, 70);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Stadtpfarrkirche", "P3", "Pfarrplatz und Domgasse", false, 60);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Pfarrgasse 3", "P4", "Pfarrplatz und Domgasse", false, 50);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Pfarrplatz", "P5", "Pfarrplatz und Domgasse", false, 85);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Domgasse", "P6", "Pfarrplatz und Domgasse", false, 40);

INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Klosterstraße 7", "A1", "Altstadt", false, 50);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Landhaus", "A2", "Altstadt", false, 60);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Altstadt 13", "A3", "Altstadt", false, 60;
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Alter Markt", "A4", "Altstadt", false, 55);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Hofgasse 13", "A5", "Altstadt", false, 40);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Schlossmuseum", "A6", "Altstadt", true, 10);

INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Annagasse", "L1", "Landstraße", false, 40);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Taubenmarkt", "L2", "Landstraße", false, 45);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Bethlehemstraße", "L3", "Landstraße", false, 55);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Spittelwiese 4", "L4", "Landstraße", false, 55);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Ursulinenkirche", "L5", "Landstraße", false, 50);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Karmeliterkirche", "L6", "Landstraße", false, 45);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("OK-Platz", "L8", "Landstraße", false, 80);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Martin-Luther-Platz", "L9", "Landstraße", false, 70);

INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Cafe Traxlmayr", "X1", "Promenade", false, 55);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Sparkasse", "X2", "Promenade", false, 50);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Promenade 17", "X3", "Promenade", false, 45);
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Medienhaus Wimmer", "X4", "Promenade", false, 40);





SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
