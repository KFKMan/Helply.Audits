namespace Helply.Audits.Abstractions
{
	public interface IUpdateAudit<T>
	{
		public T UpdatedBy { get; set; }
	}
}
