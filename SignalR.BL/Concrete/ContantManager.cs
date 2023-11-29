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
    public class ContantManager : IContantService
    {
        private readonly IContantDal _contantDal;

        public ContantManager(IContantDal contantDal)
        {
            _contantDal = contantDal;
        }

        public void TAdd(Contant entity)
        {
            _contantDal.Add(entity);
        }

        public void TDelete(Contant entity)
        {
            _contantDal.Delete(entity);
        }

        public Contant TGetById(int id)
        {
            return _contantDal.GetById(id);
        }

        public List<Contant> TGetListAll()
        {
            return _contantDal.GetListAll();
        }

        public void TUpdate(Contant entity)
        {
             _contantDal.Update(entity);
        }
    }
}
