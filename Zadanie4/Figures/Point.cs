using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie4
{
    class Point : Figure
    {
        public Point(Bitmap workingBitmap) : base(workingBitmap)
        {
        }

        public override void CalculatePoints()
        {
            _points.AddLast(_startingPoint);
        }

        public override void MouseDown(int x, int y)
        {
        }

        public override void MouseMove(int x, int y)
        {
        }

        public override void MouseUp(int x, int y)
        {
            _startingPoint = new System.Drawing.Point(x, y);

            CalculatePoints();

            FillBitmap();
        }
    }
}
