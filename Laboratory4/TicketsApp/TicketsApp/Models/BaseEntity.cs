using System.ComponentModel.DataAnnotations;

namespace TicketsApp.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
