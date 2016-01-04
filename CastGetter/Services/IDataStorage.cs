using CastGetter.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastGetter.Services
{
    public interface IDataStorage
    {
        void SaveCast(Podcast p);
        List<Podcast> GetAllCasts();
        Podcast GetCast(string name);
    }
}
