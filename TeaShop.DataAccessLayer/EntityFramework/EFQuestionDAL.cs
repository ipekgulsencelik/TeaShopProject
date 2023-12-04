using TeaShop.DataAccessLayer.Abstract;
using TeaShop.DataAccessLayer.Concrete;
using TeaShop.DataAccessLayer.Repository;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.EntityFramework
{
    public class EFQuestionDAL : GenericRepository<Question>, IQuestionDAL
    {
        public EFQuestionDAL(TeaContext context) : base(context)
        {
        }

        public void ChangeHomeStatus(int id)
        {
            var context = new TeaContext();
            var question = context.Questions.Where(x => x.QuestionID == id).FirstOrDefault();
            if (question.IsHome == true)
            {
                question.IsHome = false;
            }
            else
            {
                question.IsHome = true;
            }
            context.Update(question);
            context.SaveChanges();
        }

        public void ChangeQuestionStatus(int id)
        {
            var context = new TeaContext();
            var question = context.Questions.Where(x => x.QuestionID == id).FirstOrDefault();
            if (question.QuestionStatus == true)
            {
                question.QuestionStatus = false;
            }
            else
            {
                question.QuestionStatus = true;
            }
            context.Update(question);
            context.SaveChanges();
        }

        public List<Question> GetActiveFrequentlyQuestions()
        {
            var context = new TeaContext();
            var values = context.Questions.Where(x => x.QuestionStatus == true).ToList();
            return values;
        }

        public List<Question> GetLast5FrequentlyQuestions()
        {
            var context = new TeaContext();
            var questionCount = context.Questions.Where(x => x.QuestionStatus == true && x.IsHome == true).Count();
            var values = context.Questions.Where(x => x.QuestionStatus == true && x.IsHome == true).ToList();
            if (questionCount <= 5)
            {
                values = context.Questions.Where(x => x.QuestionStatus == true && x.IsHome == true).OrderByDescending(x => x.QuestionID).ToList();
            }
            else
            {
                values = context.Questions.Where(x => x.QuestionStatus == true && x.IsHome == true).OrderByDescending(x => x.QuestionID).Take(5).ToList();
            }
            return values;
        }
    }
}