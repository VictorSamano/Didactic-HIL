using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace prueba
{
    class Animation
    {
        private int ellipsePosX = 0, ellipsePosY = 0;
        private int lineStartXM1 = 200, lineEndXM1 = 450, lineStartYM1 = 190, lineEndYM1 = 190;
        private int lineStartX = 450, lineStartY = 190, lineEndX = 700, lineEndY = 190;
        private int lineEndX2 = 200, lineEndY2 = 170, lineEndX3 = 700, lineEndY3 = 170;
        private int lineLength = 250, lineLength2 = 25;
        private int Lx = 0, Ly = 0;

        public void DibujarComponentes(Graphics papel)
        {
            papel.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen lapiz1 = new Pen(Color.WhiteSmoke))
            {
                papel.DrawEllipse(lapiz1, ellipsePosX - 2, ellipsePosY - 26, 25, 25);
                papel.DrawLine(lapiz1, lineStartX, lineStartY, lineEndX, lineEndY);
                papel.DrawLine(lapiz1, lineStartXM1, lineStartYM1, lineEndXM1, lineEndYM1);
                papel.DrawLine(lapiz1, lineStartXM1, lineStartYM1, lineEndX2, lineEndY2);
                papel.DrawLine(lapiz1, lineEndX, lineEndY, lineEndX3, lineEndY3);
                papel.DrawLine(lapiz1, 450, 190, 430, 250);
                papel.DrawLine(lapiz1, 450, 190, 470, 250);
                papel.DrawLine(lapiz1, 430, 250, 470, 250);
            }
        }

        public void UpdateLinePositions(double valueSP)
        {
            double rad = (valueSP / 490.0) * (-90.0 * Math.PI / 180.0);
            if (rad > 0.524) rad = 0.524;
            if (rad < -0.524) rad = -0.524;

            lineEndX = lineStartX + (int)(lineLength * Math.Cos(rad));
            lineEndY = lineStartY - (int)(lineLength * Math.Sin(rad));

            lineStartXM1 = lineEndXM1 - (int)(lineLength * Math.Cos(rad));
            lineStartYM1 = lineEndYM1 + (int)(lineLength * Math.Sin(rad));

            lineEndX2 = lineStartXM1 + (int)(lineLength2 * Math.Sin(-rad));
            lineEndY2 = lineStartYM1 - (int)(lineLength2 * Math.Cos(-rad));

            lineEndX3 = lineEndX + (int)(lineLength2 * Math.Sin(-rad));
            lineEndY3 = lineEndY - (int)(lineLength2 * Math.Cos(-rad));

            Lx = lineStartXM1 + (int)(478 * Math.Cos(rad));
            Ly = lineStartYM1 - (int)(478 * Math.Sin(rad));
        }

        public void UpdateEllipsePosition(double valueGS)
        {
            ellipsePosX = lineStartXM1 + (int)((valueGS / 4095.0) * (Lx - lineStartXM1));
            ellipsePosY = lineStartYM1 + (int)((valueGS / 4095.0) * (Ly - lineStartYM1));
        }
    }
}
