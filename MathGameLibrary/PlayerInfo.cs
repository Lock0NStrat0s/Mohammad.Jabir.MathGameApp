using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGameLibrary
{
    public class PlayerInfo
    {
        public int Score { get; set; }
        public List<Questions> HistoryOfQuestions { get; set; } = new List<Questions>();
    }
}
