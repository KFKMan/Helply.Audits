namespace Helply.Audits.Abstractions
{
	public interface ITargetedAuditHandler
	{
		bool CanProcess(object entry);
		void Process(object entry);
	}
}
