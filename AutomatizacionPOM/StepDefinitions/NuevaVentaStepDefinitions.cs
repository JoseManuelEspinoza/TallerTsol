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
            newSale.SelectConcept(_concepto);
        }

        [When("ingresa la cantidad {string}")]
        public void WhenIngresaLaCantidad(string _cantidad)
        {
            newSale.EnterAmount(_cantidad);
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
        [When("selecciona el tipo de entrega")]
        public void WhenSeleccionaElTipoDeEntrega()
        {
            newSale.selectEntregaInmediata();
            newSale.SelectGUIA();
        }

        [When("selecciona el tipo de fecha {string}")]
        public void WhenSeleccionaElTipoDeFecha(string p0)
        {
            newSale.SelectFecha(p0);
        }

        [When("introduce el peso bruto {string}")]
        public void WhenIntroduceElPesoBruto(string p0)
        {
            newSale.EnterPesoBrutoTotal(p0);
        }

        [When("introduce el numero de bultos {string}")]
        public void WhenIntroduceElNumeroDeBultos(string p0)
        {
            newSale.EnterNumerosBultos(p0);
        }

        [When("selecciona la modalidad de transporte {string}")]
        public void WhenSeleccionaLaModalidadDeTransporte(string p0)
        {
            newSale.SelectTransportePublico(p0);
        }

        [When("introduce el numero de identifacion {string}")]
        public void WhenIntroduceElNumeroDeIdentifacion(string p0)
        {
            newSale.EnterRucTransporte(p0);
        }

        

        

        [When("introduce el detalle de origen {string}")]
        public void WhenIntroduceElDetalleDeOrigen(string p0)
        {
            newSale.EnterDetalleDireccionOrigen(p0);
        }

       

        [When("selecciona el detalle de destino {string}")]
        public void WhenSeleccionaElDetalleDeDestino(string p0)
        {
            newSale.EnterDetalleDireccionDestino(p0);
        }

        [When("guardar guia")]
        public void WhenGuardarGuia()
        {
            newSale.SaveGUIA();
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
            newSale.InformationPayment(value);
        }

        [Then("la venta se guarda correctamente")]
        public void ThenLaVentaSeGuardaCorrectamente()
        {
            newSale.SaveSale();
        }
    }
}
