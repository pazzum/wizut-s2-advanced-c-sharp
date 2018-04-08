using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie4
{
    class Line : Figure
    {

        public Line(Bitmap workingBitmap) : base(workingBitmap)
        {
            IsDrawing = false;
        }

        public override void MouseDown(int x, int y)
        {
            IsDrawing = !IsDrawing;
            if(IsDrawing == true)
            {
                _startingPoint = new System.Drawing.Point(x, y);
            }
        }

        public override void MouseMove(int x, int y)
        {
        }

        public override void MouseUp(int x, int y)
        {
            if(IsDrawing == false)
            {
                _endingPoint = new System.Drawing.Point(x, y);

                CalculatePoints();

                FillBitmap();
            }
        }

        public override void CalculatePoints()
        {
            _points.AddLast(_startingPoint);

            for (var i=_startingPoint.X; i < _endingPoint.X; i++)
            {
                var newElement = InterpolateLinear(i);
                _points.AddLast(newElement);
            }

            _points.AddLast(_endingPoint);
        }
    }
}
