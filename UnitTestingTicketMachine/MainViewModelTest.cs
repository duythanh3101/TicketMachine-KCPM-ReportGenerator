using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TicketMachine;
using Assert = NUnit.Framework.Assert;

namespace UnitTestingTicketMachine
{
    [TestFixture]
    public class MainViewModelTest
    {
        private MainViewModel _testViewModel;
        private PrivateObject _privateObject;

        public MainViewModelTest()
        {
            _testViewModel = new MainViewModel();
            _privateObject = new PrivateObject(_testViewModel);
        }

        #region Pay_Click
        [Test]
        /**
        * @fn: Test_Pay_Click_IsFalse_01()
        * @brief: Test function Pay_Click
        * @pre-condition: FullName is empty
        * @expected-result: return false
        */
        public void Test_Pay_Click_IsFalse_01()
        {
            // Arrage
            _testViewModel.FullName = string.Empty;

            // Actual
            var actual = _testViewModel.Pay_Click();

            // Assert
            Assert.AreEqual(false, actual);
        }

        [Test]
        /**
        * @fn: Test_Pay_Click_IsFalse_02()
        * @brief: Test function Pay_Click
        * @pre-condition: PhoneNumber is empty
        * @expected-result: return false
        */
        public void Test_Pay_Click_IsFalse_02()
        {
            // Arrage
            _testViewModel.PhoneNumber = string.Empty;

            // Actual
            var actual = _testViewModel.Pay_Click();

            // Assert
            Assert.AreEqual(false, actual);
        }

        [Test]
        /**
        * @fn: Test_Pay_Click_IsTrue_01()
        * @brief: Test function Pay_Click
        * @pre-condition: PhoneNumber and FullName are not empty
        * @expected-result: return true
        */
        public void Test_Pay_Click_IsTrue_01()
        {
            // Arrage
            _testViewModel.FullName = "John";
            _testViewModel.PhoneNumber = "0912345678";

            // Actual
            var actual = _testViewModel.Pay_Click();

            // Assert
            Assert.AreEqual(true, actual);
        }

        #endregion Pay_Click
        #region IsPhoneNumberHasContent

        [Test]
        /**
        * @fn: Test_IsPhoneNumberHasContent_IsTrue_01()
        * @brief: Test function IsPhoneNumberHasContent
        * @pre-condition: PhoneNumber is not empty
        * @expected-result: return true
        */
        public void Test_IsPhoneNumberHasContent_IsTrue_01()
        {
            // Arrage
            _testViewModel.PhoneNumber = "123";

            // Actual
            var actual = _privateObject.Invoke("IsPhoneNumberHasContent");

            // Assert
            Assert.AreEqual(true, actual);
        }

        [Test]
        /**
        * @fn: Test_IsPhoneNumberHasContent_IsFalse()
        * @brief: Test function IsPhoneNumberHasContent
        * @pre-condition: PhoneNumber is not empty
        * @expected-result: return false
        */
        public void Test_IsPhoneNumberHasContent_IsFalse()
        {
            // Arrage
            _testViewModel.PhoneNumber = string.Empty;

            // Actual
            var actual = _privateObject.Invoke("IsPhoneNumberHasContent");

            // Assert
            Assert.AreEqual(false, actual);
        }

        #endregion IsPhoneNumberHasContent

    }
}
