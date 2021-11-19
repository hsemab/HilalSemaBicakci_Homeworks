using System;
using System.Collections.Generic;
using System.Text;

namespace MyFruitProject
{
    class Food
    {
        //Private
        private string _type = "";
        private string _name = "";
        private string _color = "";
        private int _piece = 0;

        //Public
        public string Type { get { return _type; }  }
        public string Name { get { return _name; } set { _name = value; } }
        public string Color { get { return _color; } set { _color = value; } }
        public int Piece { get { return _piece; } set { _piece = value; } }

        // Constructor
        public Food(string foodType, string foodName, string foodColor, int foodPiece)
        {
            _type = foodType;
            _name = foodName;
            _color = foodColor;
            _piece = foodPiece;
        }
    }
}
