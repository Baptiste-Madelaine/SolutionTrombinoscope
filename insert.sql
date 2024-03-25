INSERT INTO fonctions (intitule) VALUES 
('Directeur'),
('Chef de service'),
('Assistant'),
('Technicien'),
('Secrétaire');

-- Insérer des services
INSERT INTO services (intitule) VALUES 
('Ressources Humaines'),
('Finance'),
('Informatique'),
('Marketing'),
('Logistique');

-- Insérer des personnels
INSERT INTO personnels (prenom, nom, idService, idFonction, telephone, photo) VALUES 
('Jean', 'Dupont', 1, 1, '01 23 45 67 89', NULL),
('Marie', 'Martin', 2, 2, '06 12 34 56 78', NULL),
('Pierre', 'Durand', 3, 3, '02 34 56 78 90', NULL),
('Sophie', 'Lefevre', 4, 4, '07 89 12 34 56', NULL),
('Luc', 'Dubois', 5, 5, '03 45 67 89 01', NULL);
