using System;
using System.Collections.Generic;

namespace SchoolHeath.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? LastLogin { get; set; }

    public virtual Manager? Manager { get; set; }

    public virtual ICollection<MedicalEvent> MedicalEvents { get; set; } = new List<MedicalEvent>();

    public virtual ICollection<MedicationRequest> MedicationRequests { get; set; } = new List<MedicationRequest>();

    public virtual Parent? Parent { get; set; }

    public virtual SchoolNurse? SchoolNurse { get; set; }

    public virtual ICollection<UserNotification> UserNotifications { get; set; } = new List<UserNotification>();
}
