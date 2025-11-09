Feature: Pago

Background:
  Given el usuario ingresa al ambiente 'http://localhost:31096/'
  When el usuario inicia sesión con usuario 'admin@plazafer.com' y contraseña 'calidad'
  And accede al módulo 'Venta'
  And accede al submódulo 'Nueva Venta'
  And el usuario agrega el concepto '400000437'
  And selecciona al cliente con documento '60587924'

# =========================
# 1–2 EFECTIVO (CO + EF)
# =========================
@PagoEfectivo
Scenario Outline: Pago en Efectivo - Condicion <condicion>
  When el usuario selecciona el tipo de pago '<tipo_pago>'
  And el usuario selecciona el medio de pago 'EF'
  And el usuario ingresa el monto recibido '<recibido>'
  Then el usuario guarda la venta correctamente
Examples:
  | condicion | tipo_pago | recibido |
  | 1  | CO | 130.00 |   # RECIBIDO > PAGO → éxito
  | 2  | CO | -1.00  |   # negativo → inconsistencia

# ===================================
# 3–10 TARJETA CRÉDITO (CO + TCRE)
# ===================================
@TarjetaCredito
Scenario Outline: Pago con Tarjeta de Credito - Condicion <condicion>
  When el usuario selecciona el tipo de pago '<tipo_pago>'
  And el usuario selecciona el medio de pago 'TCRE'
  And el usuario ingresa nombre del banco credito '<nombre_banco>'
  And el usuario selecciona tipo de tarjeta credito '<tipo_tarjeta>'
  And el usuario ingresa numero de operacion credito '<numero_operacion>'
  Then el usuario guarda la venta correctamente
Examples:
  | condicion | tipo_pago | nombre_banco                 | tipo_tarjeta     | numero_operacion |
  | 3  | CO | SCOTIABANK                 | VISA             | 1234567890  |
  | 4  | CO | INTERBANK                  | MASTER CARD      |              |
  | 5  | CO | BBVA CONTINENTAL           | AMERICAN EXPRESS | 123          |
  | 6  | CO | BANCO DE CREDITO DEL PERU  | DINERS CLUB      | 00112233     |
  | 7  | CO | BANCO DE LA NACION         | VISA             | 9876543210   |
  | 8  | CO | SCOTIABANK                 | MASTER CARD      | 000000       |
  | 9  | CO | INTERBANK                  | AMERICAN EXPRESS | 565656       |
  | 10 | CO | BBVA CONTINENTAL           | DINERS CLUB      | ABC-9090     |

# ==================================
# 11–18 TARJETA DÉBITO (CO + TDEB)
# ==================================
@TarjetaDebito
Scenario Outline: Pago con Tarjeta de Débito - Condición <condicion>
  When el usuario selecciona el tipo de pago '<tipo_pago>'
  And el usuario selecciona el medio de pago 'TDEB'
  And el usuario ingresa nombre del banco debito '<nombre_banco>'
  And el usuario selecciona tipo de tarjeta debito '<tipo_tarjeta>'
  And el usuario ingresa numero de operacion debito '<numero_operacion>'
  Then el usuario guarda la venta correctamente
Examples:
  | condicion | tipo_pago | nombre_banco                 | tipo_tarjeta     | numero_operacion |
  | 11 | CO | SCOTIABANK                 | VISA             | 1122334455  |
  | 12 | CO | INTERBANK                  | MASTER CARD      |             |
  | 13 | CO | BBVA CONTINENTAL           | AMERICAN EXPRESS | 9           |
  | 14 | CO | BANCO DE CREDITO DEL PERU  | DINERS CLUB      | 445566      |
  | 15 | CO | BANCO DE LA NACION         | VISA             | 123-XYZ     |
  | 16 | CO | SCOTIABANK                 | MASTER CARD      | 000001      |
  | 17 | CO | INTERBANK                  | AMERICAN EXPRESS | 5656AB      |
  | 18 | CO | BBVA CONTINENTAL           | DINERS CLUB      |             |

# ==============================
# 19–22 TRANSFERENCIA (TRANFON)
# ==============================
@Transferencia
Scenario Outline: Pago por Transferencia - Condición <condicion>
  When el usuario selecciona el tipo de pago '<tipo_pago>'
  And el usuario selecciona el medio de pago 'TRANFON'
  And el usuario ingresa cuenta bancaria correcta '<cuenta_correcta>'
  And el usuario ingresa numero de operacion '<numero_operacion>'
  Then el usuario guarda la venta correctamente
Examples:
  | condicion | tipo_pago | cuenta_correcta     | numero_operacion |
  | 19 | CO | 001103180100023457 | 00112233     |  # BBVA
  | 20 | CO | 001103180100023457 |              |
  | 21 | CO | 5601898737134      | ABC123       |  # BCP
  | 22 | CO | 5601898737134      | 77889955     |

# ==========================
# 23–26 DEPÓSITO (DEPCU)
# ==========================
@Deposito
Scenario Outline: Pago por Deposito - Condición <condicion>
  When el usuario selecciona el tipo de pago '<tipo_pago>'
  And el usuario selecciona el medio de pago 'DEPCU'
  And el usuario ingresa cuenta bancaria correcta '<cuenta_correcta>'
  And el usuario ingresa numero de operacion '<numero_operacion>'
  Then el usuario guarda la venta correctamente
Examples:
  | condicion | tipo_pago | cuenta_correcta     | numero_operacion |
  | 23 | CO | 001103180100023457 | 556677      |
  | 24 | CO | 5601898737134      | ABC-7788    |
  | 25 | CO | 5601898737134      | 90909090    |
  | 26 | CO | 001103180100023457 |             |

# ==============================================
# 27–42 CRÉDITO CONFIGURADO (CC + Financiamiento)
# ==============================================
@CreditoConfigurado
Scenario Outline: Pago con Crédito Configurado - Condición <condicion>
  When el usuario selecciona el tipo de pago '<tipo_pago>'
  And el usuario verifica cuota inicial '<cuota_inicial_menor_total>'
  And el usuario verifica cuotas totales '<cuotas_menor_total>'
  And el usuario selecciona dia del mes de pago '<selecciona_dia>'
  And el usuario genera cuota
  Then el usuario guarda la venta correctamente
Examples:
  | condicion | tipo_pago | cuota_inicial_menor_total | cuotas_menor_total | selecciona_dia |
  | 27        | CC        | 1.00                      | 2                  | 17 de cada mes |
  | 28        | CC        | 0.00                      | 0                  |                |
  | 29        | CC        | 8.70                      | 2                  | 12 de cada mes |
  | 30        | CC        | 12.00                     | 0                  |                |
  | 31        | CC        | 15.25                     | 3                  | 7 de cada mes  |
  | 32        | CC        | 60.00                     | 0                  |                |
  | 33        | CC        | 2.50                      | 4                  |                |
  | 34        | CC        | 18.90                     | 0                  |                |
  | 35        | CC        | 9.99                      | 5                  |                |
  | 36        | CC        | 55.00                     | 0                  |                |
  | 37        | CC        | 20.00                     | 6                  |                |
  | 38        | CC        | 0.10                      | 0                  |                |
  | 39        | CC        | 10.75                     | 8                  |                |
  | 40        | CC        | 43.48                     | 0                  |                |
  | 41        | CC        | 7.30                      | 12                 |                |
  | 42        | CC        | -5.00                     | -1                 | 5 de cada mes  |
  | 43        | CC        | -10.00                    | 2                  | 10 de cada mes  |
  | 44        | CC        | 1.00                      | 3                  | 4 de cada mes  |
  | 45        | CC        | 5.00                     |   5               | 6 de cada mes  |
  | 46        | CC        | 1.00                     | -4                 | 5 de cada mes  |
  | 47        | CC        | 1.00                     | 2                 | 10 de cada mes  |
  | 48        | CC        | 1.00                     | 5                 | 25 de cada mes  |

  
  
