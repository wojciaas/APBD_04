using System;
using LegacyApp.Interfaces;

namespace LegacyApp
{
    public class UserService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUserCreditService _userCreditService;
        private readonly UserManager _userManager;
        
        
        public UserService()
        {
            _clientRepository = new ClientRepository();
            _userCreditService = new UserCreditService();
            _userManager = new UserManager(_userCreditService);
        }
        
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!UserValidator.Validate_Name(firstName, lastName)
                || !UserValidator.Validate_Email(email)
                || !UserValidator.Validate_Age(dateOfBirth))
            {
                return false;
            }

            var client = _clientRepository.GetById(clientId);
            var user = _userManager.CreateUser(firstName, lastName, email, dateOfBirth, client);

            if (UserValidator.Is_Credit_Limit_Required(user)) return false;

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
