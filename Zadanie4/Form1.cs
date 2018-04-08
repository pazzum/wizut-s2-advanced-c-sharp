using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie4
{
    public partial class Painter : Form
    {
        private Color _drawingColor;
        private FigureEnum _chosenFigure;
        private Figure _workingFigure;
        private Bitmap _bitmap;

        public Painter()
        {
            InitializeComponent();
            _chosenFigure = FigureEnum.LINE;
            DoubleBuffered = true;
            _drawingColor = System.Drawing.Color.Black;
            _bitmap = new Bitmap(this.Panel.Width, this.Panel.Height);
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            if(_workingFigure != null)
            {
                e.Graphics.DrawImageUnscaled(_bitmap, new System.Drawing.Point(0, 0));
                this.Status.Text = "";
                if(_workingFigure.IsDrawing)
                {
                    this.Status.Text = "Rysowanie trwa";
                }
            }
            else
            {
                e.Graphics.Clear(System.Drawing.Color.White);
            }
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if(_workingFigure != null)
            {
                _workingFigure.MouseMove(e.X, e.Y);
            }
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if(_workingFigure == null || _workingFigure.IsDrawing == false)
            { 
                switch (_chosenFigure)
                {
                    case FigureEnum.LINE:
                        _workingFigure = new Line(_bitmap);
                        break;

                    case FigureEnum.RECTANGLE:
                        _workingFigure = new Rectangle(_bitmap);
                        break;

                    case FigureEnum.POINT:
                        _workingFigure = new Point(_bitmap);
                        break;
                }
            }

            _workingFigure._drawingColor = _drawingColor;

            _workingFigure.MouseDown(e.X, e.Y);
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (_workingFigure != null)
            {
                _workingFigure.MouseUp(e.X, e.Y);
                _bitmap = _workingFigure._workingBitmap;
            }

            this.Panel.Invalidate();
        }

        private void Color_Click(object sender, EventArgs e)
        {
            this.ColorPickerDialog.ShowDialog();
            _drawingColor = this.ColorPickerDialog.Color;
            if(_workingFigure != null)
            {
                _workingFigure._drawingColor = _drawingColor;
            }
        }

        private void Line_Click(object sender, EventArgs e)
        {
            _chosenFigure = FigureEnum.LINE;
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            _chosenFigure = FigureEnum.RECTANGLE;
        }

        private void Point_Click(object sender, EventArgs e)
        {
            _chosenFigure = FigureEnum.POINT;
        }
    }
}
