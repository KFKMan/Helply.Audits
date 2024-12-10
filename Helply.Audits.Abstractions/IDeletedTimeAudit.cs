namespace Helply.Audits.Abstractions
{
	public interface IDeletedTimeAudit<T> : ISoftDelete
	{
		public T? DeletedAt { get; set; }
	}
}
