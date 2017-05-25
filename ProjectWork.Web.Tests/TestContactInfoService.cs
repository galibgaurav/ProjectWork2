using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Moq;
using NUnit.Framework;
using ProjectWork.Data;
using ProjectWork.Entities;
using ProjectWork.Services;
using ProjectWork.Web.Infrastructure.Core;

namespace ProjectWork.Web.Tests
{
    [TestFixture]
    public class TestContactInfoService
    {
        public TestContactInfoService(IContactInfoService contactInfoService)
           
        {
            contactInfoServiceObj = contactInfoService;
        }
        public IContactInfoService contactInfoServiceObj;
        
        [TestFixtureSetUp]
        public void TestPrerunMethod()
        {
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
        }

        [Test]//test1 
        public async Task TestGetContactInfo()
        {
            //mock config-- moq is used for mocking next layer, here we are moking add method of EntityBaseRepository
            var _contactInfoRepository = new Mock<IEntityBaseRepository<ContactInfo>>();
           
            _contactInfoRepository.Setup(x => x.Add(It.IsAny<ContactInfo>())); //here add method returns void so we are not putting any return value, with mock setup;

            //crating sample input data
            ICollection<ContactInfo> contactLst = new List<ContactInfo>();
            ContactInfo contact = new ContactInfo();
            contact.ID = 1;
            contact.AddressCorrespondance = "aneoei";
            contact.AddressPermanent = "qwdfd";
            contact.ContactedCreated = DateTime.Now;
            contact.ContactedUpdated = DateTime.Now;
            ICollection<ContactHistory> ContactHistoryLst = new List<ContactHistory>();
            ContactHistory contactHistoryObj = new ContactHistory();
            contactHistoryObj.communicationDetails = new CommunicationDetails();
            contactHistoryObj.communicationDetails.callDetails = new CallDetails();
            contactHistoryObj.communicationDetails.callDetails.CallDuration = TimeSpan.MinValue;
            contactHistoryObj.communicationDetails.callDetails.CallStatus = 1;
            contactHistoryObj.communicationDetails.callDetails.ID = 2;
            contactHistoryObj.communicationDetails.communicationTypes = 1;
            contactHistoryObj.communicationDetails.ID = 3;
            contactHistoryObj.communicationTime = DateTime.Now;
            contactHistoryObj.ID = 3;
            contactHistoryObj.userID = "user1";
            ContactHistoryLst.Add(contactHistoryObj);
            contact.ContactHistory = ContactHistoryLst;
            contact.Name = "gaurav";
            contact.PrimaryContactNumber = "9902738900";
            contact.PrimaryEmail = "dwwd@iude.com";
            contact.SecondaryContactNumber = "9902738900";
            contact.SecondaryEmail = "d23d@efd2.com";
            contactLst.Add(contact);

            //calling AddContactInfo method from services
            var result=await contactInfoServiceObj.AddContactInfo(contactLst);
            //comapare the result of the test.
            //if any change is made on the AddContactInfo method than it can break the
            //the test cases, we will multiple positive and negative test so that 
            //any change in the code of AddContactInfo breaks the test case
            //and we are hence force to update our test case code.
            //Role of Moq- since we have mocked Add method , when call stack hits 
            //Add method present in AddContactInfo it work as we defined in our mock config above; 
            Assert.AreEqual(result, "Success");

        }

    }
}
