using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using GraphFunction.ViewModel;

namespace GraphFunction
{
    public partial class Form1 : Form
    {
        #region Class Members
        
        private DrawGraphViewModel _viewModel;

        // Delegate for the function to draw.
        private delegate float FunctionDelegate(float x);

        // The function we are currently drawing.
        private FunctionDelegate TheFunction;

        #endregion

        public Form1(DrawGraphViewModel viewModel)
        {
            _viewModel = viewModel;

            InitializeComponent();

            PopulateFunctionChoices();
        }

        // Select the first equation.
        private void Form1_Load(object sender, EventArgs e)
        {
            equationComboBox.SelectedIndex = 0;
        }

        private void PopulateFunctionChoices()
        {
            foreach (var function in _viewModel.AvailableFunctions)
                equationComboBox.Items.Add(function);
        }

        // Draw the currently selected function.
        private void graphPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            DrawGraph(e.Graphics);
        }

        // Draw the graph.
        private void DrawGraph(Graphics gr)
        {
            // Map to turn right-side up and center at the origin.
            const float wxmin = -10;
            const float wymin = -10;
            const float wxmax = 10;
            const float wymax = 10;
            RectangleF rect = new RectangleF(wxmin, wymin, wxmax - wxmin, wymax - wymin);
            PointF[] pts = 
            {
                new PointF(0, graphPictureBox.ClientSize.Height),
                new PointF(graphPictureBox.ClientSize.Width, graphPictureBox.ClientSize.Height),
                new PointF(0, 0),
            };
            Matrix transform = new Matrix(rect, pts);
            gr.Transform = transform;

            // See how far it is between horizontal pixels in world coordinates.
            pts = new PointF[] { new PointF(1, 0) };
            transform.Invert();
            transform.TransformVectors(pts);
            float dx = pts[0].X;

            // Generate points on the curve.
            List<PointF> points = new List<PointF>();
            for (float x = wxmin; x <= wxmax; x += dx)
                points.Add(new PointF(x, TheFunction(x)));

            // Use a thin pen.
            using (Pen thin_pen = new Pen(Color.Gray, 0))
            {
                // Draw the coordinate axes.
                gr.DrawLine(thin_pen, wxmin, 0, wxmax, 0);
                gr.DrawLine(thin_pen, 0, wymin, 0, wymax);
                for (float x = wxmin; x <= wxmax; x++)
                    gr.DrawLine(thin_pen, x, -0.5f, x, 0.5f);
                for (float y = wymin; y <= wymax; y++)
                    gr.DrawLine(thin_pen, -0.5f, y, 0.5f, y);

                // Draw the graph.
                thin_pen.Color = Color.Red;
                //thin_pen.Color = Color.Black;
                gr.DrawLines(thin_pen, points.ToArray());
            }
        }


        // Select the appropriate function and redraw.
        private void equationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
      
            TheFunction = _viewModel.AvailableFunctions[equationComboBox.SelectedIndex].calculate;

            graphPictureBox.Refresh();
        }
    }
}
