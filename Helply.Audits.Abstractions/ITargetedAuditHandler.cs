namespace Helply.Audits.Abstractions
{
	public interface ITargetedAuditHandler : IAuditHandler
	{
		/// <summary>
		/// With that we can Process method we can skip checks for same object type,
		/// Also we can create process count mechanism like process with any processable and break
		/// </summary>
		/// <param name="entry"></param>
		/// <returns></returns>
		bool CanProcess(object entry);
	}
}
