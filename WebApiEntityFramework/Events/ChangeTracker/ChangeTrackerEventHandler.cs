using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApiEntityFramework.Data;

namespace WebApiEntityFramework.Events.ChangeTracker
{
    public class ChangeTrackerEventHandler: IChangeTrackerEvent
    {
        private ILogger<ChangeTrackerEventHandler> _logger;

        public ChangeTrackerEventHandler(ILogger<ChangeTrackerEventHandler> logger)
        {
            _logger = logger;
        }

        public void Tracked(object sender,EntityTrackedEventArgs args)
        {
            var message = $"{args.Entry.Entity.GetType().Name} has Being Tracked";
            _logger.LogInformation(message);
        }

        public void StateChanged(object sender,EntityStateChangedEventArgs args)
        {
            var message = $"{args.Entry.Entity.GetType().Name} State Is Changed From {args.OldState} To {args.NewState}";
            _logger.LogInformation(message);
        }

        public void SavingChanges(object sender,SavingChangesEventArgs args)
        {
            var entries = ((ApplicationDbContext)sender).ChangeTracker.Entries();
            foreach(var entry in entries)
            {
                var message = $"{entry.Entity.GetType().Name} is going to be {entry.State}";
                _logger.LogInformation(message);
            }
        }

        public void SavedChanges(object sender,SavedChangesEventArgs args)
        {
            var message = "Changes are saved successfully";
            _logger.LogInformation(message);
        }

        public void SaveChangesFailed(object sender,SaveChangesFailedEventArgs args)
        {
            var message = "failed to save changes";
            _logger.LogError(args.Exception,message);
        }
    }
}
