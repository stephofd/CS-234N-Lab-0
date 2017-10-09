using System;
using System.Collections.Generic;
using System.Text;

namespace MTDClasses
{
    public class PrivateTrain : Train
    {
        Hand hand;
        bool isOpen;

        public bool IsOpen
        { get { return isOpen; } }

        public PrivateTrain(int engValue, Hand h)
        {
            hand = h;
            isOpen = false;
            engineValue = engValue;
        }

        public void Close()
        {
            isOpen = false;
        }

        public void Open()
        {
            isOpen = true;
        }

        public bool IsPlayable(Domino d, out bool mustFlip, Hand h)
        {
            mustFlip = false;
            if (h == hand)
            {
                if (d.Side1 == PlayableValue)
                {
                    return true;
                }
                else if (d.Side2 == PlayableValue)
                {
                    mustFlip = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;

        }

        public void Play(Domino d, Hand h)
        {
            bool mustFlip;
            if (IsPlayable(d, out mustFlip, h))
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
    }
}
