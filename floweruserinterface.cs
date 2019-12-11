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

	//window dimensions
	private int MAXIMUM_FORM_WIDTH = 1000;
	private int MAXIMUM_FORM_HEIGHT = 800;

	private double x_pos = 0.0;
	private double y_pos = 0.0;
	private double t_variable = 0.0;
	private double delta_t = 0.0;
	private double x_offset = 500.0;
	private double y_offset = 350.0;


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

		start_button.Text = "START";
		start_button.Size = new Size(75,30);
		start_button.Location = new Point(10,100);
		start_button.Click += new EventHandler(manage_start_button);

		restart_button.Text = "RESET";
		restart_button.Size = new Size(75,30);
		restart_button.Location = new Point(95,100);
		restart_button.Click += new EventHandler(update_restart_button);

		exit_button.Text = "EXIT";
		exit_button.Size = new Size(75,30);
		exit_button.Location = new Point(180,100);
		exit_button.Click = new EventHandler(update_exit_button);

		//initialize the pointer to point to the bitmap so it can be modified???
		pointer_to_graphic_surface = Graphics.FromImage(pointer_to_bitmap_in_memory);

	} //end of floweruserinterface constructor

	protected override void OnPaint(PaintEventArgs e){

		Graphics graph = e.Graphics;

		graph.DrawLine(Pen.Black,500,100,500,600); //y-axis
		graph.DrawLine(Pen.Black,0,350,1000,350); //x-axis

		//copy the bitmap onto graph
		graph.DrawImage(pointer_to_bitmap_in_memory,0,0,form_width,form_height);

		base.OnPaint(e);

	} //end of OnPaint override

	protected void manage_ui(Object o, ElapsedEventArgs e){

		pointer_to_graphic_surface.FillEllipse(Brushes.Red,x_pos,y_pos,1,1);
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

	protected void update_start_button(Object o, EventArgs e){

		animation_clock.Enabled = true;

	} //end of update_start_button

	protected void update_pause_button(Object o, EventArgs e){

		animation_clock.Enabled = false;

	} //end of update_pause_button


	protected void update_exit_button(Object o, EventArgs e){

		Close();

	} //end of update_exit_button

} //end of floweruserinterface
