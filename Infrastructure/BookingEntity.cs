using System;
using appointment_sys_api.Infrastructure.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appointment_sys_api.Infrastructure
{
    [Table("bookings")]
    public class BookingEntity : IEntity
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set;}
    }
}