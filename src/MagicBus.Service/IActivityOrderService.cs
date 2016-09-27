namespace MagicBus.Service
{
    public interface IActivityOrderService
    {
        void OrderUp(int activityId);
        void OrderDown(int activityId);
    }
}