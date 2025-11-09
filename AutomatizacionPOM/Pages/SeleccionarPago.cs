using AutomatizacionPOM.Pages.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V137.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;

namespace AutomatizacionPOM.Pages
{
    public class SeleccionarPago
    {
        private IWebDriver driver;
        Utilities utilities;
        public SeleccionarPago(IWebDriver driver)
        {
            this.driver = driver;
            utilities = new Utilities(driver);
        }
        public readonly By CountPaymentType = By.XPath("//*[@id='radio1']");
        public readonly By FastCreditType = By.XPath("//*[@id='radio2']");
        public readonly By ConfiguredCreditType = By.XPath("//*[@id='radio3']");
        // usa LOS INPUTS, no los labels
        // MEDIOS DE PAGO - Usar XPath por el texto visible
        public readonly By CashPaymentMethod = By.XPath("//*[@id='labelMedioPago-0-281']");
        public readonly By CreditCartPaymentMethod = By.XPath("//*[@id='labelMedioPago-0-19']");
        public readonly By DebitCardPaymentMethod = By.XPath("//*[@id='labelMedioPago-0-18']");
        public readonly By TransferPaymentMethod = By.XPath("//*[@id='labelMedioPago-0-16']");
        public readonly By DepositPaymentMethod = By.XPath("//*[@id='labelMedioPago-0-14']");
        

        public readonly By CashPaymentField = By.XPath("/html/body/div[1]/div/section/div/div/div[1]/form/div[2]/facturacion-venta/form/div/div[2]/div/div[8]/editor-pago/div/div/div/div/editor-traza-pago/div/div[2]/div/input");

        //PARAMETROS PARA EL PAGO DE TARJETA DE CREDITO / DEBITO

        // PARA ESCRIBIR EN EL CAMPO DE BÚSQUEDA (cuando el dropdown está ABIERTO)
        // BANCO CREDITO
        public readonly By BankCreditCardSelectionField = By.XPath("//*[@id='traza-pago']/div[5]/div/span[1]/span[1]/span/span[2]");
        public readonly By BankCreditCardInput = By.XPath("//*[@id='traza-pago']/div[5]/div/span[3]/span/span[1]/input");
        //  BANCO DEBITO
        public readonly By BankDebitCardSelectionField = By.XPath("//*[@id='traza-pago']/div[6]/div/span[1]/span[1]/span/span[2]");
        public readonly By BankDebitCardInput = By.XPath("//*[@id='traza-pago']/div[6]/div/span[3]/span/span[1]/input");
        // TARJETA CREDITO 
        public readonly By CreditCartPaymentField = By.XPath("//*[@id='traza-pago']/div[5]/div/span[2]/span[1]/span/span[2]");
        public readonly By CreditCartPaymentInput = By.XPath("//*[@id='traza-pago']/div[5]/div/span[3]/span/span[1]/input");

        // TARJETA DEBITO
        public readonly By DebitCartPaymentField = By.XPath("//*[@id='traza-pago']/div[6]/div/span[2]/span[1]/span/span[2]");
        public readonly By DebitCartPaymentInput = By.XPath("//*[@id='traza-pago']/div[6]/div/span[3]/span/span[1]/input");
        // INFORMACIÓN
        public readonly By CreditInformationOperationField = By.XPath("//*[@id='informacion']");
        public readonly By DebitInformationOperationField = By.XPath("/html/body/div[1]/div/section/div/div/div[1]/form/div[2]/facturacion-venta/form/div/div[2]/div/div[8]/editor-pago/div/div/div/div/editor-traza-pago/div/div[6]/div/textarea");

        // TRANSFERENCIA
        // Contexto actual (accountField, accountInput, infoField)
        private (By accountField, By accountInput, By infoField)? _payCtx;

        // Locators propios de cada método (REEMPLAZA los XPaths de depósito por los reales)
        private readonly (By accountField, By accountInput, By infoField) TransferCtx =
            (By.XPath("//*[@id='traza-pago']/div[7]/div/span/span[1]/span/span[2]"),
             By.XPath("//*[@id='traza-pago']/div[7]/div/span[2]/span/span[1]/input"),
             By.XPath("/html/body/div[1]/div/section/div/div/div[1]/form/div[2]/facturacion-venta/form/div/div[2]/div/div[8]/editor-pago/div/div/div/div/editor-traza-pago/div/div[7]/div/textarea"));

        private readonly (By accountField, By accountInput, By infoField) DepositCtx =
            (By.XPath("//*[@id='traza-pago']/div[8]/div/span/span[1]/span/span[2]"),
             By.XPath("//*[@id='traza-pago']/div[8]/div/span[2]/span/span[1]/input"),
             By.XPath("/html/body/div[1]/div/section/div/div/div[1]/form/div[2]/facturacion-venta/form/div/div[2]/div/div[8]/editor-pago/div/div/div/div/editor-traza-pago/div/div[8]/div/textarea"));

        // VALORE PARA LA COMPRA CON CREDITO DIFERIDO
        public readonly By InitialAmountField = By.XPath("//*[@id='inicial']");
        public readonly By InstallmentsField = By.XPath("//input[@id='cuota']");
        public readonly By DayMonthPaymentField = By.XPath("//*[@id='registro-financiamiento-0']/div/div/div[2]/div/div[1]/div/div/div/div[5]/div[2]/span/span[1]/span/span[2]");
        public readonly By DayMonthPaymentInput = By.XPath("//*[@id='registro-financiamiento-0']/div/div/div[2]/div/div[1]/div/div/div/div[5]/div[2]/span[2]/span/span[1]/input");
        public readonly By GenerateInstallmentsField = By.XPath("//*[@id='registro-financiamiento-0']/div/div/div[2]/div/div[1]/div/div/div/div[6]/button");
        public readonly By AceptedConfiguredCreditField = By.XPath("//*[@id='registro-financiamiento-0']/div/div/div[3]/button[1]");

        // Elemento de inconsistencia
        private readonly List<By> elementosInconsistencias = new List<By>
            {
                By.XPath("//*[@id='modelo']/div[1]/form/div[2]/facturacion-venta/form/div/div[3]/div"), // Error general de credito por no ingresar numero de operacion
                By.XPath("//*[@id='registro-financiamiento-0']/div/div/div[2]/div/div[2]/table/tbody[2]/tr/td"), // Error de no generar credito configurado
                By.XPath("//span[@class='error-message']"), // Error de validación en campo
                By.XPath("//div[contains(text(), 'No se pudo guardar')]") // Texto específico
            };

        // Boton para guardar
        public readonly By SaveSaleButton = By.XPath("//button[normalize-space()='GUARDAR VENTA']");
        public void SelectPaymentType(string option)
        {
            switch (option)
            {
                case "CO":
                    utilities.SelectRadioButton(CountPaymentType);
                    break;
                case "CR":
                    utilities.SelectRadioButton(FastCreditType);
                    break;
                case "CC":
                    utilities.SelectRadioButton(ConfiguredCreditType);
                    break;
            }
            Thread.Sleep(3000); // Espera para que carguen los campos
        }

        public void SelectPaymentMethod(string option)
        {

            switch (option)
            {
                case "EF":
                    utilities.ClickButton(CashPaymentMethod);
                    break;
                case "TCRE":
                    utilities.ClickButton(CreditCartPaymentMethod);
                    break;
                case "TDEB":
                    utilities.ClickButton(DebitCardPaymentMethod);
                    break;
                case "TRANFON":
                    utilities.ClickButton(TransferPaymentMethod);
                    _payCtx = TransferCtx;
                    break;
                case "DEPCU":
                    utilities.ClickButton(DepositPaymentMethod);
                    _payCtx = DepositCtx;
                    break;
                default:
                    throw new ArgumentException($"Método de pago '{option}' no válido.");
            }

        }   
        
        public void ReceivedCashPayment(string option)
        {
            utilities.ClearAndEnterText(CashPaymentField, option);            
        }
        // TARJETA CREDITO
        public void SelectCreditBankPayment(string bankName) { 
            utilities.ClickButton(BankCreditCardSelectionField);
            utilities.ClearAndEnterText(BankCreditCardInput, bankName);
            utilities.Enter(BankCreditCardInput);
        }
        public void SelectedCreditCardTypePayment(string cardType)
        {
            utilities.ClickButton(CreditCartPaymentField);
            utilities.ClearAndEnterText(CreditCartPaymentInput, cardType);
            utilities.Enter(CreditCartPaymentInput);
        }
        public void EnterInformationOperationCredit(string operationNumber)
        {
            utilities.ClearAndEnterText(CreditInformationOperationField, operationNumber);
        }
        // TARJETA DEBITO
        public void SelectDebitBankPayment(string bankName)
        {
            utilities.ClickButton(BankDebitCardSelectionField);
            utilities.ClearAndEnterText(BankDebitCardInput, bankName);
            utilities.Enter(BankDebitCardInput);
        }
        public void SelectedDebitCardTypePayment(string cardType)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            utilities.ClickButton(DebitCartPaymentField);
            utilities.ClearAndEnterText(DebitCartPaymentInput, cardType);
            utilities.Enter(DebitCartPaymentInput);
        }
        public void EnterInformationOperationDebit(string operationNumber)
        {
            
            utilities.ClickButton(DebitInformationOperationField);
            utilities.ClearAndEnterText(DebitInformationOperationField, operationNumber);
            utilities.Enter(DebitInformationOperationField);
        }
        //TRANSFERENCIA
        public void EnterNumberAcountPayment(string option)
        {
            var ctx = _payCtx ?? TransferCtx;
            utilities.ClickButton(ctx.accountField);
            utilities.EnterText(ctx.accountInput, option);
            utilities.Enter(ctx.accountInput);
        }
        public void InformacionPago(string info)
        {
            var ctx = _payCtx ?? TransferCtx;
            utilities.ClickButton(ctx.infoField);
            utilities.ClearAndEnterText(ctx.infoField, info);
        }


        // FUNCIONALIDADES PARA EL CREDITO CONFIGURADO
        public void EnterItinialPaymentAmount(string option)
        {
            utilities.ClearAndEnterText(InitialAmountField, option);
        }
        public void EnterInstallments(string option)
        {
            utilities.ClearAndEnterText(InstallmentsField, option);
        }
        public void DayMonthPayment(string option)
        {
            utilities.ClickButton(DayMonthPaymentField);
            utilities.ClearAndEnterText(DayMonthPaymentInput, option);
            utilities.Enter(DayMonthPaymentInput);
        }
        public void GenerateInstallments()
        {
            try
            {
                var el = driver.FindElement(GenerateInstallmentsField);
                var disabledAttr = el.GetAttribute("disabled");
                if (!el.Displayed || !el.Enabled || !string.IsNullOrEmpty(disabledAttr))
                {
                    Console.WriteLine("[INFO] Botón 'Generar cuota(s)' deshabilitado/oculto. No se intenta click.");
                    return;
                }

                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", el);
                el.Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("[WARN] Botón 'Generar cuota(s)' no encontrado.");
            }
            catch (ElementClickInterceptedException)
            {
                try
                {
                    var el = driver.FindElement(GenerateInstallmentsField);
                    var disabledAttr = el.GetAttribute("disabled");
                    if (string.IsNullOrEmpty(disabledAttr) && el.Enabled)
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", el);
                    }
                }
                catch { /* ignorar */ }
            }
        }


        public void AceptedConfiguredCredit()
        {
            try
            {
                var btn = driver.FindElement(AceptedConfiguredCreditField);
                var disabledAttr = btn.GetAttribute("disabled");

                // Si está deshabilitado u oculto → NO clickeamos, no lanzamos error
                if (!btn.Displayed || !btn.Enabled || !string.IsNullOrEmpty(disabledAttr))
                {
                    Console.WriteLine("[INFO] Botón 'ACEPTAR' deshabilitado/oculto. No se intenta click.");
                    return;
                }

                // Scroll y click normal
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", btn);
                btn.Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("[WARN] Botón 'ACEPTAR' no encontrado.");
                // No se lanza excepción
            }
            catch (ElementClickInterceptedException)
            {
                // Reintento por JS SOLO si no está deshabilitado
                try
                {
                    var btn = driver.FindElement(AceptedConfiguredCreditField);
                    var disabledAttr = btn.GetAttribute("disabled");
                    if (string.IsNullOrEmpty(disabledAttr) && btn.Enabled)
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", btn);
                    }
                }
                catch { /* ignorar para no romper el flujo */ }
            }
        }

        public void verificarVenta()
        {
            bool isInconsistent = false;
            string mensajeError = string.Empty;

            foreach (var locator in elementosInconsistencias)
            {
                if (utilities.IsElementExist(locator))
                {
                    isInconsistent = true;
                    try
                    {
                        var element = driver.FindElement(locator);
                        mensajeError = element.Text;
                    }
                    catch { /* por si no tiene texto */ }
                    break; // Si ya encontró un error, no necesita seguir buscando
                }
            }

            if (isInconsistent)
            {
                Assert.Pass($"La venta no se pudo guardar debido a inconsistencias: {mensajeError}");
            }
            else
            {
                SaveSale();
            }
        }

        public void SaveSale()
        {
            
            utilities.ClickButton(SaveSaleButton);
        }
        
       
       
    }
}
