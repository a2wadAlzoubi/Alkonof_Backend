using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Shared.Contracts.Messaging.Emails;

public sealed record ResponsibleApprovedEmailMessage(string customerEmail , string Subject , string Body , Guid bookingId);
