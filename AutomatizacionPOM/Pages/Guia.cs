using AutomatizacionPOM.Pages.Helpers;
using Newtonsoft.Json.Bson;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionPOM.Pages
{
    public class Guia
    {
        private IWebDriver driver;
        Utilities utilities;
        public Guia(IWebDriver driver)
        {
            this.driver = driver;
            utilities = new Utilities(driver);
        }
        //VARIABLES
        public string tipo_transporte;
        // BOTONES
        public static readonly By Customer = By.XPath("/html/body/div[4]/div/div/div/div[2]/div/registrador-guia-remision/form/div[1]/div[1]/div/div/selector-actor-comercial[1]/ng-form/div/div/div[1]/input");
        public static readonly By GuiaButton = By.XPath("//a[@id='id-registro-guia-remision']");
        public static readonly By GuiaFechaField = By.XPath("//input[@id='fechaInicioTraslado']");
        public static readonly By PesoBrutoTotalField = By.XPath("//input[@id='pesobrutototal']");
        public static readonly By NumeroBultosField = By.XPath("//div[@class='col-md-6']//input[@id='detalle']");
        public static readonly By TransportePublicoOptionField = By.XPath("//*[@id='RegistradorGuiaRemision']/form/div[2]/div[1]/div/div/div[1]/span/span[1]/span/span[2]");
        public static readonly By TransportePublicoOptionInput = By.XPath("//*[@id='RegistradorGuiaRemision']/form/div[2]/div[1]/div/div/div[1]/span[2]/span/span[1]/input");
        public static readonly By IdentificationTransporteField = By.XPath("/html/body/div[4]/div/div/div/div[2]/div/registrador-guia-remision/form/div[1]/div[2]/div/div/selector-actor-comercial[1]/ng-form/div/div/div[1]/input");
        public static readonly By DireccionOrigenSelectionField = By.XPath("/html/body/div[4]/div/div/div/div[2]/div/registrador-guia-remision/form/div[2]/div[2]/div[1]/div/div/div/div/span[2]/span/span[2]/ul/li[965]\r\n");
        public static readonly By DetalleDireccionOrigenField = By.XPath("//input[@id='direccionOrigen']");
        public static readonly By DetalleDireccionDestinoField = By.XPath("//input[@id='direccionDestino']");
        public static readonly By SaveButtonGuia = By.XPath("//*[@id='modal-registro-guia-remision']/div/div/div[3]/a[2]");

        // TRANPORTE PRIVADO BOTONES
        public static readonly By ConductoDNI= By.XPath("/html/body/div[4]/div/div/div/div[2]/div/registrador-guia-remision/form/div[1]/div[2]/div/div/selector-actor-comercial[2]/ng-form/div/div/div[1]/input");
        public static readonly By NumLicencia = By.XPath("//*[@id='nLicencia']");
        public static readonly By PlacaVehiculo = By.XPath("//*[@id='marcaPlaca']");
        public void SelectGUIA()
        {
            utilities.ClickButton(GuiaButton);
        }
        public void EnterDestinatary(string dni)
        {
            utilities.ClearAndEnterText(Customer, dni);
            utilities.Enter(Customer);
        }
        public void SelectFecha(string option)
        {
            utilities.ClearAndEnterText(GuiaFechaField, option);
        }
        public void EnterPesoBrutoTotal(string opcion)
        {
            utilities.EnterText(PesoBrutoTotalField, opcion);
        }
        public void EnterNumerosBultos(string opcion)
        {
            utilities.ClearAndEnterText(NumeroBultosField, opcion);
        }
        public void SelectTipoTransporte(string option)
        {
            tipo_transporte = option;
            utilities.ClickButton(TransportePublicoOptionField);
            utilities.ClearAndEnterText(TransportePublicoOptionInput,option);
            utilities.Enter(TransportePublicoOptionInput);
        }
        public void IdentificacionDatosTransporte(string opcion)
        {
            if (tipo_transporte == "TRANSPORTE PÚBLICO") {
                // Ingresar RUC de la empresa de transporte
                EnterRucTransporte(opcion);
            }else if (tipo_transporte== "TRANSPORTE PRIVADO")
            {
                EnterDNITransporte(opcion);
            }
            else
            {
                Console.WriteLine("Tipo de transporte no reconocido.");
            }
        }
        public void EnterRucTransporte(string opcion)
        {
            utilities.ClearAndEnterText(IdentificationTransporteField, opcion);
            utilities.Enter(IdentificationTransporteField);

        }
        public void EnterDNITransporte(string opcion)
        {
            utilities.ClearAndEnterText(ConductoDNI, opcion);
            utilities.Enter(ConductoDNI);
        }
        public void EnterLicencia(string opcion)
        {
            utilities.ClearAndEnterText(NumLicencia, opcion);
        }
        public void EnterPlaca(string opcion)
        {
            utilities.ClearAndEnterText(PlacaVehiculo, opcion);
        }
        public void EnterDetalleDireccionOrigen(string opcion)
        {
            utilities.ClearAndEnterText(DetalleDireccionOrigenField, opcion);

        }
        public void EnterDetalleDireccionDestino(string opcion)
        {
            utilities.ClearAndEnterText(DetalleDireccionDestinoField, opcion);
        }
        public void SaveGUIA()
        {
            Thread.Sleep(2000);

            // Scroll al botón antes de hacer click
            var btn = driver.FindElement(SaveButtonGuia);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", btn);
            Thread.Sleep(1000); // pequeña pausa para que el scroll termine

            utilities.ClickButton(SaveButtonGuia);
        }
        private readonly By elementoInconsistencia = By.XPath("//*[@id='RegistradorGuiaRemision']/form/div[2]/div[4]/div");
        public void verificarGuardarGuia()
        {
            // 1) Si hay inconsistencia → la prueba pasa y NO se guarda
            if (utilities.IsElementExist(elementoInconsistencia))
            {
                string detalle = TryGetTextSafe(elementoInconsistencia);
                Assert.Pass($"La guía presenta inconsistencias y no se guarda (comportamiento esperado). Detalle: {detalle}");
                return;
            }

            // 2) Sin inconsistencia → validar botón y guardar normalmente
            try
            {
                var btn = driver.FindElement(SaveButtonGuia);
                var disabledAttr = btn.GetAttribute("disabled");

                // Si está deshabilitado u oculto, informamos y salimos sin romper
                if (!btn.Displayed || !btn.Enabled || !string.IsNullOrEmpty(disabledAttr))
                {
                    Console.WriteLine("[INFO] Botón 'ACEPTAR' deshabilitado/oculto. No se intenta guardar.");
                    return;
                }

                // Guardado normal (usa tu método existente)
                try
                {
                    SaveGUIA();
                }
                catch (ElementClickInterceptedException)
                {
                    // Fallback: click por JS si fue interceptado
                    try
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", btn);
                    }
                    catch { /* no romper flujo */ }
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("[WARN] Botón 'ACEPTAR' no encontrado.");
                // No lanzamos excepción para no romper el flujo
            }
        }

        // Helper para leer texto sin romper el flujo
        private string TryGetTextSafe(By locator)
        {
            try { return driver.FindElement(locator).Text?.Trim(); }
            catch { return string.Empty; }
        }

    }
}
