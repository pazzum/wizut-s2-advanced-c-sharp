using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie4
{
    abstract class Figure
    {
        public Bitmap _workingBitmap { get; }
        protected LinkedList<System.Drawing.Point> _points;
        public Color _drawingColor { get; set; }
        public bool IsDrawing;
        protected System.Drawing.Point _startingPoint;
        protected System.Drawing.Point _endingPoint;

        public Figure(Bitmap workingBitmap)
        {
            _workingBitmap = workingBitmap;
            _points = new LinkedList<System.Drawing.Point>();
        }

        public abstract void MouseUp(int x, int y);

        public abstract void MouseDown(int x, int y);

        public abstract void MouseMove(int x, int y);

        public abstract void CalculatePoints();

        protected double CalculateDistance()
        {
            return Math.Pow((_startingPoint.X - _endingPoint.X), 2.0) + Math.Pow((_startingPoint.Y - _endingPoint.Y), 2.0);
        }

        protected System.Drawing.Point InterpolateLinear(int x)
        {
            double y;
            if ((_endingPoint.X - _startingPoint.X) == 0)
            {
                y = (_startingPoint.Y + _endingPoint.Y) / 2;
            }
            else
            {
                y = _startingPoint.Y + (x - _startingPoint.X) * (_endingPoint.Y - _startingPoint.Y) / (_endingPoint.X - _startingPoint.X);
            }
            return new System.Drawing.Point(x, (int)Math.Ceiling(y));
        }

        protected void FillBitmap()
        {
            foreach (var point in _points)
            {
                try
                {
                    _workingBitmap.SetPixel(point.X, point.Y, _drawingColor);
                }
                catch (ArgumentOutOfRangeException e)
                {

                }
            }
        }
    }
}
