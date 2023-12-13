using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendServices.Repository
{
    public interface IAccount
    {
        Task Register(string username, string password);
        Task<string> Login(string username, string password);
    }
}