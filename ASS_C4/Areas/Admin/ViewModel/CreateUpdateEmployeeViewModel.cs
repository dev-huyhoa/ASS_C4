using System;

namespace ASS_C4.Areas.Admin.ViewModel
{
    public class CreateUpdateEmployeeViewModel
    {
        public Guid IdEmployee { get; set; }
        public string NameEmployee { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string UrlImage { get; set; }
        public string Password { get; set; }
        public bool IsOnline { get; set; }
        public bool IsActice { get; set; }
        public bool IsDelete { get; set; }
        public int RoleId { get; set; }
        public string NameRole { get; set; }
    }
}
