using Helply.Audits.Abstractions;

namespace Helply.Audits.EFCore
{
	public class DefaultModifyHandler : IAuditHandler
	{
		public virtual void Process(object entry)
		{
			if (entry is IUpdateTimeAudit<DateTime> auditDT)
			{
				auditDT.UpdatedAt = DateTime.Now;
			}
			else if (entry is IUpdateTimeAudit<DateTimeOffset> auditDTO)
			{
				auditDTO.UpdatedAt = DateTimeOffset.Now;
			}
		}
	}
}
