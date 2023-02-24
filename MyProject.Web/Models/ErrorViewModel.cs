//namespace MyProject.Web.Models    //22
namespace MyProject.BL.Entities   //22
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}