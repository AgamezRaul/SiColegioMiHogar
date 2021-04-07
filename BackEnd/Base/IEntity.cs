using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Base
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
