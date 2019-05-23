using System;
using System.Collections.Generic;
using System.Text;

namespace Photography.Infrastructure.Types
{
    public partial interface IBaseEntity
    {
        int Id { get; set; }
        string Hash { get; set; }
        bool Enabled { get; set; }
        DateTimeOffset Created { get; set; }
        DateTimeOffset? Updated { get; set; }
        DateTimeOffset? Deleted { get; set; }
    }
}
