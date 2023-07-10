USE E_COMMERCE12

-- PROVINCIAS
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


-- MARCAS
INSERT INTO Marcas (Nombre, Estado)
VALUES ('Nike', 1),
       ('Converse', 1),
       ('Calvin Klein', 1),
       ('Rebook', 1),
       ('Puma', 1),
       ('Vans', 1),
       ('Red Bull', 1),
       ('Adidas', 1);


-- CATEGORIAS
INSERT INTO Categorias (Nombre, Estado)
VALUES ('Zapatillas', 1),
       ('Pantalones', 1),
       ('Medias', 1),
       ('Remeras', 1),
       ('Buzos', 1),
       ('Camperas', 1),
       ('Conjuntos Deportivos', 1);


-- TIPOS DE USUARIO
INSERT INTO TipoUsuario (Nombre)
VALUES  ('Usuario'),
        ('Vendedor'),
        ('Admin');

-- ESTADOS VENTA
INSERT INTO EstadoVenta (Estado)
VALUES ('PAGO PENDIENTE'),
       ('PAGADO'),
       ('EN PROCESO'),
       ('ENVIADO'),
       ('ENTREGADO'),
       ('CANCELADO');
       
-- PRODUCTOS
INSERT INTO Productos (ID_Categoria, ID_Marca, Codigo, Nombre, Descripcion, Precio, Stock, Estado)
VALUES (1, 1, 'Z001', 'Air Max Pre-Day Se', 'Manteniéndose fiel al estilo running pero agregando un estilo deportivo muy moderno, las Zapatillas Nike Air Max Pre-Day llegan a tus días para sacar la audacia que hay dentro tuyo. Con estampados de animales potentes y colores animados este calzado construye un patchwork ideal para tu look salvaje y atrevido.', 75, 10, 1),
       (1, 1, 'Z002', 'Air Jordan 5 Retro GTX', 'Conquistá la noche con las Zapatillas Air Jordan 5 Retro GTX Mujer. Un par que te alista para todas las temporadas y te mantiene fiel a tu estilo noventoso. Construidas con material súper resistente, cuero de primera calidad y características impermeables.', 150, 10, 1),
       (1, 5, 'Z003', 'Rs-X Triple', 'Las Zapatillas Puma Rs-X Triple Unisex son ideales para que te acompañen a donde quieras. Poseen una capellada de sintético y una suela de goma que brindan una resistencia inigualable. Su diseño moderno permite que siempre estés a la moda y, a la vez, que te sientas cómoda para enfrentar tu jornada.', 47.69, 10, 1),
       (1, 1, 'Z004', 'Jordan Air 4 Retro', 'Las Zapatillas Jordan Air 4 Retro Hombre actualizan la moda otoñal trayendo un calzado totalmente blanco con toques en azul marino medianoche para resaltar tu outfit y mantenerte fiel al AF. Con las famosas alas o ribetes para pasar los cordones que agregan el toque moderno que esperás.', 126.49, 10, 1),

       (4, 6, 'R001', 'Vans Classic', 'Vos que tenés claro que la moda pasa pero el estilo permanece, seguí tu instinto con la Remera Vans Classic es un clásico que no puede faltar a la hora de renovar tu ropero. Su logo en el frente está diseñado para poder combinarlo con cualquier prenda sin perder el estilo, y su corte clásico es ideal para mantenerte cómoda durante todo el día.', 9.59, 10, 1),
       (4, 7, 'R002', 'Red Bull Racing', 'Para vos que tenés una personalidad autentica y audaz que sabe lo que quiere, la Remera Puma Red Bull Racing Hombre con su llamativo estampado con gráficos visuales de una de las marcas más grandes del mundo te da un look informal y urbano, ideal para combinar con tus pantalones o joggers favoritos', 16.59, 10, 1),
       (4, 1, 'R003', 'Sportswear Air', 'La Remera Nike Sportswear Air es de esas prendas que visten tu look deportivo o casual y lo hacen a la perfección. Con un algodón suave y de calidad para durar muchos años y el logo de la marca en el frente que además, te mantiene fiel a tu estilo. ¿cuál es el plan? Bueno, eso no importa, el outfit ya está listo.', 14.89, 10, 1),
       (4, 5, 'R004', 'Dare To Relaxed', 'Tus días se llenan de deporte, sin renunciar a tu moda con la Remera Puma Dare To Relaxed. Una prenda cómoda y liviana para salir del gimnasio y recorrer la ciudad. Con un diseño cropped que se mantiene fiel a tu estilo y un algodón tan suave que no podrás dejar de usar. El logo Puma en el frente es el sello de la calidad que buscás.', 15.49, 10, 1),

       (6, 5, 'C001', 'Dare To', 'La Campera Puma Dare To es una prenda que trae moda retro a la actualidad para llenarte de estilo y personalidad. Con un diseño cropped y cuello de pico para crear un diseño insuperable que se complementa con un acabado arrugado, un dobladillo elástico y bolsillos grandes en el frente de la prenda. Sumá deporte a tus días con esta campera hecha para mujeres arriesgadas.', 36.19, 10, 1),
       (6, 5, 'C002', 'Windrunner', 'Con la Campera Nike Windrunner Hombre vas a lucir un look icónico y elegante. Gracias a los logotipos de la marca bordados en el pecho, el puño de las mangas y la espalda, vas a poder elevar tu look a niveles muy altos. Su suave tejido de tafetán aporta un estilo relajado y canchero y, al mismo tiempo, te protege en condiciones de lluvia', 45.19, 10, 1),
       (7, 5, 'C003', 'Individual Rise Hombre', 'Salí a ejercitarte con la mejor compañía con el Conjunto Entrenamiento Puma Individual Rise Hombre. Su construcción en materiales ligeros te da la calidez que necesitás y la transpirabilidad en los momentos de mayor esfuerzo. Tiene un diseño discreto, cómodo y práctico gracias a los bolsillos en ambas prendas y el cierre que te permite usarlo en los días de frío y en los de mayor temperatura.', 38.19, 10, 1),

       (5, 8, 'B001', 'Urbano Classics Trefoil Hombre', 'Salí a ejercitarte con la mejor compañía. Su construcción en materiales ligeros te da la calidez que necesitás y la transpirabilidad en los momentos de mayor esfuerzo. Tiene un diseño discreto, cómodo y práctico gracias a los bolsillos en ambas prendas y el cierre que te permite usarlo en los días de frío y en los de mayor temperatura.', 45.99, 10, 1),
       (5, 3, 'B002', 'Urbo Diagonal', 'Salí a ejercitarte con la mejor compañía. Su construcción en materiales ligeros te da la calidez que necesitás y la transpirabilidad en los momentos de mayor esfuerzo. Tiene un diseño discreto, cómodo y práctico gracias a los bolsillos en ambas prendas y el cierre que te permite usarlo en los días de frío y en los de mayor temperatura.', 45.99, 10, 1),
       (5, 8, 'B003', 'adidas Camo Series Infill', ' Su logo en el frente está diseñado para poder combinarlo con cualquier prenda sin perder el estilo, y su corte clásico es ideal para mantenerte cómoda durante todo el día.', 58.99, 10, 1),
       (5, 6, 'B004', 'Urbano Vans Core Basic Unisex', 'Con el Buzo Vans Core Basic Hombre sentite siempre en tendencia. Su amplio bolsillo tipo canguro en la parte delantera permite que tus objetos personales se mantengan seguros en todo momento. Mantenete cómodo a toda hora con su tela suave de algodón y su capucha con cordones para que lo ajustes como quieras. Abrigate con estilo.', 32.89, 10, 1),

       (3, 8, 'M001', 'Medias adidas Clasicos', 'Adecuadas para todo el dia', 7.99, 10, 1),
       (3, 1, 'M002', 'Pack de medias Nike Everyday Plus', 'El Pack de medias Nike Everyday Plus trae 2 pares de medias livianas, cómodas y con un ajuste perfecto para acompañarte en toda tu rutina, evitando molestias en tus pies a la hora de entrenar y dar todo de vos en el gimnasio o en el club', 7.39, 10, 1),

       (2, 5, 'P001', 'Pantalon Puma Classics', 'Ir a correr una mañana fresca o estar relajada en casa, siempre será mejor con el Pantalón Puma Classics Mujer. Una prenda suave, liviana y cómoda que costará sacar al momento de ir a la oficina. Con un diseño relajado y puños que liberan tus movimientos y evitan la entrada de frío. Una cintura elástica se mueve con vos alejando las incomodidades de tu cuerpo. Con el logo Puma en el frente que es el detalle de calidad que elegís vestir.', 27.99, 10, 1),
       (2, 8, 'P002', 'Pantalón adidas Adicolor', 'Lucite en cualquier ocasión mostrando tu estilo y dedicación por la moda; lleva el Pantalón adidas Adicolor y no dejes que te falte una prenda que resalta cualquier look que elijas. Está elaborado en algodón y poliéster para brindarle suavidad y durabilidad. Sus bolsillos son prácticos, para llevar todo lo que necesites con vos, y el diseño liso te permite combinarlo con todos tus outfits favoritos a la hora de encarar tu rutina.', 39.99, 10, 1),
       (2, 8, 'P003', 'Pantalon adidas Mat Pt', 'Lucite en cualquier ocasión mostrando tu estilo y dedicación por la moda', 15.79, 10, 1),
        (4, 2, 'R005', 'Remera Converse Laces', 'Adecuada para todo el día', 13.49, 10, 1);

-- IMAGENES
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
       (10, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw3b913686/products/NIDX0694-010/NIDX0694-010-6.JPG', 'Nike Windrunner'),

       (11, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw644f9fdd/products/PU657534-01/PU657534-01-1.JPG', 'Individual Rise Hombre'),
       (11, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwe294883a/products/PU657534-01/PU657534-01-2.JPG', 'Individual Rise Hombre'),
       (11, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw9241457d/products/PU657534-01/PU657534-01-3.JPG', 'Individual Rise Hombre'),
       (11, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw7fecb0c3/products/PU657534-01/PU657534-01-4.JPG', 'Individual Rise Hombre'),
       (11, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwc64c47e3/products/PU657534-01/PU657534-01-5.JPG', 'Individual Rise Hombre'),
       (11, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw6523e49a/products/PU657534-01/PU657534-01-6.JPG', 'Individual Rise Hombre'),

       (12, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw87aa6e23/products/ADHK7270/ADHK7270-1.JPG', 'Urbano adidas Adicolor Classics Trefoil Hombre'),
       (12, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw32bdcda8/products/ADHK7270/ADHK7270-2.JPG', 'Urbano adidas Adicolor Classics Trefoil Hombre'),
       (12, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw82ffc83a/products/ADHK7270/ADHK7270-3.JPG', 'Urbano adidas Adicolor Classics Trefoil Hombre'),
       (12, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwfde2218f/products/ADHK7270/ADHK7270-4.JPG', 'Urbano adidas Adicolor Classics Trefoil Hombre'),

       (13, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw2a9ea809/products/UR_NIFW22001/UR_NIFW22001-1.JPG', 'Buzo Urbo Diagonal'),
       (13, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwc51cf88a/products/UR_NIFW22001/UR_NIFW22001-2.JPG', 'Buzo Urbo Diagonal'),
       (13, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw5c35bc2c/products/UR_NIFW22001/UR_NIFW22001-3.JPG', 'Buzo Urbo Diagonal'),

       (14, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw88777836/products/ADHK2802/ADHK2802-1.JPG', 'adidas Camo Series Infill'),
       (14, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwe5092849/products/ADHK2802/ADHK2802-2.JPG', 'adidas Camo Series Infill'),
       (14, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw97333719/products/ADHK2802/ADHK2802-3.JPG', 'adidas Camo Series Infill'),

       (15, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw06abdb39/products/VAVN0A7YDV3KSCASA/VAVN0A7YDV3KSCASA-1.JPG', 'Buzo Urbano Vans Core Basic Unisex'),
       (15, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwf63431e5/products/VAVN0A7YDV3KSCASA/VAVN0A7YDV3KSCASA-2.JPG', 'Buzo Urbano Vans Core Basic Unisex'),
       (15, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwdd5f2798/products/VAVN0A7YDV3KSCASA/VAVN0A7YDV3KSCASA-3.JPG', 'Buzo Urbano Vans Core Basic Unisex'),
       (15, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw567105b7/products/VAVN0A7YDV3KSCASA/VAVN0A7YDV3KSCASA-4.JPG', 'Buzo Urbano Vans Core Basic Unisex'),
       (15, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw750ded07/products/VAVN0A7YDV3KSCASA/VAVN0A7YDV3KSCASA-5.JPG', 'Buzo Urbano Vans Core Basic Unisex'),

       (16, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw8c21b93a/products/ADHL6765/ADHL6765-1.JPG', 'Medias adidas Clasicos'),
       (16, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw945f6f62/products/ADHL6765/ADHL6765-2.JPG', 'Medias adidas Clasicos'),

       (17, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw7973bb82/products/NIDQ7698-903/NIDQ7698-903-1.JPG', 'Pack de medias Nike Everyday Plus'),
       (17, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw7b3b9f6b/products/NIDQ7698-903/NIDQ7698-903-2.JPG', 'Pack de medias Nike Everyday Plus'),

       (18, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwdf2f4c4d/products/PU535685-01/PU535685-01-1.JPG', 'Pantalon Puma Classics'),
       (18, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwe314ca00/products/PU535685-01/PU535685-01-2.JPG', 'Pantalon Puma Classics'),
       (18, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwff94fa50/products/PU535685-01/PU535685-01-3.JPG', 'Pantalon Puma Classics'),
       (18, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw3250b024/products/PU535685-01/PU535685-01-4.JPG', 'Pantalon Puma Classics'),

       (19, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw135b0f93/products/AD_HF7529/AD_HF7529-1.JPG', 'Pantalón adidas Adicolor'),
       (19, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwd37e8255/products/AD_HF7529/AD_HF7529-2.JPG', 'Pantalón adidas Adicolor'),
       (19, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwdba04fe2/products/AD_HF7529/AD_HF7529-3.JPG', 'Pantalón adidas Adicolor'),

       (20, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw8be6443b/products/ADGT0168/ADGT0168-1.JPG', 'Pantalon adidas Mat Pt'),
       (20, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw4b603f6b/products/ADGT0168/ADGT0168-2.JPG', 'Pantalon adidas Mat Pt'),
       (20, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwaea7c3d2/products/ADGT0168/ADGT0168-3.JPG', 'Pantalon adidas Mat Pt'),

       (21, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw6195a924/products/COD5602401/COD5602401-1.JPG', 'Remera Converse Laces'),
       (21, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwcfa4c7bc/products/COD5602401/COD5602401-2.JPG', 'Remera Converse Laces'),
       (21, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw1647078d/products/COD5602401/COD5602401-3.JPG', 'Remera Converse Laces'),
       (21, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwb43c5bad/products/COD5602401/COD5602401-4.JPG', 'Remera Converse Laces'),
       (21, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwb43c5bad/products/COD5602401/COD5602401-4.JPG', 'Remera Converse Laces'),
       (21, 'https://www.moov.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw5b14c102/products/COD5602401/COD5602401-5.JPG', 'Remera Converse Laces');



-- USER COMUN
INSERT INTO Usuarios (ID_TipoUsuario, Dni, Nombre, Apellido, Email, Contrasena, Telefono, FechaNacimiento, Estado)
VALUES (1, '34655789', 'Juan', 'Perez', 'juanperez@gmail.com', '7f25da57311a420ee12b065d163eecab55538f34ec017db5d34628914fc48dde', '2995323232', GETDATE(), 1);

-- USER VENDEDOR
INSERT INTO Usuarios (ID_TipoUsuario, Dni, Nombre, Apellido, Email, Contrasena, Telefono, FechaNacimiento, Estado)
VALUES (2, '34986521', 'Elven', 'Dedor', 'elvendedor@gmail.com', '7f25da57311a420ee12b065d163eecab55538f34ec017db5d34628914fc48dde', '2995123123', GETDATE(), 1);

-- USER ADMIN (TODAS LAS PASS SON luis1234)
INSERT INTO Usuarios (ID_TipoUsuario, Dni, Nombre, Apellido, Email, Contrasena, Telefono, FechaNacimiento, Estado)
VALUES (3, '0000001', 'Admin', 'Admin', 'admin@email.com', '7f25da57311a420ee12b065d163eecab55538f34ec017db5d34628914fc48dde', '0000000', GETDATE(), 1);

-- USER ADMIN (TODAS LAS PASS SON luis1234)
INSERT INTO Usuarios (ID_TipoUsuario, Dni, Nombre, Apellido, Email, Contrasena, Telefono, FechaNacimiento, Estado)
VALUES (3, '0000002', 'Admin1', 'Admin1', 'admin1@email.com', '7f25da57311a420ee12b065d163eecab55538f34ec017db5d34628914fc48dde', '0000000', GETDATE(), 1);

-- USER ADMIN (TODAS LAS PASS SON luis1234)
use E_COMMERCE12
INSERT INTO Usuarios (ID_TipoUsuario, Dni, Nombre, Apellido, Email, Contrasena, Telefono, FechaNacimiento, Estado)
VALUES (3, '0000030', 'teguiu', 'stin', 'agustin@gmail.com', 'EstaEsLaPassDeTeguiu', '0000000', GETDATE(), 1);

-- DOMICILIO VENDEDOR
INSERT INTO Domicilios(ID_Usuario, ID_Provincia, Localidad, Calle, Numero, CodigoPostal, Estado)
VALUES (1, 14, 'Neuquen', 'Belgrano', '1500', '8300', 1);

-- DOMICILIO USER
INSERT INTO Domicilios(ID_Usuario, ID_Provincia, Localidad, Calle, Numero, CodigoPostal, Piso, Referencia, Alias, Estado)
VALUES (2, 14, 'Neuquen', 'Lainez', '2456', '8300', '1', 'Escalera blanca', 'Casa', 1);

delete from Facturas
select * from usuarios
select * from Productos_x_Factura WHERE ID_Factura = 41
select * from Ventas
INSERT INTO Facturas(Pago, Cancelada) VALUES(0,0)
SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID;

SELECT P.ID_Producto, P.Codigo, P.Descripcion, P.Estado, Cantidad 
FROM Productos_x_Factura PF
INNER JOIN Productos P ON PF.ID_Producto = P.ID_Producto
WHERE ID_Factura = @ID_Factura

SELECT P.ID_Producto AS IDProducto, P.Nombre, P.Codigo, P.Descripcion, P.ID_Categoria AS IDCategoria, C.Nombre as Categoria, P.ID_Marca as IDMarca, M.Nombre as Marca, P.Precio, P.Estado, P.Stock, PF.Cantidad, PF.ID_Factura FROM Productos P INNER JOIN Productos_x_Factura PF ON P.ID_Producto = PF.ID_Factura INNER JOIN Marcas M ON P.ID_Marca = M.ID_Marca INNER JOIN Categorias C ON P.ID_Categoria = C.ID_Categoria WHERE PF.ID_Factura = @ID_Factura
SELECT ID_Venta, ID_Factura, ID_Usuario, ID_Estado, Monto Fecha FROM Ventas
SELECT ID_Venta, ID_Factura, ID_Usuario, ID_Estado, Monto, Fecha FROM Ventas



SELECT V.ID_Venta, V.ID_Usuario, V.ID_Estado, EV.Estado as EstadoVenta, V.Monto, V.Fecha, F.Cancelada, F.Pago, F.ID_Factura, U.ID_Usuario, U.ID_TipoUsuario, TU.Nombre AS TipoUsuario, U.Dni, U.Nombre, U.Apellido, U.Email, U.Telefono, U.FechaNacimiento, U.Estado AS EstadoUsuario, D.ID_Domicilio, D.Localidad, D.Calle, D.Numero, D.CodigoPostal, D.Piso, D.Referencia, D.Alias, D.Estado AS EstadoDomicilio, P.ID_Provincia, P.Nombre as Provincia FROM Ventas V INNER JOIN Facturas F ON V.ID_Factura = F.ID_Factura INNER JOIN Usuarios U ON V.ID_Usuario = U.ID_Usuario INNER JOIN TipoUsuario TU ON U.ID_TipoUsuario = TU.ID_Tipo INNER JOIN EstadoVenta EV ON V.ID_Estado = EV.ID_Estado INNER JOIN Domicilios D INNER JOIN Provincias P ON D.ID_Provincia = P.ID_Provincia