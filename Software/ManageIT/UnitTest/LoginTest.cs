using BusinessLogicLayer.Services;
using EntitiesLayer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    ///<remarks>Darijo Bračić </remarks>
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void Test_GetWorkerByEmailAndPassword_ReturnsCorrectResult()
        {
            string validUsername = "admin";
            string validPassword = "rpp2024";
            WorkerService workerservice = new WorkerService();

            List<Worker> result = workerservice.GetWorkerByEmailAndPassword(validUsername, validPassword);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Test_Authenticate_ReturnsAuthenticatedWorker()
        {
            string validUsername = "admin";
            string validPassword = "rpp2024";
            WorkerService workerservice = new WorkerService();
            Worker authenticatedWorker = workerservice.Authenticate(validUsername, validPassword);

            Assert.IsNotNull(authenticatedWorker);
        }
        [TestMethod]
        public void Test_Authenticate_WithInvalidCredentials_ReturnsNull()
        {
            string invalidUsername = "krivoime";
            string invalidPassword = "krivasifra";
            WorkerService worekerservice = new WorkerService();

            Worker authenticatedWorker = worekerservice.Authenticate(invalidUsername, invalidPassword);

            Assert.IsNull(authenticatedWorker);
        }
    }
}
