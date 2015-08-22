using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamenPsicoligico
{
    public class Circle
    {
        public int x=40;
        public int y=40;
        public float radio=9.7f;
        bool selected = false;
        
        public List<Circle> circles =  new List<Circle>();

        public void set_X(int pX)
        {
            x = pX;
        }
        public int getX()
        {
            return x;
        }
        public void set_Y(int pY)
        {
            y= pY;
        }
        public int getY()
        {
            return y;
        }
        public float getRadio()
        {
            return radio; 
        }
        public void setSelected(bool pSelected)
        {
            selected = pSelected;
        }
        public bool getSelected()
        {
            return selected;
        }

    }
}
