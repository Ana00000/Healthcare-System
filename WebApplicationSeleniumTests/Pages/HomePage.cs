﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplicationSeleniumTests.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:49900/#/patient";
        private IWebElement AppointmentButton => driver.FindElement(By.Id("AppointmentsShow"));
        private IWebElement FeedbackButton => driver.FindElement(By.Id("UserExperiences"));

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickAppointmentButton()
        {
            AppointmentButton.Click();
        }
        public void ClickFeedbackButton()
        {
            FeedbackButton.Click();
        }
        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
