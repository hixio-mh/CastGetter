using System;
using System.Collections.Generic;
using CastGetter.Interface;
using System.IO;
using Newtonsoft.Json;

namespace CastGetter.Services
{
    public class JSONDataStorage : IDataStorage
    {
        private const string FILENAME = "database.json";

        List<Podcast> _cache = null;

        bool changed = false;

        public JSONDataStorage()
        {
            if (File.Exists(FILENAME) == false)
            {
                using (File.CreateText(FILENAME))
                {
                    
                }
            }
        }

        public List<Podcast> GetAllCasts()
        {
            if (_cache == null || changed == true)
            {
                string input = ReadFile();
                changed = false;
                _cache = JsonConvert.DeserializeObject<List<Podcast>>(input);
            }
            return _cache;
        }

        public Podcast GetCast(string name)
        {
            if (_cache == null || changed == true)
            {
                GetAllCasts();
            }
            foreach (var cast in _cache)
            {
                if (cast.Name == name)
                {
                    return cast;
                }
            }
            return null;
        }

        public void SaveCast(Podcast p)
        {
            if (_cache == null)
            {
                _cache = new List<Podcast>();
            }
            
            _cache.Add(p);
            using (TextWriter _writer = new StreamWriter(FILENAME))
            {
                string output = JsonConvert.SerializeObject(_cache);
                _writer.Write(output);
            }
        }

        private string ReadFile()
        {
            using (TextReader _reader = new StreamReader(FILENAME))
            {
                return _reader.ReadToEnd();
            }
        }
    }
}
