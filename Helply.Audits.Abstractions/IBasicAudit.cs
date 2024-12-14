namespace Helply.Audits.Abstractions
{
	public interface IBasicAudit<T> : ICreateAudit<T>, ICreateTimeAudit<T>, IUpdateAudit<T>, IUpdateTimeAudit<T>
	{

	}

	public interface IBasicAudit : IBasicAudit<DateTimeOffset>
	{

	}
}
