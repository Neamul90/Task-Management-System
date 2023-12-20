using Domain.Enums;
using Domain.Primitives;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class WorkTask : Entity<Guid>
    {
        [ForeignKey("TaskCategories")]
        public int? TaskCategoryId { get; set; }
        public virtual TaskCategory TaskCategories { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        [DefaultValue(Status.Pending)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
    }
}
