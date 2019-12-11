// Author: Ethan Kamus
// Email: ethanjpkamus@csu.fullerton.edu

// Version 1: December 10, 2019

/* The purpose of this program is to show how to use a Bitmap
 * and how to animate a dot following a flower pattern
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class floweruserinterface : Form {

	//Buttons
	private Button go_button = new Button();
	private Button pause_button = new Button();
	private Button exit_button = new Button();

	private static int MAXIMUM_FORM_WIDTH = 1000;
	private static int MAXIMUM_FORM_HEIGHT = 800;
	private double x_pos = 0.0;
	private double y_pos = 0.0;
	private double t_variable = 0.0;
	private double delta_t = 0.0;
	private double x_offset = 500.0;
	private double y_offset = 350.0;

	private Pen blackpen = new Pen(Brushes.Black);


	//Labels
	private Label x_pos_label = new Label();
	private Label y_pos_label = new Label();

	private System.Drawing.Graphics pointer_to_graphic_surface;
       private System.Drawing.Bitmap pointer_to_bitmap_in_memory = new Bitmap(MAXIMUM_FORM_WIDTH,
											 MAXIMUM_FORM_HEIGHT,
											 System.Drawing.Imaging.PixelFormat.Format24bppRgb);

	//Clocks
	private static System.Timers.Timer ui_clock = new System.Timers.Timer();
	private static System.Timers.Timer animation_clock = new System.Timers.Timer();


	//CONSTRUCTOR
	public floweruserinterface(){

		MaximumSize = new Size(MAXIMUM_FORM_WIDTH,MAXIMUM_FORM_HEIGHT);
		MinimumSize = new Size(MAXIMUM_FORM_WIDTH,MAXIMUM_FORM_HEIGHT);

		DoubleBuffered = true;

		Text = "Flower on Coordinate Plane by: Ethan Kamus";
		BackColor = Color.White;

		ui_clock.Interval = 33.3; //30 Hz
		ui_clock.Enabled = true;
		ui_clock.AutoReset = true;
		ui_clock.Elapsed += new ElapsedEventHandler(manage_ui);

		animation_clock.Interval = 16.6; //60 Hz
		animation_clock.Enabled = false;
		animation_clock.AutoReset = true;
		animation_clock.Elapsed += new ElapsedEventHandler(manage_animation);

		go_button.Text = "START";
		go_button.Size = new Size(75,30);
		go_button.Location = new Point(10,620);
		go_button.Click += new EventHandler(manage_go_button);
		go_button.ForeColor = Color.Green;
		go_button.BackColor = Color.White;

		pause_button.Text = "PAUSE";
		pause_button.Size = new Size(75,30);
		pause_button.Location = new Point(95,620);
		pause_button.Click += new EventHandler(update_pause_button);
		pause_button.ForeColor = Color.Blue;
		pause_button.BackColor = Color.White;

		exit_button.Text = "EXIT";
		exit_button.Size = new Size(75,30);
		exit_button.Location = new Point(180,620);
		exit_button.Click = new EventHandler(update_exit_button);
		exit_button.ForeColor = Color.Red;
		exit_button.BackColor = Color.White;

		x_pos_label.Text = "X-Pos: 0.0";
		x_pos_label.BackColor = Color.White;
		x_pos_label.ForeColor = Color.Black;
		x_pos_label.Size = new Size(75,30);
		x_pos_label.Location = new Point(200,620);


		y_pos_label.Text = "Y-Pos: 0.0";
		y_pos_label.BackColor = Color.White;
		y_pos_label.ForeColor = Color.Black;
		y_pos_label.Size = new Size(75,30);
		y_pos_label.Location = new Point(200,720);

		//initialize the pointer to point to the bitmap so it can be modified???
		pointer_to_graphic_surface = Graphics.FromImage(pointer_to_bitmap_in_memory);

		Controls.Add(go_button);
		Controls.Add(pause_button);
		Controls.Add(exit_button);
		Controls.Add(x_pos_label);
		Controls.Add(y_pos_label);

	} //end of floweruserinterface constructor

	protected override void OnPaint(PaintEventArgs e){

		Graphics graph = e.Graphics;

		graph.FillRectangle(Brushes.Blue,0,0,1000,100);
		graph.FillRectangle(Brushes.Orange,0,600,1000,200);

		graph.DrawLine(blackpen,500,100,500,600); //y-axis
		graph.DrawLine(blackpen,0,350,1000,350); //x-axis

		//copy the bitmap onto graph
		graph.DrawImage(pointer_to_bitmap_in_memory,0,0,
				  (float)MAXIMUM_FORM_WIDTH,
				  (float)MAXIMUM_FORM_HEIGHT);

		base.OnPaint(e);

	} //end of OnPaint override

	protected void manage_ui(Object o, ElapsedEventArgs e){

		pointer_to_graphic_surface.FillEllipse(Brushes.Red,(float)x_pos,(float)y_pos,1,1);

		x_pos_label.Text = "X-Pos: " + x_pos.ToString();
		y_pos_label.Text = "Y-Pos: " + y_pos.ToString();

		Invalidate();

	} //end of manage_ui

	// this method calculates the x an y position of the dot to be drawn
	protected void manage_animation(Object o, ElapsedEventArgs e){

		//keep T within the bounds (0 , 2pi)
		if(t_variable >= (Math.PI * 2)){

			t_variable = 0.0;
			delta_t = 0.0;

		}

		//find x and y coordinates
		x_pos = Math.Cos(2.0 * (t_variable + delta_t)) * Math.Cos(t_variable + delta_t);
		y_pos = Math.Cos(2.0 * (t_variable + delta_t)) * Math.Sin(t_variable + delta_t);

		//move coordinate to origin drawn on screen
		x_pos += x_offset;
		y_pos += y_offset;

		//make graph easier to see for user
		x_pos *= 10;
		y_pos *= 10;

		//increment delta_t
		delta_t += Math.PI / 2;

	} //end of manage_animation

	protected void update_go_button(Object o, EventArgs e){

		animation_clock.Enabled = true;

	} //end of update_go_button

	protected void update_pause_button(Object o, EventArgs e){

		animation_clock.Enabled = false;

	} //end of update_pause_button


	protected void update_exit_button(Object o, EventArgs e){

		Close();

	} //end of update_exit_button

} //end of floweruserinterface
