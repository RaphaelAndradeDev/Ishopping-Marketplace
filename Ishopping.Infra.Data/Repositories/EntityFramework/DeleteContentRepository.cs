using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Infra.Data.Contexto;
using System.Linq;

namespace Ishopping.Infra.Data.Repositories
{
    public class DeleteContentRepository : IDeleteContentRepository
    {
        protected IshoppingContext db = new IshoppingContext();
        
        public void DeleteContent(string userId)
        {
            var contentButton = db.ContentButton.Where(x => x.IdUser == userId).ToList();
            db.ContentButton.RemoveRange(contentButton);

            var contentIcon = db.ContentIcon.Where(x => x.IdUser == userId).ToList();
            db.ContentIcon.RemoveRange(contentIcon);

            var contentList = db.ContentList.Where(x => x.IdUser == userId).ToList();
            db.ContentList.RemoveRange(contentList);

            var contentText = db.ContentText.Where(x => x.IdUser == userId).ToList();
            db.ContentText.RemoveRange(contentText);

            var contentVideo = db.ContentVideo.Where(x => x.IdUser == userId).ToList();
            db.ContentVideo.RemoveRange(contentVideo);

            // Options
            var contentButtonOption = db.ContentButtonOption.Where(x => x.IdUser == userId).ToList();
            db.ContentButtonOption.RemoveRange(contentButtonOption);

            var contentListOption = db.ContentListOption.Where(x => x.IdUser == userId).ToList();
            db.ContentListOption.RemoveRange(contentListOption);

            var contentTextOption = db.ContentTextOption.Where(x => x.IdUser == userId).ToList();
            db.ContentTextOption.RemoveRange(contentTextOption);

            db.SaveChanges();
        }
    }
}
