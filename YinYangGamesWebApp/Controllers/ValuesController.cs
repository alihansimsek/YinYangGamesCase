using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YinYangGamesWebApp.Models;

namespace YinYangGamesWebApp.Controllers
{
    public class ValuesController : ApiController
    {

        // GET api/values/5
        public string Get(int id)
        {
            string[] lines = File.ReadAllLines("D:/player.txt");
            foreach (string line in lines)
            {
                if (line.Contains(id.ToString()))
                {
                    return line;
                }
            }
            return "ID unknown";
        }

        // POST api/values
        public void Post([FromBody] Player value)
        {
            File.AppendAllText("D:/player.txt", Environment.NewLine + Newtonsoft.Json.JsonConvert.SerializeObject(value));
        }

    }
}
