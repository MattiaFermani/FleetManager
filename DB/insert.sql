---- 1. INSERIMENTO MODELLI
--INSERT INTO MODELLI (Marca, NomeModello) VALUES 
--('Fiat', '500 Hybrid'), ('Volkswagen', 'Golf'), ('Tesla', 'Model 3'), 
--('Ford', 'Transit'), ('Iveco', 'Daily'), ('Toyota', 'Yaris');

---- 2. INSERIMENTO GUIDATORI
--INSERT INTO GUIDATORI (Nome, Cognome, CodiceFiscale, ScadenzaPatente) VALUES 
--('Mario', 'Rossi', 'RSSMRA80A01H501U', '2030-05-20'),
--('Luigi', 'Verdi', 'VRDLGU85B12F205Z', '2028-11-15'),
--('Anna', 'Bianchi', 'BNCNNA92C41L219X', '2032-02-10'),
--('Giulia', 'Neri', 'NREGLI88D22H501A', '2029-07-30');

---- 3. INSERIMENTO VEICOLI (FK_Modello 1-6)
--INSERT INTO VEICOLI (Targa, FK_Modello, AnnoProduzione, Chilometraggio, Stato) VALUES 
--('AB123CD', 1, 2022, 15000, 'Disponibile'),
--('EF456GH', 2, 2021, 45000, 'In Uso'),
--('IJ789KL', 3, 2023, 5000, 'Disponibile'),
--('MN012OP', 4, 2019, 120000, 'In Manutenzione'),
--('QR345ST', 5, 2020, 85000, 'Disponibile'),
--('UV678WX', 6, 2024, 500, 'Disponibile');

---- 4. INSERIMENTO MANUTENZIONI (FK_Veicolo 1-6)
--INSERT INTO MANUTENZIONI (FK_Veicolo, DataIntervento, Costo, Descrizione) VALUES 
--(4, '2024-01-15', 450.00, 'Tagliando completo'),
--(2, '2023-11-02', 120.50, 'Cambio olio'),
--(5, '2024-03-10', 800.00, 'Cinghia di distribuzione');

---- 5. INSERIMENTO INCIDENTI (FK_Veicolo / FK_Guidatore)
--INSERT INTO INCIDENTI (FK_Veicolo, FK_Guidatore, DataIncidente, DescrizioneDanni) VALUES 
--(2, 1, '2024-02-14', 'Tamponamento lieve posteriore'),
--(4, 2, '2023-12-05', 'Rottura specchietto destro');

---- 6. INSERIMENTO ASSEGNAZIONI (Storico e Attive)
--INSERT INTO ASSEGNAZIONI (FK_Veicolo, FK_Guidatore, DataInizio, DataFine) VALUES 
--(1, 1, '2024-01-01', '2024-01-31'),
--(2, 2, '2024-02-01', NULL),
--(3, 3, '2024-03-01', NULL),
--(6, 4, '2024-04-01', NULL);


---- 1. MODELLI (Dati strutturali)
--INSERT INTO MODELLI (Marca, NomeModello) VALUES 
--('Tesla', 'Model Y'), ('Fiat', 'Panda Sport'), ('BMW', 'i4'), 
--('Ford', 'Transit Custom'), ('Renault', 'Zoe'), ('Audi', 'A3');

---- 2. GUIDATORI (Anagrafiche)
--INSERT INTO GUIDATORI (Nome, Cognome, CodiceFiscale, ScadenzaPatente) VALUES 
--('Roberto', 'Galli', 'GLLRRT82M15H501O', '2031-10-12'),
--('Elena', 'Rizzo', 'RZZLNE95P45F205R', '2033-05-20'),
--('Marco', 'Santi', 'SNTMRC78A10L219W', '2028-03-15'),
--('Sara', 'Villa', 'VLLSRA90E51H501Q', '2030-07-04');

---- 3. VEICOLI (Status aggiornato ad aprile 2026)
--INSERT INTO VEICOLI (Targa, FK_Modello, AnnoProduzione, Chilometraggio, Stato) VALUES 
--('GA111BB', 1, 2024, 8200, 'In Uso'),
--('GA222CC', 2, 2023, 12500, 'Disponibile'),
--('GA333DD', 3, 2025, 1200, 'In Uso'),
--('GA444EE', 4, 2022, 98000, 'In Manutenzione'),
--('GA555FF', 5, 2023, 21000, 'In Uso'),
--('GA666GG', 6, 2024, 4300, 'Disponibile');

---- 4. ASSEGNAZIONI (Tutte nell'ultimo mese)
--INSERT INTO ASSEGNAZIONI (FK_Veicolo, FK_Guidatore, DataInizio, DataFine) VALUES 
--(1, 1, '2026-03-20', NULL),           -- Assegnata il 20 marzo, ancora attiva
--(5, 2, '2026-03-25', NULL),           -- Assegnata il 25 marzo, ancora attiva
--(3, 4, '2026-04-01', NULL),           -- Appena assegnata (1 aprile)
--(2, 3, '2026-03-15', '2026-03-30'),   -- Assegnazione conclusa a fine marzo
--(4, 3, '2026-04-05', NULL);           -- Assegnata ad aprile e poi andata in manutenzione

---- 5. MANUTENZIONI (Interventi recentissimi)
--INSERT INTO MANUTENZIONI (FK_Veicolo, DataIntervento, Costo, Descrizione) VALUES 
--(4, '2026-04-10', 320.00, 'Revisione straordinaria impianto frenante'),
--(2, '2026-04-02', 150.00, 'Lavaggio professionale e sanificazione post-noleggio'),
--(5, '2026-03-28', 85.00, 'Rabbocco liquidi e controllo pressione pneumatici');

---- 6. INCIDENTI (Eventi recenti)
--INSERT INTO INCIDENTI (FK_Veicolo, FK_Guidatore, DataIncidente, DescrizioneDanni) VALUES 
--(1, 1, '2026-04-05', 'Piccola ammaccatura sportello sinistro in parcheggio'),
--(5, 2, '2026-03-29', 'Scheggiatura parabrezza dovuta a sasso in autostrada');

--INSERT INTO MODELLI (Marca, NomeModello) VALUES 
--('Fiat', 'Panda'), ('Volkswagen', 'Golf'), ('Ford', 'Focus'), ('Toyota', 'Yaris'), ('Audi', 'A4'),
--('BMW', 'Serie 3'), ('Mercedes', 'Classe A'), ('Renault', 'Clio'), ('Peugeot', '208'), ('Opel', 'Corsa'),
--('Hyundai', 'Tucson'), ('Kia', 'Sportage'), ('Nissan', 'Qashqai'), ('Jeep', 'Renegade'), ('Fiat', '500'),
--('Alfa Romeo', 'Giulia'), ('Volvo', 'XC40'), ('Skoda', 'Octavia'), ('Citroen', 'C3'), ('Dacia', 'Sandero'),
--('Tesla', 'Model 3'), ('Mini', 'Cooper'), ('Seat', 'Leon'), ('Mazda', 'CX-5'), ('Honda', 'Civic'),
--('Land Rover', 'Evoque'), ('Porsche', 'Macan'), ('Suzuki', 'Vitara'), ('Lancia', 'Ypsilon'), ('Dacia', 'Duster');

--INSERT INTO VEICOLI (Targa, FK_Modello, AnnoProduzione, Chilometraggio, Stato)
--SELECT 
--    -- Genera targa formato AA 000 AA
--    CHAR(65 + ABS(CHECKSUM(NEWID()) % 26)) + 
--    CHAR(65 + ABS(CHECKSUM(NEWID()) % 26)) + ' ' +
--    CAST(100 + ABS(CHECKSUM(NEWID()) % 899) AS VARCHAR) + ' ' +
--    CHAR(65 + ABS(CHECKSUM(NEWID()) % 26)) + 
--    CHAR(65 + ABS(CHECKSUM(NEWID()) % 26)),
--    M.ID_Modello, 
--    2022, 
--    10000, 
--    'Disponibile'
--FROM MODELLI M;

--INSERT INTO GUIDATORI (Nome, Cognome, CodiceFiscale, ScadenzaPatente) VALUES 
--('Luca', 'Bianchi', 'BNCLCU85B02H501B', '2028-05-15'),
--('Beatrice', 'Fiume', 'FIMBRT95D30H501D', '2033-02-02'), ('Giulia', 'Verdi', 'VRDGLI90C03H501C', '2027-10-20'),
--('Elena', 'Neri', 'NRELNA95D04H501D', '2032-03-10'), ('Marco', 'Gialli', 'GLLMRC88E05H501E', '2029-11-30'),
--('Sara', 'Blu', 'BLUSRA92F06H501F', '2026-07-22'), ('Paolo', 'Viola', 'VLOPLA82G07H501G', '2031-04-12'),
--('Anna', 'Grigi', 'GRGANN91H08H501H', '2027-12-05'), ('Luigi', 'Rosa', 'RSALGU89I09H501I', '2033-02-18'),
--('Chiara', 'Marroni', 'MRRCHR94J10H501J', '2028-09-09'), ('Davide', 'Arancio', 'RNCDVD87K11H501K', '2030-06-25'),
--('Sofia', 'Turchese', 'TRCSFA93L12H501L', '2029-08-14'),
--('Matteo', 'Oro', 'OROMTT85M13H501M', '2026-05-30'), ('Laura', 'Argento', 'RGNLRA96N14H501N', '2032-12-01'),
--('Roberto', 'Bronzo', 'BRNRBT84O15H501O', '2027-04-17'), ('Alice', 'Ferro', 'FRRALC92P16H501P', '2031-01-20'),
--('Stefano', 'Rame', 'RMASFN89Q17H501Q', '2028-11-11'), ('Valentina', 'Piombo', 'PMBVLT91R18H501R', '2029-07-07'),
--('Andrea', 'Zinco', 'ZNCNDR83S19H501S', '2030-03-03'), ('Elena', 'Stagno', 'STGNLE95T20H501T', '2033-09-09'),
--('Nicola', 'Acciaio', 'CCLNCL87U21H501U', '2026-02-28'), ('Francesca', 'Vetro', 'VTRFNC90V22H501V', '2027-06-15'),
--('Simone', 'Legno', 'LGNSEM88W23H501W', '2032-10-10'), ('Gaia', 'Pietra', 'PTRGAI94X24H501X', '2028-04-04'),
--('Alessandro', 'Sabbia', 'SBBALS82Y25H501Y', '2031-12-12'), ('Ilaria', 'Cielo', 'CLILRA93Z26H501Z', '2029-01-01'),
--('Giovanni', 'Mare', 'MREGVN86A27H501A', '2027-05-05'), ('Martina', 'Monti', 'MNTMTN92B28H501B', '2030-08-08'),
--('Federico', 'Valli', 'VLLFDC89C29H501C', '2026-11-11'), ('Beatrice', 'Fiume', 'FIMBRT95D30H501D', '2033-02-02');

INSERT INTO MANUTENZIONI (FK_Veicolo, DataIntervento, Costo, Descrizione) VALUES 
(1077, '2026-01-10', 150.00, 'Tagliando'), (1078, '2026-01-12', 85.00, 'Cambio olio'),
(1079, '2026-01-15', 200.00, 'Revisione freni'), (1080, '2026-01-20', 120.00, 'Controllo luci'),
(1081, '2026-01-22', 95.00, 'Sostituzione filtri'), (1082, '2026-01-25', 300.00, 'Cambio gomme'),
(1083, '2026-01-28', 450.00, 'Distribuzione'), (1084, '2026-02-02', 110.00, 'Ricarica clima'),
(1085, '2026-02-05', 75.00, 'Lavaggio interno'), (1086, '2026-02-08', 210.00, 'Batteria'),
(1087, '2026-02-12', 130.00, 'Allineamento ruote'), (1088, '2026-02-15', 55.00, 'Tergicristalli'),
(1089, '2026-02-18', 350.00, 'Riparazione sospensioni'), (1090, '2026-02-20', 90.00, 'Liquido radiatore'),
(1091, '2026-02-25', 180.00, 'Controllo centralina'), (1092, '2026-03-01', 140.00, 'Cambio candele'),
(1093, '2026-03-05', 400.00, 'Frizione'), (1094, '2026-03-08', 125.00, 'Pastiglie freni'),
(1095, '2026-03-10', 60.00, 'Bilanciatura'), (1096, '2026-03-12', 220.00, 'Alternatore'),
(1097, '2026-03-15', 80.00, 'Controllo pressione'), (1098, '2026-03-18', 190.00, 'Sensori parcheggio'),
(1099, '2026-03-20', 310.00, 'Radiatore'), (1100, '2026-03-22', 160.00, 'Olio freni'),
(1101, '2026-03-25', 115.00, 'Guarnizione'), (1102, '2026-03-28', 250.00, 'Motorino avviamento'),
(1103, '2026-04-01', 70.00, 'Lampadine fari'), (1104, '2026-04-03', 100.00, 'Sanificazione'),
(1105, '2026-04-05', 380.00, 'Turbina'), (1106, '2026-04-08', 50.00, 'Check-up liquidi');

INSERT INTO INCIDENTI (FK_Veicolo, FK_Guidatore, DataIncidente, DescrizioneDanni) VALUES 
(1107, 1032, '2026-01-05', 'Graffio portiera'), (1108, 1033, '2026-01-07', 'Urtata paraurti'),
(1109, 1034, '2026-01-10', 'Specchietto rotto'), (1110, 1035, '2026-01-15', 'Parabrezza crepato'),
(1111, 1036, '2026-01-20', 'Ammaccatura parafango'), (1112, 1037, '2026-01-22', 'Danno fanale'),
(1113, 1038, '2026-01-28', 'Segni su cofano'), (1114, 1039, '2026-02-01', 'Graffio cerchione'),
(1115, 1040, '2026-02-05', 'Danno portellone'), (1116, 1041, '2026-02-08', 'Urtata posteriore'),
(1117, 1042, '2026-02-12', 'Sportello bloccato'), (1118, 1043, '2026-02-15', 'Rottura fendinebbia'),
(1119, 1044, '2026-02-18', 'Ammaccatura tetto'), (1120, 1045, '2026-02-22', 'Graffio profondo'),
(1121, 1046, '2026-02-25', 'Danno griglia'), (1122, 1047, '2026-03-01', 'Specchio retrovisore'),
(1123, 1048, '2026-03-05', 'Paraurti sganciato'), (1124, 1049, '2026-03-08', 'Vetro laterale'),
(1125, 1050, '2026-03-12', 'Danno spoiler'), (1126, 1051, '2026-03-15', 'Graffio parcheggio'),
(1127, 1052, '2026-03-18', 'Urtata laterale'), (1128, 1053, '2026-03-20', 'Ammaccatura baule'),
(1129, 1054, '2026-03-22', 'Tergicristallo rotto'), (1130, 1055, '2026-03-25', 'Danno ruota'),
(1131, 1056, '2026-03-28', 'Segni carrozzeria'), (1132, 1057, '2026-04-01', 'Urtata frontale'),
(1133, 1058, '2026-04-03', 'Graffio plastica'), (1134, 1059, '2026-04-05', 'Danno tetto'),
(1135, 1060, '2026-04-08', 'Ammaccatura porta'), (1136, 1061, '2026-04-10', 'Scheggiatura');

INSERT INTO ASSEGNAZIONI (FK_Veicolo, FK_Guidatore, DataInizio, DataFine) VALUES 
(1137, 1032, '2026-04-01', NULL), (1138, 1033, '2026-04-01', NULL),
(1139, 1034, '2026-04-02', NULL), (1140, 1035, '2026-04-02', NULL),
(1141, 1036, '2026-04-03', NULL), (1142, 1037, '2026-04-03', NULL),
(1143, 1038, '2026-04-04', NULL), (1144, 1039, '2026-04-04', NULL),
(1145, 1040, '2026-04-05', NULL), (1146, 1041, '2026-04-05', NULL),
(1147, 1042, '2026-04-06', NULL), (1148, 1043, '2026-04-06', NULL),
(1149, 1044, '2026-04-07', NULL), (1150, 1045, '2026-04-07', NULL),
(1151, 1046, '2026-04-08', NULL), (1152, 1047, '2026-04-08', NULL),
(1153, 1048, '2026-04-09', NULL), (1154, 1049, '2026-04-09', NULL),
(1155, 1050, '2026-04-10', NULL), (1156, 1051, '2026-04-10', NULL),
(1157, 1052, '2026-04-11', NULL), (1158, 1053, '2026-04-11', NULL),
(1159, 1054, '2026-04-12', NULL), (1160, 1055, '2026-04-12', NULL),
(1161, 1056, '2026-04-13', NULL), (1162, 1057, '2026-04-13', NULL),
(1163, 1058, '2026-04-14', NULL), (1164, 1059, '2026-04-14', NULL),
(1165, 1060, '2026-04-15', NULL), (1166, 1061, '2026-04-15', NULL);

SELECT ID_Modello FROM MODELLI ORDER BY ID_Modello;
SELECT ID_Veicolo FROM VEICOLI ORDER BY ID_Veicolo;
SELECT ID_Guidatore FROM GUIDATORI ORDER BY ID_Guidatore;



SELECT V.ID_Veicolo, V.Targa, M.Marca, M.NomeModello, V.AnnoProduzione, V.Chilometraggio, V.Stato
FROM VEICOLI V
JOIN MODELLI M ON V.FK_Modello = M.ID_Modello