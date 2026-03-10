using MySongs.Common.DTOs;
using System.Collections.Generic;

namespace MySongs.Services.Interfaces
{
    public interface ITagService
    {
        List<TagDto> GetAll();
        void Add(TagDto tag);
    }
}