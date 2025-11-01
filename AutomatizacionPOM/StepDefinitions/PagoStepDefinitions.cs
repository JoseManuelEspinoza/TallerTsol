using System;
using AutomatizacionPOM.Pages;
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

        [When("el usuario ingresa el monto recibido {string}")]
        public void WhenElUsuarioIngresaElMontoRecibido(string p0)
        {
            seleccionarPago.ReceivedCashPayment(p0);
            System.Threading.Thread.Sleep(2000);
        }

        [When("ingresa nombre del banco {string}")]
        public void WhenIngresaNombreDelBanco(string p0)
        {
            seleccionarPago.SelectBankPayment(p0);
        }

        [When("selecciona tipo de tarjeta {string}")]
        public void WhenSeleccionaTipoDeTarjeta(string p0)
        {
            seleccionarPago.SelectedCardTypePayment(p0);
        }

        [When("ingresa número de operación {string}")]
        public void WhenIngresaNumeroDeOperacion(string p0)
        {
            seleccionarPago.EnterInformationOperation(p0);
        }

        [When("ingresa cuenta bancaria correcta {string}")]
        public void WhenIngresaCuentaBancariaCorrecta(string p0)
        {
            seleccionarPago.EnterNumberAcountPayment(p0);
        }

        [When("verifica cuota inicial {string}")]
        public void WhenVerificaCuotaInicial(string p0)
        {
            seleccionarPago.EnterItinialPaymentAmount(p0);
        }

        [When("verifica cuotas totales {string}")]
        public void WhenVerificaCuotasTotales(string p0)
        {
            seleccionarPago.EnterInstallments(p0);
        }

        [When("selecciona día del mes de pago {string}")]
        public void WhenSeleccionaDiaDelMesDePago(string p0)
        {
            seleccionarPago.DayMonthPayment(p0);
        }

        [When("genera cuota")]
        public void WhenGeneraCuota()
        {
            seleccionarPago.GenerateInstallments();
        }
    }
}
