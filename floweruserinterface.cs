//Author: Ethan Kamus
//email: ethanjpkamus@csu.fullerton.edu

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class floweruserinterface : Form {

	//Buttons
	private Button go_button = new Button();
	private Button pause_button = new Button();
	private Button exit_button = new Button();

	//Labels
	private Label x_pos_label = new Label();
	private Label y_pos_label = new Label();

	private System.Drawing.Graphics pointer_to_graphic_surface;
       private System.Drawing.Bitmap pointer_to_bitmap_in_memory =
              new Bitmap(form_width,form_height,
			    System.Drawing.Imaging.PixelFormat.Format24bppRgb);

	//constructor
	public floweruserinterface(){

		//initialize the pointer to point to the bitmap so it can be modified???
		pointer_to_graphic_surface = Graphics.FromImage(pointer_to_bitmap_in_memory);

	} //end of floweruserinterface

	protected override void OnPaint(PaintEventArgs e){

		Graphics graph = e.Graphics;

		//copy the bitmap onto graph
		graph.DrawImage(pointer_to_bitmap_in_memory,0,0,form_width,form_height);

		base.OnPaint(e);

	} //end of OnPaint override

	//the ui_clock will call onpaint override and

} //end of floweruserinterface
