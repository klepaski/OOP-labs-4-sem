using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Lab4_5
{
    [DataContract]
    class TitleInfo
    {
        [DataMember]
        public static Queue<string> _lastDocs;
        static TitleInfo() => _lastDocs = new Queue<string>();
        public string FilePath { get; set; }
        public static int NumWindows { get; set; } 
    }
}
