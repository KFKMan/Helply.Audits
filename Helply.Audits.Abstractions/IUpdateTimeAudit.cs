namespace Helply.Audits.Abstractions
{
	public interface IUpdateTimeAudit<T>
	{
		public T UpdatedAt { get; set; }
	}
}
