using BulkyBookModels.Model;

namespace BulkyBookDataAccess.Repositray.IRepositray
{
    public interface FeedbackInterface : IRepositray<Feedback>
    {
        void Update(Feedback FeedbackObj);
    }
}