using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace LvvlStarterNetApi.SharedKernel.Interfaces
{
    public interface IComment
    {
        string Author { get; set; }
        string Text { get; set; }
    }
}
