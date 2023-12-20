using Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Task.Queries.GetTaskById
{
    public class GetTaskViewModel
    {
        public Guid Id { get; set; }
        public int? TaskCategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
    }
}
