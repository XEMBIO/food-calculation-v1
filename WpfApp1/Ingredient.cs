using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace food_calculation
{
    class Ingredient
    {
        private string name;
        private string amount;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Amount
        {
            get => amount;
            set => amount = value;
        }

        public Ingredient(string name, string amount)
        {
            this.name = name;
            this.amount = amount;
        }

        private string splitAmount()
        {
            string[] parts = amount.Split(' ');
            return parts[0];
        }

        public int getAmount(int people)
        {
            int perPerson = int.Parse(splitAmount());

            return perPerson * people;
        }
    }
}
