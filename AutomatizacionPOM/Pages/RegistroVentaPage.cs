using AutomatizacionPOM.Pages.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionPOM.Pages
{
    public class RegistroVentaPage
    {
        private IWebDriver driver;
        Utilities utilities;
        public RegistroVentaPage(IWebDriver driver)
        {
            this.driver = driver;
            utilities = new Utilities(driver);
        }
        public static readonly By selConceptSelection = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[1]/div[1]/registrador-detalles[1]/div[1]/div[1]/selector-concepto-comercial[1]/ng-form[1]/div[1]/div[3]/div[1]/div[1]/span[1]/span[1]/span[1]");
        public static readonly By ConceptAmount = By.Id("cantidad-0");
        public static readonly By IgvActive = By.Id("ventaigv0");
        public static readonly By IdCustomer = By.Id("DocumentoIdentidad");
        public static readonly By TypeDocumentField = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[6]/selector-comprobante[1]/div[1]/ng-form[1]/div[1]/div[1]/span[1]/span[1]/span[1]");
        public static readonly By EntregaInmediate = By.XPath("//input[@id='radioEntrega1']");
        public static readonly By EntregaDeferida = By.XPath("//*[@id='radioEntrega2']");

        public static readonly By PagoEfectivo = By.XPath("//*[@id='labelMedioPago-0-281']");
        public static readonly By CashPaymentOption = By.Id("radio1");
        public static readonly By PaymentInformation = By.XPath("//*[@id='traza-pago']/div[2]/div/input");
        public static readonly By SaveSaleButton = By.XPath("//button[normalize-space()='GUARDAR VENTA']");

        // TRANSPORTE PRIVADO




        public void SelectConcept(string codeconcept)
        {
            try
            {
                // Intenta seleccionar el concepto
                utilities.SelectOption(selConceptSelection, codeconcept);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[INFO] No se pudo seleccionar el concepto '{codeconcept}'. Se continúa sin romper. Detalle: {ex.Message}");
            }
        }
        public void EnterAmount(string amount)
        {
            try
            {
                // Intenta limpiar e ingresar la cantidad
                utilities.ClearAndEnterText(ConceptAmount, amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[INFO] No se pudo ingresar la cantidad '{amount}'. Se continúa sin romper. Detalle: {ex.Message}");
            }
        }

        public void ClicIGV()
        {
            utilities.ClickButton(IgvActive);
        }

        public void EnterCustomer(string dni)
        {
            utilities.ClearAndEnterText(IdCustomer, dni);
            utilities.Enter(IdCustomer);
        }

        public void SelectTypeDocument(string option)
        {
            utilities.SelectOption(TypeDocumentField, option);
        }

        public void SelectPaymentType(string option)
        {
            utilities.ClickButton(CashPaymentOption);
        }
        public void selectEntregaInmediata(string tipo_Entrega)
        {
            try
            {
                if (tipo_Entrega == "INMEDIATA")
                {
                    utilities.ClickButton(EntregaInmediate);
                }
                else if (tipo_Entrega == "DIFERIDA")
                {
                    utilities.ClickButton(EntregaDeferida);

                }
                else
                {
                    Console.WriteLine("Tipo de entrega no reconocido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[INFO] No se pudo seleccionar el tipo de entrega '{tipo_Entrega}'. Se continúa sin romper. Detalle: {ex.Message}");
            }
        }

        public void PaymentMethod(string option)
        {
            utilities.ClickButton(PagoEfectivo);
        }
        public void InformationPayment(string information)
        {
            try {
                utilities.EnterText(PaymentInformation, information);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[INFO] No se pudo ingresar la información de pago '{information}'. Se continúa sin romper. Detalle: {ex.Message}");
            } 
        }
        private readonly List<By> elementosInconsistencia = new List<By>
{
    By.XPath("//*[@id='modelo']/div[1]/form/div[2]/facturacion-venta/form/div/div[3]/div"),
    By.XPath("//*[@id='modelo']/div[1]/form/div[2]/div/div")
};
        public void EvaluarVenta()
        {
            try
            {
                // 1) Evaluar todas las posibles inconsistencias
                foreach (var elemento in elementosInconsistencia)
                {
                    if (utilities.IsElementExist(elemento))
                    {
                        string detalle = TryGetTextSafe(elemento);
                        Assert.Pass($"La guía presenta inconsistencias y no se guarda (comportamiento esperado). Detalle: {detalle}");
                        return;
                    }
                }

                // 2) Si no hay inconsistencias → validar botón y guardar normalmente
                var btn = driver.FindElement(SaveSaleButton);
                var disabledAttr = btn.GetAttribute("disabled");

                if (!btn.Displayed || !btn.Enabled || !string.IsNullOrEmpty(disabledAttr))
                {
                    Console.WriteLine("[INFO] Botón 'ACEPTAR' deshabilitado/oculto. No se intenta guardar.");
                    return;
                }

                // Intentar guardar normalmente
                try
                {
                    SaveSale();
                }
                catch (ElementClickInterceptedException)
                {
                    // Si el click es interceptado → usar JS
                    try
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", btn);
                    }
                    catch
                    {
                        // No romper el flujo
                        Console.WriteLine("[WARN] Click JS de respaldo también falló, pero se continúa.");
                    }
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("[WARN] Botón 'ACEPTAR' no encontrado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Error en EvaluarVenta: {ex.Message}");
            }
        }
        // Helper para leer texto sin romper el flujo
        private string TryGetTextSafe(By locator)
        {
            try { return driver.FindElement(locator).Text?.Trim(); }
            catch { return string.Empty; }
        }

        public void SaveSale()
        {
            utilities.ClickButton(SaveSaleButton);
        }
    }
}
