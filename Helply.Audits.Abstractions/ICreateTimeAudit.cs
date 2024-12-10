namespace Helply.Audits.Abstractions
{
	public interface ICreateTimeAudit<T>
	{
		public T CreatedAt { get; set; }
	}
}
