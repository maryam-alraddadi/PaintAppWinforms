using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintAppWinforms
{

    public partial class Form1 : Form
    {
        List<Shape> shapes;
        private List<Line> lines;
        private Line currentLine = null;
        private List<Circle> circles;
        private List<Rectangle> rectangles;
        private Circle currentCircle = null;
        private Rectangle currentRectangle = null;
        private int LineWeight;
        int LineStyle;
        Pen pen;
        Color penColor;
        enum Shapes
        {
            Line,
            Circle,
            Rectangle
        }
        int selectedShape;

        public Form1()
        {
            InitializeComponent();
            this.lines = new List<Line>();
            this.circles = new List<Circle>();
            this.rectangles = new List<Rectangle>();
            this.shapes = new List<Shape>();
            this.selectedShape = (int)Shapes.Line;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Shapes shape = (Shapes)selectedShape;
            switch (shape)
            {
                case Shapes.Line:
                    this.currentLine = new Line();
                    currentLine.start = new Point(e.X, e.Y);
                    break;
                case Shapes.Circle:
                    this.currentCircle = new Circle();
                    currentCircle.start = new Point(e.X, e.Y);
                    break;
                case Shapes.Rectangle:
                    this.currentRectangle = new Rectangle();
                    currentRectangle.start = new Point(e.X, e.Y);
                    break;

            }


        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

            Shapes shape = (Shapes)selectedShape;
            switch (shape)
            {
                case Shapes.Line:
                    currentLine.end = new Point(e.X, e.Y);
                    this.shapes.Add(currentLine);
                    break;
                case Shapes.Circle:
                    currentCircle.end = new Point(e.X, e.Y);
                    this.shapes.Add(currentCircle);
                    break;
                case Shapes.Rectangle:
                    currentRectangle.end = new Point(e.X, e.Y);
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
            pen = new Pen(Brushes.Black, this.LineWeight);
            pen.Color = this.penColor;
            if (LineStyle == 0)//dashed
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            }
            else if (LineStyle == 1)//dotted
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            }
            else //solid
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            }
            Shapes shape = (Shapes)selectedShape;

            foreach (var i in this.shapes)
            {
                if (shape.GetType() == typeof(Line))
                {
                    g.DrawLine(pen, i.start.X, i.start.Y, i.end.X, i.end.Y);
                }
                else if (shape.GetType() == typeof(Circle))
                {
                    g.DrawEllipse(pen, i.start.X, i.start.Y, i.end.X, i.end.Y);
                }
                else if (shape.GetType() == typeof(Rectangle))
                {
                    g.DrawRectangle(pen, i.start.X, i.start.Y, i.end.X, i.end.Y);
                }

            }

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void lineWeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = lineWeight.Items[lineWeight.SelectedIndex].ToString();
            this.LineWeight = Int32.Parse(selectedItem);
        }

        private void lineStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLineStyle = lineStyle.Items[lineStyle.SelectedIndex].ToString();
            this.LineStyle = lineStyle.SelectedIndex;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            this.selectedShape = (int)Shapes.Circle;
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            this.selectedShape = (int)Shapes.Line;
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            this.selectedShape = (int)Shapes.Rectangle;
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
        public Point start { get; set; }
        public Point end { get; set; }
    }
    public class Line : Shape
    {
        public Point start;
        public Point end;
    }

    public class Circle : Shape
    {
        public Point start;
        public Point end;
    }
    public class Rectangle : Shape
    {
        public Point start;
        public Point end;
    }

}