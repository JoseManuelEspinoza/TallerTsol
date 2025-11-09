Feature: Guia

Background: 
Given el usuario ingresa al ambiente 'http://localhost:31096/'
When el usuario inicia sesión con usuario 'admin@plazafer.com' y contraseña 'calidad'
And accede al módulo 'Venta'
And accede al submódulo 'Nueva Venta'
And el usuario agrega el concepto '400000437'
And selecciona al cliente con documento '60587924'
And selecciona el tipo de entrega 'INMEDIATA'

@Publico
Scenario: Guia de para transporte publico <condicion>
	When selecciona destinatario '<destinatario>'
	And fecha inicio translado '<fecha>'
	And introduce el peso bruto '<p_bruto>'
	And introduce el numero de bultos '<n_bultos>'
    And selecciona la modalidad de transporte 'TRANSPORTE PÚBLICO'
    And introduce el numero de identifacion '<n_identificacion>'
	And introduce el detalle de origen '<detalle_origen>'
    And selecciona el detalle de destino '<detalle_destino>'
    Then guardar guia
Examples:
	| condicion | destinatario | fecha      | p_bruto | n_bultos | n_identificacion | detalle_origen       | detalle_destino |
	| 100 | 60587924 | 28/11/2025 | 100 | 20 | 20608671880 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 101 | 60587924 |  | 100 | 20 | 20608671880 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 102 | 60587924 | 28/11/2025 | 0 | 20 | 20608671880 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 103 | 60587924 | 28/11/2025 | 100 | 0 | 20608671880 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 104 | 60587924 | 28/11/2025 | 100 | 20 | 00000000000 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 105 | 60587924 | 28/11/2025 | 100 | 20 | 20608671880 |  | Calle Falsa 456 |
	| 106 | 60587924 | 28/11/2025 | 100 | 20 | 20608671880 | Av. Siempre Viva 123 |  |
	| 107 | 60587924 |  | 0 | 20 | 20608671880 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 108 | 60587924 |  | 100 | 0 | 20608671880 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 109 | 60587924 |  | 100 | 20 | 00000000000 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 110 | 60587924 | 28/11/2025 | 0 | 0 | 20608671880 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 111 | 60587924 | 28/11/2025 | 0 | 20 | 00000000000 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 112 | 60587924 | 28/11/2025 | 100 | 0 | 00000000000 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 113 | 60587924 | 28/11/2025 | 100 | 20 | 20608671880 |  |  |
	| 114 | 60587924 |  | 0 | 0 | 20608671880 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 115 | 60587924 |  | 0 | 20 | 00000000000 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 116 | 60587924 |  | 100 | 0 | 00000000000 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 117 | 60587924 | 28/11/2025 | 0 | 0 | 00000000000 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 118 | 60587924 | 28/11/2025 | 0 | 0 | 20608671880 |  |  |
	| 119 | 60587924 |  | 100 | 20 | 00000000000 |  |  |
	| 120 | 60587924 |  | 0 | 0 | 00000000000 |  |  |
	| 121 | 60587924 | 28/11/2025 | abc | 20 | 20608671880 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 122 | 60587924 | 28/11/2025 | 100 | xyz | 20608671880 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 123 | 60587924 | 32/13/2025 | 100 | 20 | 20608671880 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 124 | 60587924 | 28/11/2025 | -5 | 20 | 20608671880 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 125 | 60587924 | 28/11/2025 | 100 | -1 | 20608671880 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 126 | 60587924 | 28/11/2025 | 0 | 0 | 12345678901 |  |  |
	| 127 | 60587924 |  |  |  |  |  |  |
	| 128 | 60587924 | 28/11/2025 | 50 | 1 | 20608671880 | Jr. Sven Ericson N° 109 | Av. SpringField 742 |
	| 129 | 60587924 | 28/11/2025 | 1 | 1 | 20608671880 | Calle A 123 | Calle B 456 |
	| 130 | 60587924 | 20/11/2025 | 10.5 | 2 | 20608671880 | JR. LOS JASMÍNES | JR. VENABIDES |
	| 131 | 60587924 | 01/12/2025 | 999.99 | 100 | 20608671880 | Av. Siempre Viva 123 | Calle Falsa 456 |
#
@Privado
Scenario: Guia para transporte privado <condicion>
	When selecciona destinatario '<destinatario>'
	And fecha inicio translado '<fecha>'
	And introduce el peso bruto '<p_bruto>'
	And introduce el numero de bultos '<n_bultos>'
    And selecciona la modalidad de transporte 'TRANSPORTE PRIVADO'
    And introduce el numero de identifacion '<n_identificacion>'
	And introduce el numero de licencia'<n_licencia>'
	And introduce la placa '<placa>'
	And introduce el detalle de origen '<detalle_origen>'
    And selecciona el detalle de destino '<detalle_destino>'
    Then guardar guia
Examples:
	|condicion|destinatario|fecha       |p_bruto|n_bultos|n_identificacion|n_licencia|placa    |detalle_origen      |detalle_destino    |
	| 200 | 60587924 | 28/11/2025 | 200 | 30 | 60587924 | 123456789 | XYZ987 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 201 | 60587924 |  | 200 | 30 | 60587924 | 123456789 | XYZ987 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 202 | 60587924 | 28/11/2025 | 0 | 30 | 60587924 | 12345678 | XYZ987 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 203 | 60587924 | 28/11/2025 | 200 | 0 | 60587924 | 12345678 | XYZ987 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 204 | 60587924 | 28/11/2025 | 200 | 30 | 00000000 | 12345678 | XYZ987 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 205 | 60587924 | 28/11/2025 | 200 | 30 | 1234567 | 12345678 | XYZ987 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 206 | 60587924 | 28/11/2025 | 200 | 30 | 60587924 |  | XYZ987 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 207 | 60587924 | 28/11/2025 | 200 | 30 | 60587924 | 123456789 |  | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 208 | 60587924 | 28/11/2025 | 200 | 30 | 60587924 | 123456789 | XYZ987 |  | Calle Falsa 456 |
	| 209 | 60587924 | 28/11/2025 | 200 | 30 | 60587924 | 123456789 | XYZ987 | Av. Siempre Viva 123 |  |
	| 210 | 60587924 |  | 0 | 30 | 60587924 | 123456789 | XYZ987 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 211 | 60587924 |  | 200 | 0 | 60587924 | 123456789 | XYZ987 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 212 | 60587924 | 28/11/2025 | 0 | 0 | 60587924 | 123456789 | XYZ987 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 213 | 60587924 | 28/11/2025 | 200 | 30 | 00000000 |  | XYZ987 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 214 | 60587924 | 28/11/2025 | 200 | 30 | 60587924 |  |  | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 215 | 60587924 | 28/11/2025 | 200 | 30 | 00000000 | 12345678 | XYZ987 |  |  |
	| 216 | 60587924 |  | 0 | 0 | 00000000 |  |  |  |  |
	| 217 | 60587924 | 32/13/2025 | 200 | 30 | 60587924 | 123456789 | XYZ987 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 218 | 60587924 | 28/11/2025 | abc | 30 | 60587924 | 123456789 | XYZ987 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 219 | 60587924 | 28/11/2025 | 200 | xyz | 60587924 | 123456789 | XYZ987 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 220 | 60587924 | 28/11/2025 | -1 | 30 | 60587924 | 123456789 | XYZ987 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 221 | 60587924 | 28/11/2025 | 200 | -5 | 60587924 | 123456789 | XYZ987 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 222 | 60587924 | 20/11/2025 | 1 | 1 | 60587924 | A1-999999 | ABC123 | JR. LOS JASMÍNES | JR. VENABIDES |
	| 223 | 60587924 | 01/12/2025 | 999.99 | 100 | 60587924 | B2-111111 | DEF456 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 224 | 60587924 |  |  |  |  |  |  |  |  |
	| 225 | 60587924 | 28/11/2025 | 0 | 0 | 00000000 |  |  |  |  |
	| 226 | 60587924 | 28/11/2025 | 0 | 0 | 60587924 |  | XYZ987 |  |  |
	| 227 | 60587924 | 28/11/2025 | 0 | 0 | 60587924 | 12345678 |  |  |  |
	| 228 | 60587924 | 28/11/2025 | 0 | 0 | 60587924 |  |  |  |  |
	| 229 | 60587924 | 28/11/2025 | 10.5 | 2 | 60587924 | 99999999 | JKL789 | Calle A 123 | Calle B 456 |
	| 230 | 60587924 | 28/11/2025 | 5 | 1 | 60587924 | L-1234567 | MNO321 | Av. Siempre Viva 123 | Calle Falsa 456 |
	| 231 | 60587924 | 28/11/2025 | 50 | 10 | 45879632 | 55667788 | PQR654 | Av. Peru 123 | Av. Lima 456 |






