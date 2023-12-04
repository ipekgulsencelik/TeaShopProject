using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Abstract
{
    public interface IQuestionService : IGenericService<Question>
    {
        void TChangeQuestionStatus(int id);
        void TChangeHomeStatus(int id);
        List<Question> TGetLast5FrequentlyQuestions();
        List<Question> TGetActiveFrequentlyQuestions();
    }
}