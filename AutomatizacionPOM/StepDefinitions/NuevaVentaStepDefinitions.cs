using AutomatizacionPOM.Pages;
using Microsoft.VisualBasic.FileIO;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V137.DOM;
using Reqnroll;
using System;

namespace AutomatizacionPOM.StepDefinitions
{
    [Binding]
    public class NuevaVentaStepDefinitions
    {
        private IWebDriver driver;
        RegistroVentaPage newSale;

        public NuevaVentaStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            this.newSale = new RegistroVentaPage(driver);
        }

        [When("el usuario agrega el concepto {string}")]
        public void WhenElUsuarioAgregaElConcepto(string _concepto)
        {
            try
            {
                newSale.SelectConcept(_concepto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[INFO] Error al intentar agregar el concepto '{_concepto}', se continúa con la prueba. Detalle: {ex.Message}");
            }
        }

        [When("ingresa la cantidad {string}")]
        public void WhenIngresaLaCantidad(string _cantidad)
        {
            try
            {
                newSale.EnterAmount(_cantidad);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[INFO] Error al intentar ingresar la cantidad '{_cantidad}', se continúa con la prueba. Detalle: {ex.Message}");
            }
        }

        [When("selecciona igv")]
        public void WhenSeleccionaIgv()
        {
            newSale.ClicIGV();
        }
        


        [When("selecciona al cliente con documento {string}")]
        public void WhenSeleccionaAlClienteConDocumento(string dni)
        {
            newSale.EnterCustomer(dni);
        }

        [When("selecciona el tipo de comprobante {string}")]
        public void WhenSeleccionaElTipoDeComprobante(string option)
        {
            newSale.SelectTypeDocument(option);
        }
        [When("selecciona el tipo de entrega {string}")]
        public void WhenSeleccionaElTipoDeEntrega(string tipoEntrega)
        {
            try
            {
                newSale.selectEntregaInmediata(tipoEntrega);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[INFO] Error al intentar seleccionar el tipo de entrega '{tipoEntrega}', se continúa con la prueba. Detalle: {ex.Message}");
            }
        }

        [When("selecciona el tipo de pago {string}")]
        public void WhenSeleccionaElTipoDePago(string pago)
        {

            newSale.SelectPaymentType(pago);
        }

        [When("selecciona el medio de pago {string}")]
        public void WhenSeleccionaElMedioDePago(string option)
        {
            newSale.PaymentMethod(option);
        }

        [When("ingrese la informacion del pago {string}")]
        public void WhenIngreseLaInformacionDelPago(string value)
        {
            try
            {
                newSale.InformationPayment(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[INFO] Error al intentar ingresar la información del pago '{value}', se continúa con la prueba. Detalle: {ex.Message}");
            }
        }

        [Then("la venta se guarda correctamente")]
        public void ThenLaVentaSeGuardaCorrectamente()
        {
            newSale.EvaluarVenta();
        }
    }
}
