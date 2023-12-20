using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives;

public abstract class Entity<T> 
{
 
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual T Id { get;  set; }

  
}

