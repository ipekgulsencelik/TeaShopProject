using TeaShop.DataAccessLayer.Abstract;
using TeaShop.DataAccessLayer.Concrete;
using TeaShop.DataAccessLayer.Repository;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.EntityFramework
{
    public class EFMapDAL : GenericRepository<Map>, IMapDAL
    {
        public EFMapDAL(TeaContext context) : base(context)
        {
        }

        public void ChangeMapStatus(int id)
        {
            var context = new TeaContext();
            var map = context.Maps.Where(x => x.MapID == id).FirstOrDefault();
            if (map.MapStatus == true)
            {
                map.MapStatus = false;
            }
            else
            {
                map.MapStatus = true;
            }
            context.Update(map);
            context.SaveChanges();
        }

        public Map GetActiveMap()
        {
            var context = new TeaContext();
            var values = context.Maps.Where(x => x.MapStatus == true).OrderByDescending(x => x.MapID).Take(1);
            return (Map)values;
        }
    }
}