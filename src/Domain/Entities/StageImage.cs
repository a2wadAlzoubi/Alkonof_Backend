using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class StageImage : BaseAuditableEntity
{
    public StageImage(string fileName, string filePath, string description, Guid stageId)
    {
        FileName = fileName;
        FilePath = filePath;
        Description = description;
        StageId = stageId;
    }

    public string FileName { get; private set; } = string.Empty;
    public string FilePath { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    // Relations
    public Stage? Stage { get; private set; }
    public Guid StageId { get; private set; }
}
