USE ControlPlagasDB
GO

-- =========================================================================
-- Author: Moisés David Ramón Esteban
-- Create Date: 2026/04/04
-- Description: Inserción de datos en tablas
-- P08R01MDRE: 03CargaInicial  
-- =========================================================================

-- Insertar datos para la tabla Plagas
INSERT INTO Plagas (NombreComun, NombreCientifico, Categoria, NivelRiesgo, UrlImage, Enfermedades)
VALUES
('Cucaracha Alemana', 'Blattella germanica', 'Insectos', 'Alto', 'https://imgs.search.brave.com/4rX7MHfcT2cnJFTebtYsGGy9l8HZKb5CCjApQSbs6gU/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9pbWcu/ZnJlZXBpay5jb20v/Zm90b3MtcHJlbWl1/bS9jdWNhcmFjaGEt/YWlzbGFkYS1zb2Jy/ZS1mb25kby1ibGFu/Y29fMzIyOTU4LTM0/NzAuanBnP3NlbXQ9/YWlzX2h5YnJpZA', 'Salmonelosis, disentería, gastroenteritis, asma'),
('Chinche de Cama', 'Cimex lectularius', 'Insectos', 'Medio', 'https://imgs.search.brave.com/lRxOjBiQQ7wt4Pw7B7ou5sKJjkjA29j9uSIbDDCSSAg/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9pbWcu/ZnJlZXBpay5jb20v/Zm90b3MtcHJlbWl1/bS9jZXJjYS1jb2xv/bmlhLWNoaW5jaGVz/LXNhYmFuYS1ibGFu/Y2EtY2FtYS1kb3Jt/aXRvcmlvXzE3ODcy/OC0xODMzLmpwZz9z/ZW10PWFpc19pbmNv/bWluZyZ3PTc0MCZx/PTgw', 'Reacciones alérgicas severas, insomnio, ansiedad'),
('Ratón Doméstico', 'Mus musculus', 'Roedores', 'Alto', 'https://imgs.search.brave.com/CLWD45eJvneHeSUZwwnhDw8MwYgjGSit6w2SHVFMspw/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9mdW15/Y29udHJvbC5jby93/cC1jb250ZW50L3Vw/bG9hZHMvZWxlbWVu/dG9yL3RodW1icy9N/dXMtbXVzY3VsdXMt/by1yYXRvbi1kb21l/c3RpY28tcjR0eThz/cjJhNm9jcnBjaHFz/ZG5kYWZ5cjJ0djMw/Z3FoMmFpNjNlcmdv/LndlYnA', 'Hantavirus, salmonelosis, leptospirosis, coriomeningitis linfocítica');

-- Insertar datos para la tabla Prevencion
INSERT INTO Prevencion (IdPlaga, Titulo, Descripcion)
VALUES
(1, 'Saneamiento e Higiene', 'Mantener la cocina libre de migajas y grasa. Sellar grietas en azulejos.'),
(2, 'Revisión de equipaje', 'Inspeccionar maletas al regresar de viajes antes de guardarlas en armarios.'),
(3, 'Sellado de accesos', 'Tapar agujeros en paredes y usar guardapolvos en la parte inferior de las puertas.');

-- Insertar datos para la tabla Tratamientos
INSERT INTO Tratamientos (IdPlaga, Tipo, NombreProducto, Instrucciones)
VALUES
(1, 'Químico', 'Gel Cebo Insecticida', 'Aplicar pequeñas gotas en esquinas de alacenas y bisagras.'),
(2, 'Térmico', 'Vapor a alta presión', 'Aplicar vapor a más de 60 grados Celsius en costuras de colchones y sillones.'),
(3, 'Físico', 'Trampas de captura', 'Colocar junto a las paredes donde se detecten rastros de heces o roeduras.');