﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Infrastructure.Interface
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetDbConnection();
    }
}
