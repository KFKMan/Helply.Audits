using Helply.Audits.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Helply.Audits.EFCore
{
	/// <summary>
	///     This class is used to intercept the save changes and apply the audit trail to the entities.
	/// </summary>
	public class AuditingSaveChangesInterceptor : SaveChangesInterceptor
	{
		private IAuditHandler AddHandler;
		private IAuditHandler DeleteHandler;
		private IAuditHandler ModifyHandler;

		public AuditingSaveChangesInterceptor(IAuditHandler addHandler, IAuditHandler deleteHandler, IAuditHandler modifyHandler)
		{
			AddHandler = addHandler;
			DeleteHandler = deleteHandler;
			ModifyHandler = modifyHandler;
		}

		/// <summary>
		///     This method is used to apply audit trail to the entities.
		/// </summary>
		/// <param name="eventData"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
		{
			if (eventData.Context != null)
			{
				ApplyAuditTrail(eventData.Context);
			}
			return base.SavingChanges(eventData, result);
		}

		/// <summary>
		///     This method is used to apply audit trail to the entities.
		/// </summary>
		/// <param name="eventData"></param>
		/// <param name="result"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
			DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
		{
			if (eventData.Context != null)
			{
				ApplyAuditTrail(eventData.Context);
			}
			return base.SavingChangesAsync(eventData, result, cancellationToken);
		}

		/// <summary>
		///     This method is used to apply audit trail to the entities.
		/// </summary>
		/// <param name="context"></param>
		private void ApplyAuditTrail(DbContext context)
		{
			var entries = context.ChangeTracker.Entries();

			foreach (var entry in entries)
			{
				switch (entry.State)
				{
					case EntityState.Deleted:
						DeleteHandler.Process(entry.Entity);
						break;
					case EntityState.Added:
						AddHandler.Process(entry.Entity);
						break;
					case EntityState.Modified:
						ModifyHandler.Process(entry.Entity);
						break;
				}
			}
		}
	}
}
