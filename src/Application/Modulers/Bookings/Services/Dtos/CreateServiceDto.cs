using System;
using System.Collections.Generic;
using System.Text;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;

namespace Alkonof_Backend.Application.Modulers.Bookings.Services.Dtos;

public class CreateServiceDto
{
    public string ServiceName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ServiceType ServiceType { get; set; }
}
