using MySongs.Common.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MySongs.Repository.Entities
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public string TagName { get; set; }
        public TagType TagType { get; set; } = TagType.General;
        public virtual ICollection<SongTag> SongTags { get; set; }
    }
}
