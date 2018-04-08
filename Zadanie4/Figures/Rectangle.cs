using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie4
{
    class Rectangle : Figure
    {
        public Rectangle(Bitmap workingBitmap) : base(workingBitmap)
        {
            IsDrawing = false;
        }

        public override void MouseDown(int x, int y)
        {
            IsDrawing = !IsDrawing;
            if (IsDrawing == true)
            {
                _startingPoint = new System.Drawing.Point(x, y);
            }
        }

        public override void MouseMove(int x, int y)
        {
        }

        public override void MouseUp(int x, int y)
        {
            if (IsDrawing == false)
            {
                _endingPoint = new System.Drawing.Point(x, y);

                CalculatePoints();

                FillBitmap();
            }
        }

        public override void CalculatePoints()
        {
            for (var i = _startingPoint.X; i < _endingPoint.X; i++)
            {
                _points.AddLast(new System.Drawing.Point(i, _startingPoint.Y));
                _points.AddLast(new System.Drawing.Point(i, _endingPoint.Y));
            }

            for (var j = _startingPoint.Y; j < _endingPoint.Y; j++)
            {
                _points.AddLast(new System.Drawing.Point(_startingPoint.X, j));
                _points.AddLast(new System.Drawing.Point(_endingPoint.X, j));
            }
        }
    }
}
