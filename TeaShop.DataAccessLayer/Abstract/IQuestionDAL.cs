using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.Abstract
{
    public interface IQuestionDAL : IGenericDAL<Question>
    {
        void ChangeQuestionStatus(int id);
        void ChangeHomeStatus(int id);
        List<Question> GetLast5FrequentlyQuestions();
        List<Question> GetActiveFrequentlyQuestions();
    }
}