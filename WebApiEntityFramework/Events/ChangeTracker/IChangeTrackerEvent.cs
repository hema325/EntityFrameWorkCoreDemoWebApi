using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebApiEntityFramework.Events.ChangeTracker
{
    public interface IChangeTrackerEvent
    {
        void Tracked(object sender, EntityTrackedEventArgs args);
        void StateChanged(object sender, EntityStateChangedEventArgs args);
        void SavedChanges(object sender, SavedChangesEventArgs args);
        void SaveChangesFailed(object sender, SaveChangesFailedEventArgs args);
        void SavingChanges(object sender, SavingChangesEventArgs args);
    }
}
