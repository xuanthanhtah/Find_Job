//using FindJobSolution.Data.EF;
//using FindJobSolution.Data.Entities;
//using FindJobSolution.ViewModels.Catalog.ApplyJob;
//using FindJobSolution.ViewModels.Catalog.Message;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FindJobSolution.Application.Catalog
//{
//    public interface IMessageService
//    {
//        Task<List<MessageModel>> GetbyUserId(Guid UserId);

//        Task<bool> Create(Guid userId, MessageCreateRequest request);
//    }

//    public class MessageService : IMessageService
//    {
//        private readonly FindJobDBContext _context;

//        public MessageService(FindJobDBContext context)
//        {
//            _context = context;
//        }

//        public async Task<bool> Create(Guid userId, MessageCreateRequest request)
//        {
//            var userid = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
//            if (userid == null) return false;
//            var message = new Message()
//            {
//                userName = userid.UserName,
//                userId = userId,
//                text = request.text,
//                date = DateTime.Now,
//            };

//            _context.Messages.Add(message);

//            await _context.SaveChangesAsync();

//            return true;
//        }

//        public async Task<List<MessageModel>> GetbyUserId(Guid UserId)
//        {
//            //get message by user id
//            var userId = await _context.Messages.FirstAsync(x => x.userId == UserId);
//            if (userId == null) { return null; }
//            //get message b
//            var query = from j in _context.Messages
//                        where j.userId == UserId
//                        select new { j };

//            return await query
//               .Select(p => new MessageModel()
//               {
//                   id = p.j.id,
//                   userId = p.j.userId,
//                   userName = p.j.userName,
//                   text = p.j.text,
//                   time = p.j.date,
//               }).ToListAsync();
//        }
//    }
//}