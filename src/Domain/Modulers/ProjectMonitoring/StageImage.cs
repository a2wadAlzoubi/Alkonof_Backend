using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alkonof_Backend.Domain.Entities.ProjectMonitoring;

public class StageImage : BaseAuditableEntity
{
    public StageImage(Guid id ,string fileName, string filePath, string description, Guid stageId)
    {
        Id = id;
        FileName = fileName;
        FilePath = filePath;
        Description = description;
        StageId = stageId;
    }
    [Required]
    public string FileName { get; private set; } = string.Empty;
    [Required]
    public string FilePath { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    // Relations
    public Stage? Stage { get; private set; }
    [Required]
    public Guid StageId { get; private set; }

    public static StageImage CreateStageImage(string fileName, string filePath, string description, Guid stageId)
    {
        return new StageImage(Guid.NewGuid() , fileName, filePath, description, stageId);
    }
    public void UpdateStageImage(string fileName, string filePath, string description, Guid stageId)
    {
        FileName = fileName;
        FilePath = filePath;
        Description = description;
        StageId = stageId;
    }
}
