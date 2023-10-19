using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Helpers.Printers.Contracts
{
    public interface IPrinter
    {
        void PrintInfo(string message, bool newLine = true);
        void PrintInfo(object obj, bool newLine = true);
        void PrintError(string message, bool newLine = true);
        void PrintError(object obj, bool newLine = true);
    }
}
