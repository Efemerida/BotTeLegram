using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    internal class Lesson
    {
        private string Time { get; }
        private string Room { get; }
        private string Name { get; }
        private string Type { get; }
        private string Teacher { get; }

        public Lesson(string time, string room, string name, string type, string teacher)
        {
            Time = time;
            Room = room;
            Name = name;
            Type = type;
            Teacher = teacher;
            Time = time;
        }




        public override string ToString()
        {
            return Time + "\n" + Room + "\n" + Name + "\n" + Type + "\n" + Teacher + "\n";
        }
    }
}
