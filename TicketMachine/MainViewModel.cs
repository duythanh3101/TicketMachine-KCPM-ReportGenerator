using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using TicketMachine;

namespace TicketMachine
{
    public class MainViewModel: BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Full name
        /// </summary>
        private string _FullName;
        public string FullName { get => _FullName; set { if (value == _FullName) return; _FullName = value; OnPropertyChanged(); } }

        /// <summary>
        /// Phone number
        /// </summary>
        private string _PhoneNumber;
        public string PhoneNumber { get => _PhoneNumber; set { if (value == _PhoneNumber) return; _PhoneNumber = value; OnPropertyChanged(); } }

        /// <summary>
        /// Index of radio button
        /// </summary>
        private int indexRadio;

        /// <summary>
        /// Format of congratulation content
        /// </summary>
        private string FORMAT_CONGRATULATION = "Congratulation to {0} with the phone number {1} is get {2} ticket successfully !";

        /// <summary>
        /// Congratulation content
        /// </summary>
        private string content;

        #endregion Properties


        #region Constructor

        public MainViewModel()
        {
            indexRadio = 0;
            content = string.Empty;
        }
        #endregion Constructor


        #region Public Methods
        public void PreviewTextInputPhoneNumber(object sender, TextCompositionEventArgs e)
        {
            if (sender is TextBox myTextBox && e != null)
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
        }

        /// <summary>
        /// Pay on event click
        /// </summary>
        public void Pay_Click()
        {
            if (Validation())
            {
                string ticketName = GetTicketName();
                content = string.Format(FORMAT_CONGRATULATION, FullName, PhoneNumber, ticketName);
            }
            MessageBox.Show(content);
        }

        /// <summary>
        /// Get index of ticket type
        /// </summary>
        /// <param name="index"></param>
        public void CheckIndex(int index) => indexRadio = (index >= 0 && index < Enum.GetNames(typeof(TicketType)).Length) ? index : indexRadio;

        #endregion Public Methods


        #region Private Methods
        /// <summary>
        /// Check FullName has content
        /// </summary>
        /// <returns></returns>
        private bool IsFullNameHasContent()
        {
            if (string.IsNullOrEmpty(FullName))
            {
                content = "FullName has not content";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check PhoneNumber has content
        /// </summary>
        /// <returns></returns>
        private bool IsPhoneNumberHasContent()
        {
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                content = "PhoneNumber has not content";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate full name and phone number
        /// </summary>
        /// <returns></returns>
        private bool Validation()
        {
            return IsFullNameHasContent() && IsPhoneNumberHasContent();
        }

        /// <summary>
        /// Get ticket name
        /// </summary>
        /// <returns></returns>
        private string GetTicketName()
        {
            string name = string.Empty;
            switch (GetTicketType(indexRadio))
            {
                case TicketType.Normal:
                    name = "Normal";
                    break;
                case TicketType.Vip:
                    name = "Vip";
                    break;
                case TicketType.Royal:
                    name = "Royal";
                    break;
                default:
                    name = string.Empty;
                    break;
            }
            return name;
        }

        /// <summary>
        /// Get ticket type by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private TicketType GetTicketType(int index)
        {
            switch (index)
            {
                case 0:
                    return TicketType.Normal;
                case 1:
                    return TicketType.Vip;
                case 2:
                    return TicketType.Royal;
                default:
                    return TicketType.None;
            }
        }
        #endregion Private Methods
    }

    #region Enums
    public enum TicketType
    {
        Normal = 0,
        Vip = 1,
        Royal = 2,
        None = 4
    }

    #endregion Enums

}
