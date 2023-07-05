using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExam.Logic
{
    public enum TypeUserEnum
    {
        None,
        Manager,
        Client,
        Admin,
        Gues,
    }

    static class UserInfo
    {
        public static int id { get; set; }
        public static TypeUserEnum type { get; set; }
    }
}
