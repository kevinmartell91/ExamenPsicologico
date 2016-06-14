using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamenPsicoligico
{
    public class Circle
    {
        public float x=40;
        public float y=40;
        public float radio=7.7f;
        bool selected = false;
        
        public List<Circle> circles =  new List<Circle>();

        public void set_X(float pX)
        {
            x = pX;
        }
        public float getX()
        {
            return x;
        }
        public void set_Y(float pY)
        {
            y= pY;
        }
        public float getY()
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


        internal void set_X(object p)
        {
            throw new NotImplementedException();
        }
    }
}
