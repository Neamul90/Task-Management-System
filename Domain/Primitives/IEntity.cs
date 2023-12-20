using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    public interface IEntity
    {
        object Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }

    }

    public interface IEntity<T> : IEntity
    {
        new T Id { get; set; }
    }
}
