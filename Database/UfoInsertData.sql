-- -----------------------------------------------------
-- Insert Users
-- -----------------------------------------------------

INSERT INTO  `UFO_DB`.`User` (`username`, `password`, email) VALUES ("swk5", "4f2b5f43810fa5d42eda33aa5f4b5c34c7bea3e2", "s1310307036@students.fh-hagenberg.at");
INSERT INTO  `UFO_DB`.`User` (`username`, `password`, email) VALUES  ("s1310307036", "646b777fea9041ed328941e02c4c914182a67a12", "daniell.rotaru@gmail.com");

-- -----------------------------------------------------
-- Insert Categories
-- -----------------------------------------------------

INSERT INTO `UFO_DB`.`Category` (`label`, `identifier`) VALUES ("Akrobatik", "A");
INSERT INTO `UFO_DB`.`Category` (`label`, `identifier`) VALUES ("Komedy", "K");
INSERT INTO `UFO_DB`.`Category` (`label`, `identifier`) VALUES ("Feuershow", "F");
INSERT INTO `UFO_DB`.`Category` (`label`, `identifier`) VALUES ("Jonglage", "J");
INSERT INTO `UFO_DB`.`Category` (`label`, `identifier`) VALUES ("LuftAkrobatik", "L");
INSERT INTO `UFO_DB`.`Category` (`label`, `identifier`) VALUES ("Musik", "M");
INSERT INTO `UFO_DB`.`Category` (`label`, `identifier`) VALUES ("Samba", "S");
INSERT INTO `UFO_DB`.`Category` (`label`, `identifier`) VALUES ("Tanz", "T");
INSERT INTO `UFO_DB`.`Category` (`label`, `identifier`) VALUES ("Figurentheater", "Fig");

-- -----------------------------------------------------
-- Insert Venues
-- -----------------------------------------------------

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
INSERT INTO `UFO_DB`.`Venue` (`label`, `identifier`, `location`, `isFireSafe`, `maxNumOfSpectators`) VALUES ("Altstadt 13", "A3", "Altstadt", false, 60);
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

-- -----------------------------------------------------
-- Insert Artists
-- -----------------------------------------------------

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 1", "Österreich", "artist1@mail.com", NULL, NULL, NULL, NULL, 1);

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 2", "Deutschland", "artist2@mail.com", NULL, NULL, NULL, NULL, 2);
  
INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 3", "Holland", "artist3@mail.com", NULL, NULL, NULL, NULL, 1 );

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 4", "Frankreich", "artist4@mail.com", NULL, NULL, NULL, NULL, 2);

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 5", "Kroatien", "artist5@mail.com", NULL, NULL, NULL, NULL, 3);

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 6", "Spanien", "artist6@mail.com", NULL, NULL, NULL, NULL, 4);

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 7", "USA ", "artist7@mail.com", NULL, NULL, NULL, NULL, 1);

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 8", "Australien", "artist8@mail.com", NULL, NULL, NULL, NULL, 2);

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 9", "Italien", "artist9@mail.com", NULL, NULL, NULL, NULL, 3 );

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 10", "Portugal", "artist10@mail.com", NULL, NULL, NULL, NULL, 2 );

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 11", "Griechland", "artist11@mail.com", NULL, NULL, NULL, NULL, 1 );

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 12", "Albanien", "artist12@mail.com", NULL, NULL, NULL, NULL, 4 );

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 13", "Serbien", "artist13@mail.com", NULL, NULL, NULL, NULL, 2 );

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 14", "Polen", "artist14@mail.com", NULL, NULL, NULL, NULL, 5 );

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 15", "Slowenien", "artist15@mail.com", NULL, NULL, NULL, NULL, 2 );

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 16", "China", "artist16@mail.com", NULL, NULL, NULL, NULL, 3 );

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 17", "Japan", "artist17@mail.com", NULL, NULL, NULL, NULL, 2 );

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 18", "Marokko", "artist18@mail.com", NULL, NULL, NULL, NULL, 1 );

  INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 19", "Brasilien", "artist19@mail.com", NULL, NULL, NULL, NULL, 2 );
  
INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 20", "Finland", "artist20@mail.com", NULL, NULL, NULL, NULL, 2 );

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 21", "Schweden", "artist21@mail.com", NULL, NULL, NULL, NULL, 3 );

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 22", "Norwegen", "artist22@mail.com", NULL, NULL, NULL, NULL, 3 );

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 23", "Österreich", "artist23@mail.com", NULL, NULL, NULL, NULL, 1 );

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 24", "Deutschland", "artist24@mail.com", NULL, NULL, NULL, NULL, 1 );

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 25", "Finland", "artist25@mail.com", NULL, NULL, NULL, NULL, 3 );

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 26", "Spanien", "artist26@mail.com", NULL, NULL, NULL, NULL, 2 );

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 27", "Großbritannien", "artist27@mail.com", NULL, NULL, NULL, NULL, 1 );

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 28", "Japan", "artist28@mail.com", NULL, NULL, NULL, NULL, 2 );

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 29", "Australien", "artist29@mail.com", NULL, NULL, NULL, NULL, 1 );  

INSERT INTO `UFO_DB`.`Artist` (`name`, `country`, `email`, `homepage`, `picture`, `video`, `description`, `category`) 
  VALUES ("Artist 30", "Österreich", "artist30@mail.com", NULL, NULL, NULL, NULL, 2 );  

 -- -----------------------------------------------------
-- Insert Performance
-- ----------------------------------------------------- 

-- INSERT INTO `UFO_DB`.`Performance` (`startTime`, `duration`, `description`, `artist`, `venue`)
--  VALUES ();

 -- -----------------------------------------------------
-- Insert Schedule
-- ----------------------------------------------------- 