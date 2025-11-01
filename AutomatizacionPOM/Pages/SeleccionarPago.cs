using AutomatizacionPOM.Pages.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V137.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public readonly By CountPaymentType = By.XPath("//div[@class='radio radio-primary radio-inline pt-2']//input[@id='radio1']");
        public readonly By FastCreditType = By.XPath("//div[@class='radio radio-primary radio-inline pt-2']//input[@id='radio2']");
        public readonly By ConfiguredCreditType = By.XPath("/html/body/div[1]/div/section/div/div/div[1]/form/div[2]/facturacion-venta/form/div/div[2]/div/div[8]/editor-pago/div/div/div/div/div[1]/div[3]/input");
        public readonly By CashPaymentMethod = By.XPath("//label[@id='labelMedioPago-0-281']");
        public readonly By CreditCartPaymentMethod = By.XPath("//label[@id='labelMedioPago-0-19']");
        public readonly By DebitCardPaymentMethod = By.XPath("//label[@id='labelMedioPago-0-18']");
        public readonly By TransferPaymentMethod = By.XPath("//label[@id='labelMedioPago-0-16']");
        public readonly By DepositPaymentMethod = By.XPath("//label[@id='labelMedioPago-0-14']");
        // PARAMETROS DE INPUTS PARA LOS METODOS DE PAGOS
        public readonly By CashPaymentField = By.XPath("/html/body/div[1]/div/section/div/div/div[1]/form/div[2]/facturacion-venta/form/div/div[2]/div/div[8]/editor-pago/div/div/div/div/editor-traza-pago/div/div[2]/div/input");
        //PARAMETROS PARA EL PAGO DE TARJETA DE CREDITO / DEBITO
        public readonly By BankCreditCardSelectionField = By.XPath("//span[normalize-space()='SCOTIABANK']//span[@id='select2-idEntidadFinancera-container']");
        public readonly By BankCreditCardInput= By.XPath("/html/body/div[1]/div/section/div/div/div[1]/form/div[2]/facturacion-venta/form/div/div[2]/div/div[8]/editor-pago/div/div/div/div/editor-traza-pago/div/div[5]/div/span[3]/span/span[1]/input");
        public readonly By CartTypePaymentField = By.XPath("//span[@aria-expanded='true']//span[@id='select2-idTipoTarjeta-container']");
        public readonly By InformationOperationField = By.XPath("//div[@class='box box-primary box-solid']//textarea[@id='informacion']");
        public readonly By AcountBankField = By.XPath("//span[@id='select2-transferencias-container']");

        // VALORE PARA LA COMPRA CON CREDITO DIFERIDO
        public readonly By InitialAmountField = By.XPath("//input[@id='inicial']");
        public readonly By InstallmentsField = By.XPath("//input[@id='cuota']");
        public readonly By DayMonthPaymentField = By.XPath("//input[@class='td-datepicker form-control ng-pristine ng-untouched ng-valid ng-empty']");
        public readonly By GenerateInstallmentsField = By.XPath("//span[@class='glyphicon glyphicon-refresh']");
        public readonly By AceptedConfiguredCreditField = By.XPath("//button[normalize-space()='ACEPTAR']");



        // Boton para guardar
        public readonly By SaveSaleButton = By.XPath("//button[normalize-space()='GUARDAR VENTA']");
        public void SelectPaymentType(string option)
        {
            switch (option)
            {
                case "CO":
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", driver.FindElement(CountPaymentType));
                    break;
                case "CR":
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", driver.FindElement(FastCreditType));
                    break;
                case "CC":
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", driver.FindElement(ConfiguredCreditType));
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
                    break;
                case "DEPCU":
                    utilities.ClickButton(DepositPaymentMethod);
                    break;
                default:
                    throw new ArgumentException($"Método de pago no es válido. Usa 'EF', 'TCRE', 'TDEB', 'TRANFON' o 'DEPCU'.");
            }
        }
        public void ReceivedCashPayment(string option)
        {
            utilities.ClearAndEnterText(CashPaymentField, option);            
        }
        public void SelectBankPayment(string option)
        {
            utilities.ClickButton(BankCreditCardSelectionField);
            utilities.EnterText(BankCreditCardInput, option);
        }

        public void SelectedCardTypePayment(string option)
        {
            utilities.ClickButton(CartTypePaymentField);
            utilities.EnterText(CartTypePaymentField, option);
        }
        public void EnterInformationOperation(string option)
        {
            utilities.ClearAndEnterText(InformationOperationField, option);
        }

        public void EnterNumberAcountPayment(string option)
        {
            utilities.ClickButton(AcountBankField);
            utilities.EnterText(AcountBankField, option);
        }

        // FUNCIONALIDADES PARA EL CREDITO 
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
            utilities.ClearAndEnterText(DayMonthPaymentField, option);
        }
        public void GenerateInstallments()
        {
            utilities.ClickButton(GenerateInstallmentsField);
        }
        public void AceptedConfiguredCredit()
        {
            utilities.ClickButton(AceptedConfiguredCreditField);
        }



        public void SaveSale()
        {
            utilities.ClickButton(SaveSaleButton);
        }



    }
}
