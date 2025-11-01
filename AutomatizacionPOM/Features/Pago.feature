Feature: Pago

Background: 
Given el usuario ingresa al ambiente 'http://localhost:31096/'
When el usuario inicia sesión con usuario 'admin@plazafer.com' y contraseña 'calidad'
And accede al módulo 'Venta'
And accede al submódulo 'Nueva Venta'
And el usuario agrega el concepto '400000437'
And ingresa la cantidad '2'
And selecciona igv
And selecciona al cliente con documento '60587924'
And selecciona el tipo de comprobante 'BOLETA'

# Escenarios para Pago en Efectivo (Casos 1-26)
@PagoEfectivo
Scenario: Pago en Efectivo - Condicion <condicion>
	When el usuario selecciona el tipo de pago '<tipo_pago>'
	And el usuario selecciona el medio de pago 'EF'
	And el usuario ingresa el monto recibido '<recibido>'
	Then la venta se guarda correctamente
	Examples: 
	| condicion | tipo_pago | recibido |
	| 1         | CO      | 100      |

# Escenarios para Tarjeta de Crédito (Casos 3-10, 27-30)
@TarjetaCredito
Scenario Outline: Pago con Tarjeta de Credito - Condicion <condicion>
    When selecciona el tipo de pago '<tipo_pago>'
    And selecciona el medio de pago 'TCRE'
    And ingresa nombre del banco '<nombre_banco>'
    And selecciona tipo de tarjeta '<tipo_tarjeta>'
    And ingresa número de operación '<numero_operacion>'
    Then la venta se guarda correctamente

    Examples:
        | condicion | tipo_pago | nombre_banco | tipo_tarjeta | numero_operacion |
        | 3         | "CO"  | "SCOTIABANK"  | "VISA"       | "1234567890"     |     

# Escenarios para Tarjeta de Débito (Casos 11-18)
@TarjetaDebito
Scenario Outline: Pago con Tarjeta de Débito - Condición <condicion>
    When selecciona el tipo de pago '<tipo_pago>'
    And selecciona el medio de pago 'TDEB'
    And ingresa nombre del banco '<nombre_banco>'
    And selecciona tipo de tarjeta '<tipo_tarjeta>'
    And ingresa número de operación '<numero_operacion>'
    Then la venta se guarda correctamente

    Examples:
        | condicion | tipo_pago | nombre_banco | tipo_tarjeta | numero_operacion |
        | 8         | "CO"   | "SCOTIABANK"  | "VISA"       | "1234567890"     |     

# Escenarios para Transferencia (Casos 19-22)
@Transferencia
Scenario Outline: Pago por Transferencia - Condición <condicion>
    When selecciona el tipo de pago '<tipo_pago>'
    And selecciona el medio de pago 'TRANFON'
    And ingresa cuenta bancaria correcta '<cuenta_correcta>'
    And ingresa número de operación '<numero_operacion>'
    Then la venta se guarda correctamente

    Examples:
        | condicion |tipo_pago  | cuenta_correcta  | numero_operacion |
        | 19        | Contado | "001103180100023457" | "TT00112233"     |
@Transferencia
Scenario Outline: Pago por Deposito - Condición <condicion>
    When selecciona el tipo de pago '<tipo_pago>'
    And selecciona el medio de pago 'DEPCU'
    And ingresa cuenta bancaria correcta '<cuenta_correcta>'
    And ingresa número de operación '<numero_operacion>'
    Then la venta se guarda correctamente

    Examples:
        | condicion |tipo_pago  | cuenta_correcta  | numero_operacion |
        | 20        | Contado | "001103180100023457" | "TT00112233"     |

# Escenarios para Crédito Configurado (Casos 27-42)
@CreditoConfigurado
Scenario Outline: Pago con Crédito Configurado - Condición <condicion>
    When selecciona el tipo de pago 'CC'
    And verifica cuota inicial '<cuota_inicial_menor_total>'
    And verifica cuotas totales '<cuotas_menor_total>'
    And selecciona día del mes de pago '<selecciona_dia>'
    And genera cuota 
    Then la venta se guarda correctamente

    Examples:
	| condicion | cuota_inicial_menor_total | cuotas_menor_total | selecciona_dia  |
	| 27        | 10                        | 2                  | 3 de cada mes |