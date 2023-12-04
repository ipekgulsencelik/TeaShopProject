using TeaShop.BusinessLayer.Abstract;
using TeaShop.DataAccessLayer.Abstract;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Concrete
{
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionDAL _questionDAL;

        public QuestionManager(IQuestionDAL questionDAL)
        {
            _questionDAL = questionDAL;
        }

        public void TChangeHomeStatus(int id)
        {
            _questionDAL.ChangeHomeStatus(id);
        }

        public void TChangeQuestionStatus(int id)
        {
            _questionDAL.ChangeQuestionStatus(id);
        }

        public void TDelete(Question entity)
        {
            _questionDAL.Delete(entity);
        }

        public List<Question> TGetActiveFrequentlyQuestions()
        {
            return _questionDAL.GetActiveFrequentlyQuestions();
        }

        public Question TGetByID(int id)
        {
            return _questionDAL.GetByID(id);
        }

        public List<Question> TGetLast5FrequentlyQuestions()
        {
            return _questionDAL.GetLast5FrequentlyQuestions();
        }

        public List<Question> TGetListAll()
        {
            return _questionDAL.GetListAll();
        }

        public void TInsert(Question entity)
        {
            _questionDAL.Insert(entity);
        }

        public void TUpdate(Question entity)
        {
            _questionDAL.Update(entity);
        }
    }
}