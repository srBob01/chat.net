﻿using System.ComponentModel.DataAnnotations;

namespace Chat.DataAccess.Entities;

public class BaseEntity
{    
    public int Id { get; set; } //ключ в бд

    public Guid ExternalId { get; set; } // unique index - unique optional
    public DateTime ModificationTime { get; set; } // optional
    public DateTime CreationTime { get; set; } //optional 
}