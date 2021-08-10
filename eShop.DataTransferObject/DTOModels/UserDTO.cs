using System;

namespace eShop.DataTransferObject.DTOModels
{
    public class UserDTO : BaseDTO
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

    }
}
