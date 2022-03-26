namespace Shooter.LifetimeManagement
{
    public interface ILifetimeManager
    {
        void InitializeAndStart();
        void DisposeAndEnd();
    }
}
