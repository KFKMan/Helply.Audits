namespace Helply.Audits.Abstractions
{
	public interface IAuditHandler
	{
		void Process(object entry);
	}
}
