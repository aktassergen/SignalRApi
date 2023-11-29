using SignalR.BL.Abstract;
using SignalR.DAL.Abstract;
using SignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BL.Concrete
{
    public class SosialMediaManager : ISosialMediaService
    {
        private readonly ISosialMediaDal _sosialMediaDal;

        public SosialMediaManager(ISosialMediaDal sosialMediaDal)
        {
            _sosialMediaDal = sosialMediaDal;
        }

        public void TAdd(SosialMedia entity)
        {
            _sosialMediaDal.Add(entity);
        }

        public void TDelete(SosialMedia entity)
        {
            _sosialMediaDal.Delete(entity);
        }

        public SosialMedia TGetById(int id)
        {
            return _sosialMediaDal.GetById(id);
        }

        public List<SosialMedia> TGetListAll()
        {
            return _sosialMediaDal.GetListAll();
        }

        public void TUpdate(SosialMedia entity)
        {
            _sosialMediaDal.Update(entity);
        }
    }
}
