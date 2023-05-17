﻿using BankApplication.IHelperServices;
using BankApplicationHelperMethods;
using BankApplicationModels;
using BankApplicationServices.IServices;

namespace BankApplication
{
    public class CustomerHelperService : ICustomerHelperService
    {
        readonly ICustomerService _customerService;
        readonly IBankService _bankService;
        readonly IBranchService _branchService;
        readonly ITransactionService _transactionService;
        readonly ICommonHelperService _commonHelperService;
        readonly IValidateInputs _validateInputs;
        public CustomerHelperService(ICustomerService customerService, IBankService bankService, IBranchService branchService,
            ITransactionService transactionService, ICommonHelperService commonHelperService, IValidateInputs validateInputs)
        {
            _customerService = customerService;
            _bankService = bankService;
            _branchService = branchService;
            _transactionService = transactionService;
            _commonHelperService = commonHelperService;
            _validateInputs = validateInputs;
        }
        public void SelectedOption(ushort Option, string bankId, string branchId, string accountId)
        {
            switch (Option)
            {
                case 1: //CheckAccountBalance
                    _commonHelperService.GetCustomerAccountBalance(bankId, branchId, _customerService, _validateInputs,
                        Miscellaneous.customer, accountId);
                    break;

                case 2: //ViewTransactionHistory
                    _commonHelperService.GetTransactoinHistory(bankId, branchId, _customerService, _validateInputs, _transactionService,
                        Miscellaneous.customer, accountId);
                    break;

                case 3: //ViewExchangeRates
                    _commonHelperService.GetExchangeRates(bankId, _bankService);
                    break;

                case 4: //ViewTransactionCharges
                    _commonHelperService.GetTransactionCharges(bankId, branchId, _branchService);
                    break;

                case 5: //WithdrawAmount
                    while (true)
                    {
                        Console.Write("Enter Amount:");
                        bool result = decimal.TryParse(Console.ReadLine(), out decimal amount);
                        if (result)
                        {
                            Message isAmountWithdrawn = _customerService.WithdrawAmount(bankId, branchId, accountId, amount);
                            if (isAmountWithdrawn.Result)
                            {
                                Console.WriteLine(isAmountWithdrawn.ResultMessage);
                                break;
                            }
                            else
                            {
                                Console.WriteLine(isAmountWithdrawn.ResultMessage);
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Amount Shouldn't Contain Any Special Charecters.");
                        }
                    }
                    break;

                case 6:  //TransferAmount
                    _commonHelperService.TransferAmount(bankId, branchId, _branchService, _bankService, _validateInputs, _customerService,
                        Miscellaneous.customer, accountId);
                    break;

                case 7: // Get Passbook
                    while (true)
                    {
                        Message message;
                        message = _customerService.IsCustomersExist(bankId, branchId);
                        if (message.Result)
                        {
                            message = _customerService.IsAccountExist(bankId, branchId, accountId);
                            if (message.Result)
                            {
                                string passbookDetatils = _customerService.GetPassbook(bankId, branchId, accountId);
                                Console.WriteLine("Passbook Details:");
                                Console.WriteLine(passbookDetatils);
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
                    break;
            }
        }
    }
}
