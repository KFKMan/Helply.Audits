using Helply.Audits.Abstractions;

namespace Helply.Audits.EFCore
{
	public class DefaultAddHandler : IAuditHandler
	{
		public virtual void Process(object entry)
		{
			if(entry is ICreateTimeAudit<DateTime> auditDT)
			{
				auditDT.CreatedAt = DateTime.Now;
			}
			else if(entry is ICreateTimeAudit<DateTimeOffset> auditDTO)
			{
				auditDTO.CreatedAt = DateTimeOffset.Now;
			}
		}
	}
}
