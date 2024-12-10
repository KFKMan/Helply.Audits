namespace Helply.Audits.Abstractions
{
	public interface ICreateAudit<T>
	{
		public T CreatedBy { get; set; }
	}
}
