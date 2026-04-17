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


-- 1. MODELLI (Dati strutturali)
INSERT INTO MODELLI (Marca, NomeModello) VALUES 
('Tesla', 'Model Y'), ('Fiat', 'Panda Sport'), ('BMW', 'i4'), 
('Ford', 'Transit Custom'), ('Renault', 'Zoe'), ('Audi', 'A3');

-- 2. GUIDATORI (Anagrafiche)
INSERT INTO GUIDATORI (Nome, Cognome, CodiceFiscale, ScadenzaPatente) VALUES 
('Roberto', 'Galli', 'GLLRRT82M15H501O', '2031-10-12'),
('Elena', 'Rizzo', 'RZZLNE95P45F205R', '2033-05-20'),
('Marco', 'Santi', 'SNTMRC78A10L219W', '2028-03-15'),
('Sara', 'Villa', 'VLLSRA90E51H501Q', '2030-07-04');

-- 3. VEICOLI (Status aggiornato ad aprile 2026)
INSERT INTO VEICOLI (Targa, FK_Modello, AnnoProduzione, Chilometraggio, Stato) VALUES 
('GA111BB', 1, 2024, 8200, 'In Uso'),
('GA222CC', 2, 2023, 12500, 'Disponibile'),
('GA333DD', 3, 2025, 1200, 'In Uso'),
('GA444EE', 4, 2022, 98000, 'In Manutenzione'),
('GA555FF', 5, 2023, 21000, 'In Uso'),
('GA666GG', 6, 2024, 4300, 'Disponibile');

-- 4. ASSEGNAZIONI (Tutte nell'ultimo mese)
INSERT INTO ASSEGNAZIONI (FK_Veicolo, FK_Guidatore, DataInizio, DataFine) VALUES 
(1, 1, '2026-03-20', NULL),           -- Assegnata il 20 marzo, ancora attiva
(5, 2, '2026-03-25', NULL),           -- Assegnata il 25 marzo, ancora attiva
(3, 4, '2026-04-01', NULL),           -- Appena assegnata (1 aprile)
(2, 3, '2026-03-15', '2026-03-30'),   -- Assegnazione conclusa a fine marzo
(4, 3, '2026-04-05', NULL);           -- Assegnata ad aprile e poi andata in manutenzione

-- 5. MANUTENZIONI (Interventi recentissimi)
INSERT INTO MANUTENZIONI (FK_Veicolo, DataIntervento, Costo, Descrizione) VALUES 
(4, '2026-04-10', 320.00, 'Revisione straordinaria impianto frenante'),
(2, '2026-04-02', 150.00, 'Lavaggio professionale e sanificazione post-noleggio'),
(5, '2026-03-28', 85.00, 'Rabbocco liquidi e controllo pressione pneumatici');

-- 6. INCIDENTI (Eventi recenti)
INSERT INTO INCIDENTI (FK_Veicolo, FK_Guidatore, DataIncidente, DescrizioneDanni) VALUES 
(1, 1, '2026-04-05', 'Piccola ammaccatura sportello sinistro in parcheggio'),
(5, 2, '2026-03-29', 'Scheggiatura parabrezza dovuta a sasso in autostrada');