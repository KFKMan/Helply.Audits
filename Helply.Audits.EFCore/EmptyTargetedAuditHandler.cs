using Helply.Audits.Abstractions;

namespace Helply.Audits.EFCore
{
	public class EmptyTargetedAuditHandler : ITargetedAuditHandler
	{
		public static EmptyTargetedAuditHandler True = new EmptyTargetedAuditHandler(true);
		public static EmptyTargetedAuditHandler False = new EmptyTargetedAuditHandler(false);

		public bool ProcessAny { get; private set; } = true;

		public EmptyTargetedAuditHandler(bool processAny)
		{
			ProcessAny = processAny;
		}

		public bool CanProcess(object entry)
		{
			return ProcessAny;
		}

		public void Process(object entry)
		{

		}
	}
}
