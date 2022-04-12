using System;

namespace appointment_sys_api.Infrastructure.Interfaces;

public interface IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
}