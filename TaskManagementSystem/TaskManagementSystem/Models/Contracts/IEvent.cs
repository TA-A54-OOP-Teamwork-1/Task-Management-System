﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models.Contracts
{
    public interface IEvent
    {
        string Message { get; }
        DateTime TimeStamp { get; }
        string ToString();
    }
}
