using System;
using System.ComponentModel.DataAnnotations;

namespace xd.Model
{
    public partial class Field
    {
        [Key]
        public Guid Id { get; set; }
    }
}