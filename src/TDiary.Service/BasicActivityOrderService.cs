using System.Linq;
using TDiary.Model;
using TDiary.Repository;

namespace TDiary.Service
{
    public class BasicActivityOrderService : IActivityOrderService
    {
        private readonly DiaryContext _context;

        public BasicActivityOrderService(DiaryContext context)
        {
            _context = context;
        }

        public void OrderUp(int activityId)
        {
            var itemToMove = GetItemToMove(activityId);
            var itemToSwitch = GetItemToSwitch(itemToMove, SwitchDirection.Up);

            SwitchDates(itemToMove, itemToSwitch);
        }

        public void OrderDown(int activityId)
        {
            var itemToMove = GetItemToMove(activityId);
            var itemToSwitch = GetItemToSwitch(itemToMove, SwitchDirection.Down);

            SwitchDates(itemToMove, itemToSwitch);
        }

        private void SwitchDates(Experience item1, Experience item2)
        {
            if (item1 != null && item2 != null)
            {
                var memento = item1.SavePosition;
                item1.MovePositionTo(item2.SavePosition);
                item2.MovePositionTo(memento);
                _context.AttachRange(item1, item2);
                _context.SaveChanges();
            }
        }

        private Experience GetItemToMove(int activityId)
        {
            return _context.Experiences.Where(e => e.Id == activityId).Single();
        }

        private Experience GetItemToSwitch(Experience itemToMove, SwitchDirection direction)
        {
            if (direction == SwitchDirection.Down)
                return _context.Experiences
                   .Where(e => e.Date.Date == itemToMove.Date.Date && e.SavePosition < itemToMove.SavePosition)
                   .OrderByDescending(e => e.SavePosition).FirstOrDefault();

            return _context.Experiences
                .Where(e => e.Date.Date == itemToMove.Date.Date && e.SavePosition > itemToMove.SavePosition)
                .OrderBy(e => e.SavePosition).FirstOrDefault();
        }

        private enum SwitchDirection
        {
            Up,
            Down
        }
    }
}