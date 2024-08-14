using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingFundamentalsProject
{
    internal class Trainer
    {
        public int id;
        public string name;
        public string place;
        public string skill;

        public Trainer(int _id, string _name, string _place, string _skill)
        {
            id = _id;
            name = _name;
            place = _place;
            skill = _skill;
           
        }

        public override string ToString()
        {
            return $"[id={id},name={name},place={place},skill={skill}]";
        }
    }
}
