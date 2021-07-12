using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace QuartzExtensions
{
    /// <summary>
    /// More details:
    /// </summary>
    public class QuartzOption
    {

        public string ConfigPath { get; set; }

        public NameValueCollection ToProperties()
        {
            var path = $@"{AppDomain.CurrentDomain.BaseDirectory }\{ConfigPath}";
            var properties = new NameValueCollection();

            using (var reader = new StreamReader(path))
            {
                while (reader.Peek() > -1)
                {
                    var line = reader.ReadLine().TrimStart().TrimEnd();
                    if (line.StartsWith("#"))
                    {
                        continue;
                    }
                    var keyValue = line.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    var key = keyValue[0].TrimEnd();
                    var value = keyValue[1].TrimStart();
                    if (value.Contains("#"))
                    {
                        value = value.Split(new[] { "#" }, StringSplitOptions.RemoveEmptyEntries)[0].TrimEnd();
                    }
                    properties.Add(key, value);
                }
            }
                         


            return properties;
        }
    }
}
