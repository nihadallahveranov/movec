using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movec
{
    class FormControlImages
    {
        Constants constants = new Constants();

        public void defaultImages(System.Windows.Forms.PictureBox minimize_img, System.Windows.Forms.PictureBox close_img, System.Windows.Forms.PictureBox maximize_img)
        {
            /*** minimize_img ***/
            minimize_img.Image = Image.FromFile(constants.kYellowCircleButtonImgPath);
            minimize_img.BackColor = Colors.darkModeColor;

            /*** close_img ***/
            close_img.BackColor = Colors.darkModeColor;
            close_img.Image = Image.FromFile(constants.kRedCircleButtonImgPath);

            /*** maximize_img ***/
            if (!(maximize_img is null))
            {
                maximize_img.BackColor = Colors.darkModeColor;
                maximize_img.Image = Image.FromFile(constants.kGreenCircleButtonImgPath);
            }
        }

        public void closeImageMouseHoverEvent(System.Windows.Forms.PictureBox close_img)
        {
            close_img.Image = Image.FromFile(constants.kCloseButtonImgPath);
        }

        public void closeImageMouseLeaveEvent(System.Windows.Forms.PictureBox close_img)
        {
            close_img.Image = Image.FromFile(constants.kRedCircleButtonImgPath);
        }

        public void minimizeImageMouseHoverEvent(System.Windows.Forms.PictureBox minimize_img)
        {
            minimize_img.Image = Image.FromFile(constants.kMinimizeButtonImgPath);
        }

        public void minimizeImageMouseLeaveEvent(System.Windows.Forms.PictureBox minimize_img)
        {
            minimize_img.Image = Image.FromFile(constants.kYellowCircleButtonImgPath);
        }

        public void maximizeImageMouseHoverEvent(System.Windows.Forms.PictureBox maximize_img)
        {
            maximize_img.Image = Image.FromFile(constants.kMaximizeButtonImgPath);
        }

        public void maximizeImageMouseLeaveEvent(System.Windows.Forms.PictureBox maximize_img)
        {
            maximize_img.Image = Image.FromFile(constants.kGreenCircleButtonImgPath);
        }
    }
}
