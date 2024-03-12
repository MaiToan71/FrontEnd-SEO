using Project.Proxy.Enums;
using Project.Proxy.ViewModels;

namespace Project.Proxy.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; } = 0;
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Cmnd { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfCmnd { get; set; }
        public bool IsMoney { get; set; }
        public string Note { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public float MoneyTotal { get; set; }
        public float Money { get; set; }
        public Workflow WorkflowState { get; set; }
        public int FanPageFacebookId { get; set; }
        public UserViewModel UserCreate { get; set; } = new UserViewModel();
        public List<ImageViewModel> Images { get; set; } = new List<ImageViewModel>();
    }
}
