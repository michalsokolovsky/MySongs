using MySongs.Common.DTOs;
using MySongs.Repository.Interfaces;
using MySongs.Repository.Entities;
using MySongs.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MySongs.Services.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;

        public TagService(ITagRepository repository)
        {
            _repository = repository;
        }

        public List<TagDto> GetAll()
        {
            return _repository.GetAll()
                .Select(t => new TagDto
                {
                    TagId = t.TagId,
                    TagName = t.TagName,
                    TagType = t.TagType
                }).ToList();
        }

        public void Add(TagDto tag)
        {
            _repository.Add(new Tag { TagName = tag.TagName, TagType = tag.TagType });
        }

        public TagDto GetOrCreate(string tagName)
        {
            var tag = _repository.GetOrCreate(tagName);
            return new TagDto { TagId = tag.TagId, TagName = tag.TagName, TagType = tag.TagType };
        }
    }
}
