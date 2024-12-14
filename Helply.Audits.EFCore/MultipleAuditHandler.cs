using Helply.Audits.Abstractions;

namespace Helply.Audits.EFCore
{
	public class MultipleAuditHandler : IAuditHandler
	{
		private List<ITargetedAuditHandler> Handlers = new List<ITargetedAuditHandler>();
		private MultipleHandlerProcessType ProcessType;

		public MultipleAuditHandler(List<ITargetedAuditHandler> handlers, MultipleHandlerProcessType processType = MultipleHandlerProcessType.One)
		{
			Handlers = handlers;
			ProcessType = processType;
		}

		public void AddHandler(ITargetedAuditHandler handler)
		{
			Handlers.Add(handler);
		}

		public bool RemoveHandler(ITargetedAuditHandler handler)
		{
			return Handlers.Remove(handler);
		}

		public bool ContainsHandler(ITargetedAuditHandler handler)
		{
			return Handlers.Contains(handler);
		}

		public void Process(object entry)
		{
			var query = Handlers.Where(x => x.CanProcess(entry));
			if(ProcessType == MultipleHandlerProcessType.One)
			{
				var handler = query.FirstOrDefault(defaultValue: EmptyTargetedAuditHandler.True);
				handler.Process(entry);
			}
			else
			{
				foreach (var handler in query)
				{
					handler.Process(entry);
				}
			}
		}
	}
}
