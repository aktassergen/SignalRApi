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
	public class MessageManeager : IMessageService
	{
		private readonly IMessageDal _messageDal;

		public MessageManeager(IMessageDal messageDal)
		{
			_messageDal = messageDal;
		}

		public void TAdd(Message entity)
		{
			_messageDal.Add(entity);
		}

		public void TDelete(Message entity)
		{
			_messageDal.Delete(entity);
		}

		public Message TGetById(int id)
		{
			return _messageDal.GetById(id);
		}

		public List<Message> TGetListAll()
		{
			return _messageDal.GetListAll();
		}

		public void TUpdate(Message entity)
		{
			_messageDal.Update(entity);
		}
	}
}
