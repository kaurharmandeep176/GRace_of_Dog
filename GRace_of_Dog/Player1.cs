using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRace_of_Dog
{
   public class Player1
    {
        // global variable with the access specifier 
        public String Name { get; set; }
        public int Dog { get; set; }
        public int Bet { get; set; }
        public int Amount { get; set; }

        // this constructor is used to pass the value from local to global 
        public Player1(String Name,int Dog,int Bet,int Amount) {
            this.Name = Name;
            this.Dog = Dog;
            this.Bet = Bet;
            this.Amount = Amount;
        }

        //this code is used to check the bet if the player does not the amount as much as he try to set the bet then generate the error message 
        public int check() {
            if (Bet <= Amount)
            {
                return 1;
            }
            else {
                return 0;
            }

        }




    }
}
