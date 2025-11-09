Feature: NuevaVenta

Background: 
Given el usuario ingresa al ambiente 'http://localhost:31096/'
When el usuario inicia sesión con usuario 'admin@plazafer.com' y contraseña 'calidad'
And accede al módulo 'Venta'
And accede al submódulo 'Nueva Venta'


@RegistrarVenta
Scenario: Registro de una nueva venta con pago al contado <condicion>
	When el usuario agrega el concepto '<concepto>'
	And ingresa la cantidad '<cantidad>'
    And selecciona igv 
    And selecciona al cliente con documento '<documento>'
    And selecciona el tipo de comprobante '<tipo_comprobante>'
	And selecciona el tipo de entrega '<tipo_entrega>'
    And selecciona el tipo de pago '<tipo_pago>'
    And selecciona el medio de pago '<medio_pago>'
    And ingrese la informacion del pago '<informacion_pago>'
    Then la venta se guarda correctamente
    Examples: 
	| condicion | concepto  | cantidad | documento   | tipo_comprobante            | tipo_entrega | tipo_pago | medio_pago | informacion_pago |
	| 1         | 400000437 | 1        | 60587924    | FACTURA ELECTRONICA         | INMEDIATA    | CO        | EF         | 130.00           |
	| 2         | 400000437 | 1        | 60587924    | FACTURA ELECTRONICA         | DIFERIDA     | CO        | EF         | 130.00           |
	| 3         | 400000437 | 1        | 60587924    | BOLETA DE VENTA ELECTRONICA | INMEDIATA    | CO        | EF         | 130.00           |
	| 4         | 400000437 | 1        | 60587924    | BOLETA DE VENTA ELECTRONICA | DIFERIDA     | CO        | EF         | 130.00           |
	| 5         | 400000437 | 1        | 20608671880 | FACTURA ELECTRONICA         | INMEDIATA    | CO        | EF         | 130.00           |
	| 6         | 400000437 | 1        | 20608671880 | FACTURA ELECTRONICA         | DIFERIDA     | CO        | EF         | 130.00           |
	| 7         | 400000437 | 1        | 20608671880 | BOLETA DE VENTA ELECTRONICA | INMEDIATA    | CO        | EF         | 130.00           |
	| 8         | 400000437 | 1        | 20608671880 | BOLETA DE VENTA ELECTRONICA | DIFERIDA     | CO        | EF         | 130.00           |
	| 9         | 400000437 | 9999     | 60587924    | FACTURA ELECTRONICA         | INMEDIATA    | CO        | EF         | 130.00           |
	| 10        | 400000437 | 9999     | 60587924    | FACTURA ELECTRONICA         | DIFERIDA     | CO        | EF         | 130.00           |
	| 11        | 400000437 | 9999     | 60587924    | BOLETA DE VENTA ELECTRONICA | INMEDIATA    | CO        | EF         | 130.00           |
	| 12        | 400000437 | 9999     | 60587924    | BOLETA DE VENTA ELECTRONICA | DIFERIDA     | CO        | EF         | 130.00           |
	| 13        | 400000437 | 9999     | 20608671880 | BOLETA DE VENTA ELECTRONICA | INMEDIATA    | CO        | EF         | 130.00           |
	| 14        | 400000437 | 9999     | 20608671880 | FACTURA ELECTRONICA         | DIFERIDA     | CO        | EF         | 130.00           |
	| 15        | 400000437 | 9999     | 20608671880 | FACTURA ELECTRONICA         | INMEDIATA    | CO        | EF         | 130.00           |
	| 16        | 400000437 | 9999     | 20608671880 | BOLETA DE VENTA ELECTRONICA | DIFERIDA     | CO        | EF         | 130.00           |
	| 17        |           | 1        | 60587924    | NOTA DE VENTA (INTERNA)     | INMEDIATA    | CO        | EF         | 130.00           |
	| 18        |           | 1        | 60587924    | NOTA DE VENTA (INTERNA)     | DIFERIDA     | CO        | EF         | 130.00           |
	| 19        |           | 1        | 60587924    | NOTA DE VENTA (INTERNA)     | INMEDIATA    | CO        | EF         | 130.00           |
	| 20        |           | 1        | 60587924    | NOTA DE VENTA (INTERNA)     | DIFERIDA     | CO        | EF         | 130.00           |
	| 21        |           | 1        | 20608671880 | NOTA DE VENTA (INTERNA)     | INMEDIATA    | CO        | EF         | 130.00           |
	| 22        |           | 1        | 20608671880 | NOTA DE VENTA (INTERNA)     | DIFERIDA     | CO        | EF         | 130.00           |
	| 23        |           | 1        | 20608671880 | NOTA DE VENTA (INTERNA)     | INMEDIATA    | CO        | EF         | 130.00           |
	| 24        |           | 1        | 20608671880 | NOTA DE VENTA (INTERNA)     | DIFERIDA     | CO        | EF         | 130.00           |
	| 25        |           | 9999     | 60587924    | NOTA DE VENTA (INTERNA)     | INMEDIATA    | CO        | EF         | 130.00           |
	| 26        |           | 9999     | 60587924    | NOTA DE VENTA (INTERNA)     | DIFERIDA     | CO        | EF         | 130.00           |
	| 27        |           | 9999     | 20608671880 | NOTA DE VENTA (INTERNA)     | INMEDIATA    | CO        | EF         | 130.00           |
	| 28        |           | 9999     | 20608671880 | NOTA DE VENTA (INTERNA)     | DIFERIDA     | CO        | EF         | 130.00           |
	| 29        |           | 9999     | 20608671880 | NOTA DE VENTA (INTERNA)     | INMEDIATA    | CO        | EF         | 130.00           |
	| 30        |           | 9999     | 20608671880 | NOTA DE VENTA (INTERNA)     | DIFERIDA     | CO        | EF         | 130.00           |
	| 31        |           | 9999     | 60587924    | NOTA DE VENTA (INTERNA)     | INMEDIATA    | CO        | EF         | 130.00           |
	| 32        |           | 9999     | 60587924    | NOTA DE VENTA (INTERNA)     | DIFERIDA     | CO        | EF         | 130.00           |
	| 33        | 400000437 | -4       | 20608671880 | FACTURA ELECTRONICA         | DIFERIDA     | CO        | EF         | 130.00           |
	| 34        | 400000437 | 0        | 20608671880 | FACTURA ELECTRONICA         | DIFERIDA     | CO        | EF         | 130.00           |
	| 35        | 400000437 | 20       | 20608671880 | FACTURA ELECTRONICA         | DIFERIDA     | CO        | EF         | 130.00           |
	| 36        | 400000437 | 9999     | 20608671880 | FACTURA ELECTRONICA         | DIFERIDA     | CO        | EF         | 130.00           |
	| 37        | 400000437 | 1        | 20608671880 | FACTURA ELECTRONICA         | DIFERIDA     | CO        | EF         | -5               |
	| 38        | 400000437 | 1        | 20608671880 | FACTURA ELECTRONICA         | DIFERIDA     | CO        | EF         | 0                |
	| 39        | 400000437 | 1        | 20608671880 | FACTURA ELECTRONICA         | DIFERIDA     | CO        | EF         | 1                |
	| 40  | 400000437 | 1    | 20608671880 | FACTURA ELECTRONICA            | DIFERIDA  |CO        | EF         | 10           |


