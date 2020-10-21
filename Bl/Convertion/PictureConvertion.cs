using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;
namespace Bl.Convertion
{
    public class PictureConvertion
    {
         public static PictureDto ConvertToDto(Picture picture)
        {
            PictureDto newPicture = new PictureDto();
            newPicture.Id = picture.Id;
            newPicture.Name = picture.Name;
            newPicture.EventId = picture.EventId;
            newPicture.Image = picture.Image;
            return newPicture;
        }
        public static Picture ConvertToPicture(PictureDto picture)
        {
            Picture newPicture = new Picture();
            newPicture.Id = picture.Id;
            newPicture.Name = picture.Name;
            newPicture.EventId = picture.EventId;
            newPicture.Image = picture.Image;
            return newPicture;
        }
        public static List<PictureDto> ConvertToDtoList(List<Picture> p)
        {
            List<PictureDto> newPicture = new List<PictureDto>();
            p.ForEach(x =>
            {
                newPicture.Add(ConvertToDto(x));
            });
            return newPicture;
        }
        public static List<Picture> convertToListPicture(List<PictureDto> p)
        {
            List<Picture> newPicture = new List<Picture>();
            p.ForEach(x =>
            {
                newPicture.Add(ConvertToPicture(x));
            });
            return newPicture;
        }
    }
}
