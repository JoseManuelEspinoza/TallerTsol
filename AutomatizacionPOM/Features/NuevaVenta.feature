Feature: NuevaVenta

Background: 
Given el usuario ingresa al ambiente 'http://localhost:31096/'
When el usuario inicia sesión con usuario 'admin@plazafer.com' y contraseña 'calidad'
And accede al módulo 'Venta'
And accede al submódulo 'Nueva Venta'


@RegistrarVenta
Scenario: Registro de una nueva venta con pago al contado
	When el usuario agrega el concepto '400000437'
	And ingresa la cantidad '2'
    And selecciona igv
    And selecciona al cliente con documento '60587924'
    And selecciona el tipo de comprobante 'BOLETA'
    And selecciona el tipo de entrega 
    And selecciona el tipo de fecha '30/12/2025'
    And introduce el peso bruto '50'
    And introduce el numero de bultos '5'
    And selecciona la modalidad de transporte 'TRANSPORTE PÚBLICO'
    And introduce el numero de identifacion '20608671880'
    And introduce el detalle de origen "CASA BLANCA"
    And selecciona el detalle de destino "CASA NEGRA CON ROJA"
    And guardar guia
    And selecciona el tipo de pago 'Crédito'
    And selecciona el medio de pago 'TDEB'
    And ingrese la informacion del pago 'cancelado'
    Then la venta se guarda correctamente


