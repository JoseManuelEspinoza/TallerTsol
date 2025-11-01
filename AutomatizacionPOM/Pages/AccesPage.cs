using AutomatizacionPOM.Pages.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AutomatizacionPOM.Pages
{
    public class AccessPage
    {
        private IWebDriver driver;
        Utilities utilities;

        public AccessPage(IWebDriver driver)
        {
            this.driver = driver;
            utilities = new Utilities(driver);
        }

        // LOGIN
        private By usernameField = By.XPath("//input[@id='Email']");
        private By passwordField = By.XPath("//input[@id='Password']"); 
        private By loginButton = By.XPath("//button[normalize-space()='Iniciar']");
        private By acceptButton = By.XPath("//button[contains(text(),'Aceptar')]");
        private By logo = By.XPath("//img[@id='ImagenLogo']");

        // VENTAS
        private By VentaField = By.XPath("//a[@class='menu-lista-cabecera']/span[text()='Venta']");
        private By NuevaVentaField = By.XPath("//a[normalize-space()='Venta Modo Caja']");

        //RESTAURANTE
        private By RestauranteField = By.XPath("//a[@class='menu-lista-cabecera']/span[text()='Restaurante']");
        private By AtencionField = By.XPath("//a[normalize-space()='Atención']");

        public void OpenToAplicattion(string url)
        {
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(4000);
        }

        public void LoginToApplication(string _username, string _password)
        {
            utilities.EnterText(usernameField, _username);
            Thread.Sleep(2000);

            utilities.EnterText(passwordField, _password);
            Thread.Sleep(2000);

            utilities.ClickButton(loginButton);
            Thread.Sleep(4000);
            utilities.ClickButton(acceptButton);
            Thread.Sleep(4000);

            // Comprobar que el login fue exitoso
            var succesElement = driver.FindElement(logo);            
            Assert.IsNotNull(succesElement, "No se encontró el elemento de éxito después del login.");
        }

        public void enterModulo(string _modulo)
        {
            switch (_modulo)
            {
                case "Venta":
                    utilities.ClickButton(VentaField);
                    break;

                case "Restaurante":
                    utilities.ClickButton(RestauranteField);
                    break;

                default:
                    throw new ArgumentException($"El {_modulo} no es válido.");
            }
            Thread.Sleep(4000);
        }

        public void enterSubModulo(string _submodulo)
        {
            switch (_submodulo)
            {
                case "Nueva Venta":
                    driver.FindElement(NuevaVentaField).Click();
                    
                    break;

                case "Atención":
                    driver.FindElement(AtencionField).Click();

                    break;

                default:
                    throw new ArgumentException($"El {_submodulo} no es válido.");
            }
            Thread.Sleep(10000);
        }
    }
}
