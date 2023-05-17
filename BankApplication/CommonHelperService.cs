﻿using BankApplication.IHelperServices;
using BankApplicationHelperMethods;
using BankApplicationModels;
using BankApplicationModels.Enums;
using BankApplicationServices.IServices;
using Newtonsoft.Json;

namespace BankApplication
{
    public class CommonHelperService : ICommonHelperService
    {
        private string bankId = string.Empty;
        private string branchId = string.Empty;

        //It takes the menu options and Process It To and Fro.
        public ushort GetOption(string position)
        {
            while (true)
            {
                Console.WriteLine("Please Enter the Option");
                bool isValidOption = ushort.TryParse(Console.ReadLine(), out ushort Option);
                if (!isValidOption)
                {
                    Console.WriteLine("Option should contain only Positive Numbers.");
                    continue;
                }
                else
                {
                    string errorMessage = $"Entered Option:{Option} is Invalid.Please Select as per Above Options";
                    switch (position)
                    {
                        case "Main Page":
                            while (true)
                            {
                                if (Option == 0 || Option > 5)
                                {
                                    Console.WriteLine(errorMessage);
                                    break;
                                }
                                break;
                            }
                            break;

                        case "Customer":
                            while (true)
                            {
                                if (Option > 7)
                                {
                                    Console.WriteLine(errorMessage);
                                    break;
                                }
                                break;
                            }
                            break;

                        case "Staff":
                            while (true)
                            {
                                if (Option > 10)
                                {
                                    Console.WriteLine(errorMessage);
                                    break;
                                }
                                break;
                            }
                            break;

                        case "Branch Manager":
                            while (true)
                            {
                                if (Option > 16)
                                {
                                    Console.WriteLine(errorMessage);
                                    break;
                                }
                                break;
                            }
                            break;

                        case "Head Manager":
                            while (true)
                            {
                                if (Option > 7)
                                {
                                    Console.WriteLine(errorMessage);
                                    break;
                                }
                                break;
                            }
                            break;

                        case "Reserve Bank Manager":
                            while (true)
                            {
                                if (Option > 4)
                                {
                                    Console.WriteLine(errorMessage);
                                    break;
                                }
                                break;
                            }
                            break;
                    }
                }
                return Option;
            }
        }

        //Takes BankId Input and Validates It.
        public string GetBankId(string position, IBankService _bankService, IValidateInputs _validateInputs)
        {
            Message message;
            while (true)
            {
                Console.WriteLine($"Please Enter {position} BankId:");
                bankId = Console.ReadLine()?.ToUpper() ?? string.Empty;
                Message isValidbankId = _validateInputs.ValidateBankIdFormat(bankId);
                if (isValidbankId.Result)
                {
                    message = _bankService.AuthenticateBankId(bankId);
                    if (message.Result)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine(message.ResultMessage);
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine(isValidbankId.ResultMessage);
                    continue;
                }
            }
            return bankId;
        }

        //Takes BranchId Input and Validates It.
        public string GetBranchId(string position, IBranchService _branchService, IValidateInputs _validateInputs)
        {
            Message message;
            while (true)
            {
                Console.WriteLine($"Please Enter {position} BranchId:");
                branchId = Console.ReadLine()?.ToUpper() ?? string.Empty;
                Message isValidBranchId = _validateInputs.ValidateBranchIdFormat(branchId);
                if (isValidBranchId.Result)
                {
                    message = _branchService.AuthenticateBranchId(bankId, branchId);
                    if (message.Result)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine(message.ResultMessage);
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine(isValidBranchId.ResultMessage);
                    continue;
                }

            }
            return branchId;
        }

        //Validate  AccountId
        public string GetAccountId(string position, IValidateInputs _validateInputs)
        {
            string accountId;
            while (true)
            {
                Console.WriteLine($"Enter {position} AccountId:");
                accountId = Console.ReadLine()?.ToUpper() ?? string.Empty;
                Message isValidAccount = _validateInputs.ValidateAccountIdFormat(accountId);
                if (isValidAccount.Result)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(isValidAccount.ResultMessage);
                    continue;
                }
            }
            return accountId;
        }

        //Validate  Name
        public string GetName(string position, IValidateInputs _validateInputs)
        {
            string name;
            while (true)
            {
                Console.WriteLine($"Enter {position} Name:");
                name = Console.ReadLine()?.ToUpper().Replace(" ", "").ToUpper() ?? string.Empty;
                Message isValidName = _validateInputs.ValidateNameFormat(name);
                if (isValidName.Result)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(isValidName.ResultMessage);
                    continue;
                }

            }
            return name;
        }

        //Validate  Password
        public string GetPassword(string position, IValidateInputs _validateInputs)
        {
            string password;
            while (true)
            {
                Console.WriteLine($"Enter {position} Password:");
                password = Console.ReadLine() ?? string.Empty;
                Message isValidPassword = _validateInputs.ValidatePasswordFormat(password);
                if (isValidPassword.Result)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(isValidPassword.ResultMessage);
                    continue;
                }

            }
            return password;
        }

        //Validate  Phone Number
        public string GetPhoneNumber(string position, IValidateInputs _validateInputs)
        {
            string phoneNumber;
            while (true)
            {
                Console.WriteLine($"Enter {position} Phone Number:");
                phoneNumber = Console.ReadLine() ?? string.Empty;
                Message isValidPhoneNumber = _validateInputs.ValidatePhoneNumberFormat(phoneNumber);
                if (isValidPhoneNumber.Result)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(isValidPhoneNumber.ResultMessage);
                    continue;
                }

            }
            return phoneNumber;
        }

        // Validate  email
        public string GetEmailId(string position, IValidateInputs _validateInputs)
        {
            string emailId;
            while (true)
            {
                Console.WriteLine($"Enter {position} Email Id:");
                emailId = Console.ReadLine()?.ToUpper() ?? string.Empty;
                Message isValidEmail = _validateInputs.ValidateEmailIdFormat(emailId);
                if (isValidEmail.Result)
                {
                    break;
                }
                else
                {

                    Console.WriteLine(isValidEmail.ResultMessage);
                    continue;
                }
            }
            return emailId;
        }

        // Validate  account type
        public int GetAccountType(string position, IValidateInputs _validateInputs)
        {
            int accountType;
            while (true)
            {
                Console.WriteLine($"Enter {position} Account Type:");
                foreach (AccountType type in Enum.GetValues(typeof(AccountType)))
                {
                    Console.WriteLine("Enter {0} For {1}", (int)type, type.ToString());
                }

                accountType = int.Parse(Console.ReadLine() ?? string.Empty);
                Message isValidAccountType = _validateInputs.ValidateAccountTypeFormat(accountType);
                if (isValidAccountType.Result)
                {
                    break;

                }
                else
                {
                    Console.WriteLine(isValidAccountType.ResultMessage);
                    continue;
                }
            }
            return accountType;
        }

        // Validate address
        public string GetAddress(string position, IValidateInputs _validateInputs)
        {
            string address;
            while (true)
            {
                Console.WriteLine($"Enter {position} Address:");
                address = Console.ReadLine()?.ToUpper() ?? string.Empty;
                Message isValidAddress = _validateInputs.ValidateAddressFormat(address);
                if (isValidAddress.Result)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(isValidAddress.ResultMessage);
                    continue;
                }
            }
            return address;
        }

        // Validates  date of birth 
        public string GetDateOfBirth(string position, IValidateInputs _validateInputs)
        {
            string dateOfBirth;
            while (true)
            {
                Console.WriteLine($"Enter {position} Date Of Birth Ex:27/06/97(DD/MM/YY):");
                dateOfBirth = Console.ReadLine() ?? string.Empty;
                Message isValidDOB = _validateInputs.ValidateDateOfBirthFormat(dateOfBirth);
                if (isValidDOB.Result)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(isValidDOB.ResultMessage);
                    continue;
                }
            }
            return dateOfBirth;
        }

        //Checks whether the given GenderOption is valid or not.
        public int GetGender(string position, IValidateInputs _validateInputs)
        {
            int genderType;
            while (true)
            {
                Console.WriteLine($"Enter {position} Gender:");
                foreach (Gender gender in Enum.GetValues(typeof(Gender)))
                {
                    Console.WriteLine("Enter {0} For {1}", (int)gender, gender.ToString());
                }

                genderType = int.Parse(Console.ReadLine() ?? string.Empty);
                Message isValidGender = _validateInputs.ValidateGenderFormat(genderType);
                if (isValidGender.Result)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(isValidGender.ResultMessage);
                    continue;
                }
            }
            return genderType;
        }
        //Checks whether the given transferOptions are valid or not.
        public int ValidateTransferMethod()
        {
            int result;
            while (true)
            {
                Console.WriteLine("Enter the Transfer Method");
                foreach (TransferMethod method in Enum.GetValues(typeof(TransferMethod)))
                {
                    Console.WriteLine("Enter {0} For {1}", (int)method, method.ToString());
                }

                int choice = int.Parse(Console.ReadLine() ?? string.Empty);

                if (choice != 1 && choice != 2)
                {
                    Console.WriteLine("Enter as per Above Choices.");
                    continue;
                }
                else
                {
                    result = choice;
                    break;
                }
            }
            return result;
        }

        //Checks whether the given amount is valid or not.
        public decimal ValidateAmount()
        {
            decimal result;
            while (true)
            {
                Console.WriteLine("Enter the Amount");

                decimal amount = decimal.Parse(Console.ReadLine() ?? string.Empty);

                if (amount < 1)
                {
                    Console.WriteLine($"Entered Amount:{amount} is Invalid.,Please Enter a Valid Amout Ex:1");
                    continue;
                }
                else
                {
                    result = amount;
                    break;
                }
            }
            return result;
        }

        //checks the format and currency already exist or not 
        public string ValidateCurrency(string bankId, ICurrencyService _currencyService, IValidateInputs _validateInputs)
        {
            Message message;
            string result;
            while (true)
            {
                Console.WriteLine("Enter the Currency Name Ex:USD,KWD.");
                string currencyCode = Console.ReadLine()?.ToUpper() ?? string.Empty;
                message = _validateInputs.ValidateCurrencyCodeFormat(currencyCode);

                if (message.Result)
                {
                    message = _currencyService.ValidateCurrency(bankId, currencyCode);
                    if (message.Result)
                    {
                        result = currencyCode;
                        break;
                    }
                    else
                    {
                        Console.WriteLine(message.ResultMessage);
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine(message.ResultMessage);
                    continue;
                }
            }
            return result;
        }

        //ToValidate TransactionId Format.
        public string ValidateTransactionIdFormat()
        {
            string result;
            while (true)
            {
                Console.WriteLine("Enter the Transaction Id");
                string transactionId = Console.ReadLine()?.ToUpper() ?? string.Empty;

                if (transactionId.Length == 23 && transactionId.Contains("TXN"))
                {
                    result = transactionId;
                    break;
                }
                else
                {
                    Console.WriteLine($"TransactionId:{transactionId} Is Invalid");
                    continue;
                }
            }
            return result;
        }


        //customer,staff,manager Login
        public void LoginAccountHolder(string level, IBankService bankService, IBranchService branchService, IValidateInputs validateInputs,
            ICustomerHelperService? customerHelperService = null, IStaffHelperService? staffHelperService = null, IManagerHelperService? managerHelperService = null,
            IHeadManagerHelperService? headManagerHelperService = null, IReserveBankManagerHelperService? reserveBankManagerHelperService = null, ICustomerService? customerService = null, IStaffService? staffService = null, IManagerService? managerService = null,
            IHeadManagerService? headManagerService = null, IReserveBankManagerService? reserveBankManagerService = null)
        {
            Message message = new();
            while (true)
            {
                string bankId = string.Empty;
                if (!level.Equals("Reserve Bank Manager"))
                {
                    bankId = GetBankId(level, bankService, validateInputs);
                    message = bankService.AuthenticateBankId(bankId);
                }

                if (level.Equals("Reserve Bank Manager") || message.Result)
                {
                    if (!level.Equals("Head Manager") && !level.Equals("Reserve Bank Manager"))
                    {
                        message = branchService.IsBranchesExist(bankId);
                    }

                    if (level.Equals("Reserve Bank Manager") || level.Equals("Head Manager") || message.Result)
                    {
                        while (true)
                        {
                            string branchId = string.Empty;
                            if (!level.Equals("Head Manager") && !level.Equals("Reserve Bank Manager"))
                            {
                                branchId = GetBranchId(level, branchService, validateInputs);
                                message = branchService.AuthenticateBranchId(bankId, branchId);
                            }

                            if (message.Result || level.Equals("Head Manager") || level.Equals("Reserve Bank Manager"))
                            {

                                if (level.Equals("Customer") && customerService is not null)
                                {
                                    message = customerService.IsCustomersExist(bankId, branchId);
                                }
                                else if (level.Equals("Staff") && staffService is not null)
                                {
                                    message = staffService.IsStaffExist(bankId, branchId);
                                }
                                else if (level.Equals("Branch Manager") && managerService is not null)
                                {
                                    message = managerService.IsManagersExist(bankId, branchId);
                                }
                                else if (level.Equals("Head Manager") && headManagerService is not null)
                                {
                                    message = headManagerService.IsHeadManagersExist(bankId);
                                }

                                if (level.Equals("Reserve Bank Manager") || message.Result)
                                {
                                    while (true)
                                    {
                                        string accountId = string.Empty;
                                        string ReserveBankManagerName = string.Empty;
                                        if (!level.Equals("Reserve Bank Manager"))
                                        {
                                            accountId = GetAccountId(level, validateInputs);
                                        }

                                        if (level.Equals("Customer") && customerService is not null)
                                        {
                                            message = customerService.IsAccountExist(bankId, branchId, accountId);
                                        }
                                        else if (level.Equals("Staff") && staffService is not null)
                                        {
                                            message = staffService.IsAccountExist(bankId, branchId, accountId);
                                        }
                                        else if (level.Equals("Branch Manager") && managerService is not null)
                                        {
                                            message = managerService.IsAccountExist(bankId, branchId, accountId);
                                        }
                                        else if (level.Equals("Head Manager") && headManagerService is not null)
                                        {
                                            message = headManagerService.IsHeadManagerExist(bankId, accountId);
                                        }
                                        else if (level.Equals("Reserve Bank Manager"))
                                        {
                                            ReserveBankManagerName = GetName(level, validateInputs);
                                            if (ReserveBankManagerName is not null)
                                            {
                                                message.Result = true;
                                            }
                                            else
                                            {
                                                message.Result = false;
                                            }
                                        }

                                        if (message.Result)
                                        {
                                            string password = GetPassword(level, validateInputs);

                                            if (level.Equals("Customer") && customerService is not null)
                                            {
                                                message = customerService.AuthenticateCustomerAccount(bankId, branchId, accountId, password);
                                            }
                                            else if (level.Equals("Staff") && staffService is not null)
                                            {
                                                message = staffService.AuthenticateStaffAccount(bankId, branchId, accountId, password);
                                            }
                                            else if (level.Equals("Branch Manager") && managerService is not null)
                                            {
                                                message = managerService.AuthenticateManagerAccount(bankId, branchId, accountId, password);
                                            }
                                            else if (level.Equals("Head Manager") && headManagerService is not null)
                                            {
                                                message = headManagerService.AuthenticateHeadManager(bankId, accountId, password);
                                            }
                                            else if (level.Equals("Reserve Bank Manager") && reserveBankManagerService is not null)
                                            {
                                                message = reserveBankManagerService.AuthenticateReserveBankManager(ReserveBankManagerName!, password);
                                            }

                                            if (message.Result)
                                            {
                                                while (true)
                                                {
                                                    Console.WriteLine("Choose From Below Menu Options");
                                                    if (level.Equals("Customer"))
                                                    {
                                                        foreach (CustomerOptions option in Enum.GetValues(typeof(CustomerOptions)))
                                                        {
                                                            Console.WriteLine("Enter {0} For {1}", (int)option, option.ToString());
                                                        }
                                                    }
                                                    else if (level.Equals("Staff"))
                                                    {
                                                        foreach (StaffOptions option in Enum.GetValues(typeof(StaffOptions)))
                                                        {
                                                            Console.WriteLine("Enter {0} For {1}", (int)option, option.ToString());
                                                        }
                                                    }
                                                    else if (level.Equals("Branch Manager"))
                                                    {
                                                        foreach (ManagerOptions option in Enum.GetValues(typeof(StaffOptions)))
                                                        {
                                                            Console.WriteLine("Enter {0} For {1}", (int)option, option.ToString());
                                                        }
                                                    }
                                                    else if (level.Equals("Head Manager"))
                                                    {
                                                        foreach (HeadManagerOptions option in Enum.GetValues(typeof(HeadManagerOptions)))
                                                        {
                                                            Console.WriteLine("Enter {0} For {1}", (int)option, option.ToString());
                                                        }
                                                    }
                                                    else if (level.Equals("Reserve Bank Manager"))
                                                    {
                                                        foreach (ReserveBankManagerOptions option in Enum.GetValues(typeof(ReserveBankManagerOptions)))
                                                        {
                                                            Console.WriteLine("Enter {0} For {1}", (int)option, option.ToString());
                                                        }
                                                    }

                                                    Console.WriteLine("Enter 0 For Main Menu");
                                                    ushort selectedOption = GetOption(level);
                                                    if (selectedOption == 0)
                                                    {
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        if (level.Equals("Customer"))
                                                        {
                                                            customerHelperService?.SelectedOption(selectedOption, bankId, branchId, accountId);
                                                            continue;
                                                        }
                                                        else if (level.Equals("Staff"))
                                                        {
                                                            staffHelperService?.SelectedOption(selectedOption, bankId, branchId);
                                                            continue;
                                                        }
                                                        else if (level.Equals("Branch Manager"))
                                                        {
                                                            managerHelperService?.SelectedOption(selectedOption, bankId, branchId);
                                                            continue;
                                                        }
                                                        else if (level.Equals("Head Manager"))
                                                        {
                                                            headManagerHelperService?.SelectedOption(selectedOption, bankId);
                                                            continue;
                                                        }
                                                        else if (level.Equals("Reserve Bank Manager"))
                                                        {
                                                            reserveBankManagerHelperService?.SelectedOption(selectedOption);
                                                            continue;
                                                        }
                                                    }
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine(message.ResultMessage);
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine(message.ResultMessage);
                                            continue;
                                        }
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine(message.ResultMessage);
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine(message.ResultMessage);
                                continue;
                            }
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine(message.ResultMessage);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(message.ResultMessage);
                    continue;
                }
            }
        }

        //Get AccountBalance
        public void GetCustomerAccountBalance(string bankId, string branchId, ICustomerService _customerService, IValidateInputs _validateInputs, string level, string? userAccountId = null)
        {
            Message message;
            while (true)
            {
                message = _customerService.IsCustomersExist(bankId, branchId);
                if (message.Result || level.Equals("Customer"))
                {
                    string customerAccountId;
                    if (!level.Equals("Customer"))
                    {
                        customerAccountId = GetAccountId(Miscellaneous.customer, _validateInputs);
                        message = _customerService.IsAccountExist(bankId, branchId, customerAccountId);
                    }
                    else
                    {
                        customerAccountId = userAccountId!;
                    }

                    if (message.Result || level.Equals("Customer"))
                    {
                        message = _customerService.CheckAccountBalance(bankId, branchId, customerAccountId);
                        if (message.Result)
                        {
                            Console.WriteLine(message.ResultMessage);
                            break;
                        }
                        else
                        {
                            Console.WriteLine(message.ResultMessage);
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine(message.ResultMessage);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(message.ResultMessage);
                    break;
                }
            }
        }
        //Get Transaction History
        public void GetTransactoinHistory(string bankId, string branchId, ICustomerService _customerService, IValidateInputs _validateInputs, ITransactionService _transactionService, string level, string? userAccountId = null)
        {
            Message message = new();
            while (true)
            {
                if (!level.Equals("Customer"))
                {
                    message = _customerService.IsCustomersExist(bankId, branchId);
                }

                if (message.Result || level.Equals("Customer"))
                {
                    string customerAccountId;
                    if (!level.Equals("Customer"))
                    {
                        customerAccountId = GetAccountId(Miscellaneous.customer, _validateInputs);
                        message = _customerService.IsAccountExist(bankId, branchId, customerAccountId);
                    }
                    else
                    {
                        customerAccountId = userAccountId!;
                    }
                    if (message.Result || level.Equals("Customer"))
                    {
                        message = _transactionService.IsTransactionsAvailable(bankId, branchId, customerAccountId);
                        if (message.Result)
                        {
                            List<string> transactions = _transactionService.GetTransactionHistory(bankId, branchId, customerAccountId);
                            foreach (string transaction in transactions)
                            {
                                Console.WriteLine();
                                Console.WriteLine(transaction);
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine(message.ResultMessage);
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine(message.ResultMessage);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(message.ResultMessage);
                    break;
                }
            }
        }

        //Get Exchange Rates
        public void GetExchangeRates(string bankId, IBankService _bankService)
        {
            while (true)
            {
                Message message;
                message = _bankService.GetExchangeRates(bankId);

                Dictionary<string, decimal>? exchangeRates = JsonConvert.DeserializeObject<Dictionary<string, decimal>>(message.Data);

                if (exchangeRates != null)
                {
                    Console.WriteLine("Available Exchange Rates:");
                    foreach (KeyValuePair<string, decimal> rates in exchangeRates)
                    {
                        Console.WriteLine($"{rates.Key} : {rates.Value} Rupees");
                    }
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine(message.ResultMessage);
                    continue;
                }
            }
        }

        //Get Transaction Charges
        public void GetTransactionCharges(string bankId, string branchId, IBranchService _branchService)
        {
            while (true)
            {
                Message message;
                message = _branchService.GetTransactionCharges(bankId, branchId);
                if (message.Result)
                {
                    Console.WriteLine(message.Data);
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine(message.ResultMessage);
                    Console.WriteLine();
                    break;
                }
            }
        }

        //Transfer Amount
        public void TransferAmount(string userBankId, string userBranchId, IBranchService _branchService, IBankService _bankService, IValidateInputs _validateInputs, ICustomerService _customerService, string level, string? userAccountId = null)
        {
            Message message = new();
            while (true)
            {
                if (!level.Equals("Customer"))
                {
                    message = _customerService.IsCustomersExist(bankId, branchId);
                }
                if (message.Result || level.Equals("Customer"))
                {
                    string fromCustomerAccountId;
                    if (!level.Equals("Customer"))
                    {
                        fromCustomerAccountId = GetAccountId(Miscellaneous.customer, _validateInputs);
                        message = _customerService.IsAccountExist(bankId, branchId, fromCustomerAccountId);
                    }
                    else
                    {
                        fromCustomerAccountId = userAccountId!;
                    }

                    if (message.Result || level.Equals("Customer"))
                    {
                        int transferMethod = ValidateTransferMethod();
                        decimal amount = ValidateAmount();
                        message = _customerService.IsAccountExist(userBankId, userBranchId, fromCustomerAccountId);

                        if (message.Result)
                        {
                            while (true)
                            {
                                string toCustomerBankId = GetBankId(Miscellaneous.toCustomer, _bankService, _validateInputs);
                                message = _bankService.AuthenticateBankId(toCustomerBankId);
                                if (message.Result)
                                {
                                    string toCustomerBranchId = GetBranchId(Miscellaneous.toCustomer, _branchService, _validateInputs);
                                    message = _branchService.AuthenticateBranchId(toCustomerBankId, toCustomerBranchId);
                                    if (message.Result)
                                    {
                                        string toCustomerAccountId = GetAccountId(Miscellaneous.toCustomer, _validateInputs);
                                        message = _customerService.IsAccountExist(toCustomerBankId, toCustomerBranchId, toCustomerAccountId);
                                        if (message.Result)
                                        {
                                            message = _customerService.TransferAmount(userBankId, userBranchId, fromCustomerAccountId,
                                                toCustomerBankId, toCustomerBranchId, toCustomerAccountId, amount, transferMethod);
                                            if (message.Result)
                                            {
                                                Console.WriteLine(message.ResultMessage);
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine(message.ResultMessage);
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine(message.ResultMessage);
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine(message.ResultMessage);
                                        continue;
                                    }

                                }
                                else
                                {
                                    Console.WriteLine(message.ResultMessage);
                                    continue;
                                }
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine(message.ResultMessage);
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine(message.ResultMessage);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(message.ResultMessage);
                    break;
                }
            }
        }

        public void OpenCustomerAccount(string bankId,string branchId,ICustomerService _customerService,IValidateInputs _validateInputs)
        {
            Message message;
            while (true)
            {
                string customerName = GetName(Miscellaneous.customer, _validateInputs);
                string customerPassword = GetPassword(Miscellaneous.customer, _validateInputs);
                string customerPhoneNumber = GetPhoneNumber(Miscellaneous.customer, _validateInputs);
                string customerEmailId = GetEmailId(Miscellaneous.customer, _validateInputs);
                int customerAccountType = GetAccountType(Miscellaneous.customer, _validateInputs);
                string customerAddress = GetAddress(Miscellaneous.customer, _validateInputs);
                string customerDOB = GetDateOfBirth(Miscellaneous.customer, _validateInputs);
                int customerGender = GetGender(Miscellaneous.customer, _validateInputs);

                message = _customerService.OpenCustomerAccount(bankId,
                branchId, customerName, customerPassword, customerPhoneNumber, customerEmailId,
                customerAccountType, customerAddress, customerDOB, customerGender);
                if (message.Result)
                {
                    Console.WriteLine(message.ResultMessage);
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine(message.ResultMessage);
                    Console.WriteLine();
                    continue;
                }
            };
        }

        public void UpdateCustomerAccount(string bankId,string branchId,IValidateInputs _validateInputs,ICustomerService _customerService)
        {
            Message message;
            while (true)
            {
                message = _customerService.IsCustomersExist(bankId, branchId);
                if (message.Result)
                {
                    string customerAccountId = GetAccountId(Miscellaneous.customer, _validateInputs);
                    message = _customerService.IsAccountExist(bankId, branchId, customerAccountId);
                    if (message.Result)
                    {
                        string passbookDetatils = _customerService.GetPassbook(bankId, branchId, customerAccountId);
                        Console.WriteLine("Passbook Details:");
                        Console.WriteLine(passbookDetatils);

                        string customerName;
                        while (true)
                        {
                            Console.WriteLine("Update Customer Name");
                            customerName = Console.ReadLine() ?? string.Empty;
                            if (!string.IsNullOrEmpty(customerName))
                            {
                                message = _validateInputs.ValidateNameFormat(customerName);
                                if (!message.Result)
                                {
                                    Console.WriteLine(message.ResultMessage);
                                    Console.WriteLine();
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        string customerPassword;
                        while (true)
                        {
                            Console.WriteLine("Update Customer Password");
                            customerPassword = Console.ReadLine() ?? string.Empty;
                            if (!string.IsNullOrEmpty(customerPassword))
                            {
                                message = _validateInputs.ValidatePasswordFormat(customerPassword);
                                if (!message.Result)
                                {
                                    Console.WriteLine(message.ResultMessage);
                                    Console.WriteLine();
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        string customerPhoneNumber;
                        while (true)
                        {
                            Console.WriteLine("Update Customer Phone Number");
                            customerPhoneNumber = Console.ReadLine() ?? string.Empty;
                            if (!string.IsNullOrEmpty(customerPhoneNumber))
                            {
                                message = _validateInputs.ValidatePhoneNumberFormat(customerPhoneNumber);
                                if (!message.Result)
                                {
                                    Console.WriteLine(message.ResultMessage);
                                    Console.WriteLine();
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        string customerEmailId;
                        while (true)
                        {
                            Console.WriteLine("Update Customer Email Id");
                            customerEmailId = Console.ReadLine() ?? string.Empty;
                            if (!string.IsNullOrEmpty(customerEmailId))
                            {
                                message = _validateInputs.ValidateEmailIdFormat(customerEmailId);
                                if (!message.Result)
                                {
                                    Console.WriteLine(message.ResultMessage);
                                    Console.WriteLine();
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        int customerAccountType;
                        while (true)
                        {
                            Console.WriteLine("Choose From Below Menu Options To Update");
                            foreach (AccountType option in Enum.GetValues(typeof(AccountType)))
                            {
                                Console.WriteLine("Enter {0} For {1}", (int)option, option.ToString());
                            }
                            bool isValid = int.TryParse(Console.ReadLine(), out customerAccountType);
                            if (isValid && customerAccountType != 0)
                            {
                                message = _validateInputs.ValidateAccountTypeFormat(customerAccountType);
                                if (!message.Result)
                                {
                                    Console.WriteLine(message.ResultMessage);
                                    Console.WriteLine();
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        string customerAddress;
                        while (true)
                        {
                            Console.WriteLine("Update Customer Address");
                            customerAddress = Console.ReadLine() ?? string.Empty;
                            if (!string.IsNullOrEmpty(customerAddress))
                            {
                                message = _validateInputs.ValidateAddressFormat(customerAddress);
                                if (!message.Result)
                                {
                                    Console.WriteLine(message.ResultMessage);
                                    Console.WriteLine();
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        string customerDOB;
                        while (true)
                        {
                            Console.WriteLine("Update Customer Date Of Birth");
                            customerDOB = Console.ReadLine() ?? string.Empty;
                            if (!string.IsNullOrEmpty(customerDOB))
                            {
                                message = _validateInputs.ValidateDateOfBirthFormat(customerDOB);
                                if (message.Result == false)
                                {
                                    Console.WriteLine(message.ResultMessage);
                                    Console.WriteLine();
                                    continue;
                                }
                                else
                                {
                                    break;
                                }

                            }
                            else
                            {
                                break;
                            }
                        }

                        int customerGender;
                        while (true)
                        {
                            Console.WriteLine("Choose From Below Menu Options To Update");
                            foreach (Gender option in Enum.GetValues(typeof(Gender)))
                            {
                                Console.WriteLine("Enter {0} For {1}", (int)option, option.ToString());
                            }
                            bool isValid = int.TryParse(Console.ReadLine(), out customerGender);
                            if (isValid && customerGender != 0)
                            {
                                message = _validateInputs.ValidateGenderFormat(customerGender);
                                if (message.Result == false)
                                {
                                    Console.WriteLine(message.ResultMessage);
                                    Console.WriteLine();
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        message = _customerService.UpdateCustomerAccount(bankId, branchId, customerAccountId, customerName, customerPassword, customerPhoneNumber,
                            customerEmailId, customerAccountType, customerAddress, customerDOB, customerGender);
                        if (message.Result)
                        {
                            Console.WriteLine(message.ResultMessage);
                            Console.WriteLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine(message.ResultMessage);
                            Console.WriteLine();
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine(message.ResultMessage);
                        Console.WriteLine();
                        continue;
                    }

                }
                else
                {
                    Console.WriteLine(message.ResultMessage);
                    Console.WriteLine();
                    break;
                }
            }
        }

        public void DeleteCustomerAccount(string bankId,string branchId,ICustomerService _customerService,IValidateInputs _validateInputs)
        {
            Message message;
            while (true)
            {
                message = _customerService.IsCustomersExist(bankId, branchId);
                if (message.Result)
                {
                    string customerAccountId = GetAccountId(Miscellaneous.customer, _validateInputs);
                    message = _customerService.DeleteCustomerAccount(bankId, branchId, customerAccountId);
                    if (message.Result)
                    {
                        Console.WriteLine(message.ResultMessage);
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine(message.ResultMessage);
                        Console.WriteLine();
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine(message.ResultMessage);
                    Console.WriteLine();
                    break;
                }

            }
        }

        public void RevertCustomerTransaction(string bankId, string branchId, ICustomerService _customerService, 
            IValidateInputs _validateInputs,ITransactionService _transactionService,IBankService _bankService,
            IBranchService _branchService)
        {
            Message message;
            while (true)
            {
                message = _customerService.IsCustomersExist(bankId, branchId);
                if (message.Result)
                {
                    string fromCustomerAccountId = GetAccountId(Miscellaneous.customer, _validateInputs);
                    message = _customerService.IsAccountExist(bankId, branchId,fromCustomerAccountId);

                    if (message.Result)
                    {
                        message = _transactionService.IsTransactionsAvailable(bankId, branchId, fromCustomerAccountId);
                        if (message.Result)
                        {
                            string toCustomerBankId = GetBankId(Miscellaneous.toCustomer, _bankService, _validateInputs);
                            message = _bankService.AuthenticateBankId(toCustomerBankId);
                            if (message.Result)
                            {
                                string toCustomerBranchId = GetBranchId(Miscellaneous.toCustomer, _branchService, _validateInputs);
                                message = _branchService.AuthenticateBranchId(toCustomerBankId, toCustomerBranchId);
                                if (message.Result)
                                {
                                    string toCustomerAccountId = GetAccountId(Miscellaneous.toCustomer, _validateInputs);

                                    message = _customerService.AuthenticateToCustomerAccount(toCustomerBankId, toCustomerBranchId, toCustomerAccountId);
                                    if (message.Result)
                                    {
                                        string transactionId = ValidateTransactionIdFormat();
                                        message = _transactionService.RevertTransaction(transactionId, bankId, branchId, fromCustomerAccountId, toCustomerBankId, toCustomerBranchId, toCustomerAccountId);
                                        Console.WriteLine(message.ResultMessage);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine(message.ResultMessage);
                                        continue;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(message.ResultMessage);
                                    continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine(message.ResultMessage);
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine(message.ResultMessage);
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine(message.ResultMessage);
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine(message.ResultMessage);
                    break;
                }
            }
        }

        public void DepositAmountInCustomerAccount(string bankId, string branchId, ICustomerService _customerService,
            IValidateInputs _validateInputs,ICurrencyService _currencyService)
        {
            Message message;
            while (true)
            {
                message = _customerService.IsCustomersExist(bankId, branchId);
                if (message.Result)
                {
                    string customerAccountId = GetAccountId(Miscellaneous.customer, _validateInputs);
                    message = _customerService.IsAccountExist(bankId, branchId, customerAccountId);
                    if (message.Result)
                    {
                        decimal depositAmount = ValidateAmount();
                        string currencyCode = ValidateCurrency(bankId, _currencyService, _validateInputs);
                        message = _customerService.DepositAmount(bankId, branchId, customerAccountId, depositAmount, currencyCode);
                        if (message.Result)
                        {
                            Console.WriteLine(message.ResultMessage);
                            break;
                        }
                        else
                        {
                            Console.WriteLine(message.ResultMessage);
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine(message.ResultMessage);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(message.ResultMessage);
                    break;
                }
            }
        }
    }
}
