using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class Permission : BaseAuditableEntity
{
    private Permission()
    {
        
    }
    private Permission(Guid id, string name, string code, string description)
    {
        Id = id;
        Name = name;
        Code = code;
        Description = description;
    }

    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

}
