namespace oknig
{
    
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using System.Media;
    public partial class Form1 : Form
    {
        private SoundPlayer _player;
        public Form1()
        {
            InitializeComponent();
            _player = new SoundPlayer(@"D:\downloads\coems.wav");
            
            _player.Play();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Modify button1 and button2 to be round and invisible (but clickable)
            SetupInvisibleRoundButton(button1);
            SetupInvisibleRoundButton(button2);

            // Load background image
            this.BackgroundImage = Image.FromFile("unnamed.png"); // Use correct image path
            this.BackgroundImageLayout = ImageLayout.Center;
        }

        // Method to set up an existing button as an invisible, round, and clickable button
        private void SetupInvisibleRoundButton(Button button)
        {
            button.Size = new Size(85, 85);  // Set size to a circle
            button.BackColor = Color.Transparent;  // Set the background to transparent
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;  // Remove border
            button.FlatAppearance.MouseDownBackColor = Color.Transparent;  // Make transparent on click
            button.FlatAppearance.MouseOverBackColor = Color.Transparent;  // Transparent on hover
            button.Text = "";  // Remove button text
            button.Paint += new PaintEventHandler(Button_Paint);  // Attach round paint logic
        }

        // Event handler to make buttons round
        private void Button_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Create a round (circular) region for the button
                GraphicsPath graphicsPath = new GraphicsPath();
                graphicsPath.AddEllipse(0, 0, btn.Width, btn.Height);
                btn.Region = new Region(graphicsPath);
                // No need to draw anything since button is transparent
            }
        }

        // Click event handlers for button1 and button2

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Accept clicked!");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Decline clicked!");
        }
    }
}
