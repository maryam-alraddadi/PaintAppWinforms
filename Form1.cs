using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintAppWinforms
{

    public partial class Form1 : Form
    {
        private List<Shape> shapes;
        private Line currentLine = null;
        private Circle currentCircle = null;
        private Rectangle currentRectangle = null;
        private int LineWeight;
        private int LineStyle;
        private Pen pen;
        private Color penColor;
        private int selectedShape;
        private Point startPoint;
        private Point endPoint;
        GraphicsPath p;
        bool selectMode;
        bool drawMode;
        enum Shapes
        {
            Line,
            Circle,
            Rectangle
        }

        Shapes shapeTypes;
        public Form1()
        {
            InitializeComponent();
            this.selectedShape = (int)Shapes.Line;
            this.shapeTypes = (Shapes)selectedShape;
            this.shapes = new List<Shape> { };
            this.pen = new Pen(Brushes.Black, 2);
            this.startPoint = new Point(0, 0);
            this.endPoint = new Point(0, 0);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (drawMode)
            {
                this.startPoint.X = e.X;
                this.startPoint.Y = e.Y;
                switch (this.shapeTypes)
                {
                    case Shapes.Line:
                        this.currentLine = new Line(getPenStyle(), startPoint, endPoint);
                        break;
                    case Shapes.Circle:
                        this.currentCircle = new Circle(getPenStyle(), startPoint, endPoint);
                        break;
                    case Shapes.Rectangle:
                        this.currentRectangle = new Rectangle(getPenStyle(), startPoint, endPoint);
                        break;
                }
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawMode)
            {
                this.endPoint.X = e.X;
                this.endPoint.Y = e.Y;
                switch (this.shapeTypes)
                {
                    case Shapes.Line:
                        currentLine.End = this.endPoint;
                        this.shapes.Add(currentLine);
                        break;
                    case Shapes.Circle:
                        currentCircle.End = this.endPoint;
                        this.shapes.Add(currentCircle);
                        break;
                    case Shapes.Rectangle:
                        currentRectangle.End = this.endPoint;
                        this.shapes.Add(currentRectangle);
                        break;

                }

                this.Invalidate();
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
          
        }
        private void button6_Click(object sender, EventArgs e)
        {


        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (p != null)
            {
                pen.Color = Color.Red;
                e.Graphics.DrawPath(pen, p);
            }
               
            foreach (var shape in shapes)
            {
                
                if (shape.GetType() == typeof(Line))
                {
                    g.DrawLine(shape.Pen, shape.Start.X, shape.Start.Y, shape.End.X, shape.End.Y);
                }
                else if (shape.GetType() == typeof(Circle))
                {
                    g.DrawEllipse(shape.Pen, shape.Start.X, shape.Start.Y, shape.End.X, shape.End.Y);
                }
                else if (shape.GetType() == typeof(Rectangle))
                {
                    g.DrawRectangle(shape.Pen, shape.Start.X, shape.Start.Y, shape.End.X, shape.End.Y);
                }

            }

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void lineWeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LineWeight = Int32.Parse(lineWeight.Items[lineWeight.SelectedIndex].ToString());
            this.pen.Width = this.LineWeight;
        }

        private void lineStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LineStyle = lineStyle.SelectedIndex;
            if (LineStyle == 0)//dashed
            {
                this.pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            }
            else if (LineStyle == 1)//dotted
            {
                this.pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            }
            else //solid
            {
                this.pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            }
        }

        private Pen getPenStyle()
        {
            Pen newPen = new Pen(this.pen.Brush, this.pen.Width);
            newPen.DashStyle = this.pen.DashStyle;
            newPen.Color = this.penColor;
            return newPen;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            this.selectedShape = (int)Shapes.Circle;
            this.shapeTypes = (Shapes)selectedShape;
            this.drawMode = true;
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            this.selectedShape = (int)Shapes.Line;
            this.shapeTypes = (Shapes)selectedShape;
            this.drawMode = true;
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            this.selectedShape = (int)Shapes.Rectangle;
            this.shapeTypes = (Shapes)selectedShape;
            this.drawMode = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = colorDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.penColor = colorDialog1.Color;
                this.pen.Color = this.penColor;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (selectMode)
            {
                foreach (var shape in shapes)
                    shape.Pen.Color = shape.HitTest(shape, e.Location) ? Color.Red : Color.Black;
            this.Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void selectModeButton_Click(object sender, EventArgs e)
        {
            this.selectMode = true;
            this.drawMode = false;
        }
    }

    public abstract class Shape
    {
        public Pen Pen { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }
        public abstract bool HitTest(Shape shape, Point Pt);
        
    }

    public class Line : Shape
    {
        public Line(Pen pen, Point start, Point end)
        {
            this.Pen = pen;
            this.Start = start;
            this.End = end;
        }

        public override bool HitTest(Shape shape, Point Pt)
        {
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddLine(shape.Start.X, shape.Start.Y, shape.End.X, shape.End.Y);

            return myPath.IsVisible(Pt);
        }
    }
    public class Circle : Shape
    {
        public Circle(Pen pen, Point start, Point end)
        {
            this.Pen = pen;
            this.Start = start;
            this.End = end;
        }

        public override bool HitTest(Shape shape, Point Pt)
        {
            
            System.Drawing.Rectangle myEllipse = new System.Drawing.Rectangle(shape.Start.X, shape.Start.Y, shape.End.X, shape.End.Y);
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddEllipse(myEllipse);

            return myPath.IsVisible(Pt);
        }
    }
    public class Rectangle : Shape
    {
        public Rectangle(Pen pen, Point start, Point end)
        {
            this.Pen = pen;
            this.Start = start;
            this.End = end;
        }

        public override bool HitTest(Shape shape, Point Pt)
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(shape.Start.X, shape.Start.Y, shape.End.X, shape.End.Y);
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddRectangle(rect);

            return myPath.IsVisible(Pt);
        }
    }

}