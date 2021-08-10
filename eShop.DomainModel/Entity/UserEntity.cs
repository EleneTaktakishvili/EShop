using eShop.DomainModel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace eShop.DomainModel.Entity
{
    public class UserEntity : Base
    {
        public Guid Id { get; set; }
        public Guid? SessionId { get; set; }
        public string ActivationCode { get; set; }
        public bool IsActive { get; set; }
        public string PasswordHash { get; set; }
        public string RepeatPasswordHash { get; set; }
        public string FirtsName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }


        public void Set(UserEntity User)
        {
            Id = User.Id;
            SessionId = User.SessionId;
            ActivationCode = User.ActivationCode;
            IsActive = User.IsActive;
            Email = User.Email;
            PasswordHash = User.PasswordHash;
            RepeatPasswordHash = User.RepeatPasswordHash;
            FirtsName = User.FirtsName;
            LastName = User.LastName;
            RoleId = User.RoleId;
            RoleName = User.RoleName;
            DateCreated = User.DateCreated;
            DateChanged = User.DateChanged;
            DateDeleted = User.DateDeleted;
        }

        public UserEntity Get(UserOperationType OperationType) 
        {
            switch (OperationType)
            {
                case UserOperationType.Login:
                    this.SessionId = Guid.NewGuid();
                    break;
                case UserOperationType.Registration:
                    break;
                case UserOperationType.Activation:
                    break;
                default:
                    break;
            }
            return this;
        }


        public List<string> IsValid(UserValidationType ValidationType)
        {
            switch (ValidationType)
            {
                case UserValidationType.Login:
                    return LoginValidation();
                case UserValidationType.Registration:
                    return RegistrationValidation();
                case UserValidationType.Activation:
                    return ActivationValidation();
                default:
                    return new List<string>();
            }
        }

        private List<string> LoginValidation()
        {
            List<string> ErrorResult = new List<string>();

            if (string.IsNullOrEmpty(this.Email))
            {
                ErrorResult.Add(UserErrors.Email_Empty.ToString());
            }

            //if (Regex.IsMatch(this.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            //{
            //    ErrorResult.Add(UserErrors.Email_Is_Not_Valid.ToString());
            //}

            if (string.IsNullOrEmpty(this.PasswordHash))
            {
                ErrorResult.Add(UserErrors.Password_Empty.ToString());
            }
            return ErrorResult;
        }
        private List<string> RegistrationValidation()
        {
            return new List<string>();
        }
        private List<string> ActivationValidation()
        {
            return new List<string>();
        }
    }

    public enum UserValidationType
    {
        Login = 0,
        Registration = 1,
        RegistrationForAdmin = 2,
        Activation = 3
    }

    public enum UserErrors
    {
        Email_Empty = 0,
        Email_Is_Not_Valid = 1,
        Password_Empty = 2,
        Password_Is_Not_Match = 3
    }

    public enum UserOperationType
    {
        Login = 0,
        Registration = 1,
        Activation = 2
    }
}
