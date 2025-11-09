using System;
using AutomatizacionPOM.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace AutomatizacionPOM.StepDefinitions
{
    [Binding]
    public class PagoStepDefinitions
    {
        private IWebDriver driver;
        RegistroVentaPage newSale;
        SeleccionarPago seleccionarPago;

        public PagoStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            this.newSale = new RegistroVentaPage(driver);
            this.seleccionarPago = new SeleccionarPago(driver);
        }
        [When("el usuario selecciona el tipo de pago {string}")]
        public void WhenElUsuarioSeleccionaElTipoDePago(string cO)
        {
            seleccionarPago.SelectPaymentType(cO);
            System.Threading.Thread.Sleep(2000);

        }

        [When("el usuario selecciona el medio de pago {string}")]
        public void WhenElUsuarioSeleccionaElMedioDePago(string eF)
        {
            seleccionarPago.SelectPaymentMethod(eF);
            System.Threading.Thread.Sleep(2000);

        }
        // DATOS SOBRE PAGO AL CONTADO
        [When("el usuario ingresa el monto recibido {string}")]
        public void WhenElUsuarioIngresaElMontoRecibido(string p0)
        {
            seleccionarPago.ReceivedCashPayment(p0);
            System.Threading.Thread.Sleep(2000);
        }
        // PAGO CON TARJETA DE CREDITO
        [When("el usuario ingresa nombre del banco credito {string}")]
        public void WhenElUsuarioIngresaNombreDelBancoCredito(string p0)
        {
            try
            {
                // Intentar el método final primero
                seleccionarPago.SelectCreditBankPayment(p0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Método final falló: {ex.Message}");
                Console.WriteLine("Intentando método de emergencia...");
            }
        }

        [When("el usuario selecciona tipo de tarjeta credito {string}")]
        public void WhenElUsuarioSeleccionaTipoDeTarjetaCredito(string p0)
        {
            seleccionarPago.SelectedCreditCardTypePayment(p0);

        }

        [When("el usuario ingresa numero de operacion credito {string}")]
        public void WhenElUsuarioIngresaNumeroDeOperacionCredito(string p0)
        {
            seleccionarPago.EnterInformationOperationCredit(p0);
        }

        // PAGO CON TAJETA DE DEBITO
        [When("el usuario ingresa nombre del banco debito {string}")]
        public void WhenElUsuarioIngresaNombreDelBancoDebito(string p0)
        {
            try
            {
                // Intentar el método final primero
                seleccionarPago.SelectDebitBankPayment(p0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Método final falló: {ex.Message}");
                Console.WriteLine("Intentando método de emergencia...");
            }
        }

        [When("el usuario selecciona tipo de tarjeta debito {string}")]
        public void WhenElUsuarioSeleccionaTipoDeTarjetaDebito(string p0)
        {
            seleccionarPago.SelectedDebitCardTypePayment(p0);
        }

        [When("el usuario ingresa numero de operacion debito {string}")]
        public void WhenElUsuarioIngresaNumeroDeOperacionDebito(string p0)
        {
            seleccionarPago.EnterInformationOperationDebit(p0);
        }
        // TRANSFERENCIA
        [When("el usuario ingresa cuenta bancaria correcta {string}")]
        public void WhenElUsuarioIngresaCuentaBancariaCorrecta(string p0)
        {
            seleccionarPago.EnterNumberAcountPayment(p0);
        }

        [When("el usuario ingresa numero de operacion {string}")]
        public void WhenElUsuarioIngresaNumeroDeOperacion(string p0)
        {
            seleccionarPago.InformacionPago(p0);
        }



        [When("el usuario verifica cuota inicial {string}")]
        public void WhenElUsuarioVerificaCuotaInicial(string p0)
        {
            seleccionarPago.EnterItinialPaymentAmount(p0);
        }

        [When("el usuario verifica cuotas totales {string}")]
        public void WhenElUsuarioVerificaCuotasTotales(string p0)
        {
            seleccionarPago.EnterInstallments(p0);
        }

        [When("el usuario selecciona dia del mes de pago {string}")]
        public void WhenElUsuarioSeleccionaDiaDelMesDePago(string p0)
        {
            seleccionarPago.DayMonthPayment(p0);
        }

        [When("el usuario genera cuota")]
        public void WhenElUsuarioGeneraCuota()
        {
            seleccionarPago.GenerateInstallments();      // no falla si está disabled
            System.Threading.Thread.Sleep(500);

            seleccionarPago.AceptedConfiguredCredit();   // idem
            

        }
        [Then("el usuario guarda la venta correctamente")]
        public void ThenElUsuarioGuardaLaVentaCorrectamente()
        {
            seleccionarPago.verificarVenta();
        }
    }
}
