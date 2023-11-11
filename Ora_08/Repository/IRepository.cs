﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora_08.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
