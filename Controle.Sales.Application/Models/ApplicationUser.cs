using System.ComponentModel.DataAnnotations.Schema;

namespace Application.App.Models
{
    public class ApplicationUser 
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string FullName { get; set; }
    }
}
