USE E_COMMERCE12
INSERT INTO Provincias (Nombre)
VALUES ('Buenos Aires'),
       ('Catamarca'),
       ('Chaco'),
       ('Chubut'),
       ('Cordoba'),
       ('Corrientes'),
       ('Entre Rios'),
       ('Formosa'),
       ('Jujuy'),
       ('La Rioja'),
       ('La Pampa'),
       ('Mendoza'),
       ('Misiones'),
       ('Neuquen'),
       ('Rio Negro'),
       ('Salta'),
       ('San Juan'),
       ('San Luis'),
       ('Santa Fe'),
       ('Santa Cruz'),
       ('Santiago del Estero'),
       ('Tierra del Fuego'),
       ('Tucuman');


INSERT INTO Marcas (Nombre, Estado)
VALUES ('Nike', 1),
       ('Converse', 1),
       ('Calvin Klein', 1),
       ('Tommy Hilfiger', 1),
       ('Puma', 1),
       ('Vans', 1),
       ('Red Bull', 1),
       ('Adidas', 1);


INSERT INTO Categorias (Nombre, Estado)
VALUES ('Zapatillas', 1),
       ('Pantalones', 1),
       ('Medias', 1),
       ('Remeras', 1),
       ('Buzos', 1),
       ('Camperas', 1),
       ('Conjuntos Deportivos', 1),
       ('Zapatos', 1);


INSERT INTO TipoUsuario (Nombre)
VALUES  ('Usuario'),
        ('Admin'),
        ('Vendedor');


INSERT INTO Productos (ID_Categoria, ID_Marca, Codigo, Nombre, Descripcion, Precio, Estado)
VALUES (1, 1, 'Z001', 'Air Max Pre-Day Se', 'Manteniéndose fiel al estilo running pero agregando un estilo deportivo muy moderno, las Zapatillas Nike Air Max Pre-Day llegan a tus días para sacar la audacia que hay dentro tuyo. Con estampados de animales potentes y colores animados este calzado construye un patchwork ideal para tu look salvaje y atrevido.', 75000, 1),
       (1, 1, 'Z002', 'Air Jordan 5 Retro GTX', 'Conquistá la noche con las Zapatillas Air Jordan 5 Retro GTX Mujer. Un par que te alista para todas las temporadas y te mantiene fiel a tu estilo noventoso. Construidas con material súper resistente, cuero de primera calidad y características impermeables.', 150000, 1),
       (1, 5, 'Z003', 'Rs-X Triple', 'Las Zapatillas Puma Rs-X Triple Unisex son ideales para que te acompañen a donde quieras. Poseen una capellada de sintético y una suela de goma que brindan una resistencia inigualable. Su diseño moderno permite que siempre estés a la moda y, a la vez, que te sientas cómoda para enfrentar tu jornada.', 47699, 1),
       (1, 1, 'Z004', 'Jordan Air 4 Retro', 'Las Zapatillas Jordan Air 4 Retro Hombre actualizan la moda otoñal trayendo un calzado totalmente blanco con toques en azul marino medianoche para resaltar tu outfit y mantenerte fiel al AF. Con las famosas alas o ribetes para pasar los cordones que agregan el toque moderno que esperás.', 126499, 1),

       (4, 6, 'R001', 'Vans Classic', 'Vos que tenés claro que la moda pasa pero el estilo permanece, seguí tu instinto con la Remera Vans Classic es un clásico que no puede faltar a la hora de renovar tu ropero. Su logo en el frente está diseñado para poder combinarlo con cualquier prenda sin perder el estilo, y su corte clásico es ideal para mantenerte cómoda durante todo el día.', 9599, 1),
       (4, 7, 'R002', 'Red Bull Racing', 'Para vos que tenés una personalidad autentica y audaz que sabe lo que quiere, la Remera Puma Red Bull Racing Hombre con su llamativo estampado con gráficos visuales de una de las marcas más grandes del mundo te da un look informal y urbano, ideal para combinar con tus pantalones o joggers favoritos', 16599, 1),
       (4, 1, 'R003', 'Sportswear Air', 'La Remera Nike Sportswear Air es de esas prendas que visten tu look deportivo o casual y lo hacen a la perfección. Con un algodón suave y de calidad para durar muchos años y el logo de la marca en el frente que además, te mantiene fiel a tu estilo. ¿cuál es el plan? Bueno, eso no importa, el outfit ya está listo.', 14899, 1),
       (4, 5, 'R004', 'Dare To Relaxed', 'Tus días se llenan de deporte, sin renunciar a tu moda con la Remera Puma Dare To Relaxed. Una prenda cómoda y liviana para salir del gimnasio y recorrer la ciudad. Con un diseño cropped que se mantiene fiel a tu estilo y un algodón tan suave que no podrás dejar de usar. El logo Puma en el frente es el sello de la calidad que buscás.', 15499, 1),

       (6, 5, 'C001', 'Dare To', 'La Campera Puma Dare To es una prenda que trae moda retro a la actualidad para llenarte de estilo y personalidad. Con un diseño cropped y cuello de pico para crear un diseño insuperable que se complementa con un acabado arrugado, un dobladillo elástico y bolsillos grandes en el frente de la prenda. Sumá deporte a tus días con esta campera hecha para mujeres arriesgadas.', 36199, 1),
       (6, 5, 'C002', 'Windrunner', 'Con la Campera Nike Windrunner Hombre vas a lucir un look icónico y elegante. Gracias a los logotipos de la marca bordados en el pecho, el puño de las mangas y la espalda, vas a poder elevar tu look a niveles muy altos. Su suave tejido de tafetán aporta un estilo relajado y canchero y, al mismo tiempo, te protege en condiciones de lluvia', 45199, 1);


INSERT INTO Imagenes (ID_Producto, ImagenURL, Descripcion)
VALUES (1, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw67fd9607/products/NI_DH5111-100/NI_DH5111-100-1.JPG', 'Air Max Pre-Day Se'),
       (1, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw0d929b5d/products/NI_DH5111-100/NI_DH5111-100-2.JPG', 'Air Max Pre-Day Se'),
       (1, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw26f09e8d/products/NI_DH5111-100/NI_DH5111-100-3.JPG', 'Air Max Pre-Day Se'),
       (1, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw8e1baf3c/products/NI_DH5111-100/NI_DH5111-100-4.JPG', 'Air Max Pre-Day Se'),
       (1, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw5508934e/products/NI_DH5111-100/NI_DH5111-100-6.JPG', 'Air Max Pre-Day Se'),
       (1, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw9cf27003/products/NI_DH5111-100/DH5111-100-7.JPG', 'Air Max Pre-Day Se'),

       (2, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwf7961b97/products/NIDR0092-001/NIDR0092-001-1.JPG', 'Air Jordan 5 Retro GTX'),
       (2, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw096af25c/products/NIDR0092-001/NIDR0092-001-2.JPG', 'Air Jordan 5 Retro GTX'),
       (2, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwb515870b/products/NIDR0092-001/NIDR0092-001-3.JPG', 'Air Jordan 5 Retro GTX'),
       (2, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwec1c4775/products/NIDR0092-001/NIDR0092-001-4.JPG', 'Air Jordan 5 Retro GTX'),
       (2, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw28ab86ea/products/NIDR0092-001/NIDR0092-001-5.JPG', 'Air Jordan 5 Retro GTX'),
       (2, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw1e953147/products/NIDR0092-001/NIDR0092-001-6.JPG', 'Air Jordan 5 Retro GTX'),

       (3, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw3e80060d/products/PU392340-01/PU392340-01-1.JPG', 'Rs-X Triple'),
       (3, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw22275785/products/PU392340-01/PU392340-01-2.JPG', 'Rs-X Triple'),
       (3, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwd4305455/products/PU392340-01/PU392340-01-3.JPG', 'Rs-X Triple'),
       (3, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw0cc2c861/products/PU392340-01/PU392340-01-4.JPG', 'Rs-X Triple'),
       (3, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw3327c9ee/products/PU392340-01/PU392340-01-6.JPG', 'Rs-X Triple'),
       (3, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw3e80060d/products/PU392340-01/PU392340-01-1.JPG', 'Rs-X Triple'),

       (4, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw5623dddf/products/NIDH6927-140/NIDH6927-140-1.JPG', 'Jordan Air 4 Retro'),
       (4, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwce8ec021/products/NIDH6927-140/NIDH6927-140-2.JPG', 'Jordan Air 4 Retro'),
       (4, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw9e2341d0/products/NIDH6927-140/NIDH6927-140-3.JPG', 'Jordan Air 4 Retro'),
       (4, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw2fbb066e/products/NIDH6927-140/NIDH6927-140-4.JPG', 'Jordan Air 4 Retro'),
       (4, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw9481cc6e/products/NIDH6927-140/NIDH6927-140-5.JPG', 'Jordan Air 4 Retro'),
       (4, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw98289ec1/products/NIDH6927-140/NIDH6927-140-6.JPG', 'Jordan Air 4 Retro'),

       (5, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw583493a3/products/VA_VN0A4BRWY28/VA_VN0A4BRWY28-1.JPG', 'Vans Classic'),
       (5, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw8d36971f/products/VA_VN0A4BRWY28/VA_VN0A4BRWY28-2.JPG', 'Vans Classic'),
       (5, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwf34e7984/products/VA_VN0A4BRWY28/VA_VN0A4BRWY28-3.JPG', 'Vans Classic'),

       (6, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwe26aa3b7/products/PU534998-01/PU534998-01-1.JPG', 'Puma Red Bull Racing'),
       (6, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw43d813e3/products/PU534998-01/PU534998-01-2.JPG', 'Puma Red Bull Racing'),
       (6, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwd68d1545/products/PU534998-01/PU534998-01-3.JPG', 'Puma Red Bull Racing'),

       (7, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw90aa1aab/products/NIDR7803-010/NIDR7803-010-1.JPG', 'Sportswear Air'),
       (7, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw62bfdd07/products/NIDR7803-010/NIDR7803-010-2.JPG', 'Sportswear Air'),
       (7, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw070e3e60/products/NIDR7803-010/NIDR7803-010-3.JPG', 'Sportswear Air'),

       (8, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw0f12deb3/products/PU538321-02/PU538321-02-1.JPG', 'Puma Dare To Relaxed'),
       (8, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw7ec5c093/products/PU538321-02/PU538321-02-2.JPG', 'Puma Dare To Relaxed'),
       (8, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwb5e66982/products/PU538321-02/PU538321-02-3.JPG', 'Puma Dare To Relaxed'),

       (9, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwde421483/products/PU538340-92/PU538340-92-1.JPG', 'Puma Dare To'),
       (9, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw86c44d98/products/PU538340-92/PU538340-92-2.JPG', 'Puma Dare To'),
       (9, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw71734b9c/products/PU538340-92/PU538340-92-3.JPG', 'Puma Dare To'),

       (10, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwca65c578/products/NIDX0694-010/NIDX0694-010-1.JPG', 'Nike Windrunner'),
       (10, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw8017d746/products/NIDX0694-010/NIDX0694-010-2.JPG', 'Nike Windrunner'),
       (10, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw75cfbc8d/products/NIDX0694-010/NIDX0694-010-3.JPG', 'Nike Windrunner'),
       (10, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwfca43bb2/products/NIDX0694-010/NIDX0694-010-4.JPG', 'Nike Windrunner'),
       (10, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw3b4d1e8a/products/NIDX0694-010/NIDX0694-010-5.JPG', 'Nike Windrunner'),
       (10, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw3b913686/products/NIDX0694-010/NIDX0694-010-6.JPG', 'Nike Windrunner');


SELECT P.ID_Producto AS IDProducto, P.Nombre, P.Codigo, P.Descripcion, P.ID_Categoria AS IDCategoria, C.Nombre as Categoria, P.ID_Marca as IDMarca, M.Nombre as Marca, P.Precio, P.Estado
FROM Productos P 
INNER JOIN Marcas M ON P.ID_Marca = M.ID_Marca
INNER JOIN Categorias C ON P.ID_Categoria = C.ID_Categoria

SELECT * FROM Imagenes
WHERE ID_Producto = 2