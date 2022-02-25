// cheung kai chun ronald 202670M
using System;
using System.Collections.Generic;

namespace PokemonPocket{
    public class PokemonMaster{
        public string Name {get;set;}
        public int NoToEvolve {get; set;}
        public  string EvolveTo {get; set;}

        public PokemonMaster(string name, int noToEvolve, string evolveTo){
            this.Name = name;
            this.NoToEvolve = noToEvolve;
            this.EvolveTo = evolveTo;
        }
    }
    
    public abstract class Pokemon{
        public string pname {get;set;}
        public int hp {get;set;}
        public int exp {get;set;}
        public string skill;
        public Pokemon(string pname, int hp, int exp){
            this.pname = pname;
            this.hp = hp;
            this.exp = exp;
        }
    }

    public class Pikachu : Pokemon{
        // public string skill {get;set;}
        public Pikachu(string pname , int hp, int exp, string skill) : base(pname , hp, exp){
            this.skill = skill;
        }
    }
  
    public class Eevee : Pokemon{
        // public string skill {get;set;}
        public Eevee(string pname , int hp, int exp, string skill) : base(pname , hp, exp){
            this.skill = skill;
        }
    }

    public class Charmander : Pokemon{
        // public string skill {get;set;}
        public Charmander(string pname , int hp, int exp, string skill) : base(pname , hp, exp){
            this.skill = skill;
        }
    }  
}