using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
            this.startPoint.X = e.X;
            this.startPoint.Y = e.Y;
            switch (this.shapeTypes)
            {
                case Shapes.Line:
                    this.currentLine = new Line(pen, startPoint, endPoint);
                    break;
                case Shapes.Circle:
                    this.currentCircle = new Circle(pen, startPoint, endPoint);
                    break;
                case Shapes.Rectangle:
                    this.currentRectangle = new Rectangle(pen, startPoint, endPoint);
                    break;
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
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
            pen.Color = this.penColor;
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

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            this.selectedShape = (int)Shapes.Circle;
            this.shapeTypes = (Shapes)selectedShape;
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            this.selectedShape = (int)Shapes.Line;
            this.shapeTypes = (Shapes)selectedShape;
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            this.selectedShape = (int)Shapes.Rectangle;
            this.shapeTypes = (Shapes)selectedShape;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = colorDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.penColor = colorDialog1.Color;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }

    public abstract class Shape
    {
        public Pen Pen { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }
    }

    public class Line : Shape
    {
        public Line(Pen pen, Point start, Point end)
        {
            this.Pen = pen;
            this.Start = start;
            this.End = end;
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
    }
    public class Rectangle : Shape
    {
        public Rectangle(Pen pen, Point start, Point end)
        {
            this.Pen = pen;
            this.Start = start;
            this.End = end;
        }
    }

}