---- Svuota le tabelle in ordine inverso per non violare i vincoli
--DELETE FROM ASSEGNAZIONI;
--DELETE FROM INCIDENTI;
--DELETE FROM MANUTENZIONI;
--DELETE FROM GUIDATORI;
--DELETE FROM VEICOLI;
--DELETE FROM MODELLI;

---- Resetta i contatori IDENTITY
--DBCC CHECKIDENT ('MODELLI', RESEED, 0);
--DBCC CHECKIDENT ('VEICOLI', RESEED, 0);
--DBCC CHECKIDENT ('GUIDATORI', RESEED, 0);
--DBCC CHECKIDENT ('MANUTENZIONI', RESEED, 0);
--DBCC CHECKIDENT ('INCIDENTI', RESEED, 0);
--DBCC CHECKIDENT ('ASSEGNAZIONI', RESEED, 0);

-- MODELLI (40)
INSERT INTO MODELLI (Marca, NomeModello) VALUES 
('Fiat','500'),('Fiat','Panda'),('Fiat','Tipo'),('Alfa Romeo','Giulia'),('Alfa Romeo','Stelvio'),
('Lancia','Ypsilon'),('Volkswagen','Golf'),('Volkswagen','Polo'),('Volkswagen','Passat'),('Audi','A3'),
('Audi','A4'),('Audi','Q5'),('BMW','Serie 3'),('BMW','X3'),('Mercedes','Classe A'),
('Mercedes','Classe C'),('Ford','Fiesta'),('Ford','Focus'),('Ford','Puma'),('Toyota','Yaris'),
('Toyota','Corolla'),('Toyota','RAV4'),('Renault','Clio'),('Renault','Captur'),('Peugeot','208'),
('Peugeot','3008'),('Citroen','C3'),('Citroen','C5'),('Opel','Corsa'),('Opel','Astra'),
('Hyundai','i30'),('Hyundai','Tucson'),('Kia','Sportage'),('Kia','Rio'),('Volvo','XC40'),
('Volvo','V60'),('Jeep','Renegade'),('Jeep','Compass'),('Dacia','Sandero'),('Dacia','Duster');

-- VEICOLI (40) - Puntano a ID_Modello 1-40
INSERT INTO VEICOLI (Targa, FK_Modello, AnnoProduzione, Chilometraggio, Stato) VALUES 
('AA001AA',1,2022,10000,'Disponibile'),('AA002BB',2,2021,25000,'In Uso'),('AA003CC',3,2020,40000,'In Manutenzione'),
('AA004DD',4,2022,5000,'Disponibile'),('AA005EE',5,2021,32000,'In Uso'),('AA006FF',6,2019,65000,'Disponibile'),
('AA007GG',7,2020,42000,'In Uso'),('AA008HH',8,2021,21000,'Disponibile'),('AA009II',9,2018,95000,'Disponibile'),
('AA010JJ',10,2022,8000,'In Uso'),('AA011KK',11,2021,27000,'Disponibile'),('AA012LL',12,2020,55000,'In Uso'),
('AA013MM',13,2019,72000,'Disponibile'),('AA014NN',14,2022,15000,'In Uso'),('AA015OO',15,2021,31000,'In Uso'),
('AA016PP',16,2018,88000,'Disponibile'),('AA017QQ',17,2020,44000,'In Uso'),('AA018RR',18,2021,24000,'Disponibile'),
('AA019SS',19,2022,9000,'In Uso'),('AA020TT',20,2019,62000,'Disponibile'),('AA021UU',21,2021,33000,'In Uso'),
('AA022VV',22,2020,49000,'Disponibile'),('AA023WW',23,2018,81000,'Disponibile'),('AA024XX',24,2022,11000,'In Uso'),
('AA025YY',25,2021,29000,'In Uso'),('AA026ZZ',26,2020,51000,'Disponibile'),('AA027AB',27,2019,77000,'Disponibile'),
('AA028CD',28,2022,12000,'In Uso'),('AA029EF',29,2021,34000,'Disponibile'),('AA030GH',30,2018,99000,'In Manutenzione'),
('AA031IJ',31,2020,41000,'In Uso'),('AA032KL',32,2021,22000,'Disponibile'),('AA033MN',33,2022,6000,'In Uso'),
('AA034OP',34,2019,67000,'Disponibile'),('AA035QR',35,2021,30000,'In Uso'),('AA036ST',36,2020,53000,'Disponibile'),
('AA037UV',37,2018,91000,'Disponibile'),('AA038WX',38,2022,14000,'In Uso'),('AA039YZ',39,2021,36000,'Disponibile'),
('AA040ZA',40,2020,59000,'In Uso');

-- GUIDATORI (40)
INSERT INTO GUIDATORI (Nome, Cognome, CodiceFiscale, ScadenzaPatente) VALUES 
('Mario','Rossi','RSSMRA80A01H501U','2030-01-01'),('Luca','Bianchi','BNCLCU85C03F205A','2029-05-12'),('Sara','Verdi','VRDSRA90D44H501M','2031-07-22'),
('Anna','Neri','NRERBT81S12L219I','2030-04-20'),('Paolo','Gialli','GLLPLA75R06F205W','2028-11-11'),('Elena','Rosa','RSELEN92S50H501X','2032-06-18'),
('Marco','Blu','BLUMRC88E05L736P','2027-12-05'),('Giulia','Marroni','MRNGLI95P55H501D','2033-02-14'),('Fabio','Grigio','GRGFBA77M15F205R','2026-09-09'),
('Roberto','Costa','CSTRBT81S12L219J','2030-10-10'),('Laura','Brambilla','BRMLRA84T48F205T','2029-08-15'),('Davide','Esposito','ESPDVD89A12H501Y','2031-11-25'),
('Alice','Ricci','RCCLCA94T68H501N','2034-09-08'),('Simone','Fontana','FNTSMN87B22L219K','2027-10-05'),('Chiara','Russo','RSSCHR94S65F205P','2034-03-22'),
('Antonio','Ferrari','FRRNTN79M25H501S','2026-06-15'),('Marta','Greco','GRCMRT96A41L219V','2035-12-01'),('Giovanni','Rizzo','RZZGNN82D10F205G','2029-04-14'),
('Silvia','Lombardi','LMBSLV85E45H501J','2030-08-30'),('Daniele','Barbieri','BRBDNL88R15L219X','2031-02-18'),('Erika','Moretti','MRTARK90T55F205Y','2032-07-07'),
('Pietro','Pellegrini','PLLPTR76M28H501L','2026-11-19'),('Nicola','Martini','MRTNCL81S20F205E','2030-01-12'),('Federico','Gatti','GTTFRC87A11L219F','2028-12-30'),
('Giorgia','Ferraro','FRRGRG97M50F205B','2035-03-14'),('Lorenzo','Santi','SNTLNZ84D14H501K','2029-06-25'),('Ilaria','Valenti','VLNLRN91P48L219A','2032-10-02'),
('Enrico','Fabbri','FBBNRC78E19F205V','2026-02-28'),('Beatrice','Villa','VLLBTC95R52H501Z','2034-11-11'),('Claudio','Parisi','PRSCLD83A12L219M','2028-07-20'),
('Simona','D’Angelo','DNGSMN89S58F205S','2031-04-15'),('Matteo','Rinaldi','RNLMTT80B15H501R','2030-09-30'),('Sofia','Donati','DNTSFO92D55L219E','2032-12-12'),
('Andrea','Guerra','GRRNDR86M10F205Q','2027-05-05'),('Paola','Vitali','VTLPLA98R41H501T','2035-01-20'),('Stefano','Moro','MRSTFN82A01H501W','2029-03-15'),
('Cristina','Bruni','BRNCRN85B42L219K','2030-02-28'),('Filippo','Galli','GLLFLP88C12F205D','2031-06-10'),('Monica','Sanna','SNNMNC90D50H501G','2032-09-18'),('Alessio','Piras','PRSLSS93E15L219F','2033-11-25');

-- MANUTENZIONI (40)
INSERT INTO MANUTENZIONI (FK_Veicolo, DataIntervento, Costo, Descrizione)
SELECT ID_Veicolo, '2024-01-10', 250.00, 'Tagliando ordinario' FROM VEICOLI;

-- INCIDENTI (40)
INSERT INTO INCIDENTI (FK_Veicolo, FK_Guidatore, DataIncidente, DescrizioneDanni)
SELECT ID_Veicolo, ID_Veicolo, '2024-02-15', 'Urto lieve parcheggio' FROM VEICOLI;

-- ASSEGNAZIONI (40)
INSERT INTO ASSEGNAZIONI (FK_Veicolo, FK_Guidatore, DataInizio, DataFine)
SELECT ID_Veicolo, ID_Veicolo, '2024-01-01', NULL FROM VEICOLI;

-------------------------------------------------------
-- 1. VEICOLI (50 nuovi record)
-- Distribuisce i veicoli sui modelli esistenti
-------------------------------------------------------
DECLARE @i INT = 1;
WHILE @i <= 50
BEGIN
    INSERT INTO VEICOLI (Targa, FK_Modello, AnnoProduzione, Chilometraggio, Stato)
    SELECT TOP 1 
        CHAR(65 + (ABS(CHECKSUM(NEWID())) % 26)) + CHAR(65 + (ABS(CHECKSUM(NEWID())) % 26)) + 
        RIGHT('000' + CAST(ABS(CHECKSUM(NEWID())) % 1000 AS VARCHAR), 3) + 
        CHAR(65 + (ABS(CHECKSUM(NEWID())) % 26)) + CHAR(65 + (ABS(CHECKSUM(NEWID())) % 26)),
        ID_Modello, 
        2015 + (ABS(CHECKSUM(NEWID())) % 10), 
        (ABS(CHECKSUM(NEWID())) % 150000), 
        CASE WHEN @i % 5 = 0 THEN 'In Manutenzione' ELSE 'Disponibile' END
    FROM MODELLI ORDER BY NEWID();
    SET @i = @i + 1;
END;

-------------------------------------------------------
-- 2. GUIDATORI (50 nuovi record)
-------------------------------------------------------
INSERT INTO GUIDATORI (Nome, Cognome, CodiceFiscale, ScadenzaPatente) VALUES 
('Alessandro', 'Galli', 'GLLLSN85A01H501A', '2030-01-10'), ('Beatrice', 'Sanna', 'SNNBTC90B42L219B', '2029-11-15'),
('Claudio', 'Piras', 'PRSCLD82C03F205C', '2028-04-20'), ('Domenico', 'Serra', 'SRRDMN78D04H501D', '2031-07-25'),
('Enrica', 'Melis', 'MLSNRC92E45L219E', '2032-12-05'), ('Federico', 'Carta', 'CRTFRC88F06F205F', '2027-10-30'),
('Giovanna', 'Manca', 'MNCGNN84G47H501G', '2033-03-18'), ('Hubert', 'Rossini', 'RSSHBR75H08L219H', '2026-09-11'),
('Ilaria', 'Farris', 'FRRLRA95I49F205I', '2034-05-09'), ('Jacopo', 'Deiana', 'DNCJCP81J10H501J', '2029-02-14'),
('Katia', 'Loi', 'LOIKTA89K51L219K', '2030-08-20'), ('Leonardo', 'Marras', 'MRRLNR86L12F205L', '2032-11-15'),
('Manuela', 'Puddu', 'PDDMNL93M53H501M', '2033-01-25'), ('Nicola', 'Sulis', 'SLSNCL79N14L219N', '2028-06-10'),
('Ottavio', 'Pau', 'PAUTTV87P15F205O', '2027-12-30'), ('Patrizia', 'Urru', 'RRRPTZ94P56H501P', '2034-04-12'),
('Quintino', 'Zanda', 'ZNDQNT82Q17L219Q', '2031-10-05'), ('Rosa', 'Floris', 'FLRRSO91R58F205R', '2032-03-22'),
('Stefano', 'Usai', 'USSTFN80S19H501S', '2030-07-15'), ('Teresa', 'Vacca', 'VCCTRS88T60L219T', '2029-01-01'),
('Ubaldo', 'Lai', 'LAIBLD83U21F205U', '2028-09-14'), ('Valeria', 'Piras', 'PRSVLR96V62H501V', '2035-12-30'),
('Walter', 'Atzeni', 'ATZWTR85W23L219W', '2030-05-18'), ('Xenia', 'Mura', 'MRAXNE92X64F205X', '2033-02-07'),
('Yuri', 'Cocco', 'CCCYRU89Y25H501Y', '2031-11-19'), ('Zoe', 'Ledda', 'LDDZOE94Z66L219Z', '2034-08-25'),
('Adriano', 'Podda', 'PDDDRN77A27F205A', '2026-03-12'), ('Barbara', 'Contu', 'CNTBRB84B68H501B', '2029-10-08'),
('Cristian', 'Cabras', 'CBRCST87C29L219C', '2032-12-30'), ('Daniela', 'Sanna', 'SNNDNL90D70F205D', '2035-01-14'),
('Edoardo', 'Manca', 'MNCEDO82E31H501E', '2027-06-25'), ('Fabiana', 'Meloni', 'MLNFBN93F72L219F', '2034-09-02'),
('Gabriele', 'Piras', 'PRSGRL81G13F205G', '2026-04-28'), ('Hellen', 'Carta', 'CRTHLN95H54H501H', '2033-11-11'),
('Ivan', 'Serra', 'SRRVNI83I15L219I', '2028-07-20'), ('Lara', 'Piras', 'PRSLRA89S56F205L', '2031-05-15'),
('Massimo', 'Loi', 'LOIMSS80M17H501M', '2030-09-30'), ('Noemi', 'Marras', 'MRRNMO92N58L219N', '2032-12-12'),
('Oscar', 'Puddu', 'PDDOSC86O19F205O', '2027-06-05'), ('Paola', 'Sulis', 'SLSPLA98P60H501P', '2035-01-20'),
('Raffaele', 'Pau', 'PAURFF82A21L219R', '2029-03-15'), ('Silvia', 'Urru', 'RRRSLV85B62F205S', '2030-02-28'),
('Tommaso', 'Zanda', 'ZNDTMS88C23H501T', '2031-06-10'), ('Ugo', 'Floris', 'FLRGUO90D24L219U', '2032-09-18'),
('Viola', 'Usai', 'USSVLI93E65F205V', '2033-11-25'), ('Zaccaria', 'Vacca', 'VCCZCC79F26H501Z', '2026-08-14'),
('Ambra', 'Lai', 'LAIMBR84G67L219A', '2029-04-30'), ('Boris', 'Atzeni', 'ATZBRS81H28F205B', '2031-01-22'),
('Carla', 'Mura', 'MRACRL95I69H501C', '2034-12-08'), ('Dario', 'Cocco', 'CCCDRA83J30L219D', '2028-02-19');

-------------------------------------------------------
-- 3. MANUTENZIONI (50 nuovi record)
-------------------------------------------------------
INSERT INTO MANUTENZIONI (FK_Veicolo, DataIntervento, Costo, Descrizione)
SELECT TOP 50 ID_Veicolo, 
    DATEADD(DAY, -(ABS(CHECKSUM(NEWID())) % 365), GETDATE()), 
    (100 + ABS(CHECKSUM(NEWID())) % 900), 
    'Intervento di manutenzione programmata n. ' + CAST(ID_Veicolo AS VARCHAR)
FROM VEICOLI ORDER BY NEWID();

-------------------------------------------------------
-- 4. INCIDENTI (50 nuovi record)
-------------------------------------------------------
INSERT INTO INCIDENTI (FK_Veicolo, FK_Guidatore, DataIncidente, DescrizioneDanni)
SELECT TOP 50 V.ID_Veicolo, G.ID_Guidatore, 
    DATEADD(DAY, -(ABS(CHECKSUM(NEWID())) % 730), GETDATE()), 
    'Rilevato danno generico alla carrozzeria'
FROM VEICOLI V CROSS JOIN GUIDATORI G 
ORDER BY NEWID();

-------------------------------------------------------
-- 5. ASSEGNAZIONI (50 nuovi record)
-------------------------------------------------------
INSERT INTO ASSEGNAZIONI (FK_Veicolo, FK_Guidatore, DataInizio, DataFine)
SELECT TOP 50 V.ID_Veicolo, G.ID_Guidatore, 
    DATEADD(DAY, -(ABS(CHECKSUM(NEWID())) % 100), GETDATE()), 
    NULL
FROM VEICOLI V CROSS JOIN GUIDATORI G
WHERE V.Stato = 'In Uso' OR V.Stato = 'Disponibile'
ORDER BY NEWID();