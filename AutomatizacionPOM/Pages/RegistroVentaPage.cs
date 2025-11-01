using AutomatizacionPOM.Pages.Helpers;
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
        public static readonly By GuiaButton = By.XPath("//a[@id='id-registro-guia-remision']");
        public static readonly By GuiaFechaField = By.XPath("//input[@id='fechaInicioTraslado']");
        public static readonly By PesoBrutoTotalField = By.XPath("//input[@id='pesobrutototal']");
        public static readonly By NumeroBultosField = By.XPath("//div[@class='col-md-6']//input[@id='detalle']");
        public static readonly By TransportePublicoOption = By.XPath("//span[@id='select2-modalidad-container']");
        public static readonly By IdentificationTransporteField = By.XPath("//selector-actor-comercial[@id='SelectorTranportista']//input[@id='DocumentoIdentidad']");
        public static readonly By DireccionOrigenSelectionField = By.XPath("/html/body/div[4]/div/div/div/div[2]/div/registrador-guia-remision/form/div[2]/div[2]/div[1]/div/div/div/div/span[2]/span/span[2]/ul/li[965]\r\n");
        public static readonly By DetalleDireccionOrigenField = By.XPath("//input[@id='direccionOrigen']");
        public static readonly By DetalleDireccionDestinoField = By.XPath("//input[@id='direccionDestino']");
        public static readonly By SaveButtonGuia = By.XPath("//a[@title='GUARDAR GUIA DE REMISION']");
        public static readonly By DebitCardButton = By.Id("labelMedioPago-0-18");
        public static readonly By CashPaymentOption = By.Id("radio1");
        public static readonly By PaymentInformation = By.XPath("//div[@class='box box-primary box-solid']//textarea[@id='informacion']");
        public static readonly By SaveSaleButton = By.XPath("//button[normalize-space()='GUARDAR VENTA']");
        
        public void SelectConcept(string codeconcept)
        {
            utilities.SelectOption(selConceptSelection, codeconcept);
        }
        public void EnterAmount(string amount)
        {
            utilities.ClearAndEnterText(ConceptAmount, amount);
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
        public void selectEntregaInmediata()
        {
            utilities.ClickButton(EntregaInmediate);
        }
        public void SelectGUIA()
        {
            utilities.ClickButton(GuiaButton);
        }
        public void SelectFecha(string option)
        {
            utilities.ClearAndEnterText(GuiaFechaField,option);
        }
        public void EnterPesoBrutoTotal(string opcion)
        {
            utilities.EnterText(PesoBrutoTotalField, opcion);
        }
        public void EnterNumerosBultos(string opcion)
        {
            utilities.ClearAndEnterText(NumeroBultosField, opcion);
        }
        public void SelectTransportePublico(string option)
        {
            utilities.SelectOption(TransportePublicoOption,option);
        }
        public void EnterRucTransporte(string opcion)
        {
            utilities.ClearAndEnterText(IdentificationTransporteField, opcion);
            utilities.Enter(IdentificationTransporteField);

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
            utilities.ClickButton(SaveButtonGuia);
        }
        public void PaymentMethod(string option)
        {
            utilities.ClickButton(DebitCardButton);
        }
        public void InformationPayment(string information)
        {
            utilities.EnterText(PaymentInformation, information);
        }

        public void SaveSale()
        {
            utilities.ClickButton(SaveSaleButton);
        }
    }
}
