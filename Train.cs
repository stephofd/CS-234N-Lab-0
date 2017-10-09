using System;
using System.Collections.Generic;
using System.Text;

namespace MTDClasses
{
    public class Train
    {
        protected List<Domino> dominos;
        protected int engineValue;

        public Train()
        {
            dominos = new List<Domino>();
            engineValue = 12;
        }

        public Train(int engValue)
        {
            dominos = new List<Domino>();
            engineValue = engValue;
        }

        public int Count
        { get { return dominos.Count; } }

        public int EngineValue
        {
            get { return engineValue; }
            set { engineValue = value; }
        }

        public bool IsEmpty
        {
            get
            {
                if (dominos.Count == 0)
                    return true;
                else
                    return false;
            }
        }

        public Domino LastDomino
        {
            get
            {
                if (!IsEmpty)
                    return dominos[Count - 1];
                else
                    return null;
            }
        }

        public int PlayableValue
        {
            get
            {
                if (!IsEmpty)
                    return LastDomino.Side2;
                else
                    return EngineValue;
            }
        }

        public Domino this[int index]
        {
            get
            {
                return dominos[index];
            }
        }

        public void Add(Domino d)
        {
            dominos.Add(d);
        }

        public bool IsPlayable(Domino d, out bool mustFlip)
        {
            if (d.Side1 == PlayableValue)
            {
                mustFlip = false;
                return true;
            } else if (d.Side2 == PlayableValue)
            {
                mustFlip = true;
                return true;
            } else
            {
                mustFlip = false;
                return false;
            }

        }

        public void Play(Domino d)
        {
            bool mustFlip;
            if (IsPlayable(d, out mustFlip))
            {
                if (mustFlip)
                {
                    d.Flip();
                    dominos.Add(d);
                }
                else
                    dominos.Add(d);
            }
            else
                throw new Exception("Domino is not playable");
        }

        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < dominos.Count; i++)
                output += dominos[i].ToString() + "\n";
            return output;
        }
    }
}
