using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movec
{
    class MouseMoveController
    {
        // Features Of Mouse
        public bool isMove { get; set; }
        private int moveX;
        private int moveY;

        public void mousedDown(object sender, MouseEventArgs e, int locationX, int locationY)
        {
            // isMove is true when the mouse is pressed.
            this.isMove = true;
            this.moveX = e.X;
            this.moveY = e.Y;
            if (sender is Panel)
            {
                this.moveX += locationX;
                this.moveY += locationY;
            }
        }

        public int getMoveX
        {
            get
            {
                return moveX;
            }
        }

        public int getMoveY
        {
            get
            {
                return moveY;
            }
        }
    }
}
