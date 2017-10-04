using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTDClasses;

namespace MTDUnitTests
{
    public class BoneYard
    {
        private List<Domino> listOfDominos;

        public BoneYard(int maxDots)
        {
            listOfDominos = new List<Domino>();

            for (int s1 = 0; s1 <= maxDots; s1++)
            {
                for (int s2 = 0; s2 <= maxDots; s2++)
                {
                    listOfDominos.Add(new Domino(s1, s2));
                }
            }
        }

        public void Shuffle()
        {
            Random generator = new Random();
			for (int i = 0; i < this.DominosRemaining; i++)
            {
                int random = generator.Next(0, 91);
                Domino temp = listOfDominos[i];
                listOfDominos[i] = listOfDominos[random];
                listOfDominos[random] = temp;
            }
        }

        public bool IsEmpty()
        {
            if (listOfDominos.Count == 0)
                return true;
            else
                return false;
        }

        public int DominosRemaining
        {
            get
            {
                return listOfDominos.Count;
            }
        }

        public Domino Draw()
        {
            if (!IsEmpty())
            {
                Domino top = listOfDominos[0];
                listOfDominos.RemoveAt(0);
                return top;
            }
            else
                throw new Exception("Bone Yard is empty");
        }

        public Domino this[int index]
        {
            get
            {
                return listOfDominos[index];
            }
        }

        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < listOfDominos.Count; i++)
                output += listOfDominos[i].ToString() + "\n";
            return output;
        }
    }
}
