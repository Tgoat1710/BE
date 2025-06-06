using System;
using System.Collections.Generic;

namespace SchoolHeath.Models;

public partial class UserNotification
{
    public int NotificationId { get; set; }

    public int RecipientId { get; set; }

    public string Title { get; set; } = null!;

    public string Message { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public bool IsRead { get; set; }

    public virtual Account Recipient { get; set; } = null!;
}
