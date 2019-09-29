using NUnit.Framework;
using TicketMachine;

namespace UnitTestingTicketMachine
{
    [TestFixture]
    public class MainViewModelTest
    {
        private MainViewModel _testViewModel;

        public MainViewModelTest()
        {
            _testViewModel = new MainViewModel();
        }

        [Test]
        public void Test_Pay_Click_IsTrue()
        {
            _testViewModel.Pay_Click();
        }
    }
}
