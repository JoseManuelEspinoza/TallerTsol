using System;
using AutomatizacionPOM.Pages;
using OpenQA.Selenium;
using Reqnroll;

namespace AutomatizacionPOM.StepDefinitions
{
    [Binding]
    public class GuiaStepDefinitions
    {
        private IWebDriver driver;
        Guia guia;

        public GuiaStepDefinitions(IWebDriver _driver)
        {
            driver = _driver;
            guia = new (driver);
        }

        [When("selecciona destinatario {string}")]
        public void WhenSeleccionaDestinatario(string dni)
        {
            guia.SelectGUIA();
            Thread.Sleep(3000);
            guia.EnterDestinatary(dni);
        }

        [When("fecha inicio translado {string}")]
        public void WhenFechaInicioTranslado(string p0)
        {
            guia.SelectFecha(p0);
        }

        [When("introduce el peso bruto {string}")]
        public void WhenIntroduceElPesoBruto(string p0)
        {
           guia.EnterPesoBrutoTotal(p0);
        }

        [When("introduce el numero de bultos {string}")]
        public void WhenIntroduceElNumeroDeBultos(string p0)
        {
            guia.EnterNumerosBultos(p0);
        }

        [When("selecciona la modalidad de transporte {string}")]
        public void WhenSeleccionaLaModalidadDeTransporte(string p0)
        {
            guia.SelectTipoTransporte(p0);
        }
        [When("introduce el numero de licencia{string}")]
        public void WhenIntroduceElNumeroDeLicencia(string p0)
        {
            guia.EnterLicencia(p0);
        }

        [When("introduce la placa {string}")]
        public void WhenIntroduceLaPlaca(string placa)
        {
            guia.EnterPlaca(placa);
        }


        [When("introduce el numero de identifacion {string}")]
        public void WhenIntroduceElNumeroDeIdentifacion(string p0)
        {
            guia.IdentificacionDatosTransporte(p0);
        }

        [When("introduce el detalle de origen {string}")]
        public void WhenIntroduceElDetalleDeOrigen(string p0)
        {
            guia.EnterDetalleDireccionOrigen(p0);
        }

        [When("selecciona el detalle de destino {string}")]
        public void WhenSeleccionaElDetalleDeDestino(string p0)
        {
            guia.EnterDetalleDireccionDestino(p0);
        }

        [Then("guardar guia")]
        public void ThenGuardarGuia()
        {
            guia.verificarGuardarGuia();
        }
    }
}
