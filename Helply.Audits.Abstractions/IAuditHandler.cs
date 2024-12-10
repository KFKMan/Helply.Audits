namespace Helply.Audits.Abstractions
{
	public interface IAuditHandler
	{
		void Handle(object entry);
	}
}
