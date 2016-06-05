namespace TDiary
{
    public interface IActivityOrderService
    {
        void OrderUp(int activityId);
        void OrdrDown(int activityId);   
    }
}