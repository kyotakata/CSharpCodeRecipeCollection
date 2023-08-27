using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeRecipeCollection
{
    public class MonsterManager
    {
        private List<Monster> _monsterList = new List<Monster>();

        public MonsterManager()
        {
            _monsterList.Add(new Monster("くっぱ"));
            _monsterList.Add(new Monster("すらいむ"));
            _monsterList.Add(new Monster("とろーる"));
        }    

        public Monster this[int index]
        {
            get
            {
                return _monsterList[index];
            }
            //set
            //{
            //    _monsterList.Add(value);
            //}
        }

        public void Add(string name)
        {
            _monsterList.Add(new Monster(name));
        }
    }

    public class Monster
    {
        public Monster(string name)
        {
            Name = name;
        }

        public int Hp { get; set; }
        public int Atk { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return "Monster:" + Name;
        }

    }
}
